using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersLib
{
    public class Tutorial
    {
        private string instructions = "Chinese Checkers Rules\n\nEquipment\nThe Chinese Checkers board is in the shape of a six pointed star.Each point of the star is a triangle consisting of ten holes(four holes to each side). The interior of the board is a hexagon with each side five holes long. Each triangle is a different colour and there are six sets of ten marbles with corresponding colours.\n\nPreparation\nChinese Checkers can be played by two, three, four or six players. Obviously, for the six player game, all marbles and triangles are used. If there are four players, play starts in two pairs of opposing triangles and a two player game should also be played from opposing triangles.In a three player game the marbles will start in three triangles equidistant from each other.\nEach player chooses a colour and the 10 marbles of that colour are placed in the appropriately coloured triangle.\n\nObjective\nThe aim of the game is to be the first to player to move all ten marbles across the board and into the triangle opposite.\n\nPlay\nA toss of a coin decides who starts.Players take turns to move a single marble of their own colour. In one turn a marble may either be simply moved into an adjacent hole OR it may make one or more hops over other marbles.Where a hopping move is made, each hop must be over an adjacent marble and into the vacant hole directly beyond it. Each hop may be over any coloured marble including the player's own and can proceed in any one of the six directions. After each hop, the player may either finish or, if possible and desired, continue by hopping over another marble. Occasionally, a player will be able to move a marble all the way from the starting triangle across the board and into the opposite triangle in one turn!\nMarbles are never removed from the board.It is permitted to move a marble into any hole on the board including holes in triangles belonging to other players.However, once a marble has reached the opposite triangle, it may not be moved out of the triangle - only within the triangle.\n\nFinishing\nThe first player to occupy all 10 destination holes is the winner.\nDebate has always arisen over the situation where a player is prevented from winning because an opposing player's marble occupies one of the holes in the destination triangle. Many game rules omit to mention this implying that it is perfectly legal to block opponents in this dubious fashion.\n";


        public string getInstructions()
        {
            return instructions;
        }
    }
}
