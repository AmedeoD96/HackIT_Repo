using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public GameObject player;
    public GameObject balloon;
    

    // Update is called once per frame
    void Update()
    {
        player.SetActive(true);
        balloon.SetActive(true);
    }
}
