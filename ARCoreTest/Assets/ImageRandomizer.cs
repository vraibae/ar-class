using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will randomly pick an image to place over your head.
public class ImageRandomizer : MonoBehaviour
{
    public SpriteRenderer randomSpriteRenderer;

    public Sprite[] randomSprites;

    public float timeBetweenChange = 0.2f;
    public float timeUntilStopping = 3.0f; //The total amount of time until randomization stops.
    private int RandomImageIndex = 0;
    private float ImageChangeTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        ImageChangeTimer = timeBetweenChange;
    }

    // Update is called once per frame
    void Update()
    {
        ImageChangeTimer -= Time.deltaTime;
        timeUntilStopping -= Time.deltaTime;

        if(timeUntilStopping <= 0.0f)
        {
            randomSpriteRenderer.sprite = randomSprites[Random.Range(0, randomSprites.Length)];
            DestroyImmediate(this);
            return;
        }

        if(ImageChangeTimer <= 0.0f)
        {
            RandomImageIndex++;
            if(RandomImageIndex >= randomSprites.Length)
            {
                RandomImageIndex = 0;
            }

            //Set the image to be the next image in the sprites array.
            randomSpriteRenderer.sprite = randomSprites[RandomImageIndex];

            //Resets ImageChangeTimer
            ImageChangeTimer = timeBetweenChange;
        }
    }
}
