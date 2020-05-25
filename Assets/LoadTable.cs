using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class LoadTable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string text = File.ReadAllText("Assets/StreamingAssets/JsonChallenge.json");
        var N = JSON.Parse(text);
        for (int i = 0; i < 10; i++)
        {
            if (N["ColumnHeaders"][i] != null)
            {
                GameObject newGO = new GameObject("myTextGO");
                newGO.transform.SetParent(this.transform);
                newGO.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
                Vector3 temp = new Vector3(100.0f * i, 300.0f, 0);
                newGO.transform.position += temp;

                Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
                Text myText = newGO.AddComponent<Text>();
                myText.font = ArialFont;
                myText.text = N["ColumnHeaders"][i];
            }
        }
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (N["Data"][i][j] != null)
                {
                    GameObject newGO = new GameObject("myTextGO");
                    newGO.transform.SetParent(this.transform);
                    newGO.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
                    Vector3 temp = new Vector3(100.0f * j, 300.0f - 50.0f * (i + 1), 0);
                    newGO.transform.position += temp;

                    Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
                    Text myText = newGO.AddComponent<Text>();
                    myText.font = ArialFont;
                    myText.text = N["Data"][i][j];
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
