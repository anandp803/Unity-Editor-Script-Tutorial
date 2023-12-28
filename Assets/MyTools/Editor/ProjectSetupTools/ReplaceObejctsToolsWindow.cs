using UnityEditor;
using UnityEngine;

namespace MyTools
{
    public class ReplaceObejctsToolsWindow : EditorWindow
    {
        #region variables
        public static ReplaceObejctsToolsWindow win;
        int SelectedGameobjectscount=0;
        private GameObject targetObject;
        #endregion


        #region Main Methods
        public static void initWindow()
        {
            win = EditorWindow.GetWindow<ReplaceObejctsToolsWindow>("Replace Objects");
            win.Show();
        }

        private void OnGUI()
        {
            SelectedGameobjectscount=getSelectedGmCount();
            EditorGUILayout.BeginVertical();
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Selected objects :- "+SelectedGameobjectscount.ToString(),EditorStyles.boldLabel);
            EditorGUILayout.Space();
            targetObject = EditorGUILayout.ObjectField("Replace Object:- ",targetObject, typeof(GameObject), true) as GameObject;
            EditorGUILayout.Space();
            EditorGUILayout.EndVertical();

            if (GUILayout.Button("Replace Selected Object ", GUILayout.Height(35), GUILayout.ExpandWidth(true)))
            {
                replaceSelectedObject();
            }

            if (win != null)
            {
                win.Repaint();
            }

        }
        #endregion

        #region Custom methods
        int getSelectedGmCount()
        {
            return Selection.gameObjects.Length;
        }

        void replaceSelectedObject()
        {
            if (SelectedGameobjectscount==0)
            {
                customDispalyDialog("At least select one object");
                return;
            }

            if(!targetObject)
            {
                customDispalyDialog("At least assign one gameobject");
                return;
            }

            //replace object
            GameObject[] selectedObject = Selection.gameObjects;
            for (int i = 0; i < selectedObject.Length; i++)
            {
                Transform selectedObjectTransform = selectedObject[i].transform;
                GameObject newobject = Instantiate(targetObject, selectedObjectTransform.position,selectedObjectTransform.rotation);
                newobject.transform.localScale=selectedObjectTransform.localScale;
                newobject.name=targetObject.name;

                DestroyImmediate(selectedObject[i]);
            }
        }

        void customDispalyDialog(string eMassage)
        {
            EditorUtility.DisplayDialog("Replace Object Warning :- ",eMassage,"ok");
        }
        #endregion
    }
}
