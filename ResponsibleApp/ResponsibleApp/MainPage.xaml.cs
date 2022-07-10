using System;
using Xamarin.Forms;

namespace ResponsibleApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageVM(Navigation);
        }

        //FR//
        //OnAppearing() permet d'exécuter du code avant l'affichage de la page.

        //ENG//
        //OnAppearing() allows code to be executed before the page is displayed.
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //FR//
            //La ligne en dessous permet de déclarer une fonctionnalité qui s'exécutera automatiquement
            //Ici, nous ciblons la fonctionnalité liée au changement de la taille de la page 'SizeChanged'
            //'MyPage' est le nom 'x:Name' que nous avons attribué à la page 'MainPage.xaml'

            //ENG//
            //The line below allows you to declare a feature that will run automatically
            //Here we are targeting functionality related to changing the page size 'SizeChanged'
            //'MyPage' is the name 'x:Name' that we assigned to the page 'MainPage.xaml'
            MyPage.SizeChanged += MyPage_SizeChanged;
        }


        //FR//
        //Vous pouvez paramétrer vous même les tailles max de largeur de page

        //ENG//
        //You can set the maximum page width sizes yourself
        private static double smallSizePage { get; set; } = 800;
        private static double middleSizePage { get; set; } = 1200;

        private void MyPage_SizeChanged(object sender, System.EventArgs e)
        {
            double width = MyPage.Width;
            if (width < smallSizePage)
            {
                (BindingContext as MainPageVM).GetGridSpanNumber(2);
            }
            else if (width < middleSizePage)
            {
                (BindingContext as MainPageVM).GetGridSpanNumber(3);
            }
            else
            {
                (BindingContext as MainPageVM).GetGridSpanNumber(6);
            }
        }

        //FR//
        //Vérifier que la fonctionnalité 'SelectionChanged' fonctionne malgré le changement de largeur de la page

        //ENG//
        //Check that the 'SelectionChanged' functionality works despite the page width change
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //FR//
            //Device.BeginInvokeOnMainThread permet d'attendre que le code soit exécuté à la suite la fonctionnalité en cour d'exécution.
            //Device.BeginInvokeOnMainThread permet également de s'assurer que l'élément sélection soit déselectionné sans créer un bug
            //(dans le cas des functionnalités complexes)

            //ENG//
            //Device.BeginInvokeOnMainThread makes it possible to wait for the code to be executed following the currently executing functionality.
            //Device.BeginInvokeOnMainThread also ensures that the selection element is deselected without creating a bug
            //(in the case of complex functionalities)


            Device.BeginInvokeOnMainThread(async () =>
            {
                if (((CollectionView)sender).SelectedItem == null)
                {
                    return;
                }

                Library myLibrary = (Library)((CollectionView)sender).SelectedItem;
                string folderName = myLibrary.FolderName;
                DateTime dateTime = myLibrary.DateTime;

                await DisplayAlert("Folder info", $"Folder name: {folderName}\nDatetime: {dateTime}", "Close");

                ((CollectionView)sender).SelectedItem = null;
            });
        }
    }
}
