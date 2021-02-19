using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Delivery.Interface;

namespace Delivery.Extension
{
    public class CommonClass: ICommonClass
    {
        public  Response NextStep(string move, int x, int y)
        {
            var moveCheck = move.Contains("I") ? "I" : move.Contains("D") ? "D" : move;
            return moveCheck switch
            {
                "AX" => new Response() { x = x + 1, y = y, Move = "X" },
                "AY" => new Response() { x = x, y = y + 1, Move = "Y" },
                "AX-" => new Response() { x = x - 1, y = y, Move = "X-" },
                "AY-" => new Response() { x = x, y = y - 1, Move = "Y-" },
                "I" => new Response() { x = x, y = y, Move = MovingLeft(move) },
                "D" => new Response() { x = x, y = y, Move = MovingRight(move) },
                _ => new Response() { x = x, y = y },
            };
        }

        private string MovingRight(string move)
        {
            return move.Substring(1, move.Length - 1) switch
            {
                "X" => "Y-",
                "Y" => "X",
                "X-" => "Y",
                "Y-" => "X-",
                _ => "X"
            };
        }

        private string MovingLeft(string move)
        {
            return move.Substring(1, move.Length - 1) switch
            {
                "Y" => "X-",
                "X-" => "Y-",
                "Y-" => "X",
                "X" => "Y",
                _ => "X"
            };
        }

    }
}
