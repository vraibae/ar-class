using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MonsterGenerator : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public GameObject monster;

    private bool isMonsterPlaced = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Find all planes in the image.
        foreach (ARPlane plane in planeManager.trackables)
        {
            //If there is a horizontal plane and the monster hasn't been placed, place the monster.
            if (!isMonsterPlaced && plane.alignment == PlaneAlignment.HorizontalUp)
            {
                isMonsterPlaced = true;
                Instantiate(monster, plane.transform.position, Quaternion.identity);
            }
        }
    }
}
