using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Mechanics;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    #region Fields

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject ps;
    [SerializeField] private GameObject ps1;
    [SerializeField] private float force;

    #endregion



    #region Methods

    private void OnCollisionEnter2D(Collision2D col)
    {
        var enemy = col.transform.GetComponent<EnemyController>();

        if (enemy?.gameObject.CompareTag("water") ?? false)
        {
            Simulation.Schedule<EnemyDeath>().enemy = enemy;
            enemy.ApplyDamage(1);
            Instantiate(ps1).transform.position = transform.position;
        }

        rb.velocity = Vector2.zero;
        Instantiate(ps).transform.position = transform.position;
        Destroy(gameObject);
        if (col.transform.gameObject.CompareTag("Box"))
        {
            Destroy(col.transform.gameObject);
        }
    }


    public void Throw(Vector2 move)
    {
        rb.AddForce(move.normalized * force);
    }

    #endregion
}