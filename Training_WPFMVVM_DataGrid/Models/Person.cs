using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_WPFMVVM_DataGrid.Utils;

namespace Training_WPFMVVM_DataGrid.Models
{
    public class Person : ViewModelBase /*, IEditableObject*/
    {
        #region Variable
        private string _id;
        private string _lastname;
        private string _firstname;
        private string _age;
        //private bool inTxn = false;
        #endregion Variable

        #region Constructor
        public Person()
        {

        }
        #endregion Constructor

        #region Properties
        public string ID 
        { 
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("ID");
            }
        }

        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
                OnPropertyChanged("Firstname");
            }
        }

        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                OnPropertyChanged("Lastname");
            }
        }

        public string Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }
        #endregion Properties

        #region Public Method
        //public void BeginEdit() { inTxn = true; }

        //public void CancelEdit() { }

        //public void EndEdit()
        //{
        //    if (inTxn)
        //    {
        //        Console.WriteLine($"[Persons]\t" +
        //            $"ID :{this.ID}\t " +
        //            $"Firstname : {this.Firstname}\t " +
        //            $"Lastname : {this.Lastname}\t " +
        //            $"Age : {this.Age}\t " +
        //            $"> Modified.");
        //        inTxn = false;
        //    }
        //}
        #endregion Public Method

        #region Private Method
        #endregion Private Method
    }
}
