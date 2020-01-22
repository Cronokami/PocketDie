using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxMovement : MonoBehaviour
{

	private bool hasGyro;
	private Rigidbody rb;

	public Text gyroPos;
	public GameObject debugCube;
	public Material red;
	public Material green;

	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody>();

		if (SystemInfo.supportsGyroscope)
		{
			Input.gyro.enabled = true;
			hasGyro = true;
		}
		else
		{
			hasGyro = false;
		}


		if (hasGyro)
		{
			debugCube.GetComponent<MeshRenderer>().material = green;
		}
		else
		{
			debugCube.GetComponent<MeshRenderer>().material = red;
		}
	}

    // Update is called once per frame
    void Update()
    {
		if (hasGyro)
		{
			rb.MoveRotation(Input.gyro.attitude);

		}
		else
		{
			//faz os bagulho com o acelerômetro em algum momento aee
		}
		
		
	}



}
