using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{


    public TMPro.TextMeshProUGUI score_txt;
    public GameObject doublepoint_txt;



    [Header("Score")]
    public int score;
    [Header("Score up value")]
    public int score_up;


    [Header ("Map size for eat")]
    public float mapsize_minx;
    public float mapsize_maxx;
    public float mapsize_minz;
    public float mapsize_maxz;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("control" , 0, 10.0f);



        //InvokeRepeating("currentHighScore", 0, .1f);

    }
    private void Update()
    {
        //currentHighScore();

    }
    /*
    void currentHighScore()
    {
        if (score > PlayerPrefs.GetInt("CurrentHighScore"))
        {
            PlayerPrefs.SetInt("CurrentHighScore", score);
        }
    }
    */

    //her beþ saniyede pozisyon deðiþicek
    void control()
    {
        float x = Random.Range(-mapsize_minx, mapsize_maxx);
        float z = Random.Range(mapsize_minz, mapsize_maxz);



        int rnd = Random.Range(1, 7);


        if (rnd == 2 || rnd == 4 || rnd == 6)
        {
            doublepoint_txt.SetActive(true);
        }
        else
        {
            doublepoint_txt.SetActive(false);
        }

        Vector3 go = new Vector3(x, 0, z);
        transform.position = go;
    }

    //cancelýnvoke eðer ilk method 3 saniyede ise tekrar baþladýðýnda 2 sanýyede baþlýcak
    //baþtan baþlamasý için çýkýp baþlatýyoruz

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CancelInvoke();
            InvokeRepeating("control", 0, 5);

            if (doublepoint_txt.gameObject.activeSelf == true)
            {
                score += (score_up * 2);
            }
            else
            {
                score += score_up;
            }
            score_txt.text = "Skor : " + score;
        }
        if (other.gameObject.tag == "cas")
        {
            CancelInvoke();
            InvokeRepeating("control", 0, 5);
        }
    }
}
