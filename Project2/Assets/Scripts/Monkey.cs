using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    #region Attack_variables
    public GameObject projectile;
	public float timeToReload;
	public float fireSpeed;
	public float projectileExistTime = 2;
	float reloadTimer = 0;
	#endregion

	public GameObject explosionObj;

	List<GameObject> balloonList;

	void Awake()
	{
		balloonList = new List<GameObject>();

		reloadTimer = 0;
	}


	void Update()
	{
		// check if shooter is reloaded
		if (reloadTimer > timeToReload)
		{
			// check if there are any targets within range
			if (balloonList.Count > 0)
			{
				reloadTimer = 0;
				//shoot at one player in range
				if (balloonList.Count != 0)
				{
					GameObject obj = balloonList[0];
					//calculate the trajectory vector 
					float x = obj.transform.position.x - transform.position.x;
					float y = obj.transform.position.y - transform.position.y;
					Vector2 FireDirection = new Vector2(x, y);
					FireDirection = FireDirection.normalized * fireSpeed;

					// Create the projectile and Access its Rigidbody to add force
					GameObject newProjectile = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
					newProjectile.GetComponent<Rigidbody2D>().velocity = FireDirection;
					//If the projectile exists after 5 seconds, destroy it
					Destroy(newProjectile, projectileExistTime);
				}
			}
		}
		else
		{
			reloadTimer += Time.deltaTime;
		}
	}

	//Add enemy into target list when enemy enters range
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (IsBalloon(coll.gameObject))
		{
			balloonList.Add(coll.gameObject);
		}
		//TASK 3
		//HINT: Use coll.gameObject to get a reference to coll's GameObject
	}

	//Remove enemy from target list when enemy leaves range
	void OnTriggerExit2D(Collider2D coll)
	{
		if (IsBalloon(coll.gameObject))
		{
			balloonList.Remove(coll.gameObject);
		}
	}

    //Destroy itself when touched by a balloon
    private void OnCollisionEnter2D(Collision2D coll)
    {
		if (IsBalloon(coll.gameObject))
		{
			Destroy(this.gameObject);

			//To do: Create Explosion
			Debug.Log("Monkey got eliminated by balloon. Explosion.");
			Instantiate(explosionObj, transform.position, transform.rotation);
		}
	}

    //Returns whether or not the Game Object is the Player Character
    bool IsBalloon(GameObject obj)
	{
		return obj.CompareTag("Balloon");
	}

}
