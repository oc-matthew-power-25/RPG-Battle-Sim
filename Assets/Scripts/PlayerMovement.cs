using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 mapSize;

    void Update()
    {
        Vector3 move = new Vector3();
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            move += Vector3.up;
        }
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            move += Vector3.down;
        }

        if(Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            move += Vector3.left;
        }
        if(Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            move += Vector3.right;
        }

        transform.position += move.normalized * Time.deltaTime * moveSpeed;

        Vector3 newPos = transform.position;

        newPos.x = Mathf.Clamp(newPos.x, -mapSize.x/2, mapSize.x/2);
        newPos.y = Mathf.Clamp(newPos.y, -mapSize.y/2, mapSize.y/2);

        transform.position = newPos;
    }
}
