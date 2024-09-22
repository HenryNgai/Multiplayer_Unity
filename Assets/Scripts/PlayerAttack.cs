using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    public float attackRange = 10f; // The range of the attack raycast
    public int attackDamage = 10; // The amount of damage dealt to the target
    public LayerMask targetLayerMask; // Layer mask to filter valid attack targets

    void Update()
    {
        CheckForAttack();
    }

    void CheckForAttack()
    {
        // Check if the attack key is pressed (change "Fire1" to your preferred input)
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the center of the screen
            Debug.Log("Attacking");
            Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit, attackRange, targetLayerMask))
            {   
                Debug.Log("Raycast hit");
                // Check if the object hit has the correct tag or component
                if (hit.collider.CompareTag("Enemy"))
                {
                    Attack(hit.collider.gameObject);
                }
            }
        }
    }

    void Attack(GameObject enemy)
    {
        // Apply damage to the enemy
        enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        Debug.Log("Attacked " + enemy.name + " for " + attackDamage + " damage.");
    }
}
