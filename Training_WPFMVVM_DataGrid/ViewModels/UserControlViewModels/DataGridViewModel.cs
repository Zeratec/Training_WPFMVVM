using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_WPFMVVM_DataGrid.Models;
using Training_WPFMVVM_DataGrid.Utils;

namespace Training_WPFMVVM_DataGrid.ViewModels.UserControlViewModels
{
    public class DataGridViewModel : ViewModelBase
    {
        #region Variable
        private Random rnd = new Random();
        private string _id;
        #endregion Variable

        #region Constructor
        public DataGridViewModel()
        {
            DataGridSource = new ObservableCollection<object>();
            loadData();
            DataGridSource.CollectionChanged += _dataGridSource_CollectionChanged;
        }
        #endregion Constructor

        #region Properties
        private ObservableCollection<object> _dataGridSource = null;
        public  ObservableCollection<object> DataGridSource
        {
            get 
            { 
                return _dataGridSource;
            }
            set 
            { 
                _dataGridSource = value;
            }
        }

        private Person _selectedItem;
        public Person SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        #endregion Properties

        #region Public Method
        public void loadData()
        {
            for (int i = 1; i < 20; i++)
            {
                DataGridSource.Add(new Person()
                {
                    ID = i.ToString(),
                    Firstname = "Firstname " + i.ToString(),
                    Lastname = "Lastname " + i.ToString(),
                    Age = rnd.Next(20, 60).ToString(),
                });
            }

            foreach (Person item in DataGridSource)
            {
                item.PropertyChanged += onPropertyChanged;
            }
        }

        private void DeleteItems(List<object> itemsToDelete)
        {
            foreach (Person item in itemsToDelete)
            {
                Console.WriteLine($"[Persons] > Removed\t" +
                $"ID :{item.ID}\t " +
                $"Firstname : {item.Firstname}\t " +
                $"Lastname : {item.Lastname}\t " +
                $"Age : {item.Age}.");
            }
        }
        #endregion Public Method

        #region Private Method
        private void onPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_selectedItem.ID != null)
            {
                _id = _selectedItem.ID;
            }
            else
            {
                //_id = (Dernier ID de la collection) + 1  --> Fonction à écrire 
                _id = _dataGridSource.Count().ToString(); // ATTENTION, ne permet pas d'éviter les ID doublons !!
            }

            Console.WriteLine($"[Persons] > Modified\t" +
                $"ID :{_id}\t " +
                $"Firstname : {_selectedItem.Firstname}\t " +
                $"Lastname : {_selectedItem.Lastname}\t " +
                $"Age : {_selectedItem.Age}.");
        }

        private void _dataGridSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            /// <summary>
            ///  METHODE 1
            /// </summary>

            ////Fonction Ajout
            //if (e.NewItems != null)
            //{
            //    Person person = (Person)e.NewItems[0];
            //    person.PropertyChanged += onPropertyChanged;
            //}

            ////Fonction Suppression
            //if (e.OldItems != null)
            //{
            //    Person person = (Person)e.OldItems[0];
            //    person.PropertyChanged -= onPropertyChanged;
            //    DeleteItems(e.OldItems.Cast<object>().ToList());
            //}


            /// <summary>
            ///  METHODE 2
            /// </summary>

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Person person = (Person)e.NewItems[0];
                    if (person.ID == null)
                    {
                        person.PropertyChanged += onPropertyChanged;
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    DeleteItems(e.OldItems.Cast<object>().ToList());
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        #endregion Private Method
    }
}
