using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public  int PlayerScoreL = 0;
    public  int PlayerScoreR = 0;
    public GameObject P1WiN;
    public GameObject P2WiN;
    public GameObject Backbutton;

    public GameObject trigL;
    public GameObject trigR;
    //public SideWall[] sideWalls;

    //Buat UI Text
    public TMP_Text txtPlayerScoreL;
    public TMP_Text txtPlayerScoreR;
    
    public static GameManager instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //Mengisikan nilai integer PlayerScore ke UI
        //sideWalls = FindObjectsOfType<SideWall>();

        txtPlayerScoreL.text = PlayerScoreL.ToString();
        txtPlayerScoreR.text = PlayerScoreR.ToString();
    }


    //Method penyeleksi untuk menambah score
    public void Score(string wallID)
    {
        if (wallID == "trigL")
        {
            PlayerScoreR = PlayerScoreR + 10; //Menambah score
            txtPlayerScoreR.text = PlayerScoreR.ToString(); //Mengisikan nilai integer PlayerScore ke UI
        }
        else
        {
            PlayerScoreL = PlayerScoreL + 10;
            txtPlayerScoreL.text = PlayerScoreL.ToString();  
        }
        ScoreCheck();
    }
    public void ScoreCheck()
    {
        if (PlayerScoreL == 20)
        {
            Debug.Log("playerL win");
            P1WiN.SetActive(true);
            Backbutton.SetActive(true);

            BoxCollider2D kiri = trigL.GetComponent<BoxCollider2D>();
            kiri.isTrigger = false;

            BoxCollider2D kanan = trigR.GetComponent<BoxCollider2D>();
            kanan.isTrigger = false;

            // trigL.SetActive(true);
            // sideWalls[0].enabled = false;
            // sideWalls[1].enabled = false;
            // foreach(SideWall a in sideWalls){

            //     a = GetComponent<SideWall>();
            //     a.enabled = false;
            // }
            //this.gameObject.SendMessage("ChangeScene","MainMenu");
        }
        else if (PlayerScoreR == 20)
        {
            Debug.Log("playerR win");
            P2WiN.SetActive(true);
            Backbutton.SetActive(true);
            
            BoxCollider2D kiri = trigL.GetComponent<BoxCollider2D>();
            kiri.isTrigger = false;

            BoxCollider2D kanan = trigR.GetComponent<BoxCollider2D>();
            kanan.isTrigger = false;
            // trigR.SetActive(true);
            // sideWalls[0].enabled = false;
            // sideWalls[1].enabled = false;
            // foreach(SideWall a in sideWalls){

            //     a = GetComponent<SideWall>();
            //     a.enabled = false;
            // }
            //this.gameObject.SendMessage("ChangeScene", "MainMenu");
        }
    }

}