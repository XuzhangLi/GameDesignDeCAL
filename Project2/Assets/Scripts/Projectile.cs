using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region Attack_variables
    public float explosionDamage;
    public float explosionRadius;
    public GameObject explosionObj;
    #endregion
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (IsBalloon(coll.gameObject))
        {

            Explode();
        }

    }
    private void Explode()
    {
        // call audioManager for explosion
        //FindObjectOfType<AudioManager>().Play("Explosion");

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, explosionRadius, Vector2.zero);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.CompareTag("Balloon"))
            {
                //Cause damage
                Debug.Log("Hit Balloon with explosion");
                hit.transform.GetComponent<Balloon>().TakeDamage(explosionDamage);
                //spawn explosion prefab
                Instantiate(explosionObj, transform.position, transform.rotation);
                //hit.transform.GetComponent<PlayerController2>().TakeDamage(explosionDamage);
                Destroy(this.gameObject);
            }
        }
        Destroy(this.gameObject);
    }
        //TASK 3
        //HINT: Use coll.gameObject to get a reference to coll's GameObject
	bool IsBalloon(GameObject obj)
	{
		return obj.CompareTag("Balloon");
	}
}