
using UnityEngine;
using UnityEditor;


public class EditorScript : EditorWindow
{
  Color color;
  public float amountToFlip = 10;
  
  //Create menu attribute
[MenuItem("Tools/Editor")]
//show window
public static void CreateWindow()
  {
    GetWindow<EditorScript>();
  }
  // do stuff in window
  void OnGUI()
  {
    //Window Label
    GUILayout.Label("Colorizer", EditorStyles.boldLabel);

    color = EditorGUILayout.ColorField("Color", color);
    if (GUILayout.Button("Change Color"))
    {
      Colorize();
    }
    GUILayout.Label("Clone", EditorStyles.boldLabel);
    
    if (GUILayout.Button("Clone Object"))
    {
      Clone();
    }
    //horizontal slider to determine amount to rotate object
    
    GUILayout.BeginHorizontal();

    GUILayout.Label($"{amountToFlip}", EditorStyles.boldLabel);
    
    amountToFlip = GUILayout.HorizontalSlider(amountToFlip, 10f, 180f) ;
    GUILayout.EndHorizontal();
    //Three buttons that flip currently selected objects based on a sliders 
    //value
    GUILayout.BeginHorizontal();
    if (GUILayout.Button("Flip Y"))
    {
      
      FlipY();
    }
    if (GUILayout.Button("Flip X"))
    {

      FlipX();
    }
    if (GUILayout.Button("Flip Z"))
    {

      FlipZ();
    }
    GUILayout.EndHorizontal();
    if (GUILayout.Button("Random Size"))
    {

      RandomSize();
    }
  }


  //Changes color of selected game objects
  void Colorize()
  {
    foreach (GameObject obj in Selection.gameObjects)
    {
      Renderer renderer = obj.GetComponent<Renderer>();
      if (renderer != null)
      {
        renderer.sharedMaterial.color = color;
      }
    }
    //End colorizer part of code
    
  }
  //clones currently selected gameObjects
  void Clone()
  {
    foreach (GameObject obj in Selection.gameObjects)
    {
      GameObject clone;
      clone = Instantiate(obj);
      
    }
  }
  //flip object on Y axis
  void FlipY()
  {
    foreach(GameObject obj in Selection.gameObjects)
    {
      Transform objTransf = obj.GetComponent<Transform>();
      objTransf.Rotate(amountToFlip, 0f, 0f, Space.World);
    }
  }
  //flip object on x axis
  void FlipX()
  {
    foreach (GameObject obj in Selection.gameObjects)
    {
      Transform objTransf = obj.GetComponent<Transform>();
      objTransf.Rotate(0f, amountToFlip, 0f, Space.World);
    }
  }
  //flip object on z axis
  void FlipZ()
  {
    foreach (GameObject obj in Selection.gameObjects)
    {
      Transform objTransf = obj.GetComponent<Transform>();
      objTransf.Rotate(0f, 0f, amountToFlip, Space.World);
    }
  }
  //randomly resize objects to values between 1 and 10
  void RandomSize()
  {
    foreach(GameObject obj in Selection.gameObjects)
    {
      
      Transform objTranF = obj.GetComponent<Transform>();
      objTranF.localScale = new Vector3(Random.Range(0,10), Random.Range(0,10), Random.Range(0,10)); 

    }
  }
}
