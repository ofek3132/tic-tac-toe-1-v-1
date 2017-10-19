using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        public int player = 2; //player's turn
        public int turns = 0; //the number of turns
        public int s1 = 0; //x wins
        public int s2 = 0; //o wins
        public int sd = 0; //draws

        public Form1()
        {
            InitializeComponent();
        }
        // setting the labels
        private void Form1_Load(object sender, EventArgs e)
        {
            scoreUpdate();
        }
        //score update
        public void scoreUpdate()
        {
            xWins.Text = "x: " + s1;
            oWins.Text = "o: " + s2;
            draws.Text = "draws: " + sd;
        }
        //exit button
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //o / x buttons
        private void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "")
            {
                if (player % 2 == 0)
                {
                    button.Text = "x";
                    player++;
                    turns++;
                }
                else
                {
                    button.Text = "o";
                    player++;
                    turns++;
                }
                if (checkDraw() == true)
                {
                    MessageBox.Show("It's a tie!");
                    sd++;
                    scoreUpdate();
                    newGame();
                }
                if (checkWinner() == true)
                {
                    if (button.Text == "x")
                    {
                        MessageBox.Show("x wins!");
                        s1++;
                        scoreUpdate();
                        newGame();
                    }
                    else
                    {
                        MessageBox.Show("o wins!");
                        s2++;
                        scoreUpdate();
                        newGame();
                    }
                }
            }
        }
        //new game
        public void newGame()
        {
            player = 2;
            turns = 0;
            A00.Text = A01.Text = A02.Text = A10.Text = A11.Text = A12.Text = A20.Text = A21.Text = A22.Text = "";
        }
        //checks if a draw
        public bool checkDraw()
        {
            if (turns == 9 && checkWinner() == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //checks who is the winner
        public bool checkWinner()
        {
            if (A00.Text == A01.Text && A01.Text == A02.Text && A00.Text != "")
                return true;
            else if (A10.Text == A11.Text && A11.Text == A12.Text && A10.Text != "")
                return true;
            else if (A20.Text == A21.Text && A21.Text == A22.Text && A20.Text != "")
                return true;
            else if (A00.Text == A10.Text && A10.Text == A20.Text && A00.Text != "")
                return true;
            else if (A01.Text == A11.Text && A11.Text == A21.Text && A01.Text != "")
                return true;
            else if (A02.Text == A12.Text && A12.Text == A22.Text && A02.Text != "")
                return true;
            else if (A00.Text == A11.Text && A11.Text == A22.Text && A00.Text != "")
                return true;
            else if (A02.Text == A11.Text && A11.Text == A20.Text && A02.Text != "")
                return true;
            else
                return false;
        }
        //New game button click
        private void newGameButton_Click(object sender, EventArgs e)
        {
            newGame();
        }
        //Reset button clicked
        private void resetButton_Click(object sender, EventArgs e)
        {
            player = 2;
            turns = 0;
            s1 = 0;
            s2 = 0;
            sd = 0;
            A00.Text = A01.Text = A02.Text = A10.Text = A11.Text = A12.Text = A20.Text = A21.Text = A22.Text = "";
            scoreUpdate();
        }
    }
}
