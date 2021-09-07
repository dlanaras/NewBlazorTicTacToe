using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;


public class GameMatrixService
{

    private int givenPos;

    private Shape[,] gameMatrix;


    public int GivenPos
    {
        get => this.givenPos;
        set
        {
            this.givenPos = value;
        }
    }

    public Shape[,] GameMatrix
    {
        get => this.gameMatrix;

        set
        {
            this.gameMatrix = value;
        }
    }
}
