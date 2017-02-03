using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ToDoListWPF.ClientSettings;
namespace ToDoListWPF
{
    public class ToDoList : INotifyPropertyChanged
    {
        #region Variables
        private XDocument toDoListFile;
        private XElement toDoElement;
        private Settings clientSettings;
        private List<ToDoItem> items;
        #endregion
        #region Properties
        public List<ToDoItem> Items
        {
            get
            {
                return items;
            }
        }
        #endregion
        #region Construction
        public ToDoList()
        {
            clientSettings = new Settings();
            this.items = new List<ToDoItem>();
            if (File.Exists(clientSettings.ToDoListFile))
            {
                toDoListFile = XDocument.Load(clientSettings.ToDoListFile);
                var toDoListNode = toDoListFile.Descendants("ToDoList");
                List<XElement> toDoElement = toDoListNode.Descendants("Item").ToList<XElement>();
                foreach (XElement item in toDoElement)
                {
                    items.Add(new ToDoItem()
                    {
                        ToDoID = Int32.Parse(item.Element("ToDoID").Value),
                        CreationDate = item.Element("CreationDate").Value,
                        ModifiedDate = item.Element("ModifiedDate").Value,
                        ToDoDescription = item.Element("ToDoDescription").Value
                    });
                }
            }
        }
        #endregion

        public void Add(string description)
        {
            ToDoItem item = new ToDoItem();
            Random rndm = new Random();
            item.ToDoID = rndm.Next();
            item.CreationDate = DateTime.Now.ToString();
            item.ModifiedDate = DateTime.Now.ToString();
            item.ToDoDescription = description;
            this.items.Add(item);
            //Settings clientSettings = new Settings();
            //if (File.Exists(clientSettings.ToDoListFile))
            //{
            //	this.toDoListFile = XDocument.Load(clientSettings.ToDoListFile);
            //	XElement newNode = CreateItemNode(item);
            //	toDoListFile.Element("ToDoListWPF").Element("ToDoList").Add(newNode);
            //	toDoListFile.Save(clientSettings.ToDoListFile);
            //}
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Items"));
            }
        }
        #region Methods

        public void Delete(ToDoItem item)
        {
            this.items.Remove(item);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Items"));
            }
        }
        public void Save()
        {
            if (File.Exists(clientSettings.ToDoListFile))
            {
                //clean
                toDoListFile.Element("ToDoListWPF").Element("ToDoList").RemoveAll();
                //update latest
                foreach (ToDoItem item in this.items)
                {
                    XElement newNode = CreateItemNode(item);
                    toDoListFile.Element("ToDoListWPF").Element("ToDoList").Add(newNode);
                }
                this.toDoListFile.Save(this.clientSettings.ToDoListFile);
            }
        }
        private XElement CreateItemNode(ToDoItem item)
        {
            XElement itemNode = new XElement("Item",
                new XElement("ToDoID", item.ToDoID),
                new XElement("CreationDate", item.CreationDate),
                new XElement("ModifiedDate", item.ModifiedDate),
                new XElement("DoneDate", item.DoneDate),
                new XElement("ToDoDescription", item.ToDoDescription),
                new XElement("IDone", item.IsDone)
            );
            return itemNode;
        }
        #endregion
        #region InterfaceImplementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

    }
}