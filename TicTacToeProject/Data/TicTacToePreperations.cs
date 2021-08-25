using System;

    class TicTacToePreparations
    {
        public static bool WhoStarts()
        {
            Random rand = new Random();
            double decider = rand.NextDouble();
            if (decider > 0.5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
