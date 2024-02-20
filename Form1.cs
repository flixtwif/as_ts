using System;
using System.Windows.Forms;

namespace typingspeedtest
{
    public partial class Form1 : Form
    {
        System.Diagnostics.Stopwatch sw = new(); // create a stopwatch for later
        bool firstopen = true; // certain things will be different on the first open
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
                word += TargetExtracts.RandomWords[r.Next(0, TargetExtracts.RandomWords.Length)]; // get a random word from the big wordlist array and add my variable for the final word
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

        private string getTargetExtract()
        {
            Random r = new();
            string extract = TargetExtracts.Extracts[r.Next(0, TargetExtracts.Extracts.Length)]; // get a random extract from the Targetextracts class and put it into a string
            char[] ex2 = extract.ToCharArray(); // now turn the string into char array 
            for (int x = 60; x < ex2.Length; x += 60) // iterate through the sentence, starts at 60 and goes up 60 each time because a new line is needed at around then usually
            {
                if (x > ex2.Length) // escape if the index of the for loop is bigger than the length of the sentence so you dont get "index outside the bounds of array"
                {
                    break;
                }
                while (!(ex2[x] == ' ') && x < ex2.Length - 1) // go through until you find the nearest SPACE
                {
                    if (x < ex2.Length)
                    {
                        x++;
                    }
                }
                ex2[x] = '\n'; // replace the space with a new line
            }
            string s = new string(ex2); // turn the char array back into a string to return
            return s;
        }
        private void examplebutton_Click(object sender, EventArgs e) // when you click the button
        {
            if (firstopen == true)
            {
                firstopen = false;
                Targetword.ForeColor = System.Drawing.Color.Black;
            }
            startTime(); // call the function when the 'generate words' button is clicked
        }

        private void startTime()
        {
            sw.Stop(); // Stops any ongoing timers
            sw.Reset(); // resets the time if there was an old ongoing stopwatch              
            textBox1.Clear(); // clear the textbox
            trueOrfalse.Text = ""; // resets the text saying how accurate the user was since this is a new instance of the game
            textBox1.Focus(); // focus on the text box so users dont have to manually click it
            if (!randomwordmode.Checked)
            {
                Targetword.Text = getTargetExtract(); // get random sentence from TargetExtracts class
            }
            else if (randomwordmode.Checked)
            {
                Targetword.Text = GetRandomString(); // get the random word that they have to type
            }
            sw.Start(); // start the stopwatch
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            checktextbox(e); // call when a button is pressed
        }
        private void checktextbox(KeyEventArgs e) // big function
        {
            if (firstopen == true)
            {
                return; // basically not do any of the function if its the first open as otherwise you would be checking against the temporary label text was used before a sentence was generated
            }
            if (e.KeyCode == Keys.Enter) // continues only if ENTER was pressed
            {
                string textbox_nonewlines = textBox1.Text.Replace("\n", " ").Replace("\r", " ").TrimEnd(' '); // the content of the text box but without the new lines, as it makes checking weird
                string Targetword_nonewlines = Targetword.Text.Replace("\n", " ").Replace("\r", " ").TrimEnd(' '); // same thing as ^ but with the target word
                int accuracylevel = getaccuracylevel2(Targetword_nonewlines, textbox_nonewlines); // gets the accuracy level
                double secondstaken = Math.Round(sw.Elapsed.TotalSeconds, 2); // the amount of seconds until they pressed enter
                showfeedback(textbox_nonewlines, Targetword_nonewlines, accuracylevel, secondstaken);
            }
        }

