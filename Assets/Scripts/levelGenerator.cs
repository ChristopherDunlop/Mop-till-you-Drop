using UnityEngine;
using System.Collections;

public class levelGenerator : MonoBehaviour {

	public GameObject center,gameController;
	public int mops = 0;

	// Use this for initialization
	void Start () {
		GameObject Map = new GameObject();
		Map.name=("Map Components");

		System.Random random = new System.Random();
		int randomX = random.Next(5, 11);
		int randomY = random.Next(5, 11);

		randomX = randomX * 128;
		randomY = randomY * 96;

		GameObject mc = GameObject.Find("Main Camera");
		Vector3 cameraPos = new Vector3 ((randomX/2)/100f,(randomY/2)/100f,-10f);
		mc.transform.position = cameraPos; 

		for(float x = 0;x<randomX;x=x+128)
		{
			for(float y = 0;y<randomY;y=y+96)
			{
				Instantiate(center,new Vector3(x/100, y/100, 0),Quaternion.identity);
				GameObject newCenter = GameObject.Find("centerColl(Clone)");
				newCenter.name=("Center (" + x + ", " + y + ")");
				newCenter.transform.parent = Map.transform;
				mops++;			
			}			
		}

		EdgeCollider2D edgeCol = Map.AddComponent<EdgeCollider2D> ();

		Vector2[] colliderpoints = new Vector2[5];
		colliderpoints[0] = new Vector2(-0.01f,-0.01f);
		colliderpoints[1] = new Vector2(-0.01f,(randomY+1)/100f);
		colliderpoints [2] = new Vector2 ((randomX+1)/100f, (randomY+1)/100f);
		colliderpoints [3] = new Vector2 ((randomX+1)/100f, -0.01f);
		colliderpoints [4] = new Vector2 (-0.01f,-0.01f);
		edgeCol.points =  colliderpoints;

		GameObject gc = GameObject.Find("GameController");		
		gameController levelScript = gc.GetComponent<gameController>();
		levelScript.toMop = mops-1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
