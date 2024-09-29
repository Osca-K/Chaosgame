using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

internal class Program
{
    static Panel pnlPacement;
    static Form fChaosGame;
    static Button btnStar;
    static NumericUpDown nudButton;
    static void Main(string[] args)
    {
        fChaosGame = new Form();
        fChaosGame.Text = "CHAOS GAME";
        fChaosGame.MaximizeBox = fChaosGame.MinimizeBox = false;
        fChaosGame.StartPosition = FormStartPosition.CenterScreen;
        fChaosGame.WindowState = FormWindowState.Normal;
        fChaosGame.FormBorderStyle = FormBorderStyle.FixedSingle;
        fChaosGame.Height = 650;
        fChaosGame.Width = 550;

        pnlPacement = new Panel();
        pnlPacement.Width = fChaosGame.Width - 50;
        pnlPacement.Height = fChaosGame.Height - 120;
        pnlPacement.Top = Convert.ToInt32(12.5);
        pnlPacement.Left = Convert.ToInt32(12.5);
        pnlPacement.BackColor = System.Drawing.Color.White;
        fChaosGame.Controls.Add(pnlPacement);

        btnStar = new Button();
        btnStar.Text = "Simulate";
        btnStar.Top = pnlPacement.Height + pnlPacement.Top + 10;
        btnStar.Left = pnlPacement.Left;
        btnStar.Click += StartButton;
        fChaosGame.Controls.Add(btnStar);

        nudButton = new NumericUpDown();
        nudButton.Top = btnStar.Top;
        nudButton.Width = btnStar.Width;
        nudButton.Left = pnlPacement.Width + btnStar.Left - nudButton.Width;
        nudButton.Maximum = 100000;
        nudButton.Minimum = 10;
        nudButton.Increment = 100;
        fChaosGame.Controls.Add(nudButton);

        Label lblIterations = new Label();
        lblIterations.Text = "Iterations";
        lblIterations.Left = nudButton.Left - nudButton.Width + 20;
        lblIterations.Top = btnStar.Top;
        //lblIterations.Height = btnStar.Top;
        fChaosGame.Controls.Add(lblIterations);


       


        Application.Run(fChaosGame);
    }
    static void StartButton(object sender, EventArgs e)
    {
        GeneratePoints();
        GetTriangle();
    }
    static void GeneratePoints()
    {
        Graphics g = pnlPacement.CreateGraphics();
        g.FillEllipse(new SolidBrush(Color.Red), 245, 0, 15, 15);
       // g.DrawString("A (1 or 2)", new Font("Arial", 10), Brushes.Black, 185, 0);

        Graphics e = pnlPacement.CreateGraphics();
        e.FillEllipse(new SolidBrush(Color.Red), 5, pnlPacement.Height - 15, 15, 15);
       // g.DrawString("B (3 or 4)", new Font("Arial", 10), Brushes.Black, 5 + 20, pnlPacement.Height - 35);
        
        Graphics f = pnlPacement.CreateGraphics();
        f.FillEllipse(new SolidBrush(Color.Red), pnlPacement.Width - 15, pnlPacement.Height - 15, 15, 15);
      //  g.DrawString("C (5 or 6)", new Font("Arial", 10), Brushes.Black, pnlPacement.Width - 55, pnlPacement.Height - 35);
    }
    static void GetTriangle()
    {
        int iXRefP = (245 + 5) / 2;
        int iYRefP = (0 + (pnlPacement.Height - 15)) / 2;
        int iDiceNumber;

        Random rdmDice = new Random();
        Graphics P = pnlPacement.CreateGraphics();
        P.FillEllipse(new SolidBrush(Color.Black), iXRefP, iYRefP, 5, 5);

        for (int i = 0; i <= nudButton.Value; i++)
        {
            iDiceNumber = rdmDice.Next(1, 7);

            if (iDiceNumber == 1 || iDiceNumber == 2)
            {
                iXRefP = (iXRefP + 245) / 2;
                iYRefP = (iYRefP + 0) / 2;
                P.FillEllipse(new SolidBrush(Color.Black), iXRefP, iYRefP, 5, 5);

            }
            else if (iDiceNumber == 3 || iDiceNumber == 4)
            {
                iXRefP = (iXRefP + 5) / 2;
                iYRefP = (iYRefP + (pnlPacement.Height - 15)) / 2;
                P.FillEllipse(new SolidBrush(Color.Black), iXRefP, iYRefP, 5, 5);
            }
            else
            {
                iXRefP = (iXRefP + pnlPacement.Width - 15) / 2;
                iYRefP = (iYRefP + (pnlPacement.Height - 15)) / 2;
                P.FillEllipse(new SolidBrush(Color.Black), iXRefP, iYRefP, 5, 5);

            }
            if (i < nudButton.Value)
            {
                nudButton.Enabled = false;
                btnStar.Enabled = false;
            }
            else
            {
                nudButton.Enabled = true;
                btnStar.Enabled = true;
            }

        }

    }
}