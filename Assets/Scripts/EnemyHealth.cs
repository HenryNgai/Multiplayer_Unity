using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy
    private int currentHealth; // Current health of the enemy

    void Start()
    {
        // Set the enemy's current health to the maximum health at the start
        currentHealth = maxHealth;
    }

    // This method will be called when the enemy takes damage
    public void TakeDamage(int damageAmount)
    {
        // Reduce the current health by the damage amount
        currentHealth -= damageAmount;

        // Display the damage and remaining health in the console
        Debug.Log(gameObject.name + " took " + damageAmount + " damage, current health: " + currentHealth);

        // Check if the enemy's health is below or equal to zero
        if (currentHealth <= 0)
        {
            Die(); // Call the Die method if health is zero or less
        }
    }

    // This method handles the enemy's death
    void Die()
    {
        // You can add additional logic here, such as playing a death animation or sound

        Debug.Log(gameObject.name + " died."); // Display a message in the console

        // Destroy the enemy GameObject to remove it from the scene
        Destroy(gameObject);
    }
}
