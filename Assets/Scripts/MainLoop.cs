using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;
using JetBrains.Annotations;

public class MainLoop: MonoBehaviour {
	
	public GameObject[] stones = new GameObject[3];
	private float torque = 5.0f;
	private float minAntiGravity = 20.0f, maxAntiGravity = 40.0f;
	private float minLateralForce = -15.0f, maxLateralForce = 15.0f;
	private float minTimeBetweenStones = 1f, maxTimeBetweenStones = 3f;
	private float minX = -30.0f, maxX = 30.0f;
	private float minZ = -5.0f, maxZ = 20.0f;
	
	private bool enableStones = true;
	private Rigidbody rigidBody;
	
	// Use this for initialization
	void Start () 
	{
        GameManager.currentNumberStoneThrow = 0;
		GameManager.currentNumberDestroyedStones = 0;
		GameManager.currentTime = 90.0f;

        StartCoroutine(ThrowStones());
	}

	// Update is called once per frame

	private void Update()
	{
		if (GameManager.currentTime > 0)
			GameManager.currentTime -= Time.deltaTime;
		else
            enableStones = false;
		
	}

	IEnumerator ThrowStones()
	{
		// Initial delay
		yield return new WaitForSeconds(2.0f);

		while (enableStones)
		{


			GameObject stone = (GameObject)Instantiate(stones[Random.Range(0, stones.Length)]);
			stone.transform.position = new Vector3(Random.Range(minX, maxX), -30.0f, Random.Range(minZ, maxZ));
			stone.transform.rotation = Random.rotation;

			rigidBody = stone.GetComponent<Rigidbody>();

			rigidBody.AddTorque(Vector3.up * torque, ForceMode.Impulse);
			rigidBody.AddTorque(Vector3.right * torque, ForceMode.Impulse);
			rigidBody.AddTorque(Vector3.forward * torque, ForceMode.Impulse);

			rigidBody.AddForce(Vector3.up * Random.Range(minAntiGravity, maxAntiGravity), ForceMode.Impulse);
			rigidBody.AddForce(Vector3.right * Random.Range(minLateralForce, maxLateralForce), ForceMode.Impulse);

			GameManager.currentNumberStoneThrow++;
            

            yield return new WaitForSeconds(Random.Range(minTimeBetweenStones, maxTimeBetweenStones));
		}
	}
	public void BackMenu()
	{
		SceneManager.LoadScene(0);
	}
    

}

