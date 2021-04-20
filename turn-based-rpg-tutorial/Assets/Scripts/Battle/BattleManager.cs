using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public int enemyHealth;
    public int enemyMaxHealth;
    public int enemyMinAttack;
    public int enemyMaxAttack;
    public int currentEnemyAttack;

    [Header("UI")]
    public Text playerHealthText;
    public Text enemyHealthText;
    public Text dialogText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "Player HP " + playerHealth.playerHealth.ToString()
            + "/" + playerHealth.maxHealth.ToString();
        enemyHealthText.text = "Enemy HP " + enemyHealth.ToString()
            + "/" + enemyMaxHealth.ToString();
    }

    public void PlayerAttack()
    {
        StartCoroutine(PlayerAttacking());  
    }

    IEnumerator PlayerAttacking()
    {
        enemyHealth -= currentPlayerAttack;
        currentPlayerAttack = Random.Range(basicMinAttack, basicMaxAttack)
            + Random.Range(itemMinAttack, itemMaxAttack);

        dialogText.text = "Player attacked for " + currentPlayerAttack + " damage!";

        yield return new WaitForSeconds(3);

        StartCoroutine(EnemyAttacking());
    }

    IEnumerator EnemyAttacking()
    {
        currentEnemyAttack = Random.Range(enemyMinAttack, enemyMaxAttack);
        playerHealth.playerHealth -= currentEnemyAttack;
        dialogText.text = "Enemy attacked for " + currentEnemyAttack + " damage!";
        yield return new WaitForSeconds(3);
        dialogText.text = "";
    }


}
