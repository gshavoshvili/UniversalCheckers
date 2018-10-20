using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Damka:Figure
    {



         public Damka(int player):base (player) {

           
    }




         public override void findKillMoves(Figure[,] board, Point selfPosition)
         {
             killMoves.Clear();






             if (Rules.LongMoves)
             {
                 bool canContinue;
                 Damka imaginaryDamka = new Damka(player);
                 List<Point> killMovesTemp = new List<Point>();
                 Figure[,] boardTemp;
                 int x = 1;
                 int y = 1;
                 boardTemp = (Figure[,])board.Clone();
                 killMovesTemp.Clear();
                 canContinue = false;
                 while (selfPosition.X + x < 8 && selfPosition.Y + y < 8 && board[selfPosition.X + x, selfPosition.Y + y] == null)  // bottom right
                 {

                     x++;
                     y++;
                 }
                 if (selfPosition.X + x < 7
                     && selfPosition.Y + y < 7
                     && board[selfPosition.X + x, selfPosition.Y + y] != null
                     && board[selfPosition.X + x, selfPosition.Y + y].player != player
                     && board[selfPosition.X + x + 1, selfPosition.Y + y + 1] == null) //killable enemy figure detected 
                 {
                     //the figure must land on a continuing spot if such exist
                     boardTemp[selfPosition.X + x, selfPosition.Y + y] = null;

                     x++;
                     y++;
                     while (selfPosition.X + x < 8 && selfPosition.Y + y < 8 && board[selfPosition.X + x, selfPosition.Y + y] == null)
                     {
                         imaginaryDamka.findKillMoves(boardTemp, new Point(selfPosition.X + x, selfPosition.Y + y));
                         if (imaginaryDamka.killMoves.Count > 0 && canContinue == false)
                         {

                             killMovesTemp.Clear();
                             canContinue = true;

                         }
                         if (!canContinue || (canContinue && imaginaryDamka.killMoves.Count > 0))
                         {
                             killMovesTemp.Add(new Point(selfPosition.X + x, selfPosition.Y + y));
                         }
                         x++;
                         y++;
                     }
                     killMoves.AddRange(killMovesTemp);

                 }


                 x = 1;
                 y = 1;
                 boardTemp = (Figure[,])board.Clone();
                 killMovesTemp.Clear();
                 canContinue = false;
                 while (selfPosition.X - x >= 0 && selfPosition.Y + y < 8 && board[selfPosition.X - x, selfPosition.Y + y] == null)  // bottom left
                 {

                     x++;
                     y++;
                 }
                 if (selfPosition.X - x >= 1
                     && selfPosition.Y + y < 7
                     && board[selfPosition.X - x, selfPosition.Y + y] != null
                     && board[selfPosition.X - x, selfPosition.Y + y].player != player
                     && board[selfPosition.X - x - 1, selfPosition.Y + y + 1] == null) //killable enemy figure detected 
                 {
                     //the figure must land on a continuing spot if such exist
                     boardTemp[selfPosition.X - x, selfPosition.Y + y] = null;
                     x++;
                     y++;
                     while (selfPosition.X - x >= 0 && selfPosition.Y + y < 8 && board[selfPosition.X - x, selfPosition.Y + y] == null)
                     {
                         imaginaryDamka.findKillMoves(boardTemp, new Point(selfPosition.X - x, selfPosition.Y + y));
                         if (imaginaryDamka.killMoves.Count > 0 && canContinue == false)
                         {

                             killMovesTemp.Clear();
                             canContinue = true;

                         }
                         if (!canContinue || (canContinue && imaginaryDamka.killMoves.Count > 0))
                         {
                             killMovesTemp.Add(new Point(selfPosition.X - x, selfPosition.Y + y));
                         }
                         x++;
                         y++;
                     }

                     killMoves.AddRange(killMovesTemp);
                 }


                 x = 1;
                 y = 1;
                 boardTemp = (Figure[,])board.Clone();
                 killMovesTemp.Clear();
                 canContinue = false;
                 while (selfPosition.X + x < 8 && selfPosition.Y - y >= 0 && board[selfPosition.X + x, selfPosition.Y - y] == null)  // top right
                 {

                     x++;
                     y++;
                 }
                 if (selfPosition.X + x < 7
                     && selfPosition.Y - y >= 1
                     && board[selfPosition.X + x, selfPosition.Y - y] != null
                     && board[selfPosition.X + x, selfPosition.Y - y].player != player
                     && board[selfPosition.X + x + 1, selfPosition.Y - y - 1] == null) //killable enemy figure detected 
                 {
                     //the figure must land on a continuing spot if such exist
                     boardTemp[selfPosition.X + x, selfPosition.Y - y] = null;
                     x++;
                     y++;
                     while (selfPosition.X + x < 8 && selfPosition.Y - y >= 0 && board[selfPosition.X + x, selfPosition.Y - y] == null)
                     {
                         imaginaryDamka.findKillMoves(boardTemp, new Point(selfPosition.X + x, selfPosition.Y - y));
                         if (imaginaryDamka.killMoves.Count > 0 && canContinue == false)
                         {

                             killMovesTemp.Clear();
                             canContinue = true;

                         }
                         if (!canContinue || (canContinue && imaginaryDamka.killMoves.Count > 0))
                         {
                             killMovesTemp.Add(new Point(selfPosition.X + x, selfPosition.Y - y));
                         }
                         x++;
                         y++;
                     }
                     killMoves.AddRange(killMovesTemp);

                 }


                 x = 1;
                 y = 1;
                 boardTemp = (Figure[,])board.Clone();
                 killMovesTemp.Clear();
                 canContinue = false;
                 while (selfPosition.X - x >= 0 && selfPosition.Y - y >= 0 && board[selfPosition.X - x, selfPosition.Y - y] == null)  // top left
                 {

                     x++;
                     y++;
                 }
                 if (selfPosition.X - x >= 1
                     && selfPosition.Y - y >= 1
                     && board[selfPosition.X - x, selfPosition.Y - y] != null
                     && board[selfPosition.X - x, selfPosition.Y - y].player != player
                     && board[selfPosition.X - x - 1, selfPosition.Y - y - 1] == null) //killable enemy figure detected 
                 {
                     //the figure must land on a continuing spot if such exist
                     boardTemp[selfPosition.X - x, selfPosition.Y - y] = null;
                     x++;
                     y++;
                     while (selfPosition.X - x >= 0 && selfPosition.Y - y >= 0 && board[selfPosition.X - x, selfPosition.Y - y] == null)
                     {
                         imaginaryDamka.findKillMoves(boardTemp, new Point(selfPosition.X - x, selfPosition.Y - y));
                         if (imaginaryDamka.killMoves.Count > 0 && canContinue == false)
                         {

                             killMovesTemp.Clear();
                             canContinue = true;

                         }
                         if (!canContinue || (canContinue && imaginaryDamka.killMoves.Count > 0))
                         {
                             killMovesTemp.Add(new Point(selfPosition.X - x, selfPosition.Y - y));
                         }
                         x++;
                         y++;
                     }
                     killMoves.AddRange(killMovesTemp);

                 }
             }




             else
             {
              
                     if (selfPosition.X + 2 < 8 && selfPosition.Y - 2 >= 0)
                     {
                         if (board[selfPosition.X + 1, selfPosition.Y - 1] != null && board[selfPosition.X + 1, selfPosition.Y - 1].player != player && board[selfPosition.X + 2, selfPosition.Y - 2] == null)
                         {
                             killMoves.Add(new Point(selfPosition.X + 2, selfPosition.Y - 2));
                         }
                     }

                     if (selfPosition.X - 2 >= 0 && selfPosition.Y - 2 >= 0)
                     {
                         if (board[selfPosition.X - 1, selfPosition.Y - 1] != null && board[selfPosition.X - 1, selfPosition.Y - 1].player != player && board[selfPosition.X - 2, selfPosition.Y - 2] == null)
                         {
                             killMoves.Add(new Point(selfPosition.X - 2, selfPosition.Y - 2));
                         }
                     }
                 
               
                     if (selfPosition.X + 2 < 8 && selfPosition.Y + 2 < 8)
                     {
                         if (board[selfPosition.X + 1, selfPosition.Y + 1] != null && board[selfPosition.X + 1, selfPosition.Y + 1].player != player && board[selfPosition.X + 2, selfPosition.Y + 2] == null)
                         {
                             killMoves.Add(new Point(selfPosition.X + 2, selfPosition.Y + 2));
                         }
                     }

                     if (selfPosition.X - 2 >= 0 && selfPosition.Y + 2 < 8)
                     {
                         if (board[selfPosition.X - 1, selfPosition.Y + 1] != null && board[selfPosition.X - 1, selfPosition.Y + 1].player != player && board[selfPosition.X - 2, selfPosition.Y + 2] == null)
                         {
                             killMoves.Add(new Point(selfPosition.X - 2, selfPosition.Y + 2));
                         }
                     }

                 
             }

         }





         public override void findRegularMoves(Figure[,] board, Point selfPosition) {

             RegularMoves.Clear();

             if (Rules.LongMoves)
             {
                 int x = 1;
                 int y = 1;
                 while (selfPosition.X + x < 8 && selfPosition.Y + y < 8 && board[selfPosition.X + x, selfPosition.Y + y] == null)  // bottom right
                 {
                     RegularMoves.Add(new Point(selfPosition.X + x, selfPosition.Y + y));
                     x++;
                     y++;
                 }


                 x = 1;
                 y = 1;
                 while (selfPosition.X - x >= 0 && selfPosition.Y + y < 8 && board[selfPosition.X - x, selfPosition.Y + y] == null) // bottom left
                 {
                     RegularMoves.Add(new Point(selfPosition.X - x, selfPosition.Y + y));
                     x++;
                     y++;
                 }


                 x = 1;
                 y = 1;
                 while (selfPosition.X + x < 8 && selfPosition.Y - y >= 0 && board[selfPosition.X + x, selfPosition.Y - y] == null) // top right
                 {
                     RegularMoves.Add(new Point(selfPosition.X + x, selfPosition.Y - y));
                     x++;
                     y++;
                 }


                 x = 1;
                 y = 1;
                 while (selfPosition.X - x >= 0 && selfPosition.Y - y >= 0 && board[selfPosition.X - x, selfPosition.Y - y] == null) // top left
                 {
                     RegularMoves.Add(new Point(selfPosition.X - x, selfPosition.Y - y));
                     x++;
                     y++;
                 }
             }


             else
             {
                 if (selfPosition.X + 1 < 8 && selfPosition.Y - 1 >= 0)
                 {

                     if (board[selfPosition.X + 1, selfPosition.Y - 1] == null)
                     {
                         RegularMoves.Add(new Point(selfPosition.X + 1, selfPosition.Y - 1));
                     }
                 }


                 if (selfPosition.X - 1 >= 0 && selfPosition.Y - 1 >= 0)
                 {
                     if (board[selfPosition.X - 1, selfPosition.Y - 1] == null)
                     {
                         RegularMoves.Add(new Point(selfPosition.X - 1, selfPosition.Y - 1));
                     }
                 }



                 if (selfPosition.X + 1 < 8 && selfPosition.Y + 1 < 8)
                 {

                     if (board[selfPosition.X + 1, selfPosition.Y + 1] == null)
                     {
                         RegularMoves.Add(new Point(selfPosition.X + 1, selfPosition.Y + 1));
                     }
                 }


                 if (selfPosition.X - 1 >= 0 && selfPosition.Y + 1 < 8)
                 {
                     if (board[selfPosition.X - 1, selfPosition.Y + 1] == null)
                     {
                         RegularMoves.Add(new Point(selfPosition.X - 1, selfPosition.Y + 1));
                     }
                 }
             }
             
         
         
         
         
         }


    }
}
