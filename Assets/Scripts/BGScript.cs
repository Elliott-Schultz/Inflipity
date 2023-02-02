using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{
    public Vector2[] spawnPoints;
    public GameObject[] bgObjects;
    public float velocity;
    public short maxObjects;

    private short count = 0;
    private Queue<GameObject> activeObjects;

    private GameObject nextObject()
    {
        GameObject go;
        do
        {
            go = bgObjects[Random.Range(0, bgObjects.Length)];
        } while (activeObjects.Contains(go));
        return go;
    }

    private Vector3 nextSpawnPoint()
    {
        Vector2 sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Vector3 r = new Vector3(sp.x, sp.y, 1);
        return r;
    }
    private void spawnNewObject()
    {
        GameObject go = nextObject();
        Vector3 sp = nextSpawnPoint();
        go.transform.SetPositionAndRotation(sp, go.transform.rotation);
        activeObjects.Enqueue(go);
        count++;
    }

    // Start is called before the first frame update
    void Start()
    {
        activeObjects = new Queue<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (GameObject go in activeObjects)
        {
            Vector3 pos = new Vector3(go.transform.position.x - velocity * Time.deltaTime, go.transform.position.y, 1);
            go.transform.SetPositionAndRotation(pos, go.transform.rotation);
        }

        if (activeObjects.Count > 0 && (activeObjects.Peek().transform.position.x < -15)) {
            activeObjects.Dequeue();
            count--;
        }

        if (count < maxObjects && Random.Range(0, 1000) <= 1)
        { 
            spawnNewObject();
        }
    }
}
