using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJetController : MonoBehaviour
{
    void Start()
    {
        // самолет пролетит и самоуничтожится
        Destroy(gameObject, 5f);
    }

}
