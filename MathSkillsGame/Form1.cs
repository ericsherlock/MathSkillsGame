using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Eric Sherlock
//Yi
//CS3160
//Open Ended Project

namespace MathSkillsGame{
    public partial class MSGForm : Form{
        
        //Create Random Number Object
        Random randnum = new Random();

        //Declaring Necessary Variables
        //Syntax: ooanum = Operand One Addition number 
                //otanum = Operand Two Addition number
                //otmnum = Operand Two Multiplication number
        int ooanum, oosnum = 0, oomnum = 0, oodnum = 0, oomodnum = 0;
        int otanum, otsnum = 0, otmnum = 0, otdnum = 0, otmodnum = 0;
        int aresult = 0, sresult = 0, mresult = 0, dresult = 0, modresult = 0;
        int totalscore = 0;
        int rtime = 0;

        //MSGForm Initialize Method
        public MSGForm(){
            InitializeComponent();
            InstructionTextBox.Visible = true;
        }//End Form1

        //Method BeginGame Sets Up All Variables For Game Or Round
        public void BeginGame(){
            //Declaring Necessary Variables
            int m = 0, n = 0, x = 0, y = 0, a = 0, b = 0, c = 0, d = 0, e = 0, f = 0, t = 0, s = 0;

            //If Else Loops To Make The Game Harder Based On Current Score
            if (totalscore <= 300){
                LevelLabel.Text = "Easy";
                //Addition / Subtraction bounds
                m = -20;
                n = 50;
                //Multiplication Bounds
                x = -10;
                y = 10;
                //Division Bounds
                t = -20;
                s = 100;
                a = 1;
                b = 10;
                //Mod Bounds
                c = 1;
                d = 50;
                e = 1;
                f = 10;
                rtime = 60;
            }else if ((totalscore > 300) && (totalscore <= 600)){
                LevelLabel.Text = "Medium";
                //Addition / Subtraction Bounds
                m = -50;
                n = 500;
                //Multiplication Bounds
                x = -15;
                y = 15;
                //Division Bounds
                t = -20;
                s = 150;
                a = 1;
                b = 15;
                //Mod Bounds
                c = 10;
                d = 100;
                e = 10;
                f = 20;
                rtime = 45;
            }else if ((totalscore > 600) && (totalscore <= 1000)){
                LevelLabel.Text = "Hard";
                //Addition / Subtraction Bounds
                m = -100;
                n = 1000;
                //Multiplication Bounds
                x = -25;
                y = 25;
                //Division Bounds
                t = -100;
                s = 500;
                a = 1;
                b = 50;
                //Mod Bounds
                c = 50;
                d = 200;
                e = 10;
                f = 50;
                rtime = 30;
            }//End Levels If Else
            //Getting And Setting Random Number And Putting Them In Their Respective Labels
            ooanum = randnum.Next(m, n);
            otanum = randnum.Next(m, n);
            OOALabel.Text = ooanum.ToString();
            OTALabel.Text = otanum.ToString();
            aresult = ooanum + otanum;
            oosnum = randnum.Next(m, n);
            otsnum = randnum.Next(m, n);
            sresult = oosnum - otsnum;
            OOSLabel.Text = oosnum.ToString();
            OTSLabel.Text = otsnum.ToString();
            oomnum = randnum.Next(x, y);
            otmnum = randnum.Next(x, y);
            mresult = oomnum * otmnum;
            OOMLabel.Text = oomnum.ToString();
            OTMLabel.Text = otmnum.ToString();
            oodnum = randnum.Next(t, s);
            otdnum = randnum.Next(a, b);
            dresult = oodnum / otdnum;
            OODLabel.Text = oodnum.ToString();
            OTDLabel.Text = otdnum.ToString();
            oomodnum = randnum.Next(c, d);
            otmodnum = randnum.Next(e, f);
            modresult = oomodnum % otmodnum;
            OOModLabel.Text = oomodnum.ToString();
            OTModLabel.Text = otmodnum.ToString();
            RTimeLabel.Text = rtime.ToString() + " seconds";
            RoundTimer.Start();
        }//End Begin Game

