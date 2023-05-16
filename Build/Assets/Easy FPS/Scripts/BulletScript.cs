using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{

	[Tooltip("Furthest distance bullet will look for target")]
	public float maxDistance = 1000000;
	RaycastHit hit;
	[Tooltip("Prefab of wall damage hit. The object needs 'LevelPart' tag to create decal on it.")]
	public GameObject decalHitWall;
	[Tooltip("Prefab of wall damage hit. The object needs 'LevelPart' tag to create decal on it.")]
	public GameObject decalHitConcrete;
	[Tooltip("Decal will need to be slightly in front of the wall so it doesn't cause rendering problems so for best feel put from 0.01-0.1.")]
	public float floatInfrontOfWall;
	[Tooltip("Blood prefab particle this bullet will create upon hitting enemy")]
	public GameObject bloodEffect;
	[Tooltip("Put Weapon layer and Player layer to ignore bullet raycast.")]
	public LayerMask ignoreLayer;
	[Tooltip("Damage amount")]
	public float damage;

	/*
	* Upon bullet creation with this script attached,
	* bullet creates a raycast which searches for corresponding tags.
	* If raycast finds something it will create a decal of corresponding tag.
	*/
	void Update()
	{
		if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, ~ignoreLayer))
		{
			if (decalHitWall)
			{
				if (hit.transform.tag == "Footsteps/Wood")
				{
					Instantiate(decalHitWall, hit.point + hit.normal * floatInfrontOfWall, Quaternion.LookRotation(hit.normal));
					Destroy(gameObject);
				}
				if (hit.transform.tag == "Concrete")
				{
					Instantiate(decalHitConcrete, hit.point + hit.normal * floatInfrontOfWall, Quaternion.LookRotation(hit.normal));
					Destroy(gameObject);
				}
				if (hit.transform.tag == "Enemy")
				{
					Enemy enemy = hit.transform.GetComponent<Enemy>();
					enemy.TakeDamage(damage);
					Debug.Log(damage);
					Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
					Destroy(gameObject);
				}
			}
			Destroy(gameObject);
		}
		Destroy(gameObject, 0.1f);
	}
}