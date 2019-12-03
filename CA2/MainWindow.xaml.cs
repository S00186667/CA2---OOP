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

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<activity> AllActivties = new List<activity>();
        List<activity> selectedActivites = new List<activity>();
        List<activity> FilteredActvities = new List<activity>();
        decimal TotalCost = 0;//running total

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Lbxactivities1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            activity SelectedActivty = lbxactivities1.SelectedItem as activity;
            if (SelectedActivty != null)
            {
                txtboxdescription.Text = SelectedActivty.Description; 
            }
        
          

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //create activity objects 


            activity A1 = new activity("kayaking", new DateTime(2019,06,01),20m, "Instructor led group trek through local mountains.", ActivityType.Water);
            activity A2 = new activity("Treking", new DateTime(2019,06,01), 30m, "Instructor led half day mountain biking.  All equipment provided.", ActivityType.Land);
            activity A3 = new activity("Parachuting", new DateTime(2019,06,01), 40m, "Experience the rush of adrenaline as you descend cliff faces from 10-500m.", ActivityType.Air);
            activity A4 = new activity("Moutain Biking", new DateTime(2019,06,02), 40m, "Half day lakeland kayak with island picnic.", ActivityType.Land);
            activity A5 = new activity("Surfing", new DateTime(2019,06,02), 25m, "2 hour surf lesson on the wild atlantic way", ActivityType.Water);
            activity A6 = new activity("Hang Gliding", new DateTime(2019,06,02), 50m, "Full day lakeland kayak with island picnic.", ActivityType.Air);
            activity A7 = new activity("Absailing", new DateTime(2019,06,03), 100m," Experience the thrill of free fall while you tandem jump from an airplane.", ActivityType.Land);
            activity A8 = new activity("Sailing", new DateTime(2019,06,03), 80m, "Soar on hot air currents and enjoy spectacular views of the coastal region.", ActivityType.Water);
            activity A9 = new activity("Helicopter", new DateTime(2019,06,03), 200m, "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters", ActivityType.Air);

            //add to a list
            AllActivties.Add(A1);
            AllActivties.Add(A2);
            AllActivties.Add(A3);
            AllActivties.Add(A4);
            AllActivties.Add(A5);
            AllActivties.Add(A6);
            AllActivties.Add(A7);
            AllActivties.Add(A8);
            AllActivties.Add(A9);


            //AllActivties.Sort(); 
            
           

            //display in list box
            lbxactivities1.ItemsSource = AllActivties; 
            

        }

        private void Btnadd_Click(object sender, RoutedEventArgs e)
        {

            //know which item is selected
            

            activity SelectedActivty = lbxactivities1.SelectedItem as activity; //funds selected item

            //null check 
            if (SelectedActivty != null)
            {
                //move from left to right
                AllActivties.Remove(SelectedActivty);
                selectedActivites.Add(SelectedActivty);
                AllActivties.Sort();
                selectedActivites.Sort();

                TotalCost += SelectedActivty.Cost;//add to runnning total
                tblkTotal.Text = TotalCost.ToString();//displays running total to screen


                RefreshScreen();

            }
            else if (SelectedActivty == null) // This displays a description when nothing is there to be added
            {
                txtboxdescription.Text = "Please select an activity to add first !";
            }
           
        }

        private void Btnremove_Click(object sender, RoutedEventArgs e)
        {
            //know which item is selected


            activity SelectedActivty = lbxactivities2.SelectedItem as activity; //funds selected item

            //null check 
            if (SelectedActivty != null)
            {
                //move from left to right
                AllActivties.Add(SelectedActivty);
                selectedActivites.Remove(SelectedActivty);
                AllActivties.Sort();
                selectedActivites.Sort();



                //refresh screen 
                RefreshScreen(); 

            }
            else if (SelectedActivty == null) // This displays a description when nothing is there to remove
            {
                txtboxdescription.Text = "Please select an activity to remove first !";
            }

        }
        
        private void RefreshScreen()
        {
            lbxactivities1.ItemsSource = null;
            lbxactivities1.ItemsSource = AllActivties;

            lbxactivities2.ItemsSource = null;
            lbxactivities2.ItemsSource = selectedActivites;
        }


        //this handles all the click events from the radio buttons
        private void Orballactivties_Click(object sender, RoutedEventArgs e)
        {

            FilteredActvities.Clear(); 

            if(orballactivties.IsChecked == true)
            {
                RefreshScreen(); 
            }
            else if(orbland.IsChecked == true)
            {
                //display all land activites
                foreach(activity Activity in AllActivties)
                {
                    if (Activity.Suitable == ActivityType.Land)
                    {
                        FilteredActvities.Add(Activity);
                        lbxactivities1.ItemsSource = null;
                        lbxactivities1.ItemsSource = FilteredActvities; 
                    }
                }

            }
            else if(orbwater.IsChecked == true)
            {
                //display all water activites
                foreach (activity Activity in AllActivties)
                {
                    if (Activity.Suitable == ActivityType.Water)
                    {
                        FilteredActvities.Add(Activity);
                        lbxactivities1.ItemsSource = null;
                        lbxactivities1.ItemsSource = FilteredActvities;
                    }
                }
            }
            else if(orbair.IsChecked == true)
            {
                //display all air actvities
                foreach (activity Activity in AllActivties)
                {
                    if (Activity.Suitable == ActivityType.Air)
                    {
                        FilteredActvities.Add(Activity);
                        lbxactivities1.ItemsSource = null;
                        lbxactivities1.ItemsSource = FilteredActvities;
                    }
                }
            }
                    

        }

        private void Txtboxcost_SelectionChanged(object sender, RoutedEventArgs e)
        {
            activity SelectedActivty = lbxactivities1.SelectedItem as activity;
            if(SelectedActivty != null)
            {

                //AllActivties.updateCost
                
            }



        }
    }
}
