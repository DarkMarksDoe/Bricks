using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityController : MonoBehaviour {

    // the start and end location of the beam 
    // and the number of points along it
    public Transform startLocation;
    public Transform endLocation;
    public int numberOfPoints = 100;
    public float Power = 0.09f;
    public float Speed = 0.04f; // wiggle every speed seconds

    // a ref to the line renderer
    // used to render the beam
    private LineRenderer lineRenderer;
    private Vector3 perpendicular;
    private List<Vector3> originalPos;
    private float speedTimer;

	void Start () {
        // init variables
        lineRenderer = GetComponent<LineRenderer>();
        originalPos = new List<Vector3>();

        // calculate perpendicular vector
        perpendicular = Vector3.Cross((endLocation.position - startLocation.position).normalized, Vector3.back).normalized;

        // there must be at least 3 points
        if (numberOfPoints < 3) {
            numberOfPoints = 3;
        }

        lineRenderer.positionCount = numberOfPoints;

        // spacing between points
        Vector3 spacing = (endLocation.position - startLocation.position) / (numberOfPoints - 1);

        // set location of each point
        for (int i = 0; i < numberOfPoints; i++) {
            Vector3 position = flat(startLocation.position + spacing * i);
            lineRenderer.SetPosition(i, position);
            originalPos.Add(position);
        }
	}

    // returns a point with a z-coordinate equal
    // to that of the enclosing GameObject
    Vector3 flat(Vector3 v) {
        return new Vector3(v.x, v.y, transform.position.z);
    }

	void Update () {

        if (speedTimer <= 0)
        {
            speedTimer = Speed;
            // loop through each point in the beam and wiggle them
            for (int i = 1; i < numberOfPoints - 1; i++)
            {
                lineRenderer.SetPosition(i, originalPos[i] + perpendicular * Random.Range(-Power, Power));
            }
        }
        speedTimer -= Time.deltaTime;
	}
}
