using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public GameObject enemyObj;

    public Enemy enemy;

    public int damageAmount = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = enemyObj.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckHealth()
    {
        if (enemy.maxHealth / 4 > enemy.currentHealth)
        {
            Debug.Log("Enemy Health at less than a quarter.");
            AttackPlayer(damageAmount);
        }
    }

    public void AttackPlayer(int damageAmount)
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        Character playerCharacter = playerObj.GetComponent<Character>();

        playerCharacter.Damage(damageAmount);
    }
}
