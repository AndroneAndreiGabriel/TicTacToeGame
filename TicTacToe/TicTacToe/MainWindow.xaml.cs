using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        /// <summary>
        /// Holds the current result of cells in the active game
        /// </summary>
        private MarkType[] mResults;

        /// <summary>
        /// True if it is player 1's turn (X) or players 2's turn(0)
        /// </summary>
        private bool mPlayer1Turn;

        /// <summary>
        /// True if the game has ended
        /// </summary>
        private bool mGameEnded;

        private int Player1Score = 0, TieScore = 0, Player2Score = 0;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            NewGame();

            Player1ScoreValue.Content = Player1Score;
            TieScoreValue.Content = TieScore;
            Player2ScoreValue.Content = Player2Score;
        }

        #endregion

        /// <summary>
        /// Starts a new game and creals all values back to the start
        /// </summary>
        private void NewGame()
        {
            // Create a new blank array of free cells
            mResults = new MarkType[9];

            for (int i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;
            }

            // Make sure Player 1 starts the game
            mPlayer1Turn = true;

            // Cast UI element to enum list
            // Iterate every button on the grid
            /*
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                // Change background, foreground and content to default values
                button.Content = string.Empty;
                button.Background = Brushes.Turquoise;
                button.Foreground = Brushes.Black;
            });
            */
            // Make sure the game hasn't ended

            Button0.Content = string.Empty;
            Button0.Background = Brushes.Turquoise;
            Button0.Foreground = Brushes.Black;

            Button1.Content = string.Empty;
            Button1.Background = Brushes.Turquoise;
            Button1.Foreground = Brushes.Black;

            Button2.Content = string.Empty;
            Button2.Background = Brushes.Turquoise;
            Button2.Foreground = Brushes.Black;

            Button3.Content = string.Empty;
            Button3.Background = Brushes.Turquoise;
            Button3.Foreground = Brushes.Black;

            Button4.Content = string.Empty;
            Button4.Background = Brushes.Turquoise;
            Button4.Foreground = Brushes.Black;

            Button5.Content = string.Empty;
            Button5.Background = Brushes.Turquoise;
            Button5.Foreground = Brushes.Black;

            Button6.Content = string.Empty;
            Button6.Background = Brushes.Turquoise;
            Button6.Foreground = Brushes.Black;

            Button7.Content = string.Empty;
            Button7.Background = Brushes.Turquoise;
            Button7.Foreground = Brushes.Black;

            Button8.Content = string.Empty;
            Button8.Background = Brushes.Turquoise;
            Button8.Foreground = Brushes.Black;

            WinnerLabel.Content = string.Empty;
            WinnerLabel.Background = Brushes.White;

            mGameEnded = false;
        }

        private void ResetScoreButton_Click(object sender, RoutedEventArgs e)
        {
            Player1Score = 0;
            Player1ScoreValue.Content = Player1Score;
            
            TieScore = 0;
            TieScoreValue.Content = TieScore;
                        
            Player2Score = 0;
            Player2ScoreValue.Content = Player2Score;
        }

        /// <summary>
        /// Handles a button click event
        /// </summary>
        /// <param name="sender">The button that was clicked</param>
        /// <param name="e">The events of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Start a new game on the click after it finished
            if (mGameEnded)
            {
                NewGame();
                return;
            }

            // Cast the sender to a button
            var button = (Button)sender;

            // Find the button position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            // Don't do anything if the cell already has a value in it
            if (mResults[index] != MarkType.Free)
            {
                return;
            }

            // Set the cell value based on which players turn it is
            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            // Set button text to the result
            button.Content = mPlayer1Turn ? "X" : "0";

            // Change nought to red
            if (!mPlayer1Turn)
            {
                button.Foreground = Brushes.Red;
            }
            else
            {
                button.Foreground = Brushes.Blue;
            }
                

            // Toggle the players turns
            mPlayer1Turn ^= true;

            // Check for a winner
            CheckForWinner();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        /// <summary>
        /// Check if there is a winner of a 3 line straight
        /// </summary>
        private void CheckForWinner()
        {
            #region HorizontalWins

            // Check for horizontal wins
            // row 0
            if (mResults[0] != MarkType.Free &&
                (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                // Game ends;
                mGameEnded = true;

                // Highlight winning cells in green
                Button0.Background = Button1.Background = Button2.Background = Brushes.Green;

                IncrementScoreOfWinner();
            }

            // Check for horizontal wins
            // row 1
            if (mResults[3] != MarkType.Free &&
                (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                // Game ends;
                mGameEnded = true;

                // Highlight winning cells in green
                Button3.Background = Button4.Background = Button5.Background = Brushes.Green;

                IncrementScoreOfWinner();
            }

            // Check for horizontal wins
            // row 2
            if (mResults[6] != MarkType.Free &&
                (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                // Game ends;
                mGameEnded = true;

                // Highlight winning cells in green
                Button6.Background = Button7.Background = Button8.Background = Brushes.Green;

                IncrementScoreOfWinner();
            }

            #endregion

            #region VerticalWins
            // Check for vertical wins
            // column 0
            if (mResults[0] != MarkType.Free &&
                (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                // Game ends;
                mGameEnded = true;

                // Highlight winning cells in green
                Button0.Background = Button3.Background = Button6.Background = Brushes.Green;

                IncrementScoreOfWinner();
            }

            // Check for vertical wins
            // column 1
            if (mResults[1] != MarkType.Free &&
                (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                // Game ends;
                mGameEnded = true;

                // Highlight winning cells in green
                Button1.Background = Button4.Background = Button7.Background = Brushes.Green;

                IncrementScoreOfWinner();
            }

            // Check for vertical wins
            // column 2
            if (mResults[2] != MarkType.Free &&
                (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                // Game ends;
                mGameEnded = true;

                // Highlight winning cells in green
                Button2.Background = Button5.Background = Button8.Background = Brushes.Green;

                IncrementScoreOfWinner();
            }

            #endregion

            #region DiagonalWins

            // Check for diagonal wins
            // diagonal 1
            if (mResults[0] != MarkType.Free &&
                (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                // Game ends;
                mGameEnded = true;

                // Highlight winning cells in green
                Button0.Background = Button4.Background = Button8.Background = Brushes.Green;

                IncrementScoreOfWinner();
            }

            // Check for diagonal wins
            // diagonal 2
            if (mResults[2] != MarkType.Free &&
                (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                // Game ends;
                mGameEnded = true;

                // Highlight winning cells in green
                Button2.Background = Button4.Background = Button6.Background = Brushes.Green;

                IncrementScoreOfWinner();
            }

            #endregion

            // Check for no winner and full board
            if (!mResults.Any(result => result == MarkType.Free) && !mGameEnded)
            {
                // Game ended
                mGameEnded = true;

                /*
                // Turn all cells orange
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });
                */
                Button0.Background =
                Button1.Background =
                Button2.Background =
                Button3.Background =
                Button4.Background =
                Button5.Background =
                Button6.Background =
                Button7.Background =
                Button8.Background = Brushes.Orange;

                WinnerLabel.Content = "No player won.";
                WinnerLabel.Background = Brushes.Orange;

                TieScore++;
                TieScoreValue.Content = TieScore;
            }
        }

        private void IncrementScoreOfWinner()
        {
            // Increment score of player
            if (!mPlayer1Turn)
            {
                WinnerLabel.Content = "Player (X) has won!";
                WinnerLabel.Background = Brushes.Blue;

                Player1Score++;
                Player1ScoreValue.Content = Player1Score;
            }
            else
            {
                WinnerLabel.Content = "Player (0) has won!";
                WinnerLabel.Background = Brushes.Red;

                Player2Score++;
                Player2ScoreValue.Content = Player2Score;
            }

            return;
        }
    }
}
