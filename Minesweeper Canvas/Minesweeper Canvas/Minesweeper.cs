using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper_Canvas
{
    public partial class Minesweeper : Form
    {
        public Minesweeper()
        {
            InitializeComponent();
        }

        Cell[,] grid;
        int arrSize = 10;
        int totalBombs = 15;
        int totalLeft;
        int boardSize = 400;
        int spacing;
        int bombSize;
        bool winner;
        bool gameLost;
        bool gameOver;
        List<Point> markedLocations;
        Random rand = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            boardSize = (int)(this.Size.Width * 0.75);
            NewGame();
            //RevealAll();
        }

        void RevealAll()
        {
            for (int x = 0; x < arrSize; x++)
            {
                for (int y = 0; y < arrSize; y++)
                {
                    grid[x, y].isRevealed = true;
                }
            }
        }

        void Create2D(int newSize)
        {
            grid = new Cell[newSize, newSize];

            for (int x = 0; x < newSize; x++)
                for (int y = 0; y < newSize; y++)
                {
                    int i = rand.Next(newSize);
                    int j = rand.Next(newSize);

                    if (totalBombs > 0)
                    {
                        while (grid[i, j] != null)
                        {
                            i = rand.Next(newSize);
                            j = rand.Next(newSize);
                        }

                        grid[i, j] = new Cell(true);
                        totalBombs--;
                    }
                }

            for (int x = 0; x < newSize; x++)
                for (int y = 0; y < newSize; y++)
                {
                    if (grid[x, y] == null)
                    {
                        grid[x, y] = new Cell(false);
                    }
                }
        }

        int CountNeighbors(int x, int y)
        {
            int total = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (x + i > -1 && y + j > -1
                        && x + i < arrSize && y + j < arrSize)
                    {
                        Cell neighbor = grid[x + i, y + j];
                        if (neighbor.isBomb)
                            total++;
                    }
                }
            }

            return total;
        }

        void FillNeighbors(int x, int y)
        {
            for (int offx = -1; offx <= 1; offx++)
            {
                for (int offy = -1; offy <= 1; offy++)
                {
                    int i = x + offx;
                    int j = y + offy;

                    if (i > -1 && j > -1
                        && i < arrSize && j < arrSize)
                    {
                        Cell neighbor = grid[i, j];
                        if (!neighbor.isRevealed && !neighbor.isBomb
                            && CountNeighbors(x, y) == 0
                            && !neighbor.isMarked)
                        {
                            grid[i, j].isRevealed = true;
                            FillNeighbors(i, j);
                        }
                    }
                }
            }
        }

        bool CheckForWin()
        {
            int found = 0;

            for (int x = 0; x < arrSize; x++)
            {
                for (int y = 0; y < arrSize; y++)
                {
                    if (markedLocations.Contains(new Point(x, y)))
                    {
                        found++;
                    }
                }
            }

            if (found == setMines.Value)
                return true;
            else
                return false;
        }

        bool Contains(int x, int y, int mx, int my)
        {
            if (mx > x && mx < x + spacing && my > y && my < y + spacing)
                return true;

            return false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            Font standard = new Font("QUARTZ MS", spacing / 2);
            Font winLose = new Font("QUARTZ MS", boardSize / 10);
            Pen bombPen = new Pen(Color.Gold, spacing / 7);

            for (int x = 0; x < arrSize; x++)
            {
                for (int y = 0; y < arrSize; y++)
                {
                    if (grid[x, y].isRevealed)
                    {
                        if (grid[x, y].isBomb)
                        {
                            if(grid[x, y].isMarked)
                                g.FillRectangle(Brushes.Green, new Rectangle(x * spacing, y * spacing, spacing, spacing));
                            else if (grid[x, y].isFinal)
                                g.FillRectangle(Brushes.DarkRed, new Rectangle(x * spacing, y * spacing, spacing, spacing));
                            else
                                g.FillRectangle(Brushes.Gray, new Rectangle(x * spacing, y * spacing, spacing, spacing));
                            
                            g.DrawEllipse(bombPen, new Rectangle(x * spacing + (bombSize / 2), y * spacing + (bombSize / 2), bombSize, bombSize));
                        }
                        else
                        {
                            g.FillRectangle(Brushes.Gray, new Rectangle(x * spacing, y * spacing, spacing, spacing));

                            int neighborCount = CountNeighbors(x, y);
                            if (neighborCount > 0)
                                g.DrawString(neighborCount.ToString(), standard, Brushes.Black, new Point(x * spacing + spacing / 2, y * spacing + spacing / 2), format);
                        }
                    }
                    else
                    {
                        g.FillRectangle(Brushes.White, new Rectangle(x * spacing, y * spacing, spacing, spacing));

                        if (grid[x, y].isMarked)
                            g.DrawString("X", standard, Brushes.Red, new Point(x * spacing + spacing / 2, y * spacing + spacing / 2), format);
                    }


                    g.DrawRectangle(Pens.Black, new Rectangle(x * spacing, y * spacing, spacing, spacing));
                }
            }

            if (winner)
                g.DrawString("You Won!", winLose, Brushes.LightGreen, new Point(boardSize / 2, boardSize / 2), format);

            if (gameLost)
                g.DrawString("You Lost!", winLose, Brushes.Red, new Point(boardSize / 2, boardSize / 2), format);

            g.DrawString(totalLeft.ToString(), new Font("QUARTZ MS", 30), Brushes.Red, new Point(boardSize, 0));

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!gameOver)
            {
                for (int x = 0; x < arrSize; x++)
                {
                    for (int y = 0; y < arrSize; y++)
                    {
                        if (Contains(x * spacing, y * spacing, e.X, e.Y))
                        {
                            if (e.Button == MouseButtons.Left && !grid[x, y].isMarked)
                            {
                                if (grid[x, y].isBomb)
                                {
                                    grid[x, y].isFinal = true;
                                    gameLost = true;
                                    gameOver = true;
                                    RevealAll();
                                }

                                grid[x, y].isRevealed = true;
                                FillNeighbors(x, y);
                            }

                            if (e.Button == MouseButtons.Right && !grid[x, y].isRevealed)
                            {
                                if (grid[x, y].isMarked)
                                {
                                    grid[x, y].isMarked = false;
                                    markedLocations.Remove(new Point(x, y));
                                    totalLeft++;
                                }
                                else
                                {
                                    if (totalLeft > 0)
                                    {
                                        if (!grid[x, y].isMarked)
                                        {
                                            grid[x, y].isMarked = true;
                                            markedLocations.Add(new Point(x, y));
                                            totalLeft--;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Repaint();
        }

        void NewGame()
        {
            arrSize = (int)setSize.Value;
            totalBombs = (int)setMines.Value;
            spacing = boardSize / arrSize;
            bombSize = spacing / 2;
            totalLeft = totalBombs;
            markedLocations = new List<Point>();
            winner = false;
            gameLost = false;
            gameOver = false;

            setMines.Maximum = (int)Math.Pow(arrSize, 2);

            Create2D(arrSize);

            Repaint();
        }

        void Repaint()
        {
            this.Invalidate();
            this.Update();
            this.Refresh();
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void checkWin_Click(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                if (CheckForWin())
                {
                    winner = true;
                    gameOver = true;
                }
                else
                {
                    winner = false;
                    MessageBox.Show("You've not found all of the mines yet!", "Keep trying");
                }

                Repaint();
            }
        }

        private void setSize_ValueChanged(object sender, EventArgs e)
        {
            setMines.Maximum = (int)Math.Pow((int)setSize.Value, 2);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            boardSize = (int)(this.Size.Width * 0.75);
            arrSize = (int)setSize.Value;
            totalBombs = (int)setMines.Value;
            spacing = boardSize / arrSize;

            Repaint();
        }
    }
}
