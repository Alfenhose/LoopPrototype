using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricObject : MonoBehaviour {

    public float height = 0;
    public float worth;
    public string objectName;
    public GameObject sprite;
    private Transform spritePos;
    public SpriteRenderer spriterenderer;
 
	// Use this for initialization
	public virtual void Start () {
        spriterenderer = sprite.GetComponent<SpriteRenderer>();
        spritePos = sprite.transform;
        SetDepth();
    }
	
	// Update is called once per frame
	public virtual void Update () {
        
    }

    private void SetDepth()
    {
        float newZ = transform.position.y / 100 - height/10000;
        spritePos.position = new Vector3(transform.position.x, transform.position.y + height, newZ);
    }
}
