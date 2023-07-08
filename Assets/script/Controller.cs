using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Random;

public class Controller : MonoBehaviour
{

    public GameObject player;
    public GameObject ennemy;
    public Button passif;
    public Button basicAttack;
    public Button dash;
    public Button buff;
    public Button ult;
    public Mode mode = Mode.Deplacement;
    public GameObject[] plateau;
   

    public Player playerScript;
    public Ennemy ennemyScript;
    

    public enum Mode
    {
        Deplacement,
        basicAttack,
        dash,
        buff,
        ult,
    }

    public void ennemyAttack(){
        playerScript.life = playerScript.life - (Range(1,6)+1);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<Player>();
        ennemyScript = ennemy.GetComponent<Ennemy>();
        plateau = GameObject.FindGameObjectsWithTag("case");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerBasicAttack(){
        mode = Mode.basicAttack;
        print(mode);
    }

    public void endOfTurn(){
        //tour de l'adversaire
        ennemyScript.myTurn(playerScript.actualCase, plateau);
        
    }
}
