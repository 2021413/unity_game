using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // L'objet à suivre
    public Vector3 offset; // Le décalage entre la caméra et l'objet

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}