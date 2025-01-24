using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    // Variable publique pour régler la vitesse dans l'inspecteur
    public float speed;
    public float turnSpeed; // Vitesse de rotation de la voiture
    private float horizontalInput;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Déplacement constant vers l'avant
        //transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        _rigidbody.velocity = transform.forward * (speed * Time.deltaTime);
        // Lire l'entrée de l'axe horizontal (Q et D ou touches assignées dans Input Manager)
        horizontalInput = Input.GetAxis("Horizontal");
        
        // Si une entrée est détectée, tourner la voiture
        if (horizontalInput != 0)
        {
            transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime, Space.World);
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}