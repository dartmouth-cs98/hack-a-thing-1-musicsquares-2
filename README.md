# Hack-A-Thing 1: BeatSquare
---
### Build Description
This is a prototype of a game I lost interest in completing over the summer. It is a rhythm based game where the objective is not to time hits to a beat, but to avoid obstacles that spawn to the beat.

### Things Completed Before the Hack-A-Thing
* Prototype of the Main Game Scene
* The Title Scene and Selection Menu Scene existed but lacked content

### Things Completed During the Hack-A-Thing
* Using an Asset called "Text Mesh Pro" to make texts look more crisp. [link](https://www.youtube.com/watch?v=D33d4w89vTs)
* Adding Particles to the Background of Scenes [link](https://www.raywenderlich.com/113049/introduction-unity-particle-systems)
* Transitions from one scene to the next [link](http://www.alanzucconi.com/2016/03/23/scene-management-unity-5/)
* Using Unity's Animator to make the transitions more dynamic than static.[link](http://www.studica.com/blog/unity-tutorial-animator-controllers)

### Things Learned
* A Particle System can emit more than one texture when given a spritesheet. [link](https://forum.unity.com/threads/random-tile-from-sprite-sheet-for-each-particle.104793/)
![Texture Sheet Animation Tab](https://forum.unity.com/attachments/screen-shot-2013-12-28-at-5-38-36-pm-png.80355/)
* Unity allows you to call functions during a desired frame of animation. [link](https://docs.unity3d.com/Manual/animeditor-AnimationEvents.html)
* There are some inputs that work for both the keyboard and Android. [link](http://answers.unity3d.com/questions/575378/touch-events-in-mouse-events.html)

### What didn't work
* I could not get the Animator's Triggers to perform animations in the order I wanted. Instead, I had to code the logic into a script instead.
* I couldn't get the starting animation on the Title Scene to end prematurely if the player tapped the screen before the animation completed.
* I don't know enough about Unity Shaders to draw white outlines around buttons in the Selection Menu Scene, so I had to use a Sprite to do this.