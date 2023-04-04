using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportation : MonoBehaviour
{
    public Material mat;
    // Start is called before the first frame update
    public Material nextSkybox;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0) )
        // {
        //     Debug.Log("pressed");

        //     var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit;

        //     if (Physics.Raycast(ray, out hit))
        //     {
        //         Debug.Log(hit.collider.gameObject, gameObject);

        //         if (hit.collider.gameObject == gameObject)
        //         {
        //             RenderSettings.skybox = nextSkybox;
        //             // destroy game object
        //             Destroy(gameObject);
        //         }

        //     }
        // }  
        Debug.Log(RenderSettings.skybox.name);
        float angle = Camera.main.transform.eulerAngles.y;

        //up >325 <25
        //right >25 <140
        //down >140 <225
        //left >225 <325

        // vrCam.eulerAngles.x >= 25.0f & vrCam.eulerAngles.x < 79.0f
        if(RenderSettings.skybox.name == "88"){
            if(angle >=345 || angle<=15){

                if(Input.GetKeyDown(KeyCode.UpArrow)){
                    Debug.Log("tryin to change");
                    RenderSettings.skybox = Resources.Load("MaterialsNorth/87", typeof(Material)) as Material;
                }
            }
        }else if(RenderSettings.skybox.name == "87"){
            if(angle >= 340 || angle <= 20){

                if(Input.GetKeyDown(KeyCode.UpArrow)){
                    Debug.Log("tryin to change");
                    RenderSettings.skybox = Resources.Load("MaterialsNorth/86", typeof(Material)) as Material;
                }
            }else if(angle >= 265 || angle <= 295){

                if(Input.GetKeyDown(KeyCode.UpArrow)){
                    Debug.Log("tryin to change");
                    RenderSettings.skybox = Resources.Load("MaterialsNorth/88", typeof(Material)) as Material;
                }
            }
            
        }
        

        // //front
        // if(angle >=325 || angle <25)
        // {

        // }


        // else if(angle >=25 && angle <140)
        // {	

        // }

        // else if(angle >=140 && angle <225)
        // {

        // }	

        // else if(angle >=225 && angle <325)
        // {

        // }
        
    }
}
