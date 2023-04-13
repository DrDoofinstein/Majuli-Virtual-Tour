using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

struct To_image {
    public int left;
    public int right;
    public string to;
}


public class teleportation : MonoBehaviour
{
    public Material mat;
    public Material nextSkybox;

    private int linescount = 0;
    private string folderpath = "D:\\code\\Unity\\Majuli-Virtual-Tour\\majuli\\Assets\\Resources\\Modified_Materials";

    private IDictionary<string, List<To_image>> dict = new Dictionary<string, List<To_image>>();

    void Start()
    {
        //getting directory info from folderpath and getting .jpg and .txt files into arrays
        DirectoryInfo d = new DirectoryInfo(folderpath);
        FileInfo[] TextFile = d.GetFiles("*.txt");
        string line;
        foreach (FileInfo files in TextFile)
        {
            string filename = files.Name;
            print(filename);
            print(folderpath);

            filename = folderpath + "/" + filename;

            StreamReader file = new StreamReader(filename);

            while ((line = file.ReadLine()) != null){
                
                string[] tokens = line.Split(' ');

                if(tokens.Length < 4)
                {
                    Debug.Log("Line number: " + line + "Not Possible!!!");
                }
                else
                {
                    string src = tokens[0];
                    string dest = tokens[1];
                    int mid_angle = int.Parse(tokens[2]);
                    int offset_angle = int.Parse(tokens[3]);

                    int left =  (((mid_angle - offset_angle) % 360 + 360) % 360);
                    int right = (((mid_angle + offset_angle) % 360 + 360) % 360);

                    To_image new_data = new To_image();

                    new_data.left = left;
                    new_data.right = right;
                    new_data.to = dest;

                    if (dict.ContainsKey(src))
                    {
                        dict[src].Add(new_data);
                        Debug.Log(line + " added successfully!");
                    }
                    else
                    {
                        dict.Add(src, new List<To_image>());
                        dict[src].Add(new_data);
                        Debug.Log(line + " added successfully!");
                    }
                }

            }
        }

        //foreach (keyvaluepair<string, list<to_image>> kvp in dict)
        //{
        //    string output1 = kvp.key;

        //    foreach (to_image image in kvp.value)
        //    {
        //        output1 += image.left.tostring();
        //        output1 += image.right.tostring();
        //        output1 += image.to;
        //    }
        //    debug.log(output1);
        //}

    }

    void Update()
    {
        
        // check which USER is active


        // vrCam.eulerAngles.x >= 25.0f & vrCam.eulerAngles.x < 79.0f

        if(Input.GetKeyDown(KeyCode.UpArrow)){

            Debug.Log(RenderSettings.skybox.name);
            float angle = Camera.main.transform.eulerAngles.y;
            Debug.Log("and the angle is " + angle);
            
            string curr = RenderSettings.skybox.name;
            bool matched = false;

            for (int itr1 = 0; itr1 < dict[curr].Count; itr1++)
            {
                if(dict[curr][itr1].left < dict[curr][itr1].right)
                {
                    if(angle>= dict[curr][itr1].left && angle <= dict[curr][itr1].right)
                    {
                        matched = true;
                    }
                }
                else
                {
                    if (angle >= dict[curr][itr1].left || angle <= dict[curr][itr1].right)
                    {
                        matched = true;
                    }
                }

                if (matched)
                {
                    string path = "Modified_Materials/";
                    path += dict[curr][itr1].to;
                    RenderSettings.skybox = Resources.Load(path, typeof(Material)) as Material;
                    break;
                }

            }

            //if(RenderSettings.skybox.name == "DB65"){
            //    if(angle >= 340 && angle <= 20){
            //        if(Input.GetKeyDown(KeyCode.UpArrow)){
            //            Debug.Log("tryin to chang 68e");
            //            RenderSettings.skybox = Resources.Load("MaterialsNorth/DB68", typeof(Material)) as Material;
            //        }
            //    }else if(angle >= 250 && angle <= 290){

            //        if(Input.GetKeyDown(KeyCode.UpArrow)){
            //            Debug.Log("tryin to change 64");
            //            RenderSettings.skybox = Resources.Load("MaterialsNorth/DB64", typeof(Material)) as Material;
            //        }
            //    }
                
            //}else if(RenderSettings.skybox.name == "DB68"){
            //    if(angle >= 160 && angle <= 200){

            //        if(Input.GetKeyDown(KeyCode.UpArrow)){
            //            Debug.Log("tryin to change 65");
            //            RenderSettings.skybox = Resources.Load("MaterialsNorth/DB65", typeof(Material)) as Material;
            //        }
            //    }else if(angle >= 250 && angle <= 290){
            //        if(Input.GetKeyDown(KeyCode.UpArrow)){
            //            Debug.Log("tryin to change 66");
            //            RenderSettings.skybox = Resources.Load("MaterialsNorth/DB66", typeof(Material)) as Material;
            //        }
            //    }
                
            //}else if(RenderSettings.skybox.name == "DB66"){
            //    if(angle >= 70 && angle <= 110){
            //        if(Input.GetKeyDown(KeyCode.UpArrow)){
            //            Debug.Log("tryin to change 68");
            //            RenderSettings.skybox = Resources.Load("MaterialsNorth/DB68", typeof(Material)) as Material;
            //        }
            //    }else if(angle >= 160 && angle <= 200){

            //        if(Input.GetKeyDown(KeyCode.UpArrow)){
            //            Debug.Log("tryin to change 64");
            //            RenderSettings.skybox = Resources.Load("MaterialsNorth/DB64", typeof(Material)) as Material;
            //        }
            //    }
                
            //}else if(RenderSettings.skybox.name == "DB64"){
            //    if(angle >= 340 && angle <= 20){
            //        if(Input.GetKeyDown(KeyCode.UpArrow)){
            //            Debug.Log("tryin to change 66");
            //            RenderSettings.skybox = Resources.Load("MaterialsNorth/DB66", typeof(Material)) as Material;
            //        }
            //    }else if(angle >= 70 && angle <= 110){
            //        if(Input.GetKeyDown(KeyCode.UpArrow)){
            //            Debug.Log("tryin to change 65");
            //            RenderSettings.skybox = Resources.Load("MaterialsNorth/DB65", typeof(Material)) as Material;
            //        }
            //    }
                
            //}
            // else if(RenderSettings.skybox.name == "88"){
            //     if(angle >=345 || angle<=15){

            //         if(Input.GetKeyDown(KeyCode.UpArrow)){
            //             Debug.Log("tryin to change");
            //             RenderSettings.skybox = Resources.Load("MaterialsNorth/87", typeof(Material)) as Material;
            //         }
            //     }
            // }else if(RenderSettings.skybox.name == "87"){
            //     if(angle >= 340 || angle <= 20){

            //         if(Input.GetKeyDown(KeyCode.UpArrow)){
            //             Debug.Log("tryin to change");
            //             RenderSettings.skybox = Resources.Load("MaterialsNorth/86", typeof(Material)) as Material;
            //         }
            //     }else if(angle >= 265 || angle <= 295){

            //         if(Input.GetKeyDown(KeyCode.UpArrow)){
            //             Debug.Log("tryin to change");
            //             RenderSettings.skybox = Resources.Load("MaterialsNorth/88", typeof(Material)) as Material;
            //         }
            //     }
                
            // }
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
