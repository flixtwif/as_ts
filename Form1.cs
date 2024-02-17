using System; using System.Windows.Forms;
namespace tst
{
    public partial class Form1 : Form
    {
        /*wordlist is a massive list of random words to make a random string with (used in GetRandomSTring function) */ public string[] wordlist = { "civilian", "mathematics", "medium", "formulate", "preparation", "society", "illusion", "corruption", "memory", "momentum", "ancestor", "opposite", "appreciate", "ecstasy", "photography", "remember", "financial", "repetition", "cooperation", "agreement", "embarrassment", "solution", "agenda", "legislation", "nonremittal", "transaction", "objective", "undermine", "handicap", "anxiety" };
        System.Diagnostics.Stopwatch sw = new(); // create a stopwatch for later
        public Form1()
        {
            InitializeComponent();
        }
        private string GetRandomString()
        {
            Random r = new Random();
            string word = ""; // make an empty string for the word so you can add to it later
            int newlineneeded = 0; // this variable will check if a new line is needed
            for (int x = 0; x < wordamount.Value; x++) // iterate through the loop for each number in the numericUpDown
            {
                word += wordlist[r.Next(0, wordlist.Length)]; // get a random word from the big wordlist array and add my variable for the final word
                word += " "; // add a space every time so that the words have spaces in between them and you can read
                if (r.Next(0, 10) < 4) // creates a random 30% chance to add random punctuation to make it so you have to type some symbols as well
                {
                    string symbols = "$?!.,-:;'"; // list of symbols - had problems when having & as a symbol as it didnt show up on the form
                    word += symbols[r.Next(0, symbols.Length)]; // get a random symbol from the list
                    word += " "; // add a space after the symbol
                }
                newlineneeded++; // increment by one
                if (newlineneeded > 4) // basically after 5 words the newlineneeded variable should be 5 so if triggers this code*
                {
                    word += "\n"; // *which adds a new line
                    newlineneeded = 0; // then resets it so there isnt a new line for every cycle of the for loops from now on
                }
            }
            return word.TrimEnd(' '); // thim the spaces from the end because otherwise there wil be an invisible spoace at the end that people won't know to type
        }
        private void examplebutton_Click(object sender, EventArgs e)
        {
            startTime(); // call the function when the 'generate words' button is clicked
        }

        private void startTime()
        {
            sw.Stop(); // Stops any ongoing timers
            sw.Reset(); // resets the time if there was an old ongoing stopwatch              
            textBox1.Clear(); // clear the textbox
            trueOrfalse.Text = ""; // resets the text saying how accurate the user was since this is a new instance of the game
            textBox1.Focus(); // focus on the text box so users dont have to manually click it
            Targetword.Text = GetRandomString(); // get the random word that they have to type
            sw.Start(); // start the stopwatch
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            checktextbox(e); // call when a button is pressed
        }
        private void checktextbox(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter) // continues only if ENTER was pressed
            {
                string textbox_nonewlines = textBox1.Text.Replace("\n", "").Replace("\r", "").TrimEnd(' '); // the content of the text box but without the new lines, as it makes checking weird
                string Targetword_nonewlines = Targetword.Text.Replace("\n", "").Replace("\r", "").TrimEnd(' '); // same thing as ^ but with the target word
                int accuracylevel = getAccuracylevel(Targetword_nonewlines, textbox_nonewlines); // gets the accuracy level
                if (textbox_nonewlines == Targetword_nonewlines) // if the user's input was EXACTLY the target words
                {
                    sw.Stop(); // stop the timer. Then chnage the text to say a message, the time taken and accuracy level. same with all accuracy levels
                    trueOrfalse.Text = $"Correct! {Math.Round(sw.Elapsed.TotalSeconds, 2)}s ({Math.Round(Targetword.ToString().Length / sw.Elapsed.TotalSeconds, 2)} Letters per second at {accuracylevel}% accuracy!)";
                    trueOrfalse.ForeColor = System.Drawing.Color.DarkGreen; // change colour to green to imply good
                }
                else if (textBox1.Text != Targetword.Text && accuracylevel > 84) // if accuracy level is 85 or more, but not exactly correct
                {
                    sw.Stop();
                    trueOrfalse.Text = $"Well done! {Math.Round(sw.Elapsed.TotalSeconds, 2)}s ({Math.Round(Targetword.ToString().Length / sw.Elapsed.TotalSeconds, 2)} Letters per second at {accuracylevel}% accuracy.)";
                    trueOrfalse.ForeColor = System.Drawing.Color.Green;
                }
                else if (textBox1.Text != Targetword.Text && accuracylevel < 85) // if accuracy level is less than 85
                {
                    sw.Stop();
                    trueOrfalse.Text = $"Not quite right. {Math.Round(sw.Elapsed.TotalSeconds, 2)}s ({Math.Round(Targetword.ToString().Length / sw.Elapsed.TotalSeconds, 2)} Letters per second at {accuracylevel}% accuracy.)";
                    trueOrfalse.ForeColor = System.Drawing.Color.Red; // change colour to red to show bad
                }
            }
        }

        private int getAccuracylevel(string generatedWord, string typedWord)
        {
            if (typedWord.Length < 1) // check this at the beginning so you don't get a divide by 0 exception
            {
                return 0; // makes sense because if they typed less than 1 they would have 0 score anyway. No need to check for generatedword length as you can't generate less than 1 word.
            }
            int points = 0; // use this to track the accuracy
            for (int x = 0; x < Math.Min(typedWord.Length, generatedWord.Length); x++) // iterates through each character of either the user's word or the generate word, whichever is shorter
            {
                if (typedWord[x] == generatedWord[x])
                {
                    points++; // if the same character is in the same place, +1 points
                }
            }
            double accuracy = (double)points / generatedWord.Length * 100; // you have to make it a double because otherwise it will always be 0 before you can times by 100, meaning accuracy level will always be 0
            return Convert.ToInt32(Math.Round(accuracy, 2)); // but convert to an integer at the end
        }
    }
}