using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;
namespace ToDoListWPF.ClientSettings
{
    public class Settings
    {
        #region Variables
        private string toDoListFile;
        private string baseSettingsFile = System.IO.Path.Combine(Paths.ExecutionFolder, "BaseToDoList.xml");
        private string applicationFolder;
        #endregion

        #region Properties
        public string ToDoListFile
        {
            get { return this.toDoListFile; }
        }
        public string ApplicationFolder
        {
            get { return this.applicationFolder; }
        }
        #endregion

        #region Construction
        public Settings()
        {


            if (this.applicationFolder == null)
            {
                this.applicationFolder = System.IO.Path.Combine(LegacyPaths.AppData(), AppInfo.ApplicationAssemblyName);

                this.TryCreateApplicationFolder();

                this.toDoListFile = System.IO.Path.Combine(ApplicationFolder, "ToDoList.xml");

                // Check if ToDoList.xml exists in the given path. If not,
                // create a new Settings.xml based on BaseSettings.xml
                if (!File.Exists(this.toDoListFile))
                {
                    File.Copy(this.baseSettingsFile, this.toDoListFile);
                }
            }
        }
        #endregion

        #region Methods
        private void TryCreateApplicationFolder()
        {
            if (!Directory.Exists(this.ApplicationFolder))
            {
                Directory.CreateDirectory(this.ApplicationFolder);
            }
        }
        #endregion
    }
}