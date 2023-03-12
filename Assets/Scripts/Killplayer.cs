using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killplayer : MonoBehaviour
{
    public int respawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.CompareTag("Player"))
        {
            Reset();
        }
    }
}
