using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    Transform[] quad = new Transform[6];

    void Start()
    {
        Find();
    }

    void Find(){
        for(int i = 0; i < 6; i++){
            quad[i] = transform.GetChild(i);
        }
    }
}
