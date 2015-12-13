using UnityEngine;
using System.Collections;

public class CHangeScene : MonoBehaviour
{
    
    // Use this for initialization
    public void ChangeScene(string sceneNumber)
    {
        Application.LoadLevel(sceneNumber);
    }
}