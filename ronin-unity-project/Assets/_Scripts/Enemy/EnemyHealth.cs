using UnityEngine;

namespace RoninGame
{
	public class EnemyHealth : MonoBehaviour
	{

		public int maxHealth = 100;
		public int currentHealth;

		public EnemyHealthBar healthBar;

		void Start()
		{
			currentHealth = maxHealth;
			healthBar.SetMaxHealth(maxHealth);
		}

		void Update()
		{

		}

		public void TakeDamage(int damage)
		{
			currentHealth -= damage;
			healthBar.SetHealth(currentHealth);
			if (currentHealth <= 0)
			{
				Die();
			}
		}

		private void Die()
		{
			Destroy(gameObject);
		}
	}
}