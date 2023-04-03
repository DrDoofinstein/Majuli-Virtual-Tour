using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class AvatarSelection : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    float cnst = 1.5f;
    Vector3 left = new Vector3(-40, 1, 10);
    Vector3 center = new Vector3(0, 1, 10);
    Vector3 right = new Vector3(40, 1, 10);
    Vector3 normal = new Vector3(1.0f, 1.0f, 1.0f);
    Vector3 enlarged = new Vector3(1.5f, 1.5f, 1.5f);
    // Start is called before the first frame update

    // declare game object
    // GameObject playerBlue;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            
            Debug.Log("pressed left button");
            // save the mouse starting position
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject, gameObject);

                if (hit.collider.gameObject == gameObject)
                {
                    gameObject.transform.position = center;
                    character1.transform.position = right;
                    character2.transform.position = left;
                    // if (gameObject == GameObject.Find("Player Green"))
                    // {
                    //     // GameObject.Find("Player Green").transform.position = center;
                    //     // GameObject.Find("Player Red").transform.position = right;
                    //     // GameObject.Find("Player Blue").transform.position = left;
                    //     player1.transform.position = center;
                    //     player2.transform.position = right;

                    // }
                    // else if (gameObject == GameObject.Find("Player Red"))
                    // {
                    //     GameObject.Find("Player Green").transform.position = left;
                    //     GameObject.Find("Player Red").transform.position = center;
                    //     GameObject.Find("Player Blue").transform.position = right;
                    // }
                    // else if(gameObject == GameObject.Find("Player Blue")){
                    //     GameObject.Find("Player Green").transform.position = right;
                    //     GameObject.Find("Player Red").transform.position = left;
                    //     GameObject.Find("Player Blue").transform.position = center;
                    // }
                    //gameObject.transform.position = new Vector3(0, 0, 0);
                    //GameObject.Find("Player Green").transform.position = new Vector3(0, 0, 0);
                    //GameObject.Find("Player Red").transform.position = new Vector3(0, 0, 0);
                    //GameObject.Find("Player Blue").transform.position = new Vector3(0, 0, 0);
                    //Debug.Log("clicked on sphere");
                    // GameObject.Find("Player Green").transform.localScale = normal;
                    // GameObject.Find("Player Red").transform.localScale = normal;
                    // GameObject.Find("Player Blue").transform.localScale = normal;
                    // gameObject.transform.localScale = enlarged;

                    character1.transform.localScale = normal;
                    character2.transform.localScale = normal;
                    gameObject.transform.localScale = enlarged;

                }

            }
        }  

    }

    

}
