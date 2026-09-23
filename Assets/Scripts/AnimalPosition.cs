using UnityEngine;

public class AnimalPosition : MonoBehaviour
{
    public float radius = 300f;
    public float rotTime = 5f;
    public float offsetAngle = 0f;

    // Update is called once per frame
    void Update()
    {
        float xPos = Mathf.Sin((Time.time * rotTime + offsetAngle) * Mathf.Deg2Rad) * radius;
        float yPos = Mathf.Cos((Time.time * rotTime + offsetAngle) * Mathf.Deg2Rad) * radius;

        GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos, 0);
    }
}
