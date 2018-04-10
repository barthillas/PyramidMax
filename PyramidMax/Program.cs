using System;


public class Program
{
    private static string ConstantInput()
    {
        const string pyramid = @"215
                               193 124
                             117 237 442
                           218 935 347 235
                         320 804 522 417 345
                       229 601 723 835 133 124
                     248 202 277 433 207 263 257
                   359 464 504 528 516 716 871 182
                 461 441 426 656 863 560 380 171 923
                381 348 573 533 447 632 387 176 975 449
              223 711 445 645 245 543 931 532 937 541 444
            330 131 333 928 377 733 017 778 839 168 197 197
          131 171 522 137 217 224 291 413 528 520 227 229 928
        223 626 034 683 839 53  627 310 713 999 629 817 410 121
      924 622 911 233 325 139 721 218 253 223 107 233 230 124 233";
        return pyramid;
    }

    private static bool IsNumberPrime(int number)
    {
        int i;
        for (i = 2; i <= number - 1; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        if (i == number)
        {
            return true;
        }

        return false;
    }

    private static int[,] ParseInputElements(string inputText)
    {
        string[] textofPyramidRows = inputText.Split('\n');
        int quantityofRows = textofPyramidRows.Length;
        int[,] Pyramidarray2D = new int[quantityofRows, quantityofRows];
        for (int i = 0; i < quantityofRows; i++)
        {
            string[] NumbersInaRow = textofPyramidRows[i].Trim().Split(' ');
            for (int j = 0; j < NumbersInaRow.Length; j++)
            {
                int OneElementofPyramid;
                int.TryParse(NumbersInaRow[j], out OneElementofPyramid);
                Pyramidarray2D[i, j] = OneElementofPyramid;
            }
        }

        return Pyramidarray2D;
    }

    private static int CalculateDiagonalNonPrimeNumbers(int[,] Pyramidarray2D)
    {
        int quantityOfRows = Pyramidarray2D.GetLength(0);
        for (int i = quantityOfRows - 2; i >= 0; i--)
        {
            for (int j = quantityOfRows - 2; j >= 0; j--)
            {
                if (IsNumberPrime(Pyramidarray2D[i, j]) == false)
                {
                    Pyramidarray2D[i, j] += Math.Max(Pyramidarray2D[i + 1, j], Pyramidarray2D[i + 1, j + 1]);
                }
            }
        }

        return Pyramidarray2D[0, 0];
    }

    public static void Main()
    {
        int[,] Pyramidarray2D = ParseInputElements(ConstantInput());
        int result = CalculateDiagonalNonPrimeNumbers(Pyramidarray2D);
        Console.WriteLine(string.Format("The maximum summation of non-prime numbers from top to bottom: {0}", result));
        Console.ReadKey();
    }
}
