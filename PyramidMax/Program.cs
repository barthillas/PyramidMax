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
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;
////using System.IO;

////namespace PyramidMax
////{
////    class Program
////    {

////        private static string ConstantInput()
////        {
////            const string pyramid = @"215
////                                   193 124
////                                  117 237 442
////                                 218 935 347 235
////                                320 804 522 417 345
////                              229 601 723 835 133 124
////                             248 202 277 433 207 263 257
////                           359 464 504 528 516 716 871 182
////                          461 441 426 656 863 560 380 171 923
////                        381 348 573 533 447 632 387 176 975 449
////                      223 711 445 645 245 543 931 532 937 541 444
////                    330 131 333 928 377 733 017 778 839 168 197 197
////                  131 171 522 137 217 224 291 413 528 520 227 229 928
////                223 626 034 683 839 53  627 310 713 999 629 817 410 121
////              924 622 911 233 325 139 721 218 253 223 107 233 230 124 233";
////            return pyramid;
////        }

////        public static bool IsNumberPrime(int number)
////        {

////            {

////                bool bPrime = true;

////                int factor = number / 2;



////                int i = 0;



////                for (i = 2; i <= factor; i++)

////                {

////                    if ((number % i) == 0)

////                        bPrime = false;

////                }

////                return bPrime;

////            }


////            //int i;
////            //for (i = 2; i <= number - 1; i++)
////            //{
////            //    if (number % i == 0)
////            //    {
////            //        return false;
////            //    }
////            //}

////            //if (i == number)
////            //{
////            //    return true;
////            //}

////            //return false;


////        }

////        public static void Main()
////        {
////            // var textofPyramidfile = ConstantInput();
////            //string[] textofPyramidRows = textofPyramidfile.Split('\n');
////            string[] textofPyramidRows = File.ReadAllLines(@"C:\Users\barth\Desktop\PYRAMID\Pyramid.txt");

////            int quantityofRows = textofPyramidRows.Length;

////            int[,] Pyramidarray2D = new int[quantityofRows, quantityofRows];

////            for (int i = 0; i < quantityofRows; i++)
////            {
////                string[] NumbersInaRow = textofPyramidRows[i].Trim().Split(' ');

////                for (int j = 0; j < NumbersInaRow.Length; j++)
////                {
////                    int OneElementofPyramid;
////                    int.TryParse(NumbersInaRow[j], out OneElementofPyramid);
////                    Pyramidarray2D[i, j] = OneElementofPyramid;
////                }
////            }



////            for (int i = quantityofRows - 2; i >= 0; i--)
////            {
////                for (int j = quantityofRows - 2; j >= 0; j--)
////                {
////                    if (IsNumberPrime(Pyramidarray2D[i, j]) == false)
////                    {
////                        Pyramidarray2D[i, j] += Math.Max(Pyramidarray2D[i + 1, j],Pyramidarray2D[i + 1, j + 1]);
////                    }
////                }
////            }

////            Console.WriteLine(string.Format("Maximum summation of diagonal non-prime numbers: {0}", Pyramidarray2D[0, 0]));

////            //for (int i =0;  i<quantityofRows-2; i++)
////            //{
////            //    for (int j =0; j<quantityofRows - 2; j++)
////            //    {
////            //        if (IsNumberPrime(Pyramidarray2D[i, j])==false)
////            //        {
////            //            Pyramidarray2D[i+1, j] = Math.Max(Pyramidarray2D[i, j] + Pyramidarray2D[i + 1, j], Pyramidarray2D[i, j] + Pyramidarray2D[i + 1, j + 1]);

////            //        }
////            //    }
////            //}
////            //for (int i = 0; i < quantityofRows-1; i++)
////            //{
////            //    Console.WriteLine(Pyramidarray2D[quantityofRows-1,i]);

////            //}
////            //Console.WriteLine(string.Format("Maximum total: {0}", Pyramidarray2D[0, 0]));
////        }







////        //    static void Main(string[] args)
////        //    {

////        //        var textofPyramidfile = GetConstantInput();

////        //        string[] textofPyramidRows = textofPyramidfile.Split('\n');

////        //        int quantityofRows = textofPyramidRows.Length;

////        //        int[,] Pyramidarray2D = new int[quantityofRows, quantityofRows + 1];

////        //        for (int row = 0; row < quantityofRows; row++)
////        //        {
////        //            string[] NumbersInaRow = textofPyramidRows[row].Trim().Split(' ');

////        //            for (int column = 0; column < NumbersInaRow.Length; column++)
////        //            {
////        //                int.TryParse(NumbersInaRow[column], out int OneElementofPyramid);
////        //                Pyramidarray2D[row, column] = OneElementofPyramid;
////        //                Console.WriteLine(OneElementofPyramid.ToString());
////        //            }
////        //        }


////        //        for (int i = quantityofRows - 2; i >= 0; i--)
////        //        {
////        //            for (int j = 0; j < quantityofRows; j++)
////        //            {

