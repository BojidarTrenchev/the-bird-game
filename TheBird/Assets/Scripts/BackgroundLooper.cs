using UnityEngine;
using System.Collections;

public class BackgroundLooper : MonoBehaviour
{
    public float treeDistance = 10;

    private float distanceBetweenTrees;
    private float distanceBetweenGrounds;
    private float distanceBetweenBackgrounds;

    void Start()
    {
        this.distanceBetweenGrounds = CalculateDistance(GameObject.FindGameObjectsWithTag("Ground"));
        this.distanceBetweenBackgrounds = CalculateDistance(GameObject.FindGameObjectsWithTag("Background"));
        this.distanceBetweenTrees = CalculateDistance(GameObject.FindGameObjectsWithTag("TreeTrigger"));
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        if (obj.CompareTag("Background") || obj.CompareTag("Ground") || obj.CompareTag("TreeTrigger"))
        {
            var currentPosition = obj.transform.position;
            if (obj.CompareTag("Background"))
            {
                currentPosition.x += this.distanceBetweenBackgrounds;
            }
            else if (obj.CompareTag("Ground"))
            {
                currentPosition.x += this.distanceBetweenGrounds;
            }
            else
            {
                currentPosition.y = RandomizeTree(currentPosition.y);
                currentPosition.x += this.distanceBetweenTrees + 5 + Random.Range(-1, 1.5f);
            }
            obj.transform.position = currentPosition;
        }
    }

    private float CalculateDistance(GameObject[] gameObjects)
    {
        float distance = 0;
        float minDistance = float.MaxValue;

        for (int i = 1; i < gameObjects.Length; i++)
        {
            distance = Mathf.Abs(gameObjects[i].transform.position.x - gameObjects[i - 1].transform.position.x);
            if (distance < minDistance)
            {
                minDistance = distance;
            }
        }

        return minDistance * gameObjects.Length;
    }

    private float RandomizeTree(float currentPositionY)
    {
        currentPositionY = Random.Range(-1.5f, 1);
        return currentPositionY;
    }
}

