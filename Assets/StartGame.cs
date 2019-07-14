using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var ip = new InputParser();
        ip.JsonParse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
