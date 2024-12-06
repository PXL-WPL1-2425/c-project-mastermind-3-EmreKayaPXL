using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Mastermind2_EmreKayaPXL
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        DateTime clicked;
        TimeSpan elapsedTime;
        int attempts = 1;
        int score = 100;
        int correctTotalColor1 = 0;
        int correctTotalColor2 = 0;
        int correctTotalColor3 = 0;
        int correctTotalColor4 = 0;
        MessageBoxResult messageBoxResult;
        int MasterMindStrenghtNumber = 0;
        string randomColors;
        private string[] highscore = new string[15];
        string antwoord;
        List<string> namen = new List <string>();
        StringBuilder randomColorBuilder;
        string label1Color;
        string label2Color;
        string label3Color;
        string label4Color;
        private bool isInDebug = false;
        int maxAttempts;

        public MainWindow()
        {
            InitializeComponent();
            StartGame();
            titleRandomColors();
            UpdateTitle();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += Timer_Tick;
        }

        private void StartGame()
        {
            do
            {
                antwoord = Interaction.InputBox("Geef je naam in", "Invoer", "Naam");

                while (string.IsNullOrEmpty(antwoord))
                {
                    MessageBox.Show("Geef een naam!", "Foutieve invoer");
                    antwoord = Interaction.InputBox("Geef je naam in", "Invoer", "Naam");
                   
                }
                namen.Add(antwoord);

            }while (MessageBox.Show("Wil je naam toevoegen", "nieuwe naam", MessageBoxButton.YesNo) == MessageBoxResult.Yes);

        }

        private void HighScore()
        {
            highscore[0] = ($"{namen[0]} - {attempts}pogingen - {score}/100");
        }

        private void Afsluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Highscores_Click(object sender, RoutedEventArgs e)
        {
            HighScore();
            MessageBox.Show($"{highscore[0]}");
        }

        private void HistoryColorsAttempts()
        {
            List<Label> Rij1 = new List<Label> { A1, B1, C1, D1 };
            List<Label> Rij2 = new List<Label> { A2, B2, C2, D2 };
            List<Label> Rij3 = new List<Label> { A3, B3, C3, D3 };
            List<Label> Rij4 = new List<Label> { A4, B4, C4, D4 };
            List<Label> Rij5 = new List<Label> { A5, B5, C5, D5 };
            List<Label> Rij6 = new List<Label> { A6, B6, C6, D6 };
            List<Label> Rij7 = new List<Label> { A7, B7, C7, D7 };
            List<Label> Rij8 = new List<Label> { A8, B8, C8, D8 };
            List<Label> Rij9 = new List<Label> { A9, B9, C9, D9 };
            List<Label> Rij10 = new List<Label> { A10, B10, C10, D10 };
            List<Label> Rij11 = new List<Label> { A11, B11, C11, D11 };
            List<Label> Rij12 = new List<Label> { A12, B12, C12, D12 };
            List<Label> Rij13 = new List<Label> { A13, B13, C13, D13 };
            List<Label> Rij14 = new List<Label> { A14, B14, C14, D14 };
            List<Label> Rij15 = new List<Label> { A15, B15, C15, D15 };
            List<Label> Rij16 = new List<Label> { A16, B16, C16, D16 };
            List<Label> Rij17 = new List<Label> { A17, B17, C17, D17 };
            List<Label> Rij18 = new List<Label> { A18, B18, C18, D18 };
            List<Label> Rij19 = new List<Label> { A19, B19, C19, D19 };
            List<Label> Rij20 = new List<Label> { A20, B20, C20, D20 };
            List<Label> kolomHoofd = new List<Label> { label1, label2, label3, label4 };
            List<List<Label>> Rijen = new List<List<Label>> { Rij1, Rij2, Rij3, Rij4, Rij5, Rij6, Rij7, Rij8, Rij9, Rij10, 
                                                        Rij11, Rij12, Rij13, Rij14, Rij15, Rij16, Rij17, Rij18, Rij19, Rij20 };
            if (attempts >= 2 && attempts <= maxAttempts)
            {
                for (int j = 0; j < 20; j++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Rijen[attempts - 2][i].Background = kolomHoofd[i].Background;
                        Rijen[attempts - 2][i].BorderBrush = kolomHoofd[i].BorderBrush;
                    }
                }
            }
            if (attempts > maxAttempts)
            {
                        ToggleDebug();
                        StopCountdown();
                        messageBoxResult = MessageBox.Show($"U heeft verloren!\nScore: {score}/100\nAjjjantal pogingen: {attempts -1}");
                        sliderInformationLabel.Visibility = Visibility.Visible;
                        maxPogingSlider.Visibility = Visibility.Visible;
                        score = 100;
                        ToggleDebug();
                        AllesRessetten();
                        UpdateTitle();
                        randomColorBuilder.Clear();
                        titleRandomColors();
            }
        }
        private void AllesRessetten()
        {
            List<Label> Rij1 = new List<Label> { A1, B1, C1, D1 };
            List<Label> Rij2 = new List<Label> { A2, B2, C2, D2 };
            List<Label> Rij3 = new List<Label> { A3, B3, C3, D3 };
            List<Label> Rij4 = new List<Label> { A4, B4, C4, D4 };
            List<Label> Rij5 = new List<Label> { A5, B5, C5, D5 };
            List<Label> Rij6 = new List<Label> { A6, B6, C6, D6 };
            List<Label> Rij7 = new List<Label> { A7, B7, C7, D7 };
            List<Label> Rij8 = new List<Label> { A8, B8, C8, D8 };
            List<Label> Rij9 = new List<Label> { A9, B9, C9, D9 };
            List<Label> Rij10 = new List<Label> { A10, B10, C10, D10 };
            List<Label> Rij11 = new List<Label> { A11, B11, C11, D11 };
            List<Label> Rij12 = new List<Label> { A12, B12, C12, D12 };
            List<Label> Rij13 = new List<Label> { A13, B13, C13, D13 };
            List<Label> Rij14 = new List<Label> { A14, B14, C14, D14 };
            List<Label> Rij15 = new List<Label> { A15, B15, C15, D15 };
            List<Label> Rij16 = new List<Label> { A16, B16, C16, D16 };
            List<Label> Rij17 = new List<Label> { A17, B17, C17, D17 };
            List<Label> Rij18 = new List<Label> { A18, B18, C18, D18 };
            List<Label> Rij19 = new List<Label> { A19, B19, C19, D19 };
            List<Label> Rij20 = new List<Label> { A20, B20, C20, D20 };
            List<Label> kolomHoofd = new List<Label> { label1, label2, label3, label4 };
            List<List<Label>> Rijen = new List<List<Label>> { Rij1, Rij2, Rij3, Rij4, Rij5, Rij6, Rij7, Rij8, Rij9, Rij10,
                                                        Rij11, Rij12, Rij13, Rij14, Rij15, Rij16, Rij17, Rij18, Rij19, Rij20 };
            ComboBox1.SelectedIndex = -1;
            ComboBox2.SelectedIndex = -1;
            ComboBox3.SelectedIndex = -1;
            ComboBox4.SelectedIndex = -1;
            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    Rijen[j][i].Background = Brushes.Transparent;
                    Rijen[j][i].BorderBrush = Brushes.Transparent;
                    kolomHoofd[i].Background = Brushes.Transparent;
                    kolomHoofd[i].BorderBrush = Brushes.Transparent;
                }
            }
            resultTextBlock.Text = "";
            scoreTextBlock.Text = $" Score = 100/100";
            clicked = DateTime.Now;
            timer.Start();
            timerLabel.Content = "";
            correctTotalColor1 = 0;
            correctTotalColor2 = 0;
            correctTotalColor3 = 0;
            correctTotalColor4 = 0;
            attempts = 1;
            label1.Content = "Kleur 1";
            label2.Content = "Kleur 2";
            label3.Content = "Kleur 3";
            label4.Content = "Kleur 4";
            MasterMindStrenghtNumber = 0;
        }

        /// </summary> StopCountdown(): de timer stopt <summary>
        private void StopCountdown()
        {
            timer.Stop();
        }
        /// <summary> StartCountdown(): Start de timer, poging stijgt met 1 en de titel wordt geupdatet </summary>
        private void StartCountDown()
        {
            timer.Start();
            attempts++;
            UpdateTitle();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime = DateTime.Now - clicked;
            timerLabel.Content = $"{elapsedTime.Seconds} : {elapsedTime.Milliseconds.ToString().PadLeft(3, '0')}";

            if (correctTotalColor1 >= 1 && correctTotalColor2 >= 1 && correctTotalColor3 >= 1 && correctTotalColor4 >= 1)
            {
                attempts--;
                UpdateTitle();
                ToggleDebug();
                messageBoxResult = MessageBox.Show($"U heeft gewonnen!\nScore: {score}/100\nAantal pogingen {attempts}");
                sliderInformationLabel.Visibility = Visibility.Visible;
                maxPogingSlider.Visibility = Visibility.Visible;
                score = 100;
                ToggleDebug();
                AllesRessetten();
                UpdateTitle();
                randomColorBuilder.Clear();
                titleRandomColors();
                return;
            }
            else if (elapsedTime.Seconds >= 1000)
            {
                timer.Stop();
                MessageBox.Show("Te laat 10 seconden zijn voorbij, er wordt 1 poging toegevoegd");
                clicked = DateTime.Now;
                StartCountDown();
            }
            else if (elapsedTime.Seconds >= 9)
            {
                timerLabel.Background = Brushes.Red;
            }
            else if (elapsedTime.Seconds >= 7)
            {
                timerLabel.Background = Brushes.DarkOrange;
            }
            else if (elapsedTime.Seconds >= 4)
            {
                timerLabel.Background = Brushes.DarkGreen;
            }
            else if (elapsedTime.Seconds >= 2)
            {
                sliderInformationLabel.Visibility = Visibility.Collapsed;
                maxPogingSlider.Visibility = Visibility.Collapsed;
            }
            else
            {
                timerLabel.Background = Brushes.Transparent;
            }
        }

        private void titleRandomColors()
        {
            string[] colors = { "Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw" };
            Random random = new Random();
            randomColorBuilder = new StringBuilder("Mastermind kleur: ");

            for (int i = 0; i < 4; i++)
            {

                int randomIndex = random.Next(0, colors.Length);
                randomColorBuilder.Append(colors[randomIndex]);
                if (i < 3)
                {
                    randomColorBuilder.Append(", ");
                }
            }
            randomColors = randomColorBuilder.ToString();
            randomColorsTextBox.Text = randomColors;
        }

        private void UpdateTitle()
        {
            this.Title = $" Mastermind             poging {attempts}";
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox1.SelectedItem is ComboBoxItem ComboBox1Item) 
            {
                if (ComboBox1Item.Background is SolidColorBrush Kleur)
                {
                    label1.Background = Kleur; 
                    label1.Content = ComboBox1Item.Content.ToString();
                }
            }
        }
        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox2.SelectedItem is ComboBoxItem ComboBox2Item)
            {
                if (ComboBox2Item.Background is SolidColorBrush Kleur)
                {
                    label2.Background = Kleur;
                    label2.Content = ComboBox2Item.Content.ToString();
                }
            }
        }
        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox3.SelectedItem is ComboBoxItem ComboBox3Item)
            {
                if (ComboBox3Item.Background is SolidColorBrush Kleur)
                {
                    label3.Background = Kleur;
                    label3.Content = ComboBox3Item.Content.ToString();
                }
            }
        }
        private void ComboBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox4.SelectedItem is ComboBoxItem ComboBox4Item)
            {
                if (ComboBox4Item.Background is SolidColorBrush Kleur)
                {
                    label4.Background = Kleur;
                    label4.Content = ComboBox4Item.Content.ToString();
                }
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {

            StartCountDown();
            clicked = DateTime.Now;
            label1.BorderBrush = Brushes.Transparent;
            label2.BorderBrush = Brushes.Transparent;
            label3.BorderBrush = Brushes.Transparent;
            label4.BorderBrush = Brushes.Transparent;
            string[] titleColors = randomColorsTextBox.Text.Split(':')[1].Split(',');
            string label1Color = label1.Content.ToString();
            string label2Color = label2.Content.ToString();
            string label3Color = label3.Content.ToString();
            string label4Color = label4.Content.ToString();
            MasterMindStrenghtNumber = 0;
            if (randomColorsTextBox.Text.Contains(label1Color))
            {
                MasterMindStrenghtNumber++;
                if (titleColors[0].Contains(label1Color))
                {
                    label1.BorderBrush = Brushes.DarkRed;
                    correctTotalColor1 = 1;
                }
                else
                {
                    label1.BorderBrush = Brushes.Wheat;
                    score -= 1;
                    correctTotalColor1 = 0;
                }
            }
            else
            {
                score -= 2;
                correctTotalColor1 = 0;
            }
            if (randomColorsTextBox.Text.Contains(label2Color))
            {
                MasterMindStrenghtNumber++;
                if (titleColors[1].Contains(label2Color))
                {
                    label2.BorderBrush = Brushes.DarkRed;
                    correctTotalColor2 = 1;
                }
                else
                {
                    label2.BorderBrush = Brushes.Wheat;
                    score -= 1;
                    correctTotalColor2 = 0;
                }
            }
            else
            {
                score -= 2;
                correctTotalColor2 = 0;
            }
            if (randomColorsTextBox.Text.Contains(label3Color))
            {
                MasterMindStrenghtNumber++;
                if (titleColors[2].Contains(label3Color))
                {
                    label3.BorderBrush = Brushes.DarkRed;
                    correctTotalColor3 = 1;
                }
                else
                {
                    label3.BorderBrush = Brushes.Wheat;
                    score -= 1;
                    correctTotalColor3 = 0;
                }
            }
            else
            {
                score -= 2;
                correctTotalColor3 = 0;
            }
            if (randomColorsTextBox.Text.Contains(label4Color))
            {
                MasterMindStrenghtNumber++;
                if (titleColors[3].Contains(label4Color))
                {
                    label4.BorderBrush = Brushes.DarkRed;
                    correctTotalColor4 = 1;
                }
                else
                {
                    label4.BorderBrush = Brushes.Wheat;
                    score -= 1;
                    correctTotalColor4 = 0;
                }
            }
            else
            {
                score -= 2;
                correctTotalColor4 = 0;
            }

            switch (MasterMindStrenghtNumber)
            {
                case 4:
                    resultTextBlock.Text = "4 kleuren komen voor";
                    break;
                case 3:
                    resultTextBlock.Text = "3 kleuren komen voor";
                    break;
                case 2:
                    resultTextBlock.Text = "2 kleuren komen voor";
                    break;
                case 1:
                    resultTextBlock.Text = "1 kleur komt voor";
                    break;
                default:
                    resultTextBlock.Text = "Niet de juiste kleuren gebruikt";
                    break;
            }
            scoreTextBlock.Text = $" Score = {score}/100";
            HistoryColorsAttempts();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            clicked = DateTime.Now;
            scoreTextBlock.Text = $" Score = 100/100";
        }


        private void Window_Keydown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.F12))
            {
                ToggleDebug();
            }
        }
        /// <summary> ToggleDebug(): isInDebug waarde wordt omgedraaid, dus true wordt false en false wordt true. 
        /// Bij false is randomColorsTextBox zichtbaar en bij true niet.  </summary>
        private void ToggleDebug()
        {
            isInDebug = !isInDebug;

            if (isInDebug)
            {
                randomColorsTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                randomColorsTextBox.Visibility = Visibility.Collapsed;
            }
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs uit)
        {
            MessageBoxResult closeTheWindow = MessageBox.Show("Bent u zeker Om het spel te sluiten?", "VensterSluiten", MessageBoxButton.YesNo);

            if (closeTheWindow == MessageBoxResult.Yes)
            {
                uit.Cancel = false;
            }
            else
            {
                uit.Cancel = true;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs k)
        {
            StopCountdown();
            MessageBox.Show("Kies de juiste kleur die op de juiste plaats hoort." +
                "\nRode rand betekent dat de kleur op de juiste plaats staat." +
                "\nLichte beige rand betekent dat de kleur juist is maar op de verkeerde plaats staat");
            clicked = DateTime.Now;
            timer.Start();
        }


        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sliderInformationLabel != null)
            {

                maxAttempts = (int)maxPogingSlider.Value;
                sliderInformationLabel.Content = $"Maximum aantal pogingen {maxAttempts}";
                clicked = DateTime.Now;
                timer.Start();
            }
        }
    }
}