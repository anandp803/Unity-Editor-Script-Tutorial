using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace MyTools
{
    public class ProjectSetUpToolsWindow : EditorWindow
    {

        #region variables
        public static ProjectSetUpToolsWindow win;
        private string GameName = "Game";
        #endregion

        #region main methods
        public static void initWindow()
        {
            win = EditorWindow.GetWindow<ProjectSetUpToolsWindow>("Project SetUp");
            win.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();           
            GameName = EditorGUILayout.TextField("Game name :-",GameName);
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Create Project Structure ",GUILayout.Height(35),GUILayout.ExpandWidth(true)))
            {                
                createFolderStructure();
            }

            if (win!=null)
            {
                win.Repaint();
            }

        }
        #endregion

        #region custom method
        void createFolderStructure()
        {

            if (string.IsNullOrEmpty(GameName))
            {
                return;
            }

            if (GameName == "Game")
            {
                if (!EditorUtility.DisplayDialog("Project SetUp Warning !", "Do you really want to call you project Game?", "Yes", "No"))
                {
                    return;
                }
            }
            string assetsPath = Application.dataPath;            
            string rootpath = assetsPath + "/" + GameName;
            DirectoryInfo roothPathInfo= Directory.CreateDirectory(rootpath);

            if (!roothPathInfo.Exists)
            {
                Debug.Log("Folder "+ rootpath +"does not exists.");
                return;
            }

            createSubDirectory(rootpath);

            AssetDatabase.Refresh();
            close();
            Debug.Log("Folder Structure Created !!!");
        }

        void createSubDirectory(string rootpath)
        {
            DirectoryInfo SubFolderPath = null;
            List<string> folderNames = new List<string>();
            SubFolderPath= Directory.CreateDirectory(rootpath+"/Arts");

            if (SubFolderPath.Exists)
            {
                folderNames.Clear();
                folderNames.Add("Textures");
                folderNames.Add("Materials");
                folderNames.Add("Mesh");
                folderNames.Add("Sprites");

                createfolders(rootpath + "/Arts", folderNames);
            }       

        }

        void createfolders(string path,List<string> folderNames)
        {
            foreach (var item in folderNames)
            {
                Directory.CreateDirectory(path + "/" + item);
            }
        }

        void close()
        {
            if (win)
            {
                win.Close();
            }
        }
        #endregion
    }
}
