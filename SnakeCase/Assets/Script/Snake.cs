using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Snake : MonoBehaviour
{
    //get script
    HighscoreTable highscore;
    Eat object_eat;

    //cas == kuyruk
    public GameObject cas;

    List<GameObject> cas_s;
    Vector3 old_position;
    GameObject remove_cas;


    public float speed;



    int i = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "eat")
        {
            GameObject new_cas = Instantiate(cas, old_position, Quaternion.identity);
            cas_s.Add(new_cas);
        }

        if (other.gameObject.tag == "cas" || other.gameObject.tag == "dvr")
        {
            Debug.Log(i);
            if (i < 1)
            {

                i++;
                if (object_eat.score > 0)
                {
                    highscore.AddHighscoreEntry(object_eat.score);
                }

            }
            SceneManager.LoadScene(0);




        }
    }


    private void Start()
    {
        highscore = GameObject.FindObjectOfType<HighscoreTable>();
        object_eat = GameObject.FindObjectOfType<Eat>();

        cas_s = new List<GameObject>();

        for (int i = 0; i <= 3; i++) 
        {
            GameObject new_cas = Instantiate(cas, old_position, Quaternion.identity);
            cas_s.Add(new_cas);
        }

        InvokeRepeating("move", 0, .2f);
    }
    void move()
    {


        old_position = transform.position;
        transform.Translate(0, 0, speed * Time.deltaTime);

        if (cas_s.Count > 0)
        {
            cas_s[0].transform.position = old_position;


            remove_cas = cas_s[0];
            cas_s.RemoveAt(0);
            cas_s.Add(remove_cas);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0, 90, 0);
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0, -90, 0);
        }
    }
}
