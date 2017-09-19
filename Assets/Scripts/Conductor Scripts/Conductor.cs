using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Conductor : MonoBehaviour {

    [SerializeField]
    private List<TextAsset> beatFiles;

    [SerializeField]
    private List<AudioClip> songs;
    private AudioSource audioSource;

    // Variables for holding beats to play
    private List<BasicBeat> beats;
    private bool hasStarted, isPaused;

    // Variable about song
    private string songName;
    private string songArtist;
    private float songYear;

    // Variables for beat calculations
    public float bpm = 147.2f;
    public float milliPerBeat;
    [HideInInspector]
    public float currentMilli = 0f;
    private float delaySongMilli = 0f;
    private int startingTimeSample = 0;
    private int currentBeat = 0;

    // Variables for reading a song text file
    enum TextProcessingModes { NoMode, VisualBeatMode, EnemyBeatMode };
    TextProcessingModes currMode = TextProcessingModes.NoMode;

    private string regexVisualBeatLiteral = @"(?i:#\s*VisualBeat.*)";
    private string regexEnemyLiteral = @"(?i:#\s*Enemy.*)";
    private string regexEndLiteral = @"(?i:#\s*End.*)";

    private Regex visualBeatRgx;
    private Regex enemyRgx;
    private Regex endRgx;

    public void Awake() {
        audioSource = GetComponent<AudioSource>();

        beats = new List<BasicBeat>();
        BasicBeat.setStaticVariables(this);
    }

    public void Start() {
        prepareSong();
    }

    public void prepareSong() {
        // Initialize Regular Expressions
        visualBeatRgx = new Regex(regexVisualBeatLiteral);
        enemyRgx = new Regex(regexEnemyLiteral);
        endRgx = new Regex(regexEndLiteral);

        loadSong(beatFiles[0]);
        StartBeats();
    }

    IEnumerator startLevel() {
        yield return new WaitForSeconds(delaySongMilli / 1000f);
        hasStarted = true;
        audioSource.Play();
    }

    public void StartBeats() {
        audioSource.timeSamples = startingTimeSample;
        StartCoroutine("startLevel");
    }

    public void PauseBeats() {
        isPaused = true;
        //Time.timeScale = 0;     // TODO: Delete and just pause all elements on screen a different way
        audioSource.Pause();
    }

    public void UnpauseBeats() {
        isPaused = false;
        //Time.timeScale = 1;     // TODO: Delete later
        audioSource.UnPause();
    }

    private void loadSong(TextAsset file) {
        int currentLine = 0;
        string[] lines = file.text.Split('\n');
        foreach (string line in lines) {
            currentLine++;

            if (line.Length == 0)
                continue;

            int firstChar = (int)line[0];
            if (firstChar == 13)
                continue;
            else if (firstChar == 35) {
                if (endRgx.IsMatch(line))
                    currMode = TextProcessingModes.NoMode;
                else if (visualBeatRgx.IsMatch(line))
                    currMode = TextProcessingModes.VisualBeatMode;
                else if (enemyRgx.IsMatch(line))
                    currMode = TextProcessingModes.EnemyBeatMode;
                continue;
            }

            string[] fields = line.Split(',');

            // Determine how to process line
            switch (currentLine) {
                case 1:                         // Song Info
                    songName = fields[0];
                    songArtist = fields[1];
                    songYear = float.Parse(fields[2]);
                    setSong(int.Parse(fields[3]));
                    break;

                case 2:                         // Beats Calculations
                    bpm = float.Parse(fields[0]);
                    milliPerBeat = (60f / bpm) * 1000;
                    currentMilli = 0f;
                    currentBeat = 0;
                    delaySongMilli = float.Parse(fields[1]) * 1000f;
                    startingTimeSample = int.Parse(fields[2]);
                    
                    break;

                default:                        // Spawning Beats
                    float currMilli, milliSeparation;
                    int numberOfRepeats, beatType;

                    if(currMode == TextProcessingModes.VisualBeatMode) {
                        currMilli = (float.Parse(fields[0]) + float.Parse(fields[1])) * milliPerBeat;
                        milliSeparation = float.Parse(fields[3]) * milliPerBeat;
                        numberOfRepeats = (int.Parse(fields[2]) != 0) ? int.Parse(fields[4]) : 1;
                        beatType = int.Parse(fields[5]);

                        while (numberOfRepeats > 0) {
                            beats.Add(new VisualBeat(currMilli, beatType));

                            currMilli += milliSeparation;
                            numberOfRepeats--;
                        }
                    }

                    else if(currMode == TextProcessingModes.EnemyBeatMode) {
                        currMilli = (float.Parse(fields[0]) + float.Parse(fields[1])) * milliPerBeat;
                        milliSeparation = float.Parse(fields[3]) * milliPerBeat;
                        numberOfRepeats = (int.Parse(fields[2]) != 0) ? int.Parse(fields[4]) : 1;
                        beatType = int.Parse(fields[5]);

                        while (numberOfRepeats > 0) {
                            beats.Add(new EnemyBeat(currMilli, beatType));

                            currMilli += milliSeparation;
                            numberOfRepeats--;
                        }
                    }

                    break;
            }
        }

        debugPrint();

        // Sort Array
        beats.Sort((b1, b2) => b1.timeIndex.CompareTo(b2.timeIndex));
    }

    private void debugPrint() { 
        // TODO: Print onto a UI Panel
        //Debug.Log("Song Name: " + songName);
        //Debug.Log("Song Artist: " + songArtist);
        //Debug.Log("Song Year: " + songYear);
        //Debug.Log("BPM: " + bpm);
        //Debug.Log("Beats Length: " + beats.Count);
        //Debug.Log("Song Delay: " + delaySongMilli);

        //foreach (BasicBeat beat in beats) {
        //    beat.printBeatInfo();
        //}
    }

    public void Update() {
        if (hasStarted && !isPaused) {
            currentMilli += Time.deltaTime * 1000f;
            checkBeats();
            debugBeats();
        }
    }

    private void setSong(int index) {
        audioSource.clip = songs[index];
    }

    public void checkBeats() {
        while (currentBeat < beats.Count && beats[currentBeat].timeIndex <= currentMilli) {
            beats[currentBeat].performBeat();
            currentBeat++;
        }
    }

    public void checkTimeSample() {
        Debug.Log(audioSource.timeSamples);
    }

    public void debugBeats() {
        float majorBeat = Mathf.Floor(currentMilli / milliPerBeat);
        float minorBeat = Mathf.Floor(((currentMilli - (majorBeat * milliPerBeat)) / milliPerBeat) * 4);
        //beatCounter.text = majorBeat + " : " + minorBeat;
    }

    public void debugBackToSelection() {
        SceneManagerScript.instance.selectionScreenTransition();
    }
}
