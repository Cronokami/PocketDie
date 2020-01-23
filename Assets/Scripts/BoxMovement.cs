using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxMovement : MonoBehaviour
{

	private bool hasGyro;
	private Gyroscope gyro;
	private Rigidbody rb;

	private bool freeze;
	

	public Text gyroPos;
	public GameObject debugCube;
	public Material red;
	public Material green;


	private Quaternion offset;

	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody>();
		gyro = Input.gyro;
		hasGyro = EnableGyro();

		//StartCoroutine(HeatingUp());

	}

    // Update is called once per frame
    void Update()
    {

		if (freeze) return;

		if (hasGyro)
		{
			Quaternion rot = Quaternion.Inverse(gyro.attitude);
			 
			rb.MoveRotation(Quaternion.Slerp(rb.rotation, Quaternion.Euler(new Vector3(90.0f, 0.0f, 0.0f)) * rot, 0.5f));

		}
		else
		{
			//faz os bagulho com o acelerômetro em algum momento aee
		}

		gyroPos.text = gyro.attitude.ToString();
		
		
	}

	private bool EnableGyro()
	{
		if (SystemInfo.supportsGyroscope)
		{
			gyro.enabled = true;
			debugCube.GetComponent<MeshRenderer>().material = green;
			return true;
		}
		debugCube.GetComponent<MeshRenderer>().material = red;
		return false;

	}

	private IEnumerator HeatingUp()
	{
		freeze = true;
		yield return new WaitForSeconds(1);
		freeze = false;
	}

	private static Quaternion GyroToUnity(Quaternion q)
	{
		return new Quaternion(q.x, q.y, -q.z, -q.w);
	}

}
