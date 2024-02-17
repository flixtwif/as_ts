using Microsoft.VisualBasic;
using System;
using System.Security.AccessControl;
using System.Transactions;
using System.Windows.Forms;
namespace tst
{
    public partial class Form1 : Form
    {
        public string[] wordlist = { "civilian", "mathematics", "medium", "formulate", "preparation", "society", "illusion", "corruption", "memory", "momentum", "ancestor", "opposite", "appreciate", "ecstasy", "photography", "remember", "financial", "repetition", "cooperation", "agreement", "embarrassment", "solution", "agenda", "legislation", "nonremittal", "transaction", "objective", "undermine", "handicap", "anxiety" };
        System.Diagnostics.Stopwatch sw = new();
        public Form1()
        {
            InitializeComponent();
        }
        private string GetRandomString()
        {
            Random r = new Random();
            string word = "";
            for (int x = 0; x < wordamount.Value; x++)
            {
                word += wordlist[r.Next(0, wordlist.Length)];
                word += " ";
                if (r.Next(0, 10) < 4)
                {
                    string symbols = "$?!.,-:;'";
                    word += symbols[r.Next(0, symbols.Length)];
                    word += " ";
                }
            }
            return word.TrimEnd(' ');
        }
        private void examplebutton_Click(object sender, EventArgs e)
        {
            startTime();
        }

        private void startTime()
        {
            sw.Stop();
            sw.Reset();
            textBox1.Clear();
            trueOrfalse.Text = "";
            textBox1.Focus();
            Targetword.Text = GetRandomString();
            sw.Start();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            checktextbox(e);
        }
        private void checktextbox(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == Targetword.Text)
                {
                    sw.Stop();
                    trueOrfalse.Text = $"Correct! {sw.Elapsed.TotalSeconds}s";
                    trueOrfalse.ForeColor = System.Drawing.Color.Green;
                }
                else if (textBox1.Text != Targetword.Text)
                {
                    trueOrfalse.Text = "Wrong!";
                    trueOrfalse.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}