        private void showfeedback(string textbox_nonewlines, string Targetword_nonewlines, int accuracylevel, double secondstaken)
        {
            if (textbox_nonewlines == Targetword_nonewlines) // if the user's input was EXACTLY the target words
            {
                sw.Stop(); // stop the timer. Then chnage the text to say a message, the time taken and accuracy level. same with all accuracy levels
                trueOrfalse.Text = $"Correct! {secondstaken}s ({calculateWPM()} words per minute at {accuracylevel}% accuracy!)";
                trueOrfalse.ForeColor = System.Drawing.Color.DarkGreen; // change colour to green to imply good
            }
            else if (textBox1.Text != Targetword.Text && accuracylevel > 84) // if accuracy level is 85 or more, but not exactly correct
            {
                sw.Stop();
                trueOrfalse.Text = $"Well done! {secondstaken}s ({calculateWPM()} words per minute at {accuracylevel}% accuracy.)";
                trueOrfalse.ForeColor = System.Drawing.Color.Green;
            }
            else if (textBox1.Text != Targetword.Text && accuracylevel < 85) // if accuracy level is less than 85
            {
                sw.Stop();
                trueOrfalse.Text = $"Not quite right. {secondstaken}s ({calculateWPM()} words per minute at {accuracylevel}% accuracy.)";
                trueOrfalse.ForeColor = System.Drawing.Color.Red; // change colour to red to show bad
            }
        }

        private int wordsinstring(string s)
        {
            int numberOfSpaces = 0;
            for (int x = 0; x < s.Length; x++) // checks for the number of SPACE characters in the string
            {
                if (s[x] == ' ')
                {
                    numberOfSpaces++;
                }
            }
            return numberOfSpaces + 1; // return +1 because there will be a word after the last space
        }

        private double calculateWPM()
        {
            return Math.Round(wordsinstring(Targetword.ToString()) / sw.Elapsed.TotalMinutes, 2); // The amount of words divided by the total amount of minutes
        }
        private int getaccuracylevel2(string source, string usr) // Levenshtein distance, I don't understand it myself, sorry
        {
            int[,] matrix = new int[source.Length + 1, usr.Length + 1];
            if (usr.Length == 0)
            {
                return usr.Length;
            }
            for (int x = 0; x < source.Length + 1; x++)
            {
                matrix[x, 0] = x;
            }
            for (int y = 0; y < usr.Length + 1; y++)
            {
                matrix[0, y] = y;
            }
            for (int a = 1; a <= source.Length; a++)
            {
                for (int b = 1; b <= usr.Length; b++)
                {
                    int cost = (usr[b - 1] == source[a - 1]) ? 0 : 1;
                    matrix[a, b] = Math.Min(Math.Min(matrix[a - 1, b] + 1, matrix[a, b - 1] + 1), matrix[a - 1, b - 1] + cost);
                }
            }
            int characterswrong = matrix[source.Length, usr.Length];
            int accuracypcnt = Convert.ToInt32((double)(usr.Length - characterswrong) / usr.Length * 100); // you have to convert to a double and then back to an int because otherwise it will always return 0, this value is the percentage of characters typed accurately
            if (accuracypcnt < 0)
            {
                accuracypcnt = 0; // if you don't have this logic then you can get a negative accuracy percentage if you're really bad
            }
            return accuracypcnt;
        }

        private void randomwordmode_CheckedChanged(object sender, EventArgs e)
        {
            if (randomwordmode.Checked)
            {
                wordamount.Show(); // show the numericupdown if the box is checked, hide it if not
            }
            else if (!randomwordmode.Checked)
            {
                wordamount.Hide();
            }
        }
    }

    static class TargetExtracts
    {

