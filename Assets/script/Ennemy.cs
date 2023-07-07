using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ennemy : MonoBehaviour
{

    public int life = 10;
    public Image image;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
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
}
