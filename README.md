# SpaceGooShootem
Fly in space and shoot down goo enemies.

_WARNING!!!__THERE ARE LOUD SOUNDS!!!__ (I couldn't find the source of them...)_

Select Host (or Client if there already is a Host) and you spawn in as a spaceship.

__Movement__ - WASD or ArrowKeys, Shoot with left mouse button;
__Score and Health__ - Score is the number on the left and your Health is displayed above your ship;
__PickUps__ - Shield protects you from 1 hit, Heart gives you +1 Health (in this version of the game they technically have the same effect, I was planning on having an end screen which counts your hearts as points too though). Both have different % drop rate (but I think it's too high);
__Enemies__ - 3 types:
  - Red (purple) goes up and down;
  - Green moves only forward but shoots (you can destroy the bullets by shooting at them);
  - Orange follows player (pathfinding without NavMesh because I couldn't figure out how to do it);
 
# Design and Juice
You're flying in a goo space cave. _Don't hit the celling or floor or you may die_. I'm very satisfied with how the ship moves, shooting is fine too. I wish I could have the goos animated with actual death sounds but I had problems with the death sounds and couldn't find cute animated goos. The celling and floor are almost perfectly looped (at some point the animation pauses, couldn't figure out why). The intro camera movement was made with Cinemachine, I couldn't think of a good cutscene to create so that was the result. Particle effects everywhere! They're also fun to work with. The background music is pretty dope as well. Overall I think visually the game looks good, it's lacking networking UI, end screen and a main menu tho :(.

# Scripting
I tried to include all required elements, however I couldn't implement the fsm, my pathfinding is without a NavMesh and my networking is probably complete s***. I'm also not very confident in using the observer pattern but I did my best to put as little dependencies between the scripts as possible. My codes are a mess, lesson learned for next time :/. I experimented with a lot of little things though and I'm happy with some of the script results.


P.S. The goo in my game and your comment "Let's shoot the gooey shit out of em" are totally coincidental!
P.S.2 I'm overdue again because of a horrible ill last week which left me powerless to do whatsoever for at least 5 days. And I wanted to add and change so much in my game...

