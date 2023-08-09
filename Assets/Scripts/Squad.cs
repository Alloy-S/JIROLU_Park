using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Squad : MonoBehaviour
{
    public TMP_InputField input;

    void Start()
    {

    }
    void update()
    {
        Debug.Log(input.text);
    }


}
