using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class MenuFunctions {
    [MenuItem("Tools/Maze Generator/Set-up Generator")]
    public static void SetUp () {
        EditorWindow.GetWindow(typeof(SetUpWindow));
    }

    [MenuItem("Tools/Maze Generator/Generate a maze")]
    public static void Init () {
        GeneratorBaseClass generator = GameObject.FindObjectOfType<GeneratorBaseClass>();
        if (generator == null)
            Debug.Log("Please SetUpGenerator First");
        else
            generator.Init();
       }

    [MenuItem("Tools/Maze Generator/Reset Generator")]
    public static void Reset()
    {
        GeneratorBaseClass generator = GameObject.FindObjectOfType<GeneratorBaseClass>();
        if (generator == null)
            Debug.Log("Please SetUpGenerator First");
        else
            generator.ResetGenerator();
    }





    internal class SetUpWindow : EditorWindow {
        [SerializeField]
        int width;
        [SerializeField]
        int heigh;
        [SerializeField]
        CellInterface cellGameObject;
        private GameObject source;
        private bool configurated = false;
        private string result="";


        void OnGUI () {

            GeneratorBaseClass generator = GameObject.FindObjectOfType<GeneratorBaseClass>();
            if (generator != null && width==0 && heigh == 0)
            {
                configurated = true;
                width = generator.width;
                heigh = generator.heigh;
                cellGameObject = generator.cellGameObject;
            }

            EditorGUILayout.LabelField("Data to generate a maze: ", EditorStyles.boldLabel);
            EditorGUILayout.Separator();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Maze Width(number of cells horizontally): ");
            width = EditorGUILayout.IntField(width);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Maze Height(number of cells vertically): ");
            heigh = EditorGUILayout.IntField(heigh);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Separator();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Base cell for the Maze: ");
            source = EditorGUILayout.ObjectField(source, typeof(Object), true) as GameObject;
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("->")) {
                if (source.GetComponent<CellInterface>() != null)
                {
                    cellGameObject = source.GetComponent<CellInterface>();
                    
                }
                else
                    result = "The cell must contain a CellInterfaceComponent.";
                if (configurated)
                {
                    generator.width = width;
                    generator.heigh = heigh;
                    generator.cellGameObject = cellGameObject;
                } else {
                    GeneratorBaseClass.LaunchGenerator(cellGameObject, width, heigh);
                    configurated = true;
                }
                
            } 

            if (configurated) {
                result="Labyrinth generator builded, you can build a lot of laberinths and store as prefabs or use the GameObject with the Generator to build diferent mazes in each execution.";
                if (GUILayout.Button("Generate Maze")) {
                    Init();
                }
            }
            EditorGUILayout.Separator();
            EditorGUILayout.LabelField(result, EditorStyles.boldLabel);
        }




    }  

}