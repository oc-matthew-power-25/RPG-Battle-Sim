using UnityEngine;
using UnityEngine.InputSystem;

public class IntroScript : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public float startSize;
    public float endSize;
    public float duration;
    public Canvas canvas;
    private bool inAnim = true;

    void Start ()
    {
        canvas.gameObject.SetActive(false);
        transform.position = startPos;
        GetComponent<Camera>().orthographicSize = startSize;
        inAnim = true;
    }

    void Update()
    {
        if(inAnim){
            Vector3 delta = endPos - startPos;
            Vector3 move = delta / duration * Time.deltaTime;
            transform.position += move;

            float sizeDelta = endSize - startSize;
            float changeSize = sizeDelta / duration * Time.deltaTime;
            GetComponent<Camera>().orthographicSize += changeSize;
        }
        if((Time.timeSinceLevelLoad >= duration || Mouse.current.leftButton.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame)&& inAnim)
        {
            transform.position = endPos;
            GetComponent<Camera>().orthographicSize = endSize;
            canvas.gameObject.SetActive(true);
            inAnim = false;
        }
    }
}
