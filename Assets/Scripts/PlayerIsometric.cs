using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsometric : MonoBehaviour {

    private Rigidbody2D rigidbody2d;
    public float horizontalSpeed = 5;
    public float verticalSpeed = 5;
    private float pickupCooldown = 0;
    private float pickupCooldownMax = 3;
    private bool stealing = false;
    public GameObject selectionPrefab;
    private GameObject selectionObject;
    private GameObject closestObject;
    // Use this for initialization
    void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
        selectionObject = Instantiate(selectionPrefab);
        PlayerInput.Instance.Use.AddListener(Steal);
	}
	
	// Update is called once per frame
	void Update () {
        pickupCooldown -= Time.deltaTime;
        stealing = pickupCooldown > 0;

        if (!stealing)
        {
            UILevel1.Instance.ShowStolePanel(false);
            Move();
            closestObject = GetClosestObject("Stealable", 2f);
            UpdateSelection();
        }
        else
        {
            selectionObject.SetActive(false);
            rigidbody2d.velocity = new Vector2();
            UILevel1.Instance.ShowStolePanel(true);
        }


        SetDepth();
    }
    private void SetDepth()
    {
        float newZ = transform.position.y / 100;
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
    }
    private void Move()
    {
        rigidbody2d.velocity = new Vector2(PlayerInput.Instance.Horizontal * horizontalSpeed,
                                             PlayerInput.Instance.Vertical * verticalSpeed);
    }

    private void UpdateSelection()
    {
        if (closestObject)
        {
            GameObject sprite = closestObject.GetComponent<IsometricObject>().sprite;
            selectionObject.transform.position = sprite.transform.position + new Vector3(0, 0, -0.0001f);
            selectionObject.transform.Rotate(0, 0, 45 * Time.deltaTime);
            selectionObject.SetActive(true);
        }
        else
        {
            selectionObject.SetActive(false);
        }
    }

    private void Steal()
    {
        if (closestObject && pickupCooldown < 0)
        {
            pickupCooldown = pickupCooldownMax;
            IsometricObject other = closestObject.GetComponent<IsometricObject>();
            ScoreManager.Instance.score += other.worth;
            closestObject.SetActive(false);
            UILevel1.Instance.lastPickedUp = other;
            closestObject = null;
        }
    }

    private GameObject GetClosestObject(String tag, float maxDistance)
    {
        var objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        GameObject closestObject = null;
        foreach (var obj in objectsWithTag)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance < maxDistance)
            {
                if (closestObject == null)
                {
                    closestObject = obj;
                    continue;
                }
                //compares distances
                if (distance <= Vector3.Distance(transform.position, closestObject.transform.position))
                {
                    closestObject = obj;
                    continue;
                }
            }
        }
        return closestObject;
    }
}
