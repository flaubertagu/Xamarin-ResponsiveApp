using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ResponsibleApp
{
    public class MainPageVM : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public MainPageVM(INavigation navigation)
        {
            Navigation = navigation;
            //--------------------
            //FR//
            //Déclarer 'ObservableCollection' pour éviter des problèmes de liaison avec la page associée

            //ENG
            //Declare 'ObservableCollection' to avoid binding issues with associated page
            MyLibrary = new ObservableCollection<Library>();
            //--------------------

            //--------------------
            //FR//
            //Déclarer la valeur du 'GridItemLayout' pour éviter le crash de l'application lors du chargement de la page

            //ENG//
            //Declare the value of the 'GridItemLayout' to avoid application crash when loading the page
            GridSpan = 6;
            //--------------------

            //--------------------
            //FR//
            //Création du liste de valeur pour les besoins de la démonstration

            //ENG//
            //Creation of the list of values for the purposes of the demonstration
            MyLibrary = new ObservableCollection<Library>()
            {
                new Library { FolderName = "Folder1", DateTime = new DateTime(2022,01,01)},
                new Library { FolderName = "Folder1", DateTime = new DateTime(2022,01,02)},
                new Library { FolderName = "Folder1", DateTime = new DateTime(2022,01,03)},
                new Library { FolderName = "Folder1", DateTime = new DateTime(2022,01,04)},
                new Library { FolderName = "Folder1", DateTime = new DateTime(2022,01,05)},
                new Library { FolderName = "Folder1", DateTime = new DateTime(2022,01,06)},
                new Library { FolderName = "Folder1", DateTime = new DateTime(2022,01,07)},
                new Library { FolderName = "Folder1", DateTime = new DateTime(2022,01,08)},
                new Library { FolderName = "Folder1", DateTime = new DateTime(2022,01,09)},
                new Library { FolderName = "Folder1", DateTime = new DateTime(2022,01,10)},
                new Library { FolderName = "Folder1", DateTime = new DateTime(2022,02,25)},
                new Library { FolderName = "Folder1", DateTime = new DateTime(2022,03,14)},
                new Library { FolderName = "Folder1", DateTime = DateTime.Now},
            };
            //--------------------
        }

        //FR//
        //Fonctionnalité utilisée pour mettre à jour la valeur liée avec le 'GridItemsLayout' dans la page associée

        //ENG
        //Functionality used to update the linked value with the 'GridItemsLayout' in the associated page
        public void GetGridSpanNumber(int span)
        {
            GridSpan = span;
        }

        private int _gridSpan;
        public int GridSpan
        {
            get { return _gridSpan; }
            set
            {
                _gridSpan = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Library> _myLibrary;
        public ObservableCollection<Library> MyLibrary
        {
            get { return _myLibrary; }
            set
            {
                if (value != null)
                {
                    _myLibrary = value;
                }
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
