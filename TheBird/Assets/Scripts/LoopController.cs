using UnityEngine;
using System.Collections;

public class LoopController : MonoBehaviour
{
    private GameObject player;
    private float offset;

    // Use this for initialization
    void Start()
    {
        
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.offset = this.transform.position.x - this.player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        var pos =this.transform.position;
        pos.x = this.player.transform.position.x + offset;
        this.transform.position = pos;
    }
}
