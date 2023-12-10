using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace LP.TurnBasedStrategyTutorial
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject player = null;
        [SerializeField] private GameObject enemy = null;
        [SerializeField] private Slider playerHealth = null;
        [SerializeField] private Slider player1Health = null;
        [SerializeField] private Slider player2Health = null;
        [SerializeField] private Slider enemyHealth = null;
        [SerializeField] private Slider enemy1Health = null;
        [SerializeField] private Slider enemy2Health = null;
        [SerializeField] private Button swordButton = null;
        [SerializeField] private Button arrowButton = null;
        [SerializeField] private Button healButton = null;

        private bool isPlayerTurn = true;

        void Update()
        {
            if (playerHealth.value <= 0)
            {
                LoadGameOverScene();
            }
            else if (enemyHealth.value <= 0)
            {
                LoadGameOverScene();
            }
        }

        private void swordAttack(GameObject target)
        {
            if (target == enemy)
            {
                float damage = Random.Range(10, 20);
                enemyHealth.value -= damage;
                enemy1Health.value -= damage;
                enemy2Health.value -= damage;

            }
            else
            {
                float damage = Random.Range(10, 20);
                playerHealth.value -= damage;
                player1Health.value -= damage;
                player2Health.value -= damage;
            }

            ChangeTurn();
        }

        private void ArrowAttack(GameObject target, float damage)
        {
            if (target == enemy)
            {
                //float damage = Random.Range(5, 15);
                enemyHealth.value -= damage;
                enemy1Health.value -= damage;
                enemy2Health.value -= damage;

            }
            else
            {
                //float damage = Random.Range(5, 15);
                playerHealth.value -= damage;
                player1Health.value -= damage;
                player2Health.value -= damage;
            }

            ChangeTurn();
        }

        private void Heal(GameObject target)
        {
            if (target == enemy)
            {
                float amount = Random.Range(5, 15);
                enemyHealth.value += amount;
                enemy1Health.value += amount;
                enemy2Health.value += amount;
            }
            else
            {
                float amount = Random.Range(5, 15);
                playerHealth.value += amount;
                player1Health.value += amount;
                player2Health.value += amount;
            }

            ChangeTurn();
        }

        public void ButtonSword()
        {
            swordAttack(enemy);
        }

        public void ButtonArrows()
        {
            ArrowAttack(enemy, 99);
        }

        public void ButtonHeal()
        {
            Heal(player);
        }

        private void ChangeTurn()
        {
            isPlayerTurn = !isPlayerTurn;

            if (!isPlayerTurn)
            {
                swordButton.interactable = false;
                arrowButton.interactable = false;
                healButton.interactable = false;

                StartCoroutine(EnemyTurn());
            }
            else
            {
                swordButton.interactable = true;
                arrowButton.interactable = true;
                healButton.interactable = true;
            }
        }

        private IEnumerator EnemyTurn()
        {
            yield return new WaitForSeconds(3);

            int random = 0;
            random = Random.Range(1, 3);

            if (random == 1)
            {
                swordAttack(player);
            }
            else
            {
                Heal(enemy);
            }
        }

        private void LoadGameOverScene()
        {
            // trigger next scene
            SceneManager.LoadScene("Freeroam");
        }

    }
}


