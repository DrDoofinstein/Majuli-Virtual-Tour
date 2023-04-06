using UnityEngine;
using UnityEditor;
using System.IO;

public class MaterialGenerator : AssetPostprocessor
{

    [MenuItem("Assets/Create Materials")]
    private static void CreateMaterials()
    {

        foreach (Object o in Selection.objects)
        {


            Debug.Log("Creating material from: " + o);

            /*Cubemap selected = o as Cubemap;
            */
            Texture2D selected = o as Texture2D;


            Material material = new Material(Shader.Find("Skybox/Cubemap"));
            string nam = selected.name;

            string savePath = AssetDatabase.GetAssetPath(selected);
            Debug.Log(savePath);
            /*string p = inputFolder +savePath.Substring(savePath.LastIndexOf('\\')+1);
            Debug.Log(p);*/


            TextureImporter importer = AssetImporter.GetAtPath(savePath) as TextureImporter;
            /*importer.textureType = TextureImporterType.Cubemap;*/
            importer.textureShape = TextureImporterShape.TextureCube;
            importer.SaveAndReimport();

            Cubemap texture = AssetDatabase.LoadAssetAtPath<Cubemap>(savePath);

            Debug.Log(selected);
          /*
            material.mainTexture = selected;*/
            material.SetTexture("_Tex", texture);

/*            material.
*/


            Debug.Log(savePath);
            savePath = savePath.Substring(0, savePath.LastIndexOf('/') + 1);/*
            savePath = savePath.Substring(0, savePath.LastIndexOf('/') + 1);*/

            Debug.Log(savePath);

            string newAssetName = savePath + nam + ".mat";

            AssetDatabase.CreateAsset(material, newAssetName);

            AssetDatabase.SaveAssets();

        }
        Debug.Log("Done!");
    }


}
