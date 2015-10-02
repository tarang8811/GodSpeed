using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp2.Resources;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace PhoneApp2
{
    public partial class MainPage : PhoneApplicationPage
    {
        int j = 0,k=0,flag=0,l=0,t=0;
        Random rand = new Random();
        String[] content = { "Green", "Blue", "Orange", "Purple","Brown", "Yellow" };//Color String
        Color[] color = { Colors.Green, Colors.Blue,  Colors.Orange,  Colors.Purple, Colors.Brown, Colors.Yellow };//Color chooser
        Image[] Images = new Image[7];
        int ans, n1, n2, temp1, temp2;
        int tempanswer = 0;
        int lives = 5;
        int counter2 = 0;
        System.Windows.Threading.DispatcherTimer myDispatcherTimer;

        int[] Numbers = { 7, 1, 10, 4,5,6,9, 11, 15, 20, 100, 14, 23, 44 };
        int[] Correctanswers = {8,8,2,10000000,3,3,0};
        int counter = 0, colorindex, ContentIndex, Score = 0, Imageindex,counter1=0,p;
        // Constructor;
       
        public MainPage()
        {
            InitializeComponent();
            
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
     /*   public void pTimer(object o, RoutedEventArgs sender)
        {
            System.Windows.Threading.DispatcherTimer myDispatcherTimer4 = new System.Windows.Threading.DispatcherTimer();
            myDispatcherTimer4.Interval = new TimeSpan(0, 0, 0, 0, 1000); // 100 Milliseconds 
            myDispatcherTimer4.Tick += new EventHandler(Each_Tick_perk1);
            myDispatcherTimer4.Start();
        }

        // A variable to count with.
        //  int i = 0;

        // Raised every 100 miliseconds while the DispatcherTimer is active.
        public void Each_Tick_perk1(object o, EventArgs sender)
        {
            //if (t > 0)
            //{
         //   myTextBlock5.Text = t.ToString();
            //}
            // myTextBlock.Text = "Count up: " + i++.ToString();
        } 
       */ 
        
        //color chooser Timer function 
        public void StartTimer(object o, RoutedEventArgs sender)
        {
           
            
            System.Windows.Threading.DispatcherTimer myDispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 3000); // 3000 Milliseconds 
            myDispatcherTimer.Tick += new EventHandler(Each_Tick);
           
            myDispatcherTimer.Start();
        }
        //image game
        System.Windows.Threading.DispatcherTimer myDispatcherTimer1;
        public void Reset1(System.Windows.Threading.DispatcherTimer myDispatcherTimer1)
        {

            myDispatcherTimer1.Stop();
            Each_Tick4();

            myDispatcherTimer1.Start();

            //myDispatcherTimer = new DispatcherTimer();
            //myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 5000); // 100 Milliseconds 
            //myDispatcherTimer.Tick += new EventHandler(Each_Tick);
            //myDispatcherTimer.Start();
        }
        public void StartTimer1(object o, RoutedEventArgs sender)
        {
            //System.Windows.Threading.DispatcherTimer 
            myDispatcherTimer1 = new System.Windows.Threading.DispatcherTimer();
            myDispatcherTimer1.Interval = new TimeSpan(0, 0, 0, 0, 30000); // 3000 Milliseconds 
            myDispatcherTimer1.Tick += new EventHandler(Each_Tick1);
            myDispatcherTimer1.Start();
            Each_Tick4();
        }
        // A variable to count with.
        public void Each_Tick1(object o, EventArgs sender)
        {
            Each_Tick4();
         }

        public void Each_Tick4()
        {
            counter1 = 0;
            Random rand = new Random();
            BitmapImage bmp = new BitmapImage();

            int Imageindex = rand.Next(0, 7);
            if (Imageindex == 0)
                bmp.UriSource = new Uri("Assets/Untitled.png", UriKind.Relative);
            if (Imageindex == 1)
                bmp.UriSource = new Uri("Assets/Untitled1.png", UriKind.Relative);
            if (Imageindex == 2)
                bmp.UriSource = new Uri("Assets/Untitled2.png", UriKind.Relative);
            if (Imageindex == 3)
            {
                bmp.UriSource = new Uri("Assets/Untitled3.png", UriKind.Relative);
                myTextBlock.Text = "Score:  " + Score++.ToString();
            }
            if (Imageindex == 4)
                bmp.UriSource = new Uri("Assets/Untitled4.png", UriKind.Relative);
            if (Imageindex == 5)
                bmp.UriSource = new Uri("Assets/Untitled5.png", UriKind.Relative);
            if (Imageindex == 6)
                bmp.UriSource = new Uri("Assets/Untitled6.png", UriKind.Relative);
            myTextBlock.Text = "Score:  " + Score.ToString();

            Image.Source = bmp;
            p = rand.Next(0, 3);
            if (p == 1)
            {
                Button1.Content = Correctanswers[Imageindex];
                Button2.Content = Numbers[rand.Next(0, Numbers.Length)];
                Button3.Content = Numbers[rand.Next(0, Numbers.Length)];
            }
            else if (p == 2)
            {
                Button3.Content = Numbers[rand.Next(0, Numbers.Length)];
                Button1.Content = Numbers[rand.Next(0, Numbers.Length)];
                Button2.Content = Correctanswers[Imageindex];
            }
            else
            {
                Button2.Content = Numbers[rand.Next(0, Numbers.Length)];
                Button1.Content = Numbers[rand.Next(0, Numbers.Length)];
                Button3.Content = Correctanswers[Imageindex];
            }
        }

       
        
        
        //color chooser
        // Raised every 1000 miliseconds while the DispatcherTimer is active.
        //int c1 = 0;
        public void Each_Tick(object o, EventArgs sender)
        {
           

            if (lives <= 0)
            {
                
                lives = 5;

                NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));

            }
            flag = 0;
            counter = 0;

            colorindex = rand.Next(0, color.Length);
            ContentIndex = rand.Next(0, content.Length);
            myTextBlock.Text = "Score:  " + Score.ToString();
            //this.button.Background = new SolidColorBrush(color[colorindex]);
            this.button.Background = new SolidColorBrush(color[colorindex]);//changes background color
            
            this.ColorName.Text = content[ContentIndex];//changes the text in the background
            if (colorindex == ContentIndex)
                if (flag == 0)
                { lives--;
                if (lives < 0)
                    lives = 0;
                    noOfLives.Text = "lives: " + lives.ToString();
                }
        }
        //checks whether the user wins or loses
       
        /*private void button_Click(object sender, RoutedEventArgs e)
        {
         //   this.button.Background = new SolidColorBrush(color[colorindex]);
            if (colorindex == ContentIndex)
            {

                if (counter == 0)
                {
                    Score++;
                    myTextBlock.Text = "Score:  " + Score.ToString();
                    this.button.Content = "Right";
                    counter++;
                    
                }
            }
            if (colorindex != ContentIndex)
                this.button.Content = "Over";

            
            
                //this.button.Background = new SolidColorBrush(Color.FromArgb(10, 15, 100, 124));
        }

        private void button_Hold(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.button.Background = new SolidColorBrush(color[colorindex]);
        }*/
       
        private void button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
                
            
                if (colorindex == ContentIndex)
                {

                    if (counter == 0)
                    {
                        Score++;

                        myTextBlock.Text = "Score:  " + Score.ToString();
                        //    this.ColorName.Text = "Right";
                        counter++;

                    }
                    flag = 1;
                }
                if (colorindex != ContentIndex)
                { //this.ColorName.Text = "Over";
                    lives--;
                    flag = 1;
                    if (lives < 0)
                        lives = 0;
                    noOfLives.Text = "lives: " + lives.ToString();
                }
            
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (counter1 == 0)
            {
                if (p == 1)
                {
                    myTextBlock.Text = "Score:  " + Score++.ToString();
                    counter1++;
                    k = 0;
                }
                else
                { lives--;
                if (lives < 0)
                    lives = 0;
                noOfLives.Text = "lives: " + lives.ToString();
                k = 0;
                }
            }
            else
            Reset1(myDispatcherTimer1);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (counter1 == 0)
            {
                if (p == 2)
                {myTextBlock.Text = "Score:  " + Score++.ToString();
                counter1++;
                k = 0;}
                else
                { lives--;
                if (lives < 0)
                    lives = 0;
                noOfLives.Text = "lives: " + lives.ToString();
                    k = 0;
                }
            }
            Reset1(myDispatcherTimer1);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
           if (counter1 == 0)
            {
                if (p == 3)
                {
                    myTextBlock.Text = "Score: " + Score++.ToString();
                    counter1++;
                    k = 0;
                }
                else
                { lives--;
                if (lives < 0)
                    lives = 0;
                noOfLives.Text = "lives= " + lives.ToString();
                k = 0;
                }
                }
           Reset1(myDispatcherTimer1);
        }




        public void Reset(System.Windows.Threading.DispatcherTimer myDispatcherTimer)
        {
            
            myDispatcherTimer.Stop();
            Each_Tick2();

            myDispatcherTimer.Start();

            //myDispatcherTimer = new DispatcherTimer();
            //myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 5000); // 100 Milliseconds 
            //myDispatcherTimer.Tick += new EventHandler(Each_Tick);
            //myDispatcherTimer.Start();
        }
        //game1
        public void mathTimer(object o, RoutedEventArgs sender)
        {
            myDispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 30000); // 100 Milliseconds 
            myDispatcherTimer.Tick += new EventHandler(Each_Tick3);
            myDispatcherTimer.Start();
            Each_Tick2();

        }

        // A variable to count with.
        int i = 0;

        // Raised every 100 miliseconds while the DispatcherTimer is active.
        public void Each_Tick3(object o, EventArgs sender)
        {
            Each_Tick2();
        }

        public void Each_Tick2()
        {

            counter2 = 0;
           // myTextBlock1.Text = "Count up: " + i++.ToString() ;
            this.option2.Foreground = new SolidColorBrush(Colors.White);
            this.option1.Foreground = new SolidColorBrush(Colors.White);
            int num1 = rand.Next(25);
            int num2 = rand.Next(25);
            ans = num1 * num2;


            numbers.Text = num1 + " X " + num2;

            temp1 = rand.Next(1000);
            this.option1.Text = temp1 + "";
            temp2 = rand.Next(1000);
            this.option2.Text = temp2 + "";
            n1 = rand.Next(2);
            if (n1 == 0)
            {

                this.option1.Text = ans + "";
                temp1 = ans;

            }
            else
            {

                this.option2.Text = ans + "";
                temp2 = ans;

            }
            n1 = rand.Next(2);
            //n1 0
            //0 red 1 green n2
            if (n1 == 0)
            {
                n2 = rand.Next(2);
                if (n2 == 0)
                {
                    this.option1.Foreground = new SolidColorBrush(Colors.Red);


                }
                else
                    this.option1.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (n1 == 1)
            {
                n2 = rand.Next(2);
                if (n2 == 0)
                    this.option2.Foreground = new SolidColorBrush(Colors.Red);
                else
                    this.option2.Foreground = new SolidColorBrush(Colors.Green);
            }
            //0 f 1 t
            if (n1 == 0)
            {

                if ((temp1 == ans && n2 == 1) || (temp1 != ans && n2 == 0))
                    tempanswer = 1;
                else
                    tempanswer = 0;
            }
            else
            {

                if ((temp2 == ans && n2 == 1) || (temp2 != ans && n2 == 0))
                    tempanswer = 1;
                else
                    tempanswer = 0;
            }

        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {

            if (counter2 == 0)
            {
                if (tempanswer == 1)
                {

                    Score++;
                    j = 0;
                }
                else
                {
                    lives--;
                    if (lives < 0)
                        lives = 0;
                    noOfLives.Text = "lives: " + lives.ToString();
                    j = 0;
                }
                counter2++;
            }
            Reset(myDispatcherTimer);

        }

        private void no_Click(object sender, RoutedEventArgs e)
        {


            if (counter2 == 0)
            {
                if (tempanswer == 0)
                {
                    Score++;
                    j = 0;
                }
                else
                {
                    lives--;
                    if (lives < 0)
                        lives = 0;
                    noOfLives.Text = "lives: " + lives.ToString();
                    j = 0;
                }
                counter2++;
            }
            Reset(myDispatcherTimer);

        }

        private void Tap_TextBlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (colorindex == ContentIndex)
            {

                if (counter == 0)
                {
                    Score++;
                    myTextBlock.Text = "Score:  " + Score.ToString();
                   // this.ColorName.Text = "Right";
                    counter++;
                    
                }
                flag = 1;
            }
            if (colorindex != ContentIndex)
            { //this.ColorName.Text = "Over";
            lives--;
            if (lives < 0)
                lives = 0;
            noOfLives.Text = "lives: " + lives.ToString();
            j = 0;
            }
        }

        //game clock
        public void game1Timer(object o, RoutedEventArgs sender)
        {
            System.Windows.Threading.DispatcherTimer myDispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000); // 100 Milliseconds 
            myDispatcherTimer.Tick += new EventHandler(Each_Tick_game1);
            myDispatcherTimer.Start();
        }

        // A variable to count with.
        

        // Raised every 100 miliseconds while the DispatcherTimer is active.
        public void Each_Tick_game1(object o, EventArgs sender)
        {
            j++;
            
            game1.Text =  (30-j%31).ToString();
            if (30 - j % 31 == 0)
            { lives--;
            if (lives < 0)
                lives = 0;
            noOfLives.Text = "lives: " + lives.ToString();
            }
        }

        public void imageTimer(object o, RoutedEventArgs sender)
        {
            System.Windows.Threading.DispatcherTimer myDispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000); // 100 Milliseconds 
            myDispatcherTimer.Tick += new EventHandler(Each_Tick_game2);
            myDispatcherTimer.Start();
        }

        // A variable to count with.
        

        // Raised every 100 miliseconds while the DispatcherTimer is active.
        public void Each_Tick_game2(object o, EventArgs sender)
        {
            k++;
            game2.Text = (30-k%31).ToString();
            if (30 - k % 31 == 0)
            {lives--;
            if (lives < 0)
                lives = 0;
            noOfLives.Text = "lives: "+lives.ToString();
            }
        }

    
    }





        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        
    }
    
