using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace Air_Hockey
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(175, 50, 50, 50);
        Rectangle player2 = new Rectangle(175, 530, 50, 50);
        Rectangle ball = new Rectangle(184, 316, 30, 30);
        Rectangle theo1 = new Rectangle(125, 636, 150, 10);
        Rectangle isaiah2 = new Rectangle(125, 0, 150, 10);

        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 6;
        int ballXSpeed = 0;
        int ballYSpeed = 0;

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        bool aDown = false;
        bool dDown = false;
        bool leftDown = false;
        bool rightDown = false;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        //Soundplayer
        SoundPlayer fart = new SoundPlayer(Properties.Resources.goalSound);
        SoundPlayer ballHit = new SoundPlayer(Properties.Resources.hitSound);

        public Form1()
        {
            InitializeComponent();
        }

        //Rectangle player1 = new Rectangle(175, 50, 50, 50);
        //Rectangle player2 = new Rectangle(175, 530, 50, 50);
        //Rectangle ball = new Rectangle(295, 195, 30, 30);
        //Rectangle theo1 = new Rectangle(125, 636, 150, 10);
        //Rectangle isaiah2 = new Rectangle(125, 0, 150, 10);


        //int player1Score = 0;
        //int player2Score = 0;

        //int playerSpeed = 6;
        //int ballXSpeed = -6;
        //int ballYSpeed = 6;

        //bool wDown = false;
        //bool sDown = false;
        //bool upArrowDown = false;
        //bool downArrowDown = false;

        //bool aDown = false;
        //bool dDown = false;
        //bool leftDown = false;
        //bool rightDown = false;

        //SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        //SolidBrush redBrush = new SolidBrush(Color.Red);
        //SolidBrush whiteBrush = new SolidBrush(Color.White);
        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //Move ball up and down
            ball.X += ballXSpeed;
            ball.Y += ballYSpeed;

            //Move player one up and down
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }

            if (sDown == true && player1.Y < 336 - player1.Height)
            {
                player1.Y += playerSpeed;
            }

            //Move player one left and right 
            if (aDown == true && player1.X > 0)
            {
                player1.X -= playerSpeed;
            }

            if (dDown == true && player1.X < 410  - player1.Width) 
            {
                player1.X += playerSpeed;
            }

            //Move player two up and down 
            if (upArrowDown == true && player2.Y > 336)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < 642 - player2.Height)
            {
                player2.Y += playerSpeed;
            }

            //Move player two left and right 
            if (leftDown == true && player2.X > 0)
            {
                player2.X -= playerSpeed;
            }

            if (rightDown == true && player2.X < 410 - player2.Width)
            {
                player2.X += playerSpeed;
            }

            //check if ball hit top or bottom wall and change direction if it does 
            if (ball.Y < 0 || ball.Y > 656 - ball.Height)
            {
                ballYSpeed *= -1;  
            } 
            if (ball.X < 0 || ball.X > 405 - ball.Width)
            {
                ballXSpeed *= -1; 
            }

            //check if ball hits either player. If it does change the direction 
            //and place the ball in front of the player hit 
            if (player1.IntersectsWith(ball))
            {
                ballXSpeed *= -1;
                ball.X = player1.X + ball.Width;
                ballXSpeed = -6;
                ballYSpeed = 6;
                ballHit.Play();
            }
            else if (player2.IntersectsWith(ball))
            {
                ballXSpeed *= -1;
                ball.X = player2.X - ball.Width;
                ballXSpeed = -6;
                ballYSpeed = 6;
                ballHit.Play();
            }

            //Scoring 
            if (ball.IntersectsWith(isaiah2))
            {
                player1Score++;
                player1.X = 175;
                player1.Y = 50;

                player2.X = 175;
                player2.Y = 530;

                ball.X = 184;
                ball.Y = 316;
                ballXSpeed = 0;
                ballYSpeed = 0;
                fart.Play();
            }
            if (ball.IntersectsWith(theo1))
            {
                player2Score++;

                player1.X = 175;
                player1.Y = 50;

                player2.X = 175;
                player2.Y = 530;

                ball.X = 184;
                ball.Y = 316;
                ballXSpeed = 0;
                ballYSpeed = 0;
                fart.Play();
            }

            if (player2Score == 3)
            {
                outputLabel.Text = "Player 2 Wins!";
            }
            if (player1Score == 3)
            {
                outputLabel.Text = "Player 1 Wins!";
            }

            Refresh(); 
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(redBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, ball);
            e.Graphics.FillRectangle(whiteBrush, theo1);
            e.Graphics.FillRectangle(whiteBrush, isaiah2);

        }
    }
}
