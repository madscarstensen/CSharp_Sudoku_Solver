using System;

namespace SudokuSolver {
  class Program
  {
    static private int[,] sudokuProblemHard = {{5, 3, 4, 6, 7, 8, 9, 1, 2},
      {6, 7, 2, 1, 9, 5, 3, 4, 8},
      {1, 9, 8, 3, 4, 2, 5, 6, 7},
      {8, 5, 9, 7, 6, 1, 4, 2, 3},
      {4, 2, 6, 8, 5, 3, 7, 9, 1},
      {7, 1, 3, 9, 2, 4, 8, 5, 6},
      {9, 6, 1, 5, 3, 7, 2, 8, 4},
      {2, 8, 7, 4, 1, 9, 6, 3, 5},
      {3, 4, 5, 2, 8, 6, 1, 7, 9}};

    static private int[,] sudokuProblemEasy = {{5, 3, 4},
      {6, 0, 7},
      {3, 9, 8}};


    static void Main(string[] args)
    {
      SudokuSolver sudokuSolver = new SudokuSolver();
      SudokuPrinter.PrintSudoku(sudokuProblemHard);
      Console.WriteLine();

      int rowPosition = 5;
      int columnPosition = 4;

      for (int i = 1; i < 10; i++) {
        if (sudokuSolver.CheckNumber(sudokuProblemHard, i, rowPosition, columnPosition)) {
          Console.Write(i);
          Console.Write(" fits in position ");
          Console.Write(rowPosition);
          Console.Write(",");
          Console.WriteLine(columnPosition);
        } else {
          Console.Write(i);
          Console.Write(" does not fit in position ");
          Console.Write(rowPosition);
          Console.Write(",");
          Console.WriteLine(columnPosition);
        }
      }
    }
  }


  /* Class responsible for solving a given sudoku problem */
  class SudokuSolver {
    public int[,] SolveSudoku (int[,] sudokuProblem) {
      return sudokuProblem;
    }

    /* rowPosition indicates the row the number is to be placed in, columPosition the column */
    /* if the number is to be placed in [2, 3] then 2 is the rowPosition and 3 the columnPosition */
    public bool CheckNumber (int[,] sudokuProblem, int number, int rowPosition, int columnPosition) {
      bool numberFits = true;

      /* First check that the number will not be repeated in the column if it is inserted */
      for (int i = 0; i < sudokuProblem.GetLength(0); i++) {
        if (i != rowPosition) {
          if (sudokuProblem[i, columnPosition] == number) {
            numberFits = false;
          }
        }
      }

      /* Second check that the number will not be repeated in the row if it is inserted */
      for (int j = 0; j < sudokuProblem.GetLength(1); j++) {
        if (j != columnPosition) {
          if (sudokuProblem[rowPosition, j] == number) {
            numberFits = false;
          }
        }
      }

    return numberFits;
  }
}


/* Class responsible for visualising a sudoku problem by printing every row */
static class SudokuPrinter {
  public static void PrintSudoku (int[,] sudokuProblem) {
    for (int i = 0; i < sudokuProblem.GetLength(0); i++) {
      for (int j = 0; j < sudokuProblem.GetLength(1); j++) {
        Console.Write(sudokuProblem[i, j] + " ");
      }
      Console.WriteLine();
    }
  }
}
}
