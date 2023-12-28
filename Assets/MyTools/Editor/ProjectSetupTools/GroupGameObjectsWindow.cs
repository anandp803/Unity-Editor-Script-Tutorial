using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MyTools
{
    public class GroupGameObjectsWindow :EditorWindow
    {

        #region variables
        public static GroupGameObjectsWindow win;
        private int selectedObjcount=0;
        private string GrouprParentGmName;
        #endregion

        #region main methods
        public static void LaunchObjectGroupWindow()
        {
           win = EditorWindow.GetWindow<GroupGameObjectsWindow>();
           win.Show();

        }

        private void OnGUI()
        {
            selectedObjcount = getSelectedObjectCount();

            EditorGUILayout.LabelField("Selected gameobjects count:- " + selectedObjcount);
            EditorGUILayout.Space(10);
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.Space(10);
            GrouprParentGmName=EditorGUILayout.TextField("Group gameobject name :- ", GrouprParentGmName);
            if (GUILayout.Button("Group gameobjects",GUILayout.MinHeight(35),GUILayout.ExpandWidth(true)))
            {
                groupGameobjects();
            }
            EditorGUILayout.Space(10);
            EditorGUILayout.EndVertical();
            
            Repaint();  
        }
        #endregion

        #region custom methods
        void groupGameobjects()
        {
            if (string.IsNullOrEmpty(GrouprParentGmName))
            {
                EditorUtility.DisplayDialog("Group gameobjects", "Please give name for parent gameobjects", "Ok");
                return;
            }

            GameObject[] SelectedgameObjects = Selection.gameObjects;
            GameObject NewGm = new GameObject();
            NewGm.name = GrouprParentGmName;
            for (int i = 0; i < SelectedgameObjects.Length; i++)
            {
                SelectedgameObjects[i].transform.parent = NewGm.transform;
            }
        }

        int getSelectedObjectCount()
        {
            return Selection.gameObjects.Length;
        }
        #endregion
    }
}