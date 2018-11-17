using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{
    private BirdController playerController;
    private Rigidbody2D rb;
    private float speed;

    // Use this for initialization
    public void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        var player = GameObject.FindGameObjectWithTag("Player");
        this.playerController = player.GetComponent<BirdController>();
        this.speed = this.playerController.forwardSpeed / 2;
    }

    // Update is called once per frame
    void Update()
    {
        var currenVelocity = this.rb.velocity;

        if (!this.playerController.isMoved)
        {
            currenVelocity.x = 0;
        }
        else
        {
            currenVelocity.x = this.speed;
        }

        this.rb.velocity = currenVelocity;
    }
}
