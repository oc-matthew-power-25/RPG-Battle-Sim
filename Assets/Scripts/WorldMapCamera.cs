using UnityEngine;

public class WorldMapCamera : MonoBehaviour
{
    public Vector2 mapSize;
    public Vector2 cameraSize;
    public Vector2 maxCoords;

    void Start()
    {
        cameraSize.y = Camera.main.orthographicSize * 2;
        cameraSize.x = Camera.main.orthographicSize * 2 * Camera.main.aspect;

        maxCoords.x = mapSize.x/2 - cameraSize.x/2;
        maxCoords.y = mapSize.y/2 - cameraSize.y/2;
    }

    void LateUpdate()
    {
        Vector3 newPos = transform.parent.position;

        if(newPos.x > maxCoords.x) newPos.x = maxCoords.x;
        if(newPos.x < -maxCoords.x) newPos.x = -maxCoords.x;
        if(newPos.y > maxCoords.y) newPos.y = maxCoords.y;
        if(newPos.y < -maxCoords.y) newPos.y = -maxCoords.y;

        newPos.z = -10;

        transform.position = newPos;

    }
}
