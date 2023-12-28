using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace MyTools
{
    public class ObjectRenamerwindow : EditorWindow
    {
        #region Variables
        public static ObjectRenamerwindow win;
        GameObject[] selectedgm = new GameObject[0];
        string wantedprefix;
        string wantedsuffix;
        string wantedname;
        bool addNumbering;
        #endregion

        #region Main Methods
        public static void LaunchRenamerWindow()
        {
            win = EditorWindow.GetWindow<ObjectRenamerwindow>("Rename Objects");
            win.Show();
        }

        private void OnGUI()
        {
            selectedgm = Selection.gameObjects;
            EditorGUILayout.Space(5);
            EditorGUILayout.LabelField("Selected Objects :-" + selectedgm.Length.ToString("000"));
            EditorGUILayout.Space(10);

            EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);            
            EditorGUILayout.BeginVertical();     
            
            EditorGUILayout.Space(10);            
            wantedprefix=EditorGUILayout.TextField("Prefix:-", wantedprefix,EditorStyles.miniTextField,GUILayout.ExpandWidth(true));
            wantedsuffix=EditorGUILayout.TextField("Suffix:-", wantedsuffix, EditorStyles.miniTextField, GUILayout.ExpandWidth(true));
            wantedname=EditorGUILayout.TextField("Name:-", wantedname, EditorStyles.miniTextField, GUILayout.ExpandWidth(true));
            EditorGUILayout.Space(10);
            
            addNumbering=EditorGUILayout.Toggle("Add numbering? ",addNumbering);

            if (GUILayout.Button("Rename Selected Object", GUILayout.Height(35), GUILayout.ExpandWidth(true)))
            {
                renameObjects();
            }

            EditorGUILayout.EndVertical();            
            EditorGUILayout.EndHorizontal();

            

            Repaint();
        }
        #endregion

        #region Custom Methods
        void renameObjects()
        {
            if(selectedgm.Length==0){ customDebug("Please select at least one gameobject !"); return; }

            if (addNumbering)
            {
                for (int i = 0; i < selectedgm.Length; i++)
                {
                    selectedgm[i].transform.name = wantedprefix + "_" + wantedname + "_" + wantedsuffix+"_"+i;
                }
            }
            else
            {
                for (int i = 0; i < selectedgm.Length; i++)
                {
                    selectedgm[i].transform.name = wantedprefix + "_" + wantedname + "_" + wantedsuffix;
                }
            }

            
        }

        void customDebug(string eMassage)
        {
            EditorUtility.DisplayDialog("Rename objects", eMassage, "Ok");
        }
        #endregion
    }
}
