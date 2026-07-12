using System;
using System.IO;

namespace baekjoon
{
    class Program
    {
        static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static int n = int.Parse(sr.ReadLine());
        static int[] board = new int[15];
        static int result = 0;
        static void Main(string[] args)
        {
            DFS(0);
            Console.WriteLine(result);
            sr.Close();
        }

        static void DFS(int row)
        {
            if (row == n) result++;
            else
            {
                for (int col = 0; col < n; col++)
                {
                    //퀸의 갯수는 무조건 for문의 범위까지 돌면서 한 줄에 하나의 퀸을 놓으면 n개의 갯수만큼 채워지게 됨.
                    board[row] = col;
                    //깊이 우선 탐색, 유망성 체크
                    //현재 행에 이미 퀸이 놓여졌으면 깊이를 1 증가
                    if (isPossibleQ(row))
                        DFS(row + 1);
                }
            }
        }
        
        //현재 행에 퀸을 놓아도 되는지 체크
        static bool isPossibleQ(int nowRow)
        {
            for (int i = 0; i < nowRow; i++)
            {
                if (board[i] == board[nowRow] // 같은열에 퀸이 있는가
                || (nowRow - i) == Math.Abs(board[i] - board[nowRow])) // 대각선에 퀸이 있는가 ( 아래는 앞으로 체크할 부분이기에 윗 대각선만 체크하면 됨 )
                    return false;
            }

            return true; 
        }
    }
}
