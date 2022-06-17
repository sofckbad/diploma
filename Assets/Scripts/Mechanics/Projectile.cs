using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Mechanics;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    #region Fields

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force;

    #endregion



    #region Methods

    private void OnCollisionEnter2D(Collision2D col)
    {
        var enemy = col.transform.GetComponent<EnemyController>();

        if (enemy != null)
        {
            Simulation.Schedule<EnemyDeath>().enemy = enemy;
        }

        rb.velocity = Vector2.zero;
        Destroy(gameObject);
        if(col.transform.gameObject.CompareTag("Box"))
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