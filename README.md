# UnityLoopingBackgroundSpriteScroller
A simple looping sprite renderer background scroller script.

For use on game objects with a sprite renderer component and a stationary camera.

It will generate a child duplicate game object next to original sprite and move the width of the sprite before repositioning to it's original position on the x axis.  Repositioning should happen fast enough that it appears seamless.

# Usage:
Attach script to game object with a sprite renderer.

By default, it scrolls to the left.  Set Move Right flag to move right (and create child duplicate on the other end).

# Note:
Scale of the game object must be (1,1,1).  Resizing of object must be done at the sprite asset level (i.e. Pixels Per Unit)
