using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers
{
    public partial class Form1 : Form
    {




















        string Grid =
            /*"XXXXXXXX" + //stuck
            "XXXXXXXX" +
            "XXXXXXXX" +
            "XXXXXX2X" +
            "XXXXXXXX" +
            "XXXXXXXX" +
            "XXXXXXX1" +
            "XXXX1XXX";*/


            /*"X2XXXXXX" + //Becoming a Damka
            "XX2X2XXX" +
            "XXX2XXXX" +
            "XX2XXXXX" +
            "XXX1X2XX" +
            "XXXXXXXX" +
            "XXXXX2XX" +
            "XXXXXXXX";*/

           /*"X3XXXXXX" + //Damka killstreak
            "XXXXXXXX" +
            "XXX2XXXX" +
            "XXXXXXXX" +
            "XXX2X2XX" +
            "XXXXXXXX" +
            "XXXXX2XX" +
            "XXXXXXXX";*/


            /* "XXXXXXXX" + //Damka Double Kill
            "XXXXXXXX" +
            "XXX3XXXX" +
            "XXXXXXXX" +
            "XXXXX2XX" +
            "XXXXXXXX" +
            "XXXXX2XX" +
            "XXXXXXXX"; */


          /*"XXXXXXXX" + //Damka Test
            "XX2X2XXX" +
            "XXX3XXXX" +
            "XX2XXXXX" +
            "XXXXXXXX" +
            "XXXXXX2X" +
            "X1X1XXXX" +
            "1X1X1XXX"; */


            "X2X2X2X2" + // Normal Board
            "2X2X2X2X" +
            "X2X2X2X2" +
            "XXXXXXXX" +
            "XXXXXXXX" +
            "1X1X1X1X" +
            "X1X1X1X1" +
            "1X1X1X1X";

        SolidBrush Player1Brush = new SolidBrush(Color.FromArgb(255, 139, 69, 19));
        SolidBrush Player2Brush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
        SolidBrush green = new SolidBrush(Color.FromArgb(128, 0, 128, 0));
        SolidBrush lighterGreen = new SolidBrush(Color.FromArgb(128, 50, 205, 50));

        SolidBrush yellow = new SolidBrush(Color.FromArgb(128, 255, 255, 0));
        SolidBrush violet = new SolidBrush(Color.FromArgb(128, 138, 43, 226));

        Figure[,] board = new Figure[8, 8];

        Settings settings;
        int turn = 1;
        bool canKill;
        bool killStreak;
        Point selectedPoint;
        Figure selectedFigure;


        public Form1(Settings settings)
        {

            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered",                 // REFLECTION
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, panel1, new object[] { true });
            this.settings = settings;
            for (int i = 0; i < Grid.Length; i++)
            {
                if (Grid[i] != 'X')
                {
                    if ((int)char.GetNumericValue(Grid[i]) < 3) { board[i % 8, i / 8] = new Figure((int)char.GetNumericValue(Grid[i])); }

                    else { board[i % 8, i / 8] = new Damka((int)char.GetNumericValue(Grid[i]) - 2); }
                }

            }
            FindAllAvailableMoves();


        }

        void FindAllAvailableMoves()
        {


            bool canMove = false;
            canKill = false;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (board[x, y] != null && board[x, y].player == turn)
                    {

                        board[x, y].findKillMoves(board, new Point(x, y));
                        if (board[x, y].killMoves.Count > 0) { canMove = true; }
                        if (!canKill && board[x, y].killMoves.Count() > 0) { canKill = true; } // if we didn't know the player could kill and now we do


                    }
                }
            }

            if (!canKill || !Rules.MustKill)
            {
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if (board[x, y] != null && board[x, y].player == turn)
                        {

                            board[x, y].findRegularMoves(board, new Point(x, y));
                            if (board[x, y].RegularMoves.Count > 0) { canMove = true; }
                        }
                    }
                }
            }
            else
            {
                foreach (Figure f in board)
                {
                    if (f != null)
                    { f.RegularMoves.Clear(); }
                }
            }

            if (!canMove)
            {
                MessageBox.Show(((turn == 2) ? "Brown " : "White ") + "Victory!", "Universal Checkers", MessageBoxButtons.OK);
                settings.Show();
                Dispose();
            }
        }

        private void Form1_Paint(object sender,
   System.Windows.Forms.PaintEventArgs pe)
        {

            Graphics g = pe.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (selectedFigure != null)
            {

                g.FillEllipse(selectedFigure.player == 1 ? lighterGreen : green, selectedPoint.X * 75 + 17, selectedPoint.Y * 75 + 17, 41, 41);
                if (canKill)
                {
                    foreach (Point point in selectedFigure.killMoves)
                    {
                        g.FillRectangle(green, point.X * 75, point.Y * 75, 75, 75);
                    }
                }

                if (!canKill || (!Rules.MustKill && !killStreak))
                {
                    foreach (Point point in selectedFigure.RegularMoves)
                    {
                        g.FillRectangle(green, point.X * 75, point.Y * 75, 75, 75);
                    }
                }
            }


            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (!killStreak && board[x, y] != selectedFigure && board[x, y] != null && board[x, y].player == turn && (((canKill || !Rules.MustKill) && board[x, y].killMoves.Count > 0) || ((!canKill || !Rules.MustKill) && board[x, y].RegularMoves.Count > 0)))
                    {
                        g.FillEllipse((board[x, y].player == 1) ? yellow : violet, x * 75 + 17, y * 75 + 17, 41, 41);

                    }



                }




            }



            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                {
                    if (board[x, y] != null)
                    {
                        Figure f = board[x, y];
                        Brush b = (f.player == 1) ? Player1Brush : Player2Brush;

                        g.FillEllipse(b, x * 75 + 20, y * 75 + 20, 35, 35);
                        if (board[x, y].GetType() == typeof(Damka)) { g.DrawImage(Properties.Resources.crown, x * 75 + 18, y * 75 - 5, 40, 40); }
                    }


                }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void panel1_Click(object sender, EventArgs e)
        {

            Point clickedPoint = new Point(((MouseEventArgs)e).X / 75, ((MouseEventArgs)e).Y / 75);
            Figure clickedFigure = board[clickedPoint.X, clickedPoint.Y];


            if (clickedFigure != null && clickedFigure.player == turn && !killStreak && (clickedFigure.RegularMoves.Count() > 0 || clickedFigure.killMoves.Count() > 0)) // if selecting a figure (if a figure can kill, all figures' RegularMoves will be empty) (can't select another figure while in killstreak)
            {
                selectedPoint = clickedPoint;
                selectedFigure = clickedFigure;
                panel1.Invalidate();
            }


            else if (selectedFigure != null)
            {



                if ((canKill || !Rules.MustKill) && selectedFigure.killMoves.Contains(clickedPoint))
                { //if killing
                    board[selectedPoint.X, selectedPoint.Y] = null;
                    board[clickedPoint.X, clickedPoint.Y] = selectedFigure;

                    if (selectedFigure.GetType() == typeof(Damka))
                    {
                        int x = selectedPoint.X; int y = selectedPoint.Y;
                        while (board[x, y] == null)
                        {
                            x = x + ((clickedPoint.X > x) ? 1 : -1);
                            y = y + ((clickedPoint.Y > y) ? 1 : -1);
                        }
                        board[x, y] = null;
                    }

                    else { board[(clickedPoint.X + selectedPoint.X) / 2, (selectedPoint.Y + clickedPoint.Y) / 2] = null; }
                    selectedPoint = clickedPoint;

                    killStreak = true;
                    if (clickedPoint.Y == 0 && board[clickedPoint.X, clickedPoint.Y].player == 1)
                    {
                        board[clickedPoint.X, clickedPoint.Y] = new Damka(1);
                    }
                    else if (clickedPoint.Y == 7 && board[clickedPoint.X, clickedPoint.Y].player == 2)
                    {
                        board[clickedPoint.X, clickedPoint.Y] = new Damka(2);
                    }
                    selectedFigure = board[clickedPoint.X, clickedPoint.Y];
                    selectedFigure.findKillMoves(board, selectedPoint);
                    if (selectedFigure.killMoves.Count == 0)
                    {
                        killStreak = false;
                        selectedFigure = null;
                        turn += 1;
                        if (turn > 2)
                        {
                            turn = 1;
                        }
                    }


                }



                else if (selectedFigure.RegularMoves.Contains(clickedPoint) && (!canKill || (!Rules.MustKill && !killStreak)))
                {     // if moving to a free cell
                    board[selectedPoint.X, selectedPoint.Y] = null;
                    board[clickedPoint.X, clickedPoint.Y] = selectedFigure;
                    if (clickedPoint.Y == 0 && board[clickedPoint.X, clickedPoint.Y].player == 1)
                    {
                        board[clickedPoint.X, clickedPoint.Y] = new Damka(1);
                    }
                    else if (clickedPoint.Y == 7 && board[clickedPoint.X, clickedPoint.Y].player == 2)
                    {
                        board[clickedPoint.X, clickedPoint.Y] = new Damka(2);
                    }
                    selectedFigure = null;

                    turn += 1;
                    if (turn > 2)
                    {
                        turn = 1;
                    }

                }
                panel1.Invalidate();
                FindAllAvailableMoves();
            }






        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
