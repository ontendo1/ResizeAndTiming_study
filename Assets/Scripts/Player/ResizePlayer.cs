using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizePlayer : MonoBehaviour
{
    [SerializeField] public ResizeValues resizeValues;
    public int currentSizeIndex = 2;

    void Update()
    {
        if ((Vector2)transform.localScale != resizeValues.size[currentSizeIndex])
        {
            transform.localScale = new Vector3(resizeValues.size[currentSizeIndex].x,resizeValues.size[currentSizeIndex].y,transform.localScale.z);
        }
    }
    
}
