using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyDesigner : EditorWindow
{
    public Texture2D headersectionTexture;
    public Texture2D magesectionTexture;
    public Texture2D rougesectionTexture;
    public Texture2D worriorSectionTexture;

    public Color headersectionColor=new Color(13f/255f,32f/255f,44f/255f,1f);

    GUIStyle style;

    Rect headerSection;
    Rect rougeSection;
    Rect worriorSection;
    Rect mageSection;


    [MenuItem("Mytools/EnemyDesigner")]
    static void OpenWindow()
    {
        EnemyDesigner window = (EnemyDesigner)GetWindow(typeof(EnemyDesigner));
        window.minSize = new Vector2(500f,600f);
        window.Show();
        Debug.Log("Window Opened");
    }

    /// <summary>
    /// Onenable method
    /// </summary>
    private void OnEnable()
    {
        Debug.Log("OnEnable");
        InitTextures();
    }
    /// <summary>
    /// 
    /// </summary>
    private void InitTextures()
    {    
        headersectionTexture = new Texture2D(1,1);
        headersectionTexture.SetPixel(0,0,headersectionColor);
        headersectionTexture.Apply();

        magesectionTexture = Resources.Load<Texture2D>("sprites/SKYBLUE");        
        worriorSectionTexture = Resources.Load<Texture2D>("sprites/YELLOW");
        rougesectionTexture = Resources.Load<Texture2D>("sprites/RED");

    }
    /// <summary>
    /// 
    /// </summary>
    private void OnGUI()
    {
        style = new GUIStyle(EditorStyles.label);
        style.normal.textColor = Color.white;
        style.fontStyle = FontStyle.Bold;
        DrawLayouts();
        DrawHeadaer();
        DrawMagesettings();
        DrawRougeSettings();
        DrawworriorSettings();
    }
    /// <summary>
    /// 
    /// </summary>
    void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = Screen.width;
        headerSection.height = 50;

        mageSection.x = 0;
        mageSection.y = 50;
        mageSection.width = Screen.width/3f;
        mageSection.height = Screen.height-50f;

        worriorSection.x = Screen.width / 3f ;
        worriorSection.y = 50;
        worriorSection.width = Screen.width / 3f;
        worriorSection.height = Screen.height - 50f;

        rougeSection.x = Screen.width / 3f * 2f;
        rougeSection.y = 50;
        rougeSection.width = Screen.width / 3f;
        rougeSection.height = Screen.height - 50f;

        

        GUI.DrawTexture(headerSection,headersectionTexture);
        GUI.DrawTexture(mageSection, magesectionTexture);        
        GUI.DrawTexture(worriorSection, worriorSectionTexture);
        GUI.DrawTexture(rougeSection, rougesectionTexture);

    }

    void DrawHeadaer()
    {
        GUILayout.BeginArea(headerSection);       
        GUILayout.Label("Enemy Designer", style);

        GUILayout.EndArea();
    }

    /// <summary>
    /// 
    /// </summary>
    void DrawMagesettings()
    {
        GUILayout.BeginArea(mageSection);       
        style.normal.textColor = Color.black;   
        GUILayout.Label("Mage", style);
        GUILayout.EndArea();

    }
    /// <summary>
    /// 
    /// </summary>
    void DrawRougeSettings()
    {
        GUILayout.BeginArea(rougeSection);        
        style.normal.textColor = Color.black;
        GUILayout.Label("rouge",style);        
        GUILayout.EndArea();
    }
    /// <summary>
    /// 
    /// </summary>
    void DrawworriorSettings()
    {
        GUILayout.BeginArea(worriorSection);        
        style.normal.textColor = Color.black;
        GUILayout.Label("worrior",style);
        GUILayout.EndArea();
    }
}
