using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endtrigger : MonoBehaviour
{

    public GameManger gameManger;
    private void OnTriggerEnter(Collider other)
    {
        gameManger.Completelevel();
    }
}
