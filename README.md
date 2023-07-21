## Description:
### Overview
The goal here is to solve a puzzle (the "pieces of paper" kind of puzzle). You will receive different pieces of that puzzle as input, and you will have to find in what order you have to rearrange them so that the "picture" of the puzzle is complete.
### Puzzle pieces
All the pieces of the puzzle will be represented in the following way:
- 4 numbers, grouped in 2 tuples, which are representing the "picture" on the piece. Every piece has a 2x2 size.
- 1 id number. All id numbers are unique in a puzzle, but their value may be random.
- Note that all numbers will be non-negative integers (except for outer border "picture" numbers in C#).

For example,
``` C#
((1, 2), (3, 4), 1) 
 Puzzle piece id ^
```
is equivalent the the following square piece of puzzle, having the id number ```1```:
``` C#
+---+
|1 2|
|3 4|
+---+
```
If the piece is on a border or is a corner, some numbers will be replaced with None (-1 in C#):
``` C#
((-1, -1), (1, 2), 10)    -->   upper border
((9, -1), (-1, -1), 11)   -->   bottom right corner
```
Note that you cannot flip or rotate the pieces (*would you like to change the picture!?*)
### Solving the puzzle
- You'll get an array of pieces as well as the size of the puzzle (width and height).
- Two pieces can be assembled if they share the same pattern on the border where they are in contact (see example below).
- Puzzle pieces being unique, you'll never encounter two different pieces that could be assembled with the same third one. So to say: borders are unique.
- Once you found the proper arrangment for all the pieces, return the solved puzzle as a list of tuples (height * width) of the id number of the piece at its correct position. (For C#, return the solved puzzle as a 2-dimensional array of integers.)
### Example:
Inputs:
``` C#
int width = 3;
int height = 3;

((int,int),(int,int),int)[] pieces = {
  ((-1, 5), (-1, -1), 3),
  ((17, -1), (-1, -1), 9),
  ((-1, 4), (-1, 5), 8),
  ((4, 11), (5, 17), 5),
  ((11, -1), (17, -1), 2),
  ((-1, -1), (-1, 4), 7),
  ((5, 17), (-1, -1), 1),
  ((-1, -1), (11, -1), 4),
  ((-1, -1), (4, 11), 6)
};
```
In this case, the expected output would be:
``` C#
int[,] expected = new int[,]{{7, 6, 4}, {8, 5, 2}, {3, 1, 9}};
```
... the solved puzzle looking like this:
``` C#
      Puzzle Solved:                   Related id numbers:
 ------------------------                  7    6    4
|-1  -1 | -1  -1 | -1  -1|                 
|-1   4 |  4  11 | 11  -1|                 8    5    2
|------------------------|
|-1   4 |  4  11 | 11  -1|                 3    1    9
|-1   5 |  5  17 | 17  -1|
|------------------------| 
|-1   5 |  5  17 | 17  -1| 
|-1  -1 | -1  -1 | -1  -1|
 ------------------------
```
### Notes:
- Be careful about performances, you'll have to handle rather big puzzles.
- Width and height will be between 2 and 100 (inclusive).
- The puzzle may be rectangular too.
