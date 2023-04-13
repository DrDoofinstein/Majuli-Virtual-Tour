using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class NewBehaviourScript : MonoBehaviour
{

	public int CubemapResolution = 720;
	public Material[] SkyBox;
	public Material[,] SkyMatrix;
	public int[,] imagePosition;
	public int totalSize;
	private float yaw = -87.0f;
	private float pitch = 372.5f;
	public float speedH = 5.0f;
	public float speedV = 5.0f;
	public Transform vrCam;
	private float time = 0.0f;
	public float interpolationPeriod = 10.0f;
	public int len, wid;
	int row, col;
    int[,] obstacle;
    private int linescount = 0;
    private string folderpath = "D:\\SWE\\North Kamalabari_grid update";


    private string[] keywords = { "up", "UP", "Up", "op", "Op"};

    //confidence level for dictatiobn of speech(Low means less stricter)
/*    public ConfidenceLevel confidence = ConfidenceLevel.Low;*/
/*    
    //phaserecognizer todetect the phrase
    protected PhraseRecognizer recognizer;*/
    protected string word = "";

    // Start is called before the first frame update
    void Start()
    {

    	//imagepostion matrix to keep info about image positions and blank spaces on the grid
    	imagePosition = new int[len, wid];
    	//SkyMatrix is actual matrix to store the skyboxes
    	SkyMatrix = new Material[len, wid];
        Debug.Log("start");
        
    	//intitalising the imageposition matrix with 0
    	for(int i=0;i<len;i++)
    	{
    		for(int j=0;j<wid;j++)
    		{
    			imagePosition[i,j]=0;
    		}
    	}

        //getting directory info from folderpath and getting .jpg and .txt files into arrays
        DirectoryInfo d = new DirectoryInfo(folderpath); 
        FileInfo[] TextFile = d.GetFiles("*.txt");

        string line;
        foreach (FileInfo files in TextFile)
        {
            Debug.Log(files);
            string filename = files.Name;
            print(filename);
            print(folderpath);

            filename = folderpath + "/" + filename;

            StreamReader file =
            new StreamReader(filename);

            while ((line = file.ReadLine()) != null)
            {
                linescount++;
            }


            int currline = 0;
            obstacle = new int[linescount, 6];

            file = new StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {


                string[] tokens = line.Split(' ');
                Debug.Log(tokens);

                for (int i = 0; i < 6; i++)
                    obstacle[currline, i] = 0;

                for (int i = 0; i < tokens.Length; i++)
                {
                    if (i < 2)
                        obstacle[currline, i] = int.Parse(tokens[i]);
                    else
                    {
                        if (tokens[i] == "u" || tokens[i] == "U")
                            obstacle[currline, 2] = 1;
                        if (tokens[i] == "d" || tokens[i] == "D")
                            obstacle[currline, 3] = 1; 
                        if (tokens[i] == "l" || tokens[i] == "L")
                            obstacle[currline, 4] = 1;
                        if (tokens[i] == "r" || tokens[i] == "R")
                            obstacle[currline, 5] = 1;

                    }
                }

                currline++;
            }
        }





    	//hardcoded infor aboput presence of image on the grid
    	imagePosition[0,0]=1;
    	imagePosition[0,2]=1;
    	imagePosition[0,3]=1;
    	imagePosition[0,4]=1;
    	imagePosition[0,5]=1;
    	imagePosition[0,6]=1;
    	imagePosition[0,7]=1;
    	imagePosition[0,8]=1;
    	imagePosition[0,11]=1;
    	imagePosition[1,4]=1;
    	imagePosition[1,7]=1;
    	imagePosition[1,11]=1;
    	imagePosition[2,1]=1;
    	imagePosition[2,2]=1;
    	imagePosition[2,4]=1;
    	imagePosition[2,6]=1;
    	imagePosition[2,7]=1;
    	imagePosition[3,0]=1;
    	imagePosition[3,2]=1;
    	imagePosition[3,4]=1;
    	imagePosition[3,6]=1;
    	imagePosition[3,11]=1;
    	imagePosition[4,1]=1;
    	imagePosition[4,2]=1;
    	imagePosition[4,4]=1;
    	imagePosition[4,6]=1;
    	imagePosition[4,7]=1;
    	imagePosition[5,0]=1;
    	imagePosition[5,1]=1;
    	imagePosition[5,2]=1;
    	imagePosition[5,4]=1;
    	imagePosition[5,7]=1;
    	imagePosition[5,11]=1;
    	imagePosition[6,2]=1;
    	imagePosition[6,4]=1;
    	imagePosition[6,6]=1;
    	imagePosition[7,0]=1;
    	imagePosition[7,1]=1;
    	imagePosition[7,2]=1;
    	imagePosition[7,4]=1;
    	imagePosition[7,6]=1;
    	imagePosition[7,7]=1;
    	imagePosition[7,8]=1;
    	imagePosition[7,9]=1;
    	imagePosition[7,10]=1;
    	imagePosition[7,11]=1;     
    	imagePosition[8,1]=1;
    	imagePosition[8,2]=1;
    	imagePosition[8,4]=1;
    	imagePosition[8,6]=1;
    	imagePosition[8,7]=1;
    	imagePosition[8,11]=1;
    	imagePosition[9,0]=1;
    	imagePosition[9,1]=1;
    	imagePosition[9,2]=1;
    	imagePosition[9,4]=1;
    	imagePosition[10,4]=1;
    	imagePosition[10,11]=1;
    	imagePosition[11,0]=1; 	      	
    	imagePosition[11,1]=1;
    	imagePosition[11,3]=1;
    	imagePosition[11,4]=1;
    	imagePosition[11,5]=1;
    	imagePosition[11,7]=1;
    	imagePosition[12,4]=1;
    	imagePosition[12,11]=1;
    	imagePosition[13,0]=1; 	      	
    	imagePosition[13,4]=1;
    	imagePosition[14,4]=1;
    	imagePosition[14,11]=1;
    	imagePosition[15,0]=1; 	      	
    	imagePosition[15,4]=1;
    	imagePosition[16,4]=1;
    	imagePosition[17,4]=1;
    	imagePosition[18,4]=1;
    	imagePosition[19,0]=1;
    	imagePosition[19,1]=1;
    	imagePosition[19,2]=1;
    	imagePosition[19,4]=1;
    	imagePosition[19,6]=1;
    	imagePosition[19,7]=1;
    	imagePosition[19,8]=1;
    	imagePosition[19,9]=1;
    	imagePosition[19,10]=1;
    	imagePosition[19,11]=1;
    	imagePosition[20,11]=1;
    	imagePosition[21,11]=1;
    	imagePosition[22,11]=1;

                                                                     
    	//starting point of the tour
    	row=22;
    	col=11;

    	//assigning skyboxes in the matrix at appropriate positions
    	//(Logic is after storing all skyboxes in a 1D array, we are assigniong based on 
    	//row major order and image position to a Skymatrix 2-D array)
    	int pos=0;
    	for(int i=0;i<len;i++)
    	{
    		for(int j=0;j<wid;j++)
    		{
    			if(imagePosition[i,j]==1)
    			{
    				print(i+" "+j+" "+pos);
    				SkyMatrix[i,j] = SkyBox[pos];
                    Debug.Log(SkyBox[pos]);
    				pos++;
    			}
    		}
    	}

        RenderSettings.skybox = SkyMatrix[row,col];


    	
    }



    // Update is called once per frame
    void Update()
    {

    	//mouse control code in
    	// yaw += speedH * Input.GetAxis("Mouse X");
     //    pitch -= speedV * Input.GetAxis("Mouse Y");
     //    transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        
       	//getting angle of view
        float angle = Camera.main.transform.eulerAngles.y;


        print(angle);



        //up >325 <25
        //right >25 <140
        //down >140 <225
        //left >225 <325

        // vrCam.eulerAngles.x >= 25.0f & vrCam.eulerAngles.x < 79.0f
        if ( Input.GetKeyDown(KeyCode.UpArrow) || word=="up" || word=="Up" || word=="UP")
        {

        	
            //front
            if(angle >=325 || angle <25)
            {
	        	// time += Time.deltaTime;
	        	// if(time>=interpolationPeriod)
	        	// {
		        	// print("Up");
		        	//checking for a valid front move.

                int obflag = 0;
                for (int i = 0; i < linescount; i++)
                {
                    if (obstacle[i, 0] == row && obstacle[i, 1] == col && obstacle[i, 2] == 1)
                    {
                        obflag = 1;
                        break;
                    }
                }


                if (obflag == 0)
                {
		        	if(row>0)
		        	{
		        		row--;
                        while (imagePosition[row, col] != 1)
                        {
                            row--;
                            if (row < 0)
                            {
                                row++;
                                while (imagePosition[row, col] != 1)
                                    row++;
                                break;

                            }
                        }
                        word="";
                        print(row+" "+col);
                        if(imagePosition[row,col]==1)
		        			RenderSettings.skybox = SkyMatrix[row,col];
                        Debug.Log("using skybox");
		        		time=0.0f;
		        	}
                }
                else
                {
                    print("Obstacle Detected! Yes");
                }
	        	// }
            }


            else if(angle >=25 && angle <140)
            {
	        	// time += Time.deltaTime;
	        	// if(time>=interpolationPeriod)
	        	// {
		        	// print("right");
                int obflag = 0;
                for (int i = 0; i < linescount; i++)
                {
                    if (obstacle[i, 0] == row && obstacle[i, 1] == col && obstacle[i, 5] == 1)
                    {
                        obflag = 1;
                        break;
                    }
                }


                if (obflag == 0)
                {
		        	if(col<wid)
		        	{
		        		col++;
                        while (imagePosition[row, col] != 1)
                        {
                            col++;
                            if (col >= wid)
                            {
                                col--;
                                while (imagePosition[row, col] != 1)
                                    col--;
                                break;

                            }
                        }
                        word="";
                        print(row+" "+col);
                        if(imagePosition[row,col]==1)
		        			RenderSettings.skybox = SkyMatrix[row,col];
		        		time=0.0f;
		        	}
                }
                else
                {
                    print("Obstacle Detected!");
                }
	        	// }
            }

            else if(angle >=140 && angle <225)
            {

	        	// time += Time.deltaTime;
	        	// if(time>=interpolationPeriod)
	        	// {
		        	// print("down");
                int obflag = 0;
                for (int i = 0; i < linescount; i++)
                {
                    if (obstacle[i, 0] == row && obstacle[i, 1] == col && obstacle[i, 3] == 1)
                    {
                        obflag = 1;
                        break;
                    }
                }


                if (obflag == 0)
                {
		        	if(row<len)
		        	{
		        		row++;
                        while (imagePosition[row, col] != 1)
                        {
                            row++;
                            if (row >= len)
                            {
                                row--;
                                while (imagePosition[row, col] != 1)
                                    row--;
                                break;

                            }
                        }
                        word="";
                        print(row+" "+col);
                        if(imagePosition[row,col]==1)
		        			RenderSettings.skybox = SkyMatrix[row,col];
		        		time=0.0f;
		        	}
                }
                else
                {
                    print("Obsatcle Detetcted!");
                }
	        	// }
            }	

            if(angle >=225 && angle <325)
            {
	        	// time += Time.deltaTime;
	        	// if(time>=interpolationPeriod)
	        	// {
		        	// print("left");
                int obflag = 0;
                for (int i = 0; i < linescount; i++)
                {
                    if (obstacle[i, 0] == row && obstacle[i, 1] == col && obstacle[i, 4] == 1)
                    {
                        obflag = 1;
                        break;
                    }
                }


                if (obflag == 0)
                {

		        	if(col>0)
		        	{
		        		col--;
                        while (imagePosition[row, col] != 1)
                        {
                            col--;
                            if (col <0)
                            {
                                col++;
                                while (imagePosition[row, col] != 1)
                                    col++;
                                break;

                            }
                        }
                        word="";
                        print(row+" "+col);
                        if(imagePosition[row,col]==1)
		        			RenderSettings.skybox = SkyMatrix[row,col];
		        		time=0.0f;
		        	}
                }
                else
                {
                    print("Obsatcle Detetcted!");
                }
	        	// }
            }            				

        }
    }
}
