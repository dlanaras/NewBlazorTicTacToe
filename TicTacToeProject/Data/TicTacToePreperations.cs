using System;

    class TicTacToePreparations
    {

        private Shape playerChosenShape;
        private Shape aiChosenShape;

        public Shape AiChosenShape
        {
            get => aiChosenShape;
            set
            {
                this.aiChosenShape = value;
            }
        }
        public Shape PlayerChosenShape
        {
            get => playerChosenShape;
            set
            {
                this.playerChosenShape = value;
            }
        }

        public bool WhoStarts()
        {
            Random rand = new Random();
            double decider = rand.NextDouble();
            Console.WriteLine("\nRolling the Dice to see who starts first... \n");
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
