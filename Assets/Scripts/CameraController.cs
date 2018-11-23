﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour {

    public Transform playerAnchor;
    public RectTransform menuAnchor;

    //public Tilemap map;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;


    private float halfHeight;
    private float halfWidth;

    public int musicToPlay;
    public bool musicStarted;

	void Start () {
        playerAnchor = FindObjectOfType<PlayerController>().transform; //searches objects for scene and finds object with PlayerController script attached
        if (playerAnchor == null)
        {
            playerAnchor = menuAnchor as Transform;
        }

        //Keep camera inside bounds of map
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect; 

       // bottomLeftLimit = map.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
        //topRightLimit = map.localBounds.max - new Vector3(halfWidth, halfHeight, 0f);


	}
	
	// LateUpdate is called once per frame, but it guaranteed to run after all items have been processed in update.
	void LateUpdate() {

        transform.position = new Vector3(playerAnchor.position.x, playerAnchor.position.y, transform.position.z);

        //keep camera inside bounds
       // transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), 
         //                                Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), 
          //                               transform.position.z);

        if (!musicStarted)
        {
            musicStarted = true;
            AudioManager.Instance.PlayMusic(musicToPlay);
        }

	}
}