        //ResetGame Method To Reset Game To Defaults
        private void ResetGame(){
            //Setting All Labels And Necessary Values Back To 
            //Initial Game Settings
            totalscore = 0;
            RTimeLabel.BackColor = Color.LightGray;
            WinningPictureBox.Visible = false;
            WinningPictureBox.Enabled = false;
            NextRoundButton.Enabled = false;
            NextRoundButton.Visible = false;
            BeginButton.Visible = true;
            BeginButton.Enabled = true;
            ExitButton.Visible = true;
            ExitButton.Enabled = true;
            DoneButton.Enabled = false;
            DoneButton.Visible = false;
            ReplayButton.Enabled = false;
            ReplayButton.Visible = false;
            AAF.Enabled = true;
            SAF.Enabled = true;
            MAF.Enabled = true;
            DAF.Enabled = true;
            ModAF.Enabled = true;
            AAF.Text = "";
            SAF.Text = "";
            MAF.Text = "";
            DAF.Text = "";
            ModAF.Text = "";
            AOLabel.Visible = false;
            AAnswerLabel.Visible = false;
            ATLabel.Visible = false;
            CSAnswerLabel.Visible = false;
            ATHLabel.Visible = false;
            CMAnswerLabel.Visible = false;
            AFLabel.Visible = false;
            CDAnswerLabel.Visible = false;
            AFiLabel.Visible = false;
            CModAnswerLabel.Visible = false;
            RSLabel.Visible = false;
            TopRoundScoreLabel.Visible = false;
            BottomRoundScoreLabel.Visible = false;
            LineScoreLabel.Visible = false;
            MyScoreLabel.Text = "0";
            RTimeLabel.Text = "-";
            LevelLabel.Text = "-";
            OOALabel.Text = "?";
            OTALabel.Text = "?";
            OOSLabel.Text = "?";
            OTSLabel.Text = "?";
            OOMLabel.Text = "?";
            OTMLabel.Text = "?";
            OODLabel.Text = "?";
            OTDLabel.Text = "?";
            OOModLabel.Text = "?";
            OTModLabel.Text = "?";
        }//End ResetGame Method

        //Method To Calculate That Particular Round Score
        private int CalcRoundScore(int right, int wrong){
            int rightscore = right * 10;
            int wrongscore = wrong * 5;
            int rscore = rightscore - wrongscore;
            return rscore;
        }//End CalcRoundScore Method

        //Method Update The Current Running Score
        public void UpdateScore(int roundscore){ 
            totalscore = totalscore + roundscore;
            MyScoreLabel.Text = totalscore.ToString();
        }//End UpdateScore Method

        //Replay Button Click Method
        private void ReplayButton_Click(object sender, EventArgs e){
            //Resetting Game And Starting Next Game From Scratch
            ResetGame();
            ReadyButton.PerformClick();
        }//End Replay Button Click

        //Button To Exit The Program
        private void ExitButton_Click(object sender, EventArgs e){
            Environment.Exit(0);
        }//End Method Exit

