using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowanimation : MonoBehaviour
{
    public MeshRenderer[] Arrows; //getting all the mesh renderer of the arrows
    public List<Material> Defaultcolor = new List<Material>(); //list to store the materials of the arrows
    public Material Activatedcolor;  //material which contains the changed color
    public float time; //time between transition of the color

    private int index = 0; //index variable
    private float elapsedtime = 0; //variable for elapse time
    
    void Start()
    {
        //adding the default materials of arrows to the list
        for(int i = 0; i<Arrows.Length; i++)
        {
          Defaultcolor.Add(Arrows[i].material);
        }
    }

    private void Update()
    {
        //time check implementation
        if(elapsedtime > time)
        {
            //changing the color
            if(index != 0)
            {
                Arrows[index - 1].material = Defaultcolor[index - 1];
                Arrows[index].material = Activatedcolor;
            }
            else
            {
                Arrows[Arrows.Length-1].material = Defaultcolor[Arrows.Length-1];
                Arrows[index].material = Activatedcolor;
            }
           //changing the index
            if (index + 1 < Arrows.Length)
            {
                index++;
            }

            else
            {
                index = 0;
            }
            //resetting the elapse time
            elapsedtime = 0;
        }
        else
        {
            //increasing the time till the max time
            elapsedtime += Time.deltaTime;
        }
    }

}
