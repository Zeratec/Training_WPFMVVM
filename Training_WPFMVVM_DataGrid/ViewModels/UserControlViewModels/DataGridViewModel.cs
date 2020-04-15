using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<object> DataGridSource { get; set; } = null;

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

        public void AddItems(List<object> itemsToAdd)
        {
            foreach (var item in itemsToAdd)
            {
                Console.WriteLine($"{item} added.");
            }
        }

        public void ModifyItems(List<object> itemsToModify)
        {
            foreach (var item in itemsToModify)
            {
                Console.WriteLine($"{item} modified.");
            }
        }

        public void DeleteItems(List<object> itemsToDelete)
        {
            foreach (var item in itemsToDelete)
            {
                Console.WriteLine($"{item} removed.");
            }
        }
        #endregion Public Method

        #region Private Method
        private void _dataGridSource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            List<object> list = new List<object>();
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                list.AddRange((List<object>)e.NewItems);
                this.AddItems(list);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                list.AddRange((List<object>)e.NewItems);
                this.ModifyItems(list);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                list.AddRange((List<object>)e.NewItems);
                this.DeleteItems(list);
            }
        }
        #endregion Private Method
    }
}
