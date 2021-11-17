using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// общий абстрактный класс для всех врагов
public abstract class Enemies : MonoBehaviour
{
   
    public abstract void SetDamage(float damageValue);
}
