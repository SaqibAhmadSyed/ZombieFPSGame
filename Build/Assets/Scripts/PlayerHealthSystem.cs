using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class PlayerHealthSystem : MonoBehaviour {
	public Image greenBar, bloodBar;

	public string attackTag;
	//[HideInInspector]
	public float Life = 1;
	public static float bloodLife = 1;
	//[HideInInspector]
	public Transform currentTarget;
	private GameObject[] Targets;
	private GameObject gameManager;
	public GameObject bloodscreen;
	public static bool counterx = true;
	public static bool mycounter = false;
	// Use this for making thing on enble object
	void OnEnable() {
		print("script was enabled");
	}
	// Use this for initialization
	void Start () {
		bloodLife = 1;
		counterx = true;
		mycounter = false;
		findCurrentTarget ();
		//fill the healthbar
		greenBar.fillAmount = Life;
		//bloodBar.fillAmount = bloodLife;

		//find the GameMacnager
		//gameManager = GameObject.Find ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
//		findCurrentTarget ();
		////bloodLife -= 0.005f * Time.deltaTime;
		/// 
		/// 
		/// 
//		if(Shooter.counterx == false){
//
//			bloodscreen.SetActive(true); 
//
//		}else if(Shooter.counterx == true){
//			bloodscreen.SetActive(false); 
//		}

		if (Life != 1) {
			greenBar.fillAmount = Life;
			//if(counterx == true && mycounter == true && TimeController.islevelover == false){
                if (counterx == true && mycounter == true){
			bloodscreen.SetActive(true); 
				counterx = false;
				mycounter = false;
				
				StartCoroutine (counterdown());
			}

			}
		//if (bloodLife != 1) {
		//	bloodBar.fillAmount = bloodLife;
		//}
		if (Life <= 0 ) {
			Life = 0;
			//bloodLife = 0;
			//if(currentTarget.tag == "DummyPlayer")
				//gameManager.GetComponent<ScoreMeter> ().addScore (currentTarget.name);
			StartCoroutine (levelFail());
		}
	}

	void findCurrentTarget(){
		//find all potential targets (enemies of this character)
		Targets = GameObject.FindGameObjectsWithTag(attackTag);

		//distance between character and its nearest enemy
		float closestDistance = Mathf.Infinity;

		foreach(GameObject potentialTarget in Targets){
			//check if there are enemies left to attack and check per enemy if its closest to this character
			if(Vector3.Distance(transform.position, potentialTarget.transform.position) < closestDistance && potentialTarget != null){
				//if this enemy is closest to character, set closest distance to distance between character and enemy
				closestDistance = Vector3.Distance(transform.position, potentialTarget.transform.position);
				//also set current target to closest target (this enemy)
				if(!currentTarget || (currentTarget && Vector3.Distance(transform.position, currentTarget.position) > 102)){
					currentTarget = potentialTarget.transform;
				}
			}
		}	
	}
	IEnumerator  counterdown(){

		yield return new WaitForSeconds (1f);
		bloodscreen.SetActive(false); 
		yield return new WaitForSeconds (1f);
		counterx = true;
		mycounter = false;

	}
	IEnumerator  levelFail(){
	//	GameObject.FindWithTag("MainCamera2").GetComponent<GameDialogs> ().heathBar.SetActive (false);
	//	GameObject.FindWithTag("MainCamera2").GetComponent<GameDialogs> ().btn_Shoot.SetActive (false);
		yield return new WaitForSeconds (0.1f);
		Time.timeScale = 0;
		//if (bloodLife <= 0) {
		//	GameObject.FindWithTag ("MainCamera").GetComponent<GameDialogs> ().Dia_Failed ("You Need Food Kill Animal for Food!");
		//} else {
	//	GameObject.FindWithTag ("MainCamera2").GetComponent<GameDialogs> ().Dia_Failed ("");
		//}
	}
}
