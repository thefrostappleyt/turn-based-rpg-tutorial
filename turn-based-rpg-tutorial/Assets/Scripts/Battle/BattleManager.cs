using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    [Header("Player")]
    public PlayerHealth playerHealth;
    public int basicMinAttack;
    public int basicMaxAttack;
    public int itemMinAttack;
    public int itemMaxAttack;
    public int currentPlayerAttack;

    [Header("Enemy")]
    public Enemy currentEnemy;
    public int currentEnemyHealth;
    public int currentEnemyAttack;

    [Header("UI")]
    public Text playerHealthText;
    public Text enemyHealthText;
    public Text dialogText;
    
    // Start is called before the first frame update
    void Start()
    {
        currentEnemyHealth = currentEnemy.enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "Player HP " + playerHealth.playerHealth.ToString()
            + "/" + playerHealth.maxHealth.ToString();
        enemyHealthText.text = "Enemy HP " + currentEnemyHealth.ToString()
            + "/" + currentEnemy.enemyMaxHealth.ToString();

        if(currentEnemyHealth < 0)
        {
            currentEnemyHealth = 0;
            StartCoroutine(EnemyDied());
        }
    }

    public void PlayerAttack()
    {
        StartCoroutine(PlayerAttacking());  
    }

    IEnumerator PlayerAttacking()
    {
        currentEnemyHealth -= currentPlayerAttack;
        currentPlayerAttack = Random.Range(basicMinAttack, basicMaxAttack)
            + Random.Range(itemMinAttack, itemMaxAttack);

        dialogText.text = "Player attacked for " + currentPlayerAttack + " damage!";

        yield return new WaitForSeconds(3);

        StartCoroutine(EnemyAttacking());
    }

    IEnumerator EnemyAttacking()
    {
        currentEnemyAttack = Random.Range(currentEnemy.enemyMinAttack, currentEnemy.enemyMaxAttack);
        playerHealth.playerHealth -= currentEnemyAttack;
        dialogText.text = currentEnemy.enemyName + " attacked for " + currentEnemyAttack + " damage!";
        yield return new WaitForSeconds(3);
        dialogText.text = "";
    }

    IEnumerator EnemyDied()
    {
        dialogText.text = currentEnemy.enemyName + " died!";
        yield return new WaitForSeconds(2);
        dialogText.text = "You won! Hooray!";
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Overworld");
    }
}
