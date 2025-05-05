using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;           // จุดที่กล้องมองไป
    public float distance = 10.0f;     // ระยะห่างจาก target
    public float zoomSpeed = 2.0f;     // ความเร็วการซูม
    public float rotationSpeed = 5.0f; // ความเร็วการหมุน

    private float currentX = 0f;
    private float currentY = 0f;
    public float yMin = -20f;          // มุม Y ต่ำสุด
    public float yMax = 80f;           // มุม Y สูงสุด

    void Update()
    {
        // หมุนกล้องเมื่อคลิกเมาส์ขวา
        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            currentY = Mathf.Clamp(currentY, yMin, yMax);
        }

        // ซูมด้วย scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, 2f, 20f);
    }

    void LateUpdate()
    {
        if (target == null) return;

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 dir = new Vector3(0, 0, -distance);
        transform.position = target.position + rotation * dir;
        transform.LookAt(target);
    }
}
