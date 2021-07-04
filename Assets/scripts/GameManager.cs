using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int block_count=0;
   
    [Range(-1, 1)] public int block_level=0;
    public Sprite[] block_sprites;
    [SerializeField] AudioClip[] audios;
    public bool gamestart;
    public int score;
    public int difficulty;


    void Start()
    {
        scene_control();
    }

    
    void Update()
    {
      
    }
    public void nextlevel()
    {
        
        if (block_count==0)
        {
            
            int activelevel = PlayerPrefs.GetInt("lastscene1");
            activelevel++;
            if (activelevel>SceneManager.sceneCountInBuildSettings-1)
            {
                activelevel = Random.Range(0, SceneManager.sceneCountInBuildSettings-1);
            }
            PlayerPrefs.SetInt("lastscene1", activelevel);
            SceneManager.LoadScene("episode" + activelevel);
            

        }
    }
    public void Dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void playaudio()
    {
        int x = Random.Range(0, 5);
        GetComponent<AudioSource>().PlayOneShot(audios[x]);
    }

    private void scene_control()
    {
        int activelevel = PlayerPrefs.GetInt("lastscene1");
        if (SceneManager.GetActiveScene().name!="episode"+activelevel)
        {

            SceneManager.LoadScene("episode" + activelevel);
        }
        
       

    }
}
