using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238 

namespace RestaurantManager.UniversalWindows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame. 
    /// </summary>
    public sealed partial class OrderPage : Page
    {
        public OrderPage()
        {
            this.InitializeComponent();
            //var app = (App)Application.Current;
            //this.grdAvailableItems.ItemsSource = app.RestaurantData.MenuItems;
            //this.grdSelectedItems.ItemsSource = app.RestaurantData.CurrentlySelectedMenuItems;
        }

        /// <summary>
        /// Handles the Click event of the btnGoHome control. 
        /// </summary>
        /// <param name="sender">
        /// The source of the event. 
        /// </param>
        /// <param name="e">
        /// The <see cref="RoutedEventArgs" /> instance containing the event data. 
        /// </param>
        private void btnGoHome_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        /// <summary>
        /// Handles the Click event of the btnAddToOrder control. 
        /// </summary>
        /// <param name="sender">
        /// The source of the event. 
        /// </param>
        /// <param name="e">
        /// The <see cref="RoutedEventArgs" /> instance containing the event data. 
        /// </param>
        private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = grdAvailableItems.SelectedItems.OfType<string>();

            var app = (App)Application.Current;
            app.RestaurantData.CurrentlySelectedMenuItems = selectedItems.ToList();
            this.grdSelectedItems.ItemsSource = selectedItems.ToList();
        }

        /// <summary>
        /// Handles the Click event of the btnSubmitOrder control. 
        /// </summary>
        /// <param name="sender">
        /// The source of the event. 
        /// </param>
        /// <param name="e">
        /// The <see cref="RoutedEventArgs" /> instance containing the event data. 
        /// </param>
        private void btnSubmitOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = grdSelectedItems.Items.OfType<string>();

            var app = (App)Application.Current;
            app.RestaurantData.OrderItems.Add(selectedItems.ToList().Aggregate((current, next) => current + ", " + next));

            this.Frame.Navigate(typeof(ExpeditePage));
        }
    }
}