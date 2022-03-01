using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject Rock;
    public GameObject Brick;
    public GameObject QuestionBox;
    public GameObject Stone;
    public GameObject Lava;
    public GameObject Spawn;
    public GameObject Goal;
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
                //By default lets set it to be the floor 
                // Instantiate a new GameObject that matches the type specified by letter
                // Position the new GameObject at the appropriate location by using row and column
                if (letter == 'x')
                {
                    var thing = Instantiate(Rock);
                    thing.transform.position = new Vector3(column, row, 0f);   
                }else if (letter == '?')
                {
                    var thing = Instantiate(QuestionBox);
                    thing.transform.position = new Vector3(column, row, 0f);
                }else if (letter == 'b')
                {
                    var thing = Instantiate(Brick);
                    thing.transform.position = new Vector3(column, row, 0f);
                }else if (letter == 's')
                {
                    var thing = Instantiate(Stone);
                    thing.transform.position = new Vector3(column, row, 0f);
                }else if (letter == 'l')
                {
                    var thing = Instantiate(Lava);
                    thing.transform.position = new Vector3(column, row, 0f);
                }else if (letter == 's')
                {
                    var thing = Instantiate(Spawn);
                    thing.transform.position = new Vector3(column, row, 0f);
                }else if (letter == 'g')
                {
                    var thing = Instantiate(Goal);
                    thing.transform.position = new Vector3(column, row, 0f);
                }
                
                // Parent the new GameObject under levelRoot
                column++;
            }
            row++;
        }
    }
    // --------------------------------------------------------------------------
    public void ReloadLevel()
    {
        foreach (Transform child in levelRoot)
        {
           Destroy(child.gameObject);
        }

        FindObjectOfType<CoinManager>().restart();
        FindObjectOfType<ScoreManager>().restart();
        FindObjectOfType<TimeManager>().restart();
        LoadLevel();
    }
}
