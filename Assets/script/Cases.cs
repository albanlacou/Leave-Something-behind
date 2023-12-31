using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class Cases : MonoBehaviour
{
    public Vector2 positionInSpace;
    public int[] positionInTab;
    public GameObject self;
    public GameObject player;
    public GameObject controller;
    public Controller controllerScript;
    public Player playerScript;
    public GameObject objectOnCase; 
    

    void Start(){
        controllerScript = controller.GetComponent<Controller>();
        playerScript = player.GetComponent<Player>();
        positionInSpace.x = self.transform.position.x;
        positionInSpace.y = self.transform.position.y;
    }

void OnMouseDown(){
            
        if(Input.GetMouseButtonDown(0)){
            switch (controllerScript.mode)
            {
                case Controller.Mode.Deplacement:
                    playerScript.move(positionInSpace,positionInTab);
                    break;
                case Controller.Mode.basicAttack:
                    bool isRanged = playerScript.isAtRange(positionInTab);
                    print(isRanged);
                    if(isRanged && objectOnCase){
                        
                        if(objectOnCase.GetComponent<Ennemy>()){

                            foreach(var artifact in playerScript.artifacts)
                            {
                                artifact.doEffect(playerScript);
                            }
                            int randomNumber = Range(1,6)+ playerScript.attackValue;
                            print(randomNumber);
                            objectOnCase.GetComponent<Ennemy>().takeDamage(randomNumber);
                            foreach (var artifact in playerScript.artifacts)
                            {
                                artifact.undoEffect(playerScript);
                            }

                        }
                        else{
                            return;
                        }
                    }
                    
                    break;
                default:
                    break;
            }
            
                
                
                
        }

    void Update(){
    
        
    }
}
}
