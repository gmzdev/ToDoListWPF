using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ToDoListWPF.ClientSettings
{
    public class Paths
    {
        public static string ToDoListSubDirectory = "ToDoList";
        public static string ExecutionFolder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    }
    public class LegacyPaths
    {
        /// <summary>
        /// Gets the user's AppData\Local directory.
        /// </summary>
        /// <returns>User's AppData\Local directory.</returns>
        /// <remarks></remarks>
        public static string LocalAppData()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }
        /// <summary>
        /// Gets the user's AppData\Roaming directory.
        /// </summary>
        /// <returns>User's AppData\Roaming directory.</returns>
        /// <remarks></remarks>
        public static string AppData()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }
    }
}