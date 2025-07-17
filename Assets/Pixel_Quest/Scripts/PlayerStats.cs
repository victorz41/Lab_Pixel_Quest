using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public string nextLevel = "GeoLevel_2";
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) {
            switch (collision.tag)
            {
                case "Death":
                    {
                        string thisLevel = SceneManager.GetActiveScene().name;
                        SceneManager.LoadScene(thisLevel);
                        break;
                    }
                case "Finish":
                    {
                        SceneManager.LoadScene(nextLevel);
                        break;
                    }

            }

        }

        // Update is called once per frame
        void Update()
    {
        
    }
}
