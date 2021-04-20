using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerHealth", fileName = "Player Health")]
public class PlayerHealth : ScriptableObject
{
    public int playerHealth;
    public int maxHealth;

    // Update is called once per frame
    void Update()
    {
        if(playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }
    }
}
