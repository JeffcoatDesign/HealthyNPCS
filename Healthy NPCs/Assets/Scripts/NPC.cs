using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public void TakeDamage(int amount)
    {
        GetComponent<IHealth>().TakeDamage(amount);
    }
}
