﻿using MaintenanceTracker.Properties;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace MaintenanceTracker
{

    public partial class AirFilterOptionsForm : System.Windows.Forms.Form
    {

        //Variables
        private int mls = 15000;
        private int mx = 30000;
        private int eMX = 30000;
        private int cMX = 30000;
        private int eCount = 0;
        private int cCount = 0;
        private int oneFourth = 0;
        private int oneHalf = 0;
        private int threeFourth = 0;
        private Color primaryColor = Color.FromArgb(0, 188, 212);
        private Color secondaryColor = Color.FromArgb(149, 117, 205);
        
        public AirFilterOptionsForm()
        {
            InitializeComponent();

            //Center form on the screen.
            this.StartPosition = FormStartPosition.CenterScreen;

            //Calculations
            oneFourth = mx / 4;
            oneHalf = mx / 2;
            threeFourth = oneFourth + oneHalf;

            //OnLoad Display
            this.BackColor = primaryColor;

            //OnLoad Methods
            EngFilterStatusColor(mls);
            CabFilterStatusColor(mls);

            //Engine & Cabin Air Filter Text
            engAirFilterLB.Font = new Font(engAirFilterLB.Font.FontFamily, 10);
            engAirFilterLB.Text = "Replace the engine air filter every \n" +
                "15,000-30,000 miles, or once a \n" +
                "year. You are currently at: \n" +
                "" + string.Format("{0:n0}", mls) + "/" + string.Format("{0:n0}", mx) + " miles.";

            cabAirFilterLB.Font = new Font(cabAirFilterLB.Font.FontFamily, 10);
            cabAirFilterLB.Text = "Replace the cabin air filter every \n" +
                "15,000-25,000 miles, or once a \n" +
                "year. You are currently at: \n" +
                "" + string.Format("{0:n0}", mls) + "/" + string.Format("{0:n0}", mx) + " miles.";

            //Track bar
            engAirFilterTB.Visible = false;
            cabAirFilterTB.Visible = false;

            //Track barLabel
            engAirFilterTbLb.Visible = false;
            engAirFilterTbLb.Text = mx.ToString();
            cabAirFilterTbLb.Visible = false;
            cabAirFilterTbLb.Text = mx.ToString();

            
        }

        //Engine's Filter Condition
        private void EngFilterStatusColor(int M)
        {
            //Define the Engine Air Filter Background color
            //depending on the MPG or amount of months it
            //has been used.
            if (M <= oneFourth)
            {
                engAirFilter.BackColor = Color.Green;
            }
            else if (M > oneFourth && M <= oneHalf)
            {
                engAirFilter.BackColor = Color.GreenYellow;
            }
            else if (M > oneHalf && M <= threeFourth)
            {
                engAirFilter.BackColor = Color.Yellow;
            }
            else
            {
                engAirFilter.BackColor = Color.Red;
            }
        }
        
        //Engine's Filter Condition
        private void CabFilterStatusColor(int M)
        {
            //Define the Cabin Air Filter Background color
            //depending on the MPG or amount of months it
            //has been used.
            if (M <= oneFourth)
            {
                cabAirFilter.BackColor = Color.Green;

            }
            else if (M > oneFourth && M <= oneHalf)
            {
                cabAirFilter.BackColor = Color.GreenYellow;
            }
            else if (M > oneHalf && M <= threeFourth)
            {
                cabAirFilter.BackColor = Color.Yellow;
            }
            else
            {
                cabAirFilter.BackColor = Color.Red;
            }
        }

        private void EngAirFilter_Click(object sender, EventArgs e)
        {
            if (eCount == 0)
            {
                engAirFilter.Text = "";
                engAirFilter.BackColor = Color.White;
                engAirFilter.Image = Resources.X120;
                engAirFilterTB.Visible = true;
                engAirFilterTbLb.Visible = true;
                eCount++;
            }
            else if (eCount == 1)
            {
                engAirFilter.Text = "Engine Air Filter";
                EngFilterStatusColor(mls);
                engAirFilter.Image = null;

                // Set up the TrackBar.
                engAirFilterTB.Visible = false;
                engAirFilterTbLb.Visible = false;
                engAirFilterTB.Scroll += new System.EventHandler(EngAirFilterSB_Scroll);
                engAirFilterTB.Maximum = mx;
                engAirFilterTB.TickFrequency = 5000;
                engAirFilterTB.LargeChange = 10000;
                engAirFilterTB.SmallChange = 5000;
                eCount--;
            }
        }

        private void CabAirFilter_Click(object sender, EventArgs e)
        {
            if (cCount == 0)
            {
                cabAirFilter.Text = "";
                cabAirFilter.BackColor = Color.White;
                cabAirFilter.Image = Resources.X120;
                cabAirFilterTB.Visible = true;
                cabAirFilterTbLb.Visible = true;
                cCount++;
            }
            else if (cCount == 1)
            {
                cabAirFilter.Text = "Cabin Air Filter";
                CabFilterStatusColor(mls);
                cabAirFilter.Image = null;

                // Set up the TrackBar.
                cabAirFilterTB.Visible = false;
                cabAirFilterTbLb.Visible = false;
                cabAirFilterTB.Scroll += new System.EventHandler(CabAirFilterSB_Scroll);
                cabAirFilterTB.Maximum = mx;
                cabAirFilterTB.TickFrequency = 5000;
                cabAirFilterTB.LargeChange = 10000;
                cabAirFilterTB.SmallChange = 5000;
                cCount--;
            }
        }



        private void EngAirFilterSB_Scroll(object sender, System.EventArgs e)
        {
            //Display the trackbar value in the text box.
            engAirFilterTbLb.Text = "" + engAirFilterTB.Value;
        }

        private void CabAirFilterSB_Scroll(object sender, System.EventArgs e)
        {
            //Display the trackbar value in the text box.
            cabAirFilterTbLb.Text = "" + cabAirFilterTB.Value;
        }

        private void ExitBTTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetBTTN_Click(object sender, EventArgs e)
        {
           
        }
    }
}