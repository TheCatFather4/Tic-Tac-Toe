﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.UI
{
    public enum PlacementAttempt
    {
        SymbolPlaced,
        XWins,
        OWins,
        Draw,
        InvalidOverlap,
        InvalidOffGrid
    }
}
