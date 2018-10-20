using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Figure
    {
        public int player;
       public Figure(int player) {

           this.player = player;
    }
       public List<Point> RegularMoves = new List<Point>();
       public List<Point> killMoves = new List<Point>();
       public virtual void findKillMoves(Figure[,] board, Point selfPosition) {
           killMoves.Clear();
           if (player == 1 || Rules.BackKills)
           {
               if (selfPosition.X+2<8 && selfPosition.Y-2>=0)
               {
                   if (board[selfPosition.X + 1, selfPosition.Y - 1] != null && board[selfPosition.X + 1, selfPosition.Y - 1].player !=player && board[selfPosition.X + 2, selfPosition.Y - 2] == null )
                   {
                       killMoves.Add(new Point(selfPosition.X + 2, selfPosition.Y - 2));
                   }
               }

               if (selfPosition.X - 2 >= 0 && selfPosition.Y - 2 >= 0)
               {
                   if (board[selfPosition.X - 1, selfPosition.Y - 1] != null && board[selfPosition.X - 1, selfPosition.Y - 1].player != player  && board[selfPosition.X - 2, selfPosition.Y-2]==null)
                   {
                       killMoves.Add(new Point(selfPosition.X - 2, selfPosition.Y - 2));
                   }
               }
           }
           if (player ==2 || Rules.BackKills)
           {
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
       public virtual void findRegularMoves(Figure[,] board, Point selfPosition)
       {
           RegularMoves.Clear();
           if (player == 1)
           {
               if (selfPosition.X + 1 < 8 && selfPosition.Y - 1 >= 0)
               {

                   if (board[selfPosition.X + 1, selfPosition.Y - 1] == null)
                   {
                       RegularMoves.Add(new Point (selfPosition.X + 1, selfPosition.Y - 1 ));
                   }
               }


               if (selfPosition.X - 1 >= 0 && selfPosition.Y - 1 >= 0)
               {
                   if (board[selfPosition.X - 1, selfPosition.Y - 1] == null)
                   {
                       RegularMoves.Add(new Point( selfPosition.X - 1, selfPosition.Y - 1 ));
                   }
               }
           }

           else
           {
               if (selfPosition.X + 1 < 8 && selfPosition.Y + 1 < 8)
               {

                   if (board[selfPosition.X + 1, selfPosition.Y + 1] == null)
                   {
                       RegularMoves.Add(new Point (selfPosition.X + 1, selfPosition.Y + 1 ));
                   }
               }


               if (selfPosition.X - 1 >= 0 && selfPosition.Y + 1 < 8)
               {
                   if (board[selfPosition.X - 1, selfPosition.Y + 1] == null)
                   {
                       RegularMoves.Add(new Point( selfPosition.X - 1, selfPosition.Y + 1 ));
                   }
               }
           }



       }





    }
}
