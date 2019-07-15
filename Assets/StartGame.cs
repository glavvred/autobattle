using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //я бы прям тут всю загрузку и делал
        var ip = new InputParser(this.gameObject);
        ip.JsonParse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
