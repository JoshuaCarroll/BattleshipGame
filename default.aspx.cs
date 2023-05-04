using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BattleshipRaygun
{
    public partial class _default : System.Web.UI.Page
    {
        private Board board;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblFeedback.Text = "";

            if (Session["board"] == null)
            {
                board = new Board(8, 8);
                Session["board"] = board;
            }
            else
            {
                board = (Board)Session["board"];
            }
        }

        protected void btnFire_Click(object sender, EventArgs e)
        {
            try
            {
                string[] input = txtCoords.Text.Split(',');
                int x = int.Parse(input[0].Trim()) - 1;
                int y = int.Parse(input[1].Trim()) - 1;

                if (x > 7 || x < 0 || y > 7 || y < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                Debug.WriteLine($"{x},{y} = {board.Cells[x, y]}");
                if (board.Cells[x,y] == null)
                {
                    Table1.Rows[y].Cells[x].Text = "🌊";

                    int cellsAway1 = Math.Abs(x - board.Ship1.StartX) + Math.Abs(y - board.Ship1.StartY);
                    int cellsAway2 = Math.Abs(x - board.Ship1.EndX) + Math.Abs(y - board.Ship1.EndY);
                    int cellsAway12 = Math.Min(cellsAway1, cellsAway2);

                    int cellsAway3 = Math.Abs(x - board.Ship2.StartX) + Math.Abs(y - board.Ship2.StartY);
                    int cellsAway4 = Math.Abs(x - board.Ship2.EndX) + Math.Abs(y - board.Ship2.EndY);
                    int cellsAway34 = Math.Min(cellsAway3, cellsAway4);

                    int cellsAway = Math.Min(cellsAway12, cellsAway34);

                    if (cellsAway < 3)
                    {
                        // hot
                        lblFeedback.ForeColor = Color.Black;
                        lblFeedback.Text = "You're red hot!";
                    }
                    else if (cellsAway < 5)
                    {
                        // warm
                        lblFeedback.ForeColor = Color.Black;
                        lblFeedback.Text = "You're getting warmer.";
                    }
                    else
                    {
                        // cold
                        lblFeedback.ForeColor = Color.Black;
                        lblFeedback.Text = "You're ice cold.";
                    }
                }
                else
                {
                    // We hit something
                    Table1.Rows[y].Cells[x].Text = "💥";
                    lblFeedback.ForeColor = Color.Black;
                    lblFeedback.Text = "You hit something!";

                    // Check if you sunk it
                    if (board.Cells[x, y] == "1")
                    {
                        registerHit(board.Ship1);
                    }
                    else 
                    { 
                        registerHit(board.Ship2);
                    }
                    board.Cells[x, y] = null;

                    if (board.Ship1.HitsToSink <= 0 && board.Ship2.HitsToSink <= 0)
                    {
                        lblFeedback.ForeColor = Color.DarkGreen;
                        lblFeedback.Text = $"YOU WIN!  <a href='default.aspx?{DateTime.Now.Ticks}'>Click here to play again.</a>";
                        txtCoords.Enabled = false;
                        btnFire.Enabled = false;
                    }
                }

                int guessesLeft = int.Parse(hdnGuessesLeft.Value) - 1;
                lblTorpedoes.Text = "";
                if (guessesLeft <= 0)
                {
                    lblFeedback.ForeColor = Color.DarkRed;
                    lblFeedback.Text = $"GAME OVER  <a href='default.aspx?{DateTime.Now.Ticks}'>Click here to try again.</a>";
                    txtCoords.Enabled = false;
                    btnFire.Enabled = false;
                }
                else
                {
                    for (int i = 0; i < guessesLeft; i++)
                    {
                        lblTorpedoes.Text += "🚀";
                    }
                }
                hdnGuessesLeft.Value = guessesLeft.ToString();

                txtCoords.Text = "";
            }
            catch (Exception)
            {
                txtCoords.Text = "";
                lblFeedback.ForeColor = Color.Black;
                lblFeedback.Text = "Your firing solution was not correctly formatted. Please enter 'x,y' where X is the bottom row and Y is on the right.";
            }

        }

        private void registerHit(Ship ship)
        {
            if (ship != null)
            {
                ship.HitsToSink--;
                Debug.WriteLine($"Ship can take {ship.HitsToSink} more hit(s).");
                if (ship.HitsToSink == 0)
                {
                    Table1.Rows[ship.StartY].Cells[ship.StartX].Text = "☠️";
                    Table1.Rows[ship.EndY].Cells[ship.EndX].Text = "☠️";

                    ship.StartX = 100;
                    ship.StartY = 100;
                    ship.EndX = 101;
                    ship.EndY = 101;

                    lblFeedback.ForeColor = Color.Black;
                    lblFeedback.Text = "You sunk a ship!";
                }
            }
        }
    }
}