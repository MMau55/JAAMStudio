using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FacePlayer : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void Update()
    {
        transform.LookAt(player.transform.position);
    }
}
