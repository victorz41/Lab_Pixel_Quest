using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public int coinCount = 0;

    public int Health = 3;

    public Transform Respawn_point;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) {
            switch (collision.tag)
            {
            case "Respawn":
                {
                    Respawn_point.position = collision.transform.Find("point").position;
                    break;
                }
                case "Death":
                    {
                        Health--;
                        if (Health == 0)
                        {
                            string thisLevel = SceneManager.GetActiveScene().name;
                            SceneManager.LoadScene(thisLevel);
                        }
                        else
                        {
                            transform.position = Respawn_point.position;
                        }
                       break;
                    
                    }
                case "Finish":
                    {
                        string nextLevel = collision.GetComponent<LevelGoal>().nextLevel;
                        SceneManager.LoadScene(nextLevel);
                        break;
                    }
                case "Coin":
                    {
                        coinCount++;
                        Destroy(collision.gameObject);
                        break;
                }
                case "Health":
                    {
                        if (Health < 3)
                        {
                            Destroy(collision.gameObject);
                            Health++;
                        }
                        break;
                    }

        }

        }

        // Update is called once per frame
        void Update()
    {
        
    }
}
