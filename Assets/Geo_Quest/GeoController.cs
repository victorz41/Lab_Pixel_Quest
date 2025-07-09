using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeoController : MonoBehaviour
{
    int var1 = 1;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        print(var1);
        var1++;
    }
}
