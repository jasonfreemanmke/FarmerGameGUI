using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamerGameGUI
{
    public partial class Form1 : Form
    {
        //string food;
        //bool win;


        Farmer theFarmer = new Farmer();
        public Form1()
        {
            InitializeComponent();
            DisplayGameState();
        }

        private void btnFarmerNorth_Click(object sender, EventArgs e)
        {

            Play("");
        }

        private void btnFoxNorth_Click(object sender, EventArgs e)
        {

            Play("FOX");
        }

        private void btnChickenNorth_Click(object sender, EventArgs e)
        {
            Play("CHICKEN");
        }

       

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" This is the Farmer Game.  The object of this game is to get the farmer, fox, chicken, and grain to the other side" +
            "of the river. However, not so fast.  If the farmer leaves the chicken and the grain on either side of the river " +
            " that chicken will eat the grain, and that is not a good.  If the farmer leaves the fox and the chicken together "+
            " the fox will have a good meal and thats not good either.  If the farmer, the chicken, the fox, and the grain get safely" +
            " to the other side you win!");
        }

        private void versionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\t1.0");
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("********************************************************************************" +
            "\tName:\t\t\t\tJason Freeman\n"+

            "Course Name:\t\t\tITDEV 115-002\n"+
            "Instructor:\t\t\t\tMr. Robert Menzl\n"+
            "Assignment:\t\t\tFamer Game GUI \n"+
            "Date:\t\t\t\t" + DateTime.Today.ToShortDateString() + "\n" +
            
            "********************************************************************************");
        }
        public void Reset()
        {
            theFarmer.ResetGame();
            btnFarmerNorth.Visible = true;
            btnFarmerSouth.Visible = false;
            btnChickenNorth.Visible = true;
            btnChickenSouth.Visible = false;
            btnFoxNorth.Visible  = true;
            btnFoxSouth.Visible = false;
            btnGrainNorth.Visible = true;
            btnGrainSouth.Visible = false;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
        }

      

        private void btnFarmerSouth_Click(object sender, EventArgs e)
        {
            Play("");
        }

        private void btnGrainSouth_Click(object sender, EventArgs e)
        {
            Play("GRAIN");
        }

        private void btnGrainNorth_Click(object sender, EventArgs e)
        {
            Play("GRAIN");
             
        }

        private void btnChickenSouth_Click(object sender, EventArgs e)
        {
            Play("CHICKEN");


          
        }

        private void btnFoxSouth_Click(object sender, EventArgs e)
        {
            Play("FOX");

          
        }

        private void resetToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Reset();
        }

        public void Play(string item)
        {
            
            string status;
            string food;
            bool win;

            //if (item.Equals("FARMER"))
            //    item = "";


            DisplayGameState();
            status = theFarmer.Move(item);
            food = theFarmer.AnimalAteFood();
            win = theFarmer.DetermineWin();

            if (food.Equals("Not Eaten")&&win == true)
                MessageBox.Show("You win!!");

            if (food.Equals("Eaten") && win == false)
                MessageBox.Show("You lost!");
            
          
        }

        private void DisplayGameState()
        {
            DisplayNorthBank();
           
            DisplaySouthBank();
            MoveFarmer();
        }

        public void DisplayNorthBank()
        {
            string list;

            list = theFarmer.NorthBank;
           

            if (list.Contains("CHICKEN"))
            {
                btnChickenNorth.Visible = true;
            }
            else
            {
                btnChickenNorth.Visible = false;
            }

            if (list.Contains("FOX"))
            {
                btnFoxNorth.Visible = true;
            }
            else
            {
                btnFoxNorth.Visible = false;
            }

            if (list.Contains("GRAIN"))
            {
                btnGrainNorth.Visible = true;
            }
            else
            {
                btnGrainNorth.Visible = false;
            }

            if (list.Contains("farmer"))
            {
                btnFarmerNorth.Visible = true;
            }
            else
            {
                btnFarmerNorth.Visible = false;
            }

        }
        public void DisplaySouthBank()
        {
            string list;

            list = theFarmer.SouthBank;


            if (list.Contains("CHICKEN"))
            {
                btnChickenSouth.Visible = true;
            }
            else
            {
                btnChickenSouth.Visible = false;
            }

            if (list.Contains("FOX"))
            {
                btnFoxSouth.Visible = true;
            }
            else
            {
                btnFoxSouth.Visible = false;
            }

            if (list.Contains("GRAIN"))
            {
                btnGrainSouth.Visible = true;
            }
            else
            {
                btnGrainSouth.Visible = false;
            }
            if (list.Contains("farmer"))
            {
                btnFarmerSouth.Visible = false;
            }
            else
            {
                btnFarmerSouth.Visible = true;
            }
        }

        public void MoveFarmer()
        {
            bool place;
            place = theFarmer.TheFarmer;
            if (place)
            {
                btnFarmerNorth.Visible = true;
                btnFarmerSouth.Visible = false;
            }

            else
            {
                btnFarmerNorth.Visible = false;
                btnFarmerSouth.Visible = true;
            }
        }





    }
}