        //Next Round Button Click Method
        private void NextRoundButton_Click(object sender, EventArgs e){
            //Events Triggered When the 'NextRoundButton' Is Clicked
            //Reseting Answer Boxes and Labels
            NextRoundButton.Enabled = false;
            AAF.Enabled = true;
            SAF.Enabled = true;
            MAF.Enabled = true;
            DAF.Enabled = true;
            ModAF.Enabled = true;
            AAF.Value = -9999;
            AAF.Text = "";
            SAF.Value = -9999;
            SAF.Text = "";
            MAF.Value = -9999;
            MAF.Text = "";
            DAF.Value = -9999;
            DAF.Text = "";
            ModAF.Value = -9999;
            ModAF.Text = "";
            AOLabel.Visible = false;
            AAnswerLabel.Visible = false;
            ATLabel.Visible = false;
            CSAnswerLabel.Visible = false;
            ATHLabel.Visible = false;
            CMAnswerLabel.Visible = false;
            AFLabel.Visible = false;
            CDAnswerLabel.Visible = false;
            AFiLabel.Visible = false;
            CModAnswerLabel.Visible = false;
            ExitButton.Visible = false;
            ExitButton.Enabled = false;
            DoneButton.Enabled = true;
            DoneButton.Visible = true;
            RSLabel.Visible = false;
            TopRoundScoreLabel.Visible = false;
            BottomRoundScoreLabel.Visible = false;
            LineScoreLabel.Visible = false;
            RTimeLabel.BackColor = Color.LightGray;
            BeginGame();
        }//End NextRoundButton

        //BeginButton Click Method
        private void BeginButton_Click(object sender, EventArgs e){
            //Events Triggered By Pressing The 'Begin' Button
            ExitButton.Visible = false;
            ExitButton.Enabled = false;
            DoneButton.Visible = true;
            DoneButton.Enabled = true;
            BeginButton.Enabled = false;
            BeginButton.Visible = false;
            NextRoundButton.Enabled = true;
            NextRoundButton.Visible = true;
            MyScoreLabel.Text = "0";
            BeginGame();
        }//End Begin Button

        //ReadyButton Click Method
        private void ReadyButton_Click(object sender, EventArgs e){
            //Events Triggered By Pressing The 'Ready' Button
            //Make All Necessary Labels Visible Or Invisible
            //Setting Up Game Defaults
            InstructionTextBox.Visible = false;
            ReadyButton.Visible = false;
            DoneButton.Visible = true;
            BeginButton.Visible = true;
            ModAF.Visible = true;
            ModAF.Value = -9999;
            ModAF.Text = "";
            DAF.Visible = true;
            DAF.Value = -9999;
            DAF.Text = "";       
            MAF.Visible = true;
            MAF.Value = -9999;
            MAF.Text = "";
            SAF.Visible = true;
            SAF.Value = -9999;
            SAF.Text = "";
            AAF.Visible = true;
            AAF.Value = -9999;
            AAF.Text = "";
            OOModLabel.Visible = true;
            OTModLabel.Visible = true;
            ModLabel.Visible = true;
            ModELabel.Visible = true;
            OODLabel.Visible = true;
            OTDLabel.Visible = true;
            DivideLabel.Visible = true;
            DELabel.Visible = true;
            OOMLabel.Visible = true;
            OTMLabel.Visible = true;
            MultiplyLabel.Visible = true;
            MELabel.Visible = true;
            OOSLabel.Visible = true;
            OTSLabel.Visible = true;
            SubtractLabel.Visible = true;
            SELabel.Visible = true;
            OOALabel.Visible = true;
            OTALabel.Visible = true;
            PlusLabel.Visible = true;
            AELabel.Visible = true;
            RTimeLabel.Visible = true;
            TRLabel.Visible = true;
            ScoreLabel.Visible = true;
            LLabel.Visible = true;
            LevelLabel.Visible = true;
            DoneButton.Enabled = false;
            DoneButton.Visible = false;
            ExitButton.Enabled = true;
            ExitButton.Visible = true;
            MyScoreLabel.Text = "0";
            RTimeLabel.Text = "-";
            LevelLabel.Text = "-";
        }//End Ready Button Click

