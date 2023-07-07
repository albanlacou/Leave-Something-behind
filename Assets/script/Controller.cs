using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Controller : MonoBehaviour
{

    public GameObject player;
    public Button passif;
    public Button basicAttack;
    public Button dash;
    public Button buff;
    public Button ult;
    public Mode mode = Mode.Deplacement;
    

    public enum Mode
    {
        Deplacement,
        basicAttack,
        dash,
        buff,
        ult,
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerBasicAttack(){
        mode = Mode.basicAttack;
        print(mode);
    }
}
