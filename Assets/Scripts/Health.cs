using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy
    private int currentHealth; // Current health of the enemy
    public GameObject healthBarPrefab; // Prefab for the health bar UI
    private Slider healthSlider; // Reference to the Slider component

    void Start()
    {  
        // Set the enemy's current health to the maximum health at the start
        currentHealth = maxHealth;

        // Instantiate the health bar prefab at the desired position
        GameObject healthBarInstance = Instantiate(healthBarPrefab, transform.position + new Vector3(0, 2, 0), Quaternion.identity);

        // Set the health bar's parent to the character
        healthBarInstance.transform.SetParent(transform);

        // Adjust scale
        healthBarInstance.transform.localScale = Vector3.one * 0.01f; // Adjust this as needed

        // Adjust position
        healthBarInstance.transform.localPosition = new Vector3(0, 1, 0); // Adjust this value as needed

        // Get the Slider component from the instantiated health bar
        healthSlider = healthBarInstance.GetComponentInChildren<Slider>();

        if (healthSlider == null)
        {
            Debug.LogError("Slider component not found in health bar prefab!");
            return;
        }

        // Set the maximum value of the slider to the max health
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth; // Start with full health
    }


    // Mostly using TakeDamage (Can use negative numbers to increase health)
    public void TakeDamage(int damageAmount)
    {
        // Reduce the current health by the damage amount
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health stays within bounds

        // Update the slider value
        UpdateHealthBar();

        // Display the damage and remaining health in the console
        Debug.Log(gameObject.name + " took " + damageAmount + " damage, current health: " + currentHealth);

        // Check if the enemy's health is below or equal to zero
        if (currentHealth <= 0)
        {
            Die(); // Call the Die method if health is zero or less
        }
    }

    private void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            // Update the slider value to reflect the current health
            healthSlider.value = currentHealth;
        }
        else
        {
            Debug.LogWarning("Health slider reference is missing!");
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