        //Events Triggered By Pressing The 'Done' Button
        private void DoneButton_Click(object sender, EventArgs e){
            //Declaring Necessary Variables
            int numright = 0, numwrong = 0, roundscore = 0;
            //Stop Timer and Calculate Number Of Correct Answers
            RoundTimer.Stop();
            if (ooanum + otanum == AAF.Value){
                numright++;
            }//End Add Check If
            if (oosnum - otsnum == SAF.Value){
                numright++;
            }//End Subtract Check If
            if (oomnum * otmnum == MAF.Value){
                numright++;
            }//End Multiply Check If
            if (oodnum / otdnum == DAF.Value){
                numright++;
            }//End Divide Check If
            if (oomodnum % otmodnum == ModAF.Value){
                numright++;
            }//End Mod Check If
            //Events To Perform When 'Done' Button Clicked
            numwrong = 5 - numright;
            NextRoundButton.Enabled = true;
            roundscore = CalcRoundScore(numright, numwrong);
            UpdateScore(roundscore);
            AOLabel.Visible = true;
            AAnswerLabel.Visible = true;
            AAnswerLabel.Text = aresult.ToString();
            ATLabel.Visible = true;
            CSAnswerLabel.Visible = true;
            CSAnswerLabel.Text = sresult.ToString();
            ATHLabel.Visible = true;
            CMAnswerLabel.Visible = true;
            CMAnswerLabel.Text = mresult.ToString();
            AFLabel.Visible = true;
            CDAnswerLabel.Visible = true;
            CDAnswerLabel.Text = dresult.ToString();
            AFiLabel.Visible = true;
            CModAnswerLabel.Visible = true;
            CModAnswerLabel.Text = modresult.ToString();
            DoneButton.Visible = false;
            DoneButton.Enabled = false;
            NextRoundButton.Enabled = true;
            ExitButton.Visible = true;
            ExitButton.Enabled = true;
            RSLabel.Visible = true;
            TopRoundScoreLabel.Visible = true;
            TopRoundScoreLabel.Text = numright.ToString();
            BottomRoundScoreLabel.Visible = true;
            LineScoreLabel.Visible = true;
            AAF.Enabled = false;
            SAF.Enabled = false;
            MAF.Enabled = false;
            DAF.Enabled = false;
            ModAF.Enabled = false;

            //Message Box To Show The Number Of Points Rewarded After Each Round
            MessageBox.Show(" You Get "+ roundscore + " Points! Click 'Next Round' When Ready.", "Results");

            //If User Scores Over 1000 Points Print Message and Picture
            if (totalscore >= 1000){
                WinningPictureBox.Visible = true;
                MessageBox.Show("You Beat The Game! You Have Great Math Skills!", "Congratulations!"); 
                NextRoundButton.Enabled = false;
                DoneButton.Enabled = false;
                AAF.Enabled = false;
                SAF.Enabled = false;
                MAF.Enabled = false;
                DAF.Enabled = false;
                ModAF.Enabled = false;
                ReplayButton.Enabled = true;
                ReplayButton.Visible = true;
                ExitButton.Enabled = true;
                ExitButton.Visible = true;
            }//End If
        }//end Done Button Click

        private void DAF_ValueChanged(object sender, EventArgs e){
        }//End DAFValue

        private void PlusLabel_Click(object sender, EventArgs e){
        }//End PlusLabel

        //Method For Timer
        private void RoundTimer_Tick(object sender, EventArgs e){
            //If Time Remaining Is Not 0 Keep Ticking Down
            //Else Print 'Out Of Time Error'
            if (rtime != 0){
                rtime = rtime - 1;
                RTimeLabel.Text = rtime + " Seconds";
            }else{
                RoundTimer.Stop();
                RTimeLabel.Text = "Out Of Time!";
                MessageBox.Show("You Did Not Finish In The Time Allowed!", "Too Bad!");
                DoneButton.PerformClick();
            }//End If Else
            //Make Time Label Red If 10 Seconds Or Less Are Left
            if(rtime <= 10){
                RTimeLabel.BackColor = Color.Red;
            }//End If
        }//End Round Timer

        private void label1_Click(object sender, EventArgs e){
        }//End Label1 Click
        private void OTPLabel_Click(object sender, EventArgs e){
        }//End OTP Click
        private void textBox1_TextChanged(object sender, EventArgs e){
        }//End Textbox1 Click

    }//end partial class form
}//end namespace
