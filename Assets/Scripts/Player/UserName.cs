using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserName : MonoBehaviour
{
    public Text nameuser;
    void Start()
    {
        nameuser.text = Shared.tenPlayer;
       
    }
}
