using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Rigidbody pokeballPrefabRB;
    private Vector2 startSwipePosition;
    private float startSwipeTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount != 1) return; //If the number of touches is not exactly one, return.

        var touch = Input.GetTouch(0); //Get the first touch. (0-indexed)

        if (touch.phase == TouchPhase.Began) //If the touch has come down, but not gone back up
        {
            startSwipePosition = touch.position;
            startSwipeTime = Time.time;
        }
        else if (touch.phase == TouchPhase.Ended) //When the user releases the touch, we calculate the velocity, then throw the ball with that velocity.
        {
            //Calculate the velocity with v = d/t
            var currentPosition = touch.position;
            var currentTime = Time.time;

            var distance = (currentPosition - startSwipePosition).magnitude;
            var changeInTime = currentTime - startSwipeTime;

            var velocity = distance / changeInTime;
            ThrowBall(velocity);
        }
    }

    private void ThrowBall(float velocity)
    {
        //Instantiate the ball at x position. TODO: switch this so the ball is always there instead, but you'll need to figure out how to know if you're touching the ball.
        var position = Camera.main.transform.position + (Camera.main.transform.forward * 0.5f);
        var ball = Instantiate(pokeballPrefabRB, position, Camera.main.transform.rotation);

        //Give the Pokeball a direction.
        var direction = Vector3.RotateTowards(Camera.main.transform.forward, Vector3.up, Mathf.Deg2Rad * 30, 0);

        //Give the ball a velocity.
        ball.velocity = direction * velocity * 0.001f;

        //Give ball a rotation.
        ball.angularVelocity = Random.insideUnitSphere * Random.Range(0.5f, 2);
    }

}
