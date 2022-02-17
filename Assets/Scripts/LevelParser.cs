using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using UnityEngine;
public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject Rock;
    public GameObject Brick;
    public GameObject QuestionBox;
    public GameObject Stone;
    public Transform levelRoot;
    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }
    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");
        
        Stack<string> levelRows = new Stack<string>();
        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }
            sr.Close();
        }
        // Go through the rows from bottom to top
        int row = 0;
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();
            int column = 0;
            char[] letters = currentLine.ToCharArray();
            foreach (var letter in letters)
            {
                var thing = Instantiate(Rock); //By default lets set it to be the floor 
                // Instantiate a new GameObject that matches the type specified by letter
                // Position the new GameObject at the appropriate location by using row and column
                if (letter == 'x')
                {
                    thing.transform.position = new Vector3(column, row, 0f);   
                }else if (letter == '?')
                {
                    thing = Instantiate(QuestionBox);
                    thing.transform.position = new Vector3(column, row, 0f);
                }else if (letter == 'b')
                {
                    thing = Instantiate(Brick);
                    thing.transform.position = new Vector3(column, row, 0f);
                }else if (letter == 's')
                {
                    thing = Instantiate(Stone);
                    thing.transform.position = new Vector3(column, row, 0f);
                }
                // Parent the new GameObject under levelRoot
                column++;
            }
            row++;
        }
    }
    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in levelRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
