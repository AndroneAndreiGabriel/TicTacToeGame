﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// The type of value a cell in the game is currently at
    /// </summary>
    public enum MarkType
    {
        /// <summary>
        /// The cell hasn't been cliked yet
        /// </summary>
        Free,
        /// <summary>
        /// The cell is a 0
        /// </summary>
        Nought,
        /// <summary>
        /// The cell has an X
        /// </summary>
        Cross
    }
}