using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Ennemy : MonoBehaviour
{

    public int life = 25;
    public Image image;
    public Slider slider;
    public int energy = 5;
    public int[] position;
    public GameObject self;
    public GameObject controller;

    public Controller controllerScript;

    // Start is called before the first frame update
    void Start()
    {
        controllerScript = controller.GetComponent<Controller>();
        slider = image.GetComponent<Slider>();
        slider.maxValue = life;
        slider.value = life;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage){
        life -= damage;
        if(life>= 0){
            slider.value = life;
        }else{
            //il est mort
        }   
    }

    public void myTurn(int[] positionPlayer, GameObject[] plateau){
        if(isAtRange(positionPlayer)){
            //attack
            controllerScript.ennemyAttack();
            return;
        }
        //move
        int[] newPosTab = move(positionPlayer);
        Vector2 newPosSpace = transformTabInXYPos(newPosTab,plateau);
        self.transform.position = new Vector3(newPosSpace.x,newPosSpace.y,-1);
        StartCoroutine(ExampleCoroutine(positionPlayer,plateau));
        energy--;
        
    }

    public int[] move(int[] positionPlayer){
        
        int[] newPosition = new int[]{0,0};
        if(position[0] > positionPlayer[0]){// si la position vertical de l'ennemy est plus grande -> il est en dessous
            newPosition[0] = position[0]-1;
            newPosition[1] = position[1];
            print(position[0]-1);
            print("1");
            print("x: "+newPosition[1]);
           
        }else if(position[0] < positionPlayer[0]){// si la position vertical de l'ennemy est plus petite -> il est au dessus
            
            newPosition[0] = position[0]+1;
            newPosition[1] = position[1];
        }else if(position[1] < positionPlayer[1]){// si la position horizontal de l'ennemy est plus petite -> il est a gauche du joueur
            print("2");
            newPosition[0] = position[0];
            newPosition[1] = position[1]+1; 
            
        }else if(position[1] > positionPlayer[1]){// si la position horizontal de l'ennemy est plus grande -> il est a droite du joueur
            
            newPosition[0] = position[0];
            newPosition[1] = position[1]-1;
            
            
        }else{
            //attack
            print("attack");
        }
        return newPosition;

    }

    public Vector2 transformTabInXYPos(int[] newPos,GameObject[] plateau){
        ArrayList cases = new ArrayList();
        int i = 0;
        foreach(var gameObject in plateau)
        {
            
            cases.Add(gameObject.GetComponent<Cases>());
            
            i++;
        }
        
        foreach (var script in cases)
        {
            Cases test = script as Cases;
            //print("je suis y: "+test.positionInTab[0]+" et x: "+test.positionInTab[1]);
            //print("je suis y: "+newPos[0]+" et x: "+newPos[1]);
            if(test.positionInTab[0] == newPos[0] && test.positionInTab[1] == newPos[1]){
                position[0] = newPos[0];
                position[1] = newPos[1];
                return new Vector2(test.positionInSpace.x,test.positionInSpace.y);
            }
        }
        
        return new Vector2(0,0);
    }

    IEnumerator ExampleCoroutine(int[] positionPlayer, GameObject[] plateau)
    {
        

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        //After we have waited 5 seconds print the time again.
        if(energy > 0){
            myTurn(positionPlayer,plateau);
        }else{

        }
    }

    public bool isAtRange(int[] destinationCaseTab){
        
        int[] up = new int[]{ position[0]+1,position[1] };
        int[] down = new int[]{ position[0]-1,position[1] };
        int[] left = new int[]{ position[0],position[1]-1 };
        int[] right = new int[]{ position[0],position[1]+1 };
        
        int[][] possibility = new int[][] {up,down, left,right};
        
        bool containsDestination = Array.Exists(possibility, possibilityItem =>
        possibilityItem[0] == destinationCaseTab[0] && possibilityItem[1] == destinationCaseTab[1]);
       
        return containsDestination;
        
    }
}
