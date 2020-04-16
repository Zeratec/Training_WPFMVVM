using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        public ObservableCollection<object> DataGridSource
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
        }

        private void AddItems(List<object> itemsToAdd)
        {
            foreach (Person item in itemsToAdd)
            {
                Console.WriteLine($"[Persons]\t" +
                $"ID :{item.ID}\t " +
                $"Firstname : {item.Firstname}\t " +
                $"Lastname : {item.Lastname}\t " +
                $"Age : {item.Age}\t " +
                $"> added.");
            }
        }

        private void ModifyItems(List<object> itemsToModify)
        {
            foreach (Person item in itemsToModify)
            {
                Console.WriteLine($"[Persons]\t" +
                $"ID :{item.ID}\t " +
                $"Firstname : {item.Firstname}\t " +
                $"Lastname : {item.Lastname}\t " +
                $"Age : {item.Age}\t " +
                $"> modified.");
            }
        }

        private void DeleteItems(List<object> itemsToDelete)
        {
            foreach (Person item in itemsToDelete)
            {
                Console.WriteLine($"[Persons]\t" +
                $"ID :{item.ID}\t " +
                $"Firstname : {item.Firstname}\t " +
                $"Lastname : {item.Lastname}\t " +
                $"Age : {item.Age}\t " +
                $"> removed.");
            }
        }
        #endregion Public Method

        #region Private Method
        private void _dataGridSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            List<object> list = new List<object>();

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    list.AddRange(e.NewItems.Cast<object>().ToList());
                    AddItems(list);
                    break;

                case NotifyCollectionChangedAction.Move:
                    break;

                //Fonction Delete Fonctionne
                case NotifyCollectionChangedAction.Remove:
                    DeleteItems(e.OldItems.Cast<object>().ToList());
                    break;

                case NotifyCollectionChangedAction.Replace:
                    ModifyItems(e.OldItems.Cast<object>().ToList());
                    break;

                case NotifyCollectionChangedAction.Reset:
                    break;

                default:
                    throw new NotImplementedException();
            }
            #endregion Private Method
        }
    }
}