////        //                if ((!IsNumberPrime(Pyramidarray2D[i, j])))
////        //                {
////        //                    Pyramidarray2D[i, j] = Math.Max(Pyramidarray2D[i, j] + Pyramidarray2D[i + 1, j], Pyramidarray2D[i, j] + Pyramidarray2D[i + 1, j + 1]);
////        //                }
////        //            }
////        //        }
////        //        Console.WriteLine(string.Format("Maximum total: {0}", Pyramidarray2D[0, 0]));



//   //// }



////        //    private static string GetConstantInput()
////        //    {
////        //        const string pyramid = @"215
////        //                                193 124
////        //                                117 237 442
////        //                                218 935 347 235
////        //                                320 804 522 417 345
////        //                                229 601 723 835 133 124
////        //                                248 202 277 433 207 263 257
////        //                                359 464 504 528 516 716 871 182
////        //                                461 441 426 656 863 560 380 171 923
////        //                                381 348 573 533 447 632 387 176 975 449
////        //                                223 711 445 645 245 543 931 532 937 541 444
////        //                                330 131 333 928 377 733 017 778 839 168 197 197
////        //                                131 171 522 137 217 224 291 413 528 520 227 229 928
////        //                                223 626 034 683 839 53  627 310 713 999 629 817 410 121
////        //                                924 622 911 233 325 139 721 218 253 223 107 233 230 124 233";

////        //        return pyramid;
////        //    }







////    }



////}
//using System;

//class Program
//{
//    static void Main(string[] args)
//    {


//        //get input
//        var input = GetInput();

//        string[] arrayOfRowsByNewlines = input.Split('\n');

//        var tableHolder = FlattenTheTriangleIntoTable(arrayOfRowsByNewlines);

//        var result = WalkThroughTheNode(arrayOfRowsByNewlines, tableHolder);

//        Console.WriteLine($"The Maximum Total Sum Of Non-Prime Numbers From Top To Bottom Is:  {result[0, 0]}");

//        Console.ReadKey();
//    }

//    private static string GetInput()
//    {

//        const string input = @"   215
//                                   193 124
//                                  117 237 442
//                                218 935 347 235
//                              320 804 522 417 345
//                            229 601 723 835 133 124
//                          248 202 277 433 207 263 257
//                        359 464 504 528 516 716 871 182
//                      461 441 426 656 863 560 380 171 923
//                     381 348 573 533 447 632 387 176 975 449
//                   223 711 445 645 245 543 931 532 937 541 444
//                 330 131 333 928 377 733 017 778 839 168 197 197
//                131 171 522 137 217 224 291 413 528 520 227 229 928
//              223 626 034 683 839 053 627 310 713 999 629 817 410 121
//            924 622 911 233 325 139 721 218 253 223 107 233 230 124 233";
//        return input;
//    }
//    public static bool IsPrime(int number)
//    {
//        int i;
//        for (i = 2; i <= number - 1; i++)
//        {
//            if (number % i == 0)
//            {
//                return false;
//            }
//        }
//        if (i == number)
//        {
//            return true;
//        }
//        return false;
//    }

//    private static int[,] WalkThroughTheNode(string[] arrayOfRowsByNewlines, int[,] tableHolder)
//    {
//        // walking through the non-prime node
//        for (int i = arrayOfRowsByNewlines.Length - 2; i >= 0; i--)
//        {
//            for (int j = 0; j < arrayOfRowsByNewlines.Length; j++)
//            {
//                //only sum through the non-prime node
//                if ((!IsPrime(tableHolder[i, j])))
//                {
//                    tableHolder[i, j] = Math.Max(tableHolder[i, j] + tableHolder[i + 1, j],
//                        tableHolder[i, j] + tableHolder[i + 1, j + 1]);
//                }
//            }
//        }
//        return tableHolder;
//    }

//    private static int[,] FlattenTheTriangleIntoTable(string[] arrayOfRowsByNewlines)
//    {
//        int[,] tableHolder = new int[arrayOfRowsByNewlines.Length, arrayOfRowsByNewlines.Length + 1];

//        for (int row = 0; row < arrayOfRowsByNewlines.Length; row++)
//        {
//            var eachCharactersInRow = arrayOfRowsByNewlines[row].Trim().Split(' ');

//            for (int column = 0; column < eachCharactersInRow.Length; column++)
//            {
//                int number;
//                int.TryParse(eachCharactersInRow[column], out number);
//                tableHolder[row, column] = number;
//            }
//        }
//        return tableHolder;
//    }

//    //public static bool IsPrime(int number)
//    //{
//    //    // Test whether the parameter is a prime number.
//    //    if ((number & 1) == 0)
//    //    {
//    //        if (number == 2)
//    //        {
//    //            return true;
//    //        }
//    //        return false;
//    //    }

//    //    for (int i = 3; (i * i) <= number; i += 2)
//    //    {
//    //        if ((number % i) == 0)
//    //        {
//    //            return false;
//    //        }
//    //    }
//    //    return number != 1;
//    //}




//}