using System.Collections.Generic;
using System.Linq;

public class Kata
{
    public static void Main()
    {
        ((int, int), (int, int), int)[] pieces = {
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
        // Test
        var t = PuzzleSolver(pieces, 3, 3);
        // ...should return 7 6 4
        //                  8 5 2
        //                  3 1 9
    }

    public static int[,] PuzzleSolver(((int, int), (int, int), int)[] pieces, int width, int height)
    {
        var p = pieces.ToList();
        int[,] idMatrix = new int[height, width];
        int[,] pMatrix = new int[height + 1, width + 1];

        for (int i = 0; i <= height; ++i)
            pMatrix[i, 0] = -1;

        for (int j = 1; j <= width; ++j)
            pMatrix[0, j] = -1;

        for (int i = 1; i <= height; ++i)
        {
            for (int j = 1; j <= width; ++j)
            {
                int index = p.IndexOf(p.First(x => x.Item2.Item1 == pMatrix[i, j - 1] && 
                x.Item1.Item1 == pMatrix[i - 1, j - 1] && x.Item1.Item2 == pMatrix[i - 1, j]));

                idMatrix[i - 1, j - 1] = p[index].Item3;
                pMatrix[i, j] = p[index].Item2.Item2;
                p.RemoveAt(index);
            }
        }

        return idMatrix;
    }
}