        /* Randomwords is a massive list of random words to make a random string with (used in GetRandomSTring function) */
        public static string[] RandomWords = { "civilian", "mathematics", "medium", "formulate", "preparation", "society", "illusion", "corruption", "memory", "momentum", "ancestor", "opposite", "appreciate", "ecstasy", "photography", "remember", "financial", "repetition", "cooperation", "agreement", "embarrassment", "solution", "agenda", "legislation", "nonremittal", "transaction", "objective", "undermine", "handicap", "anxiety" };
        public static string[] Extracts = { // nabbed from https://thepracticetest.com/typing/tests/inspirational-quotes/ used in the getRandomExtract function
          "The quick brown fox jumped over the lazy dog."
        , "Heaven will be inherited by every man who has heaven in his soul."
        , "Men are valued, not for what they are, but for what they seem to be."
        , "Wise men don't need advice. Fools won't take it."
        , "Think positively about yourself, keep your thoughts and your actions clean, ask God who made you to keep on remaking you."
        , "Creative thinking may simply mean the realization that there is no particular virtue in doing things the way they have always been done."
        , "There is nothing so difficult for a truly creative painter than to paint a rose, because before he can do so he has first to forget all the roses that were ever painted."
        , "Good habits are not made on birthdays, nor Christian character at the new year. The workshop of character is everyday life. The uneventful and commonplace hour is where the battle is lost or won."
        , "It's a matter of having principles. It's easy to have principles when you're rich. The important thing is to have principles when you're poor."
        , "All that is essential for the triumph of evil is that good men do nothing."
        , "After you've done a thing the same way for two years, look it over carefully. After five years, look at it with suspicion. And after ten years, throw it out and start all over."
        , "The measure of a man's real character is what he would do if he knew he would never be found out."
        , "Courage is the first of human qualities because it is the quality which guarantees all the others."
        , "I do not pray for success. I ask for faithfulness."
        , "Father taught us that opportunity and responsibility go hand in hand. I think we all act on that principle; on the basic human impulse that makes a man want to make the best of what's in him and what's been given him."
        , "A man has made at least a start on discovering the meaning of human life when he plants shade trees under which he knows full well he will never sit."
        , "The size of a man can be measured by the size of the thing that makes him angry."
        , "The wicked flee when no man pursueth; but the righteous are bold as a lion."
        , "Luck is what happens when preparation meets opportunity."
        , "Morale is when your hands and feet keep on working when your head says it can't be done."
        , "It is better to lead from behind and to put others in front, especially when you celebrate victory when nice things occur. You take the front line when there is danger. Then people will appreciate your leadership."
        , "A new idea is delicate. It can be killed by a sneer or a yawn; it can be stabbed to death by a quip and worried to death by a frown on the right man's brow."
        , "No choice recurs. We may get similar choices again, but never that exact one. Hesitation--inaction--is just as irrevocable as action. What the motorist, locked on the one-way road, is to space, we are to the fourth dimension: we truly pass this way but once."
        , "Sitting is an eloquent business; any actor will tell you that. We sit according to our natures. We sprawl and straddle, we rest like boxers between rounds, we fidget, perch, cross and uncross our legs, lose patience, lose endurance."
        , "To argue with those who have renounced the use and authority of reason is as futile as to administer medicine to the dead."
        , "Leadership is solving problems. The day soldiers stop bringing you their problems is the day you have stopped leading them. They have either lost confidence that you can help or concluded you do not care. Either case is a failure of leadership."
        , "The farther a man knows himself to be from perfection, the nearer he is to it."
        , "You will never stub your toe standing still, but the faster you go, the more chance you have of getting somewhere."
        , "The herd may graze where it pleases or stampede where it pleases, but he who lives the adventurous life will remain unafraid when he finds himself alone."
        , "A good scare is worth more to a man than good advice."
        , "It is better to lead from behind and to put others in front, especially when you celebrate victory when nice things occur. You take the front line when there is danger. Then people will appreciate your leadership."
        , "How many cares one loses when one decides not to be something, but to be someone."
        , "Conviction is worthless unless it is converted into conduct."
        , "This above all: to thine own self be true, And it must follow, as the night the day, Thou canst not then be false to any man."
        , "One of the most important things about leadership is that you have to have the kind of humility that will allow you to be coached."
        , "So long as a man is angry he can't be in the right."
        , "The anger of a good man lasts an instant; that of a meddler two hours; that of a base man a day and a night; and that of a great sinner until death."
        , "A leader is best when people barely know he exists, when his work is done, his aim fulfilled, they will say: we did it ourselves."
        , "Father taught us that opportunity and responsibility go hand in hand. I think we all act on that principle; on the basic human impulse that makes a man want to make the best of what's in him and what's been given him."
        , "Our humanity were a poor thing were it not for the divinity that stirs within us."
        , "Let then the first act every morning be to make the following resolve for the day: I shall not fear anyone on earth. I shall fear only God. I shall not bear ill will toward anyone. I shall not submit to injustice from anyone. I shall conquer untruth by truth. And in resisting untruth I shall put up with all suffering."};
    }
}