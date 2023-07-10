# Mars Robot
Robot navigates on Mars

Takes 2 inputs from the console:
 - first input line in format WxH defining the dimensions of the grid/Mars plateau (e.g.: 5x5) 
 - second input line a string containing multiple commands as described below (e.g.: FFRFLFLF)


    L : Turn the robot left

    R: Turn the robot right
   
    F: Move forward on it's facing direction


The robot start at position X: 1, Y: 1 facing NORTH and follows the set of commands. 
The robot cannot leave the boundaries the plateau and will ignore any command that would do so.

The final position of the robot is printed in the console.



> Example:
>
> Input 
   >> 5x5
   >>  
   >> FFRFLFLF
>
> Output
   >> 1,4,West