# Enhanced `PhysicsPickup` Script Guide

## Overview of Enhancements

1. **Object Rotation**: Rotate the picked-up object using the 'R' key for better manipulation.
2. **Distance Adjustment**: Adjust the holding distance with the mouse scroll wheel for more flexibility.
3. **Vertical Movement Control**: Toggle vertical movement to maintain a fixed height for the held object.
4. **Camera and Player Rotation Lock**: Lock the player's and camera's rotation while focusing on the object.
5. **Tag Filtering**: Optionally filter objects by tags to restrict which objects can be picked up.

## How to Use the Enhanced `PhysicsPickup` Script

### Setting Up the Script

1. **Attach the Script**: Add this script to any GameObject (like a player character) in Unity that you want to use for picking up objects.
2. **Configure Inspector Parameters**:
   - **Distance (dist)**: Default distance from the camera to hold the object.
   - **Rotation Speed (rotationSpeed)**: Speed of object rotation when the 'R' key is pressed.
   - **Minimum Distance (minDist)**: Closest distance when zooming in.
   - **Maximum Distance (maxDist)**: Farthest distance when zooming out.
   - **Allow Vertical Movement**: Toggle this to enable or restrict vertical movement of the held object.
   - **Use Tag Filter**: Enable this to restrict pickups to specific tags.
   - **Tags to Pickup**: Specify which tags are allowed for pickup in the array.📍NEW

### Controls

- **Pickup/Drop Object**: 
  - Press and hold the **Left Mouse Button (LMB)** to pick up an object. Releasing the button will drop it if an object is held.
  
- **Rotate Object**: 
  - While holding an object, press the **'R' key** to rotate. Move the mouse to adjust the rotation direction.
  
- **Zoom In/Out**: 
  - Use the **mouse scroll wheel** to change the distance of the held object for closer inspection or to move it further away.

### Important Notes

- **Object Selection**: The script uses a raycast to detect objects within a 5-unit range in front of the player. Ensure objects to be picked up have Rigidbody components.
  
- **Gravity Control**: Gravity is disabled on the picked-up object while held and re-enabled when dropped.
  
- **Tag Filtering**: If tag filtering is enabled, only objects with specified tags will be eligible for pickup.

## Conclusion

These enhancements significantly improve the object-picking mechanic in your Unity project. Test the controls thoroughly to ensure they fit your game design and provide the desired user experience. Enjoy building!

### Attribution

All rights reserved to Yahyasvm for forking Samhogan's original work.
