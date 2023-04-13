using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gotoTransition : MonoBehaviour {

    public GameObject objectToToggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log("pressed left button");
            // save the mouse starting position
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("hi "+hit.collider.gameObject.name+" bi "+ gameObject.name);

                if (hit.collider.gameObject.name == "Cylinder")
                {
                    //SceneManager.LoadScene("TransitionVideoScene");
                    objectToToggle.SetActive(!objectToToggle.activeSelf);

                }

            }
        }
    }
}
