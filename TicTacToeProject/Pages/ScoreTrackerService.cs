using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;


public class ScoreTrackerService
{


    private int ties;

    private int wins;

    private int losses;


    public int Ties
    {
        get => this.ties;

        set
        {
            this.ties = value;
        }
    }

    public int Wins
    {
        get => this.wins;

        set
        {
            this.wins = value;
        }
    }

    public int Losses
    {
        get => this.losses;

        set
        {
            this.losses = value;
        }
    }
}
