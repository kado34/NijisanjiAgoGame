using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	private readonly float rightMax = 2000;
	private readonly float leftMax = 560;
	private bool isRight = true;
	private bool isMovingStop = false;
	public bool IsMovingStop {
		set { isMovingStop = value; }
		get { return isMovingStop; }
	}

	private float agoMax = 3000;
	private float height;
	private float width;
	private float defaultHeight;
	private float defaultWidth;

	// Use this for initialization
	void Start () {
		Vector2 size = this.GetComponent<RectTransform>().sizeDelta;
		this.GetComponent<BoxCollider>().size = size;
		this.height = size.y;
		this.width = size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > rightMax && isRight){
			isRight = false;
		}else if (transform.position.x < leftMax && !isRight){
			isRight = true;
		}
		if (isRight && !isMovingStop){
//			transform.position += new Vector3(50,0,0);
		}else if (!isRight && !isMovingStop){
//			transform.position += new Vector3(-50,0,0);
		}
		
	}

	public IEnumerator NobiAgo(){
		this.isMovingStop = true;
		while (this.height <= this.agoMax){
			this.height += 500; 
			this.GetComponent<RectTransform>().sizeDelta = new Vector2(this.width,this.height);
			this.GetComponent<BoxCollider>().size = new Vector2(this.width,this.height*2);
			yield return null;
		}
		yield return null;
	}
}
