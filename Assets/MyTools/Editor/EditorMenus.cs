using UnityEditor;
using UnityEngine;

namespace MyTools
{
    public class EditorMenus
    {
        [MenuItem("Mytools/ProjectSetUpTools/Create")]
        public static void CreateFolderStructure()
        {
            //Debug.Log("Folder Structure Created !!");
            ProjectSetUpToolsWindow.initWindow();
        }

        [MenuItem("Mytools/ProjectSetUpTools/ReplaceObjectMenu")]
        public static void ReplaceObjects()
        {
            Debug.Log("Replacement of objects Done !!");  
            ReplaceObejctsToolsWindow.initWindow();
        }


        [MenuItem("Mytools/ProjectSetUpTools/ObjectRenamer")]
        public static void ObjectRenamer()
        {
            Debug.Log("Replacement of objects Done !!");
            ObjectRenamerwindow.LaunchRenamerWindow();
        }

        [MenuItem("Mytools/ProjectSetUpTools/GroupObjects")]
        public static void GroupObjects()
        {
            Debug.Log("Replacement of objects Done !!");
            GroupGameObjectsWindow.LaunchObjectGroupWindow();
        }
    }
}
