using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Les deux GameObjects à définir dans l'inspecteur
    public GameObject pointA;
    public GameObject pointB;

    // Le prefab du bloc à instancier
    public GameObject blockPrefab;

    // Intervalle de temps pour le spawn
    public float spawnInterval;

    private void Start()
    {
        // Lancer la méthode SpawnBlock de façon répétée toutes les `spawnInterval` secondes
        InvokeRepeating(nameof(SpawnBlock), 0f, spawnInterval);
    }

    private void SpawnBlock()
    {
        if (pointA == null || pointB == null || blockPrefab == null)
        {
            Debug.LogError("Assurez-vous d'avoir assigné les deux points et le prefab du bloc.");
            return;
        }

        // Calculer une position aléatoire entre les deux GameObjects
        Vector3 randomPosition = Vector3.Lerp(pointA.transform.position, pointB.transform.position, Random.Range(0f, 1f));

        // Instancier le bloc à la position calculée
        Instantiate(blockPrefab, randomPosition, Quaternion.identity);
    }
}