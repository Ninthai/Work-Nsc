using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Transform target;        // สิ่งที่กล้องจะตาม (เช่น Player)
    public Vector3 offset = new Vector3(0f, 5f, -10f); // ตำแหน่งกล้องเทียบกับ Player
    public float smoothSpeed = 0.125f; // ค่าความนุ่มนวล

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
        transform.LookAt(target); // ให้กล้องหันมอง Player ตลอด
    }
}