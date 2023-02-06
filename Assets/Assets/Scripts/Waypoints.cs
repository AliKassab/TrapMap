using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoint;
    private int waypointindex = 0;

    [SerializeField] private float speed = 2f;
    private void Update()
    {
        
        if (Vector2.Distance(waypoint[waypointindex].transform.position, transform.position) < 1f)
        {
            waypointindex++;

            if (waypointindex >= waypoint.Length)
            {
                waypointindex = 0;
            }

        }

        transform.position = Vector2.MoveTowards(transform.position, waypoint[waypointindex].transform.position, Time.deltaTime * speed);

    }
}
