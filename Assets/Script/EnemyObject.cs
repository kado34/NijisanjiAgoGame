using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyObject : MonoBehaviour {
	private float speed = 0;
	private readonly float rightMax = 1750;
	private readonly float leftMax = 810;
	private readonly float heightMax = 1250;
	private readonly float heightMin = 500;
	private bool isRight = true;
	private bool isMovingStop = false;
	public bool IsMovingStop {
		set { isMovingStop = value; }
		get { return isMovingStop; }
	}
	private bool isSuccess = false;
	public bool IsSuccess {
		set { isSuccess = value; }
		get { return isSuccess; }
	}
	// Use this for initialization
	void Start () {
		float defaultY = Random.Range(heightMin,heightMax);
		float defaultX = Random.Range(leftMax,rightMax);
		transform.position = new Vector3(defaultX, defaultY, 0);
		int imageNum = Random.Range(0,2);
		//後でランダムに
		Texture texture = Resources.Load("Enemy"+imageNum) as Texture;
		GetComponent<Image>().material.mainTexture = texture;
		this.speed = Random.Range(10,50);

	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > rightMax && isRight){
			isRight = false;
		}else if (transform.position.x < leftMax && !isRight){
			isRight = true;
		}
		if (isRight && !isMovingStop){
			transform.position += new Vector3(speed,0,0);
		}else if (!isRight && !isMovingStop){
			transform.position += new Vector3(-speed,0,0);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		
	}

	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "agoagoago") {
			this.isSuccess = true;
			Debug.Log("ヴォエ！！！");
		}
	}

	private IEnumerator disapper(){
		Image image = this.GetComponent<Image>();
		for (float i = 1; i>0; i-=0.1f){
			Color defColor = image.color;
			defColor.a = i;
			image.color = defColor;
			yield return null;
		}
		Destroy(this.gameObject);
	}
}
