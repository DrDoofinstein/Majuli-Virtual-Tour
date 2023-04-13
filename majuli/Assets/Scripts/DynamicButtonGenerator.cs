using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class DynamicButtonGenerator : MonoBehaviour
{
    public GameObject buttonPrefab;
    public string[] sceneNames;

    public static string destName;

    private void Start()
    {
        for (int i = 0; i < sceneNames.Length; i++)
        {
// print x,y,z of the transform
            Debug.Log(transform.position);
            Debug.Log(transform,transform);
            GameObject buttonGO = Instantiate(buttonPrefab, transform);
            Button button = buttonGO.GetComponent<Button>();
            int sceneIndex = i;
            float newX=0;
            if(sceneNames.Length%2==1)
                 newX = (i - sceneNames.Length / 2) * 20;
            if(sceneNames.Length%2==0)
                 newX = (i - sceneNames.Length / 2+0.5f) *20;
            float getY = button.transform.position.y;
            float getZ = button.transform.position.z;

            button.transform.position = new Vector3(newX, getY, getZ);

            button.onClick.AddListener(() => LoadScene(sceneIndex));
            //buttonGO.GetComponent<Button>().onClick.AddListener(() => LoadScene(sceneIndex));
            //buttonGO.GetComponent<DestButton>().leavelText.text = sceneNames[i];

            //Debug.Log("Button: " + button.GetComponentInChildren<TextMesh>());
            button.GetComponentInChildren<TextMeshProUGUI>().text = sceneNames[i];

        }
    }

    private void LoadScene(int sceneIndex)
    {
        destName = sceneNames[sceneIndex];
        Debug.Log(sceneNames[sceneIndex].ToString());
        SceneManager.LoadScene("TransitionVideoScene");
    }
}

//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using System.Collections;
//using System.Collections.Generic;

//public class DynamicButtonGenerator : MonoBehaviour
//{
//    public GameObject buttonPrefab;
//    public string[] sceneNames;
//    public float buttonSpacing = 20f;

//    private void Start()
//    {
//        Vector3 buttonPosition = transform.position;

//        for (int i = 0; i < sceneNames.Length; i++)
//        {
//            GameObject buttonGO = Instantiate(buttonPrefab, transform);
//            buttonGO.transform.position = buttonPosition;
//            Button button = buttonGO.GetComponent<Button>();
//            int sceneIndex = i;
//            button.onClick.AddListener(() => LoadScene(sceneIndex));
//            button.GetComponentInChildren<TextMesh>().text = sceneNames[i];
//            buttonPosition += new Vector3(buttonSpacing, 0, 0);
//        }
//    }

//    private void LoadScene(int sceneIndex)
//    {
//        SceneManager.LoadScene(sceneNames[sceneIndex]);
//    }
//}
