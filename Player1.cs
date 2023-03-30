using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour {

	private int count;
	public Text countText;
	public Text winText;
	public Text Story1;
	public Transform AppearEnemy1;
	public Transform AppearEnemy2;
	public Transform AppearEnemy3;
	public Text timerText;
	public GameObject Teleport;
	public Text item;
	public GameObject door;

	// Use this for initialization
	void Start () {
	
		count = 0;
		SetCountText ();
		winText.text = "";
		Story1.text = "In a castle surrounded by walls, there are many traps and guards. \nAt night a thief infiltrated the castle. \nYou need to find all the treasures and escape the castle";
		item.text = "";


		AppearEnemy1.gameObject.SetActive (false);
		Time.timeScale = 1;

		AppearEnemy2.gameObject.SetActive (false);
		Time.timeScale = 1;

		AppearEnemy3.gameObject.SetActive (false);
		Time.timeScale = 1;

		Teleport.gameObject.SetActive (false);
		Time.timeScale = 1;

		door.gameObject.SetActive (false);
		Time.timeScale = 1;

		StartCoroutine (reloadTimer (300));

	}
	
	// Update is called once per frame
	void Update () {

		if (count >= 5) {
			AppearEnemy1.gameObject.SetActive (true);
			AppearEnemy2.gameObject.SetActive (true);
		}

		if (count == 100) {
			AppearEnemy3.gameObject.SetActive (true);
		}

		if (count >= 150){
			AppearEnemy1.gameObject.SetActive (false);
			AppearEnemy2.gameObject.SetActive (false);
			AppearEnemy3.gameObject.SetActive (false);
		}

		if (count >= 250) {
			Teleport.gameObject.SetActive (true);
		}

		if (count >= 300) {
			door.gameObject.SetActive (true);
		}

	
	}

	void OnTriggerEnter ( Collider other ) {

		if (other.gameObject.CompareTag ("sword")) {
			other.gameObject.SetActive (false);
			count = count + 50;
			SetCountText ();
		}

		if (other.gameObject.CompareTag ("sword")) {
			item.text = "You pick up the sword and expel the enemy, \ngo into the tower and find another treasures.";
		}


		
		if (other.gameObject.CompareTag ("gold coin")) {
			other.gameObject.SetActive (false);
			count = count + 5;
			SetCountText ();
		}
			
		if (other.gameObject.CompareTag ("gold coin")) {
			item.text = "You got a gold coin, \nmost of the gold coins are round disks and expensive.";
		}

		if (other.gameObject.CompareTag ("gold stick")) {
			other.gameObject.SetActive (false);
			count = count + 15;
			SetCountText ();
		}
			
		if (other.gameObject.CompareTag ("gold stick")) {
			item.text = "You get a gold bar, \ngold bar is a quantity of refined metallic \ngold of any shape that is made by a bar, \nvery expensive.";
		}

		if (other.gameObject.CompareTag ("diamond")) {
			other.gameObject.SetActive (false);
			count = count + 30;
			SetCountText ();
		}

		if (other.gameObject.CompareTag ("diamond")) {
			item.text = "You got a diamond, \ndiamond is a precious stone consisting of a clear \nand colorless crystalline form of pure carbon, \nthe hardest naturally occurring substance.";
		}
		if (other.gameObject.CompareTag ("gem")) {
			other.gameObject.SetActive (false);
			count = count + 50;
			SetCountText ();
		}

		if (other.gameObject.CompareTag ("gem")) {
			item.text = "You got a gem, \ngem is stones are cut, ground \nand polished minerals that are very expensive.";
		}
				
		if (other.gameObject.CompareTag ("trap")) {
			SceneManager.LoadScene ("Level1");
		
		}

		if (other.gameObject.CompareTag ("door")) {
			SceneManager.LoadScene ("Win");

		}

		if (other.gameObject.CompareTag ("openchest")) {
			other.gameObject.SetActive (false);
			count = count + 50;
			SetCountText ();
		}
				
		if (other.gameObject.CompareTag ("teleport")) {
			Story1.text = "You are teleported into the secret room, \nthere is a treasure chest in front, \nget it and find a way to get out!";
			item.text = "";
		}

		if (other.gameObject.CompareTag ("teleport1")) {
			Story1.text = "You collect all the treasures, \nLet's escape the castle through the door in the entrance.";
			item.text = "";
		}
	}

		
			


	IEnumerator reloadTimer(float reloadTimeInSeconds){
		float counter = 0;
		while (counter < reloadTimeInSeconds) {
			counter += Time.deltaTime;
			timerText.text = counter.ToString();
			yield return null;
		}

		SceneManager.LoadScene ("Level1");
	}


 void SetCountText () {
	countText.text = "Collection:" + count.ToString ();

		if (count >= 5) {
			Story1.text = "collect the treasure, \nguard are arresting you, \nwatch out for the spike trap ahead and pick up weapons and expel the enemy";
		}

		if (count >= 150) {
			Story1.text = "You collect 6 treasure, \nlet's go into the tower and see what's inside.";
		}

		if (count == 250) {
			Story1.text = "You find the treasure of tower, \nThe statue appears, \nlet's go out of the tower and touch it then see what happens.";
		}

		if (count >= 300) {
			winText.text = "You get all the treasure, let's escape the castle right now!!!";
		}

		if (count == 300) {
			Story1.text = "There is a statue in front, \ntouch the statue and leave the secret room!";
		}

	}


}
