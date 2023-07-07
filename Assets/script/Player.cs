using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public GameObject self;
    public int energy;
    public int[] actualCase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void move(Vector2 destination,int[] destinationCaseTab){
        
        if(energy > 0 && isAtRange(destinationCaseTab)){
            self.transform.position = new Vector3(destination.x,destination.y,-1);
            energy = energy-1;
            actualCase = destinationCaseTab;
        }else{
            print("je n'ai plus d'energie ou la case n'est pas a coté");
        }    
    }

    public bool isAtRange(int[] destinationCaseTab){
        
        int[] up = new int[]{ actualCase[0]+1,actualCase[1] };
        int[] down = new int[]{ actualCase[0]-1,actualCase[1] };
        int[] left = new int[]{ actualCase[0],actualCase[1]-1 };
        int[] right = new int[]{ actualCase[0],actualCase[1]+1 };
        
        int[][] possibility = new int[][] {up,down, left,right};
        
        bool containsDestination = Array.Exists(possibility, possibilityItem =>
        possibilityItem[0] == destinationCaseTab[0] && possibilityItem[1] == destinationCaseTab[1]);
       
        return containsDestination;
        
    }

    public void attack(int[] destinationAttack){
        bool isRangeOk = isAtRange(destinationAttack);
    }
}
