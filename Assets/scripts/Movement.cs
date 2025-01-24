using UnityEngine;

public class Movement : MonoBehaviour
{
    // Variable publique pour régler la vitesse dans l'inspecteur
    public float speed = 10f;
    public float turnSpeed = 50f; // Vitesse de rotation de la voiture
    public float returnSpeed = 5f; // Vitesse à laquelle la voiture revient à sa position initiale

    private float horizontalInput;
    private Quaternion initialRotation;

    void Start()
    {
        // Sauvegarder la rotation initiale de la voiture
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Déplacement constant vers l'avant
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));

        // Lire l'entrée de l'axe horizontal (Q et D ou touches assignées dans Input Manager)
        horizontalInput = Input.GetAxis("Horizontal");

        // Si une entrée est détectée, tourner la voiture
        if (horizontalInput != 0)
        {
            transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
        }
        else
        {
            // Si aucune touche n'est pressée, revenir progressivement à la rotation initiale
            transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, returnSpeed * Time.deltaTime);
        }
    }
}