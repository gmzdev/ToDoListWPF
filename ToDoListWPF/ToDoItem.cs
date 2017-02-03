using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ToDoListWPF
{
    public class ToDoItem : INotifyPropertyChanged
    {
        #region Variables
        private int toDoID;
        private string creationDate;
        private string modifiedDate;
        private string doneDate;
        private string toDoDescription;
        private bool isDone;
        #endregion
        #region Properties
        public int ToDoID
        {
            get { return this.toDoID; }
            set
            {
                this.toDoID = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ToDoID"));
                }
            }
        }
        public string CreationDate
        {
            get { return this.creationDate; }
            set
            {
                this.creationDate = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CreationDate"));
                }
            }
        }
        public string ModifiedDate
        {
            get { return this.modifiedDate; }
            set
            {
                this.modifiedDate = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ModifiedDate"));
                }
                {
                }
            }
        }
        public string DoneDate
        {
            get { return this.doneDate; }
            set
            {
                this.doneDate = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DoneDate"));
                }
            }
        }
        public string ToDoDescription
        {
            get { return this.toDoDescription; }
            set
            {
                this.toDoDescription = value;
                if (PropertyChanged != null)
                {
                    this.modifiedDate = DateTime.Now.ToString();
                    PropertyChanged(this, new PropertyChangedEventArgs("ToDoDescription"));
                }
            }
        }
        public bool IsDone
        {
            get
            {
                this.isDone = (this.doneDate != null);
                return this.isDone;
            }
        }

        #endregion
        #region Construction
        public ToDoItem()
        {
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
    }
}