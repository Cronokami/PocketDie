using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCrontrol : MonoBehaviour 
{

	private bool GyroEnable;

	public Gyroscope Gyro;

	private GameObject cameraContainer;

	public Quaternion rotacao;



	void Start()
	{
		cameraContainer = new GameObject("Camera Container");
		cameraContainer.transform.position = transform.position;
		transform.SetParent(cameraContainer.transform);
		cameraContainer.AddComponent<Rigidbody>();
		cameraContainer.GetComponent<Rigidbody>().freezeRotation = true;
		cameraContainer.GetComponent<Rigidbody>().isKinematic = true;
		cameraContainer.AddComponent<BoxCollider>();
		cameraContainer.GetComponent<BoxCollider>().size *= 0.4f;
		cameraContainer.tag = "CameraContainer";



		GyroEnable = EnableGyro();


	}

	private bool EnableGyro()
	{
		if (SystemInfo.supportsGyroscope)
		{
			Gyro = Input.gyro;
			Gyro.enabled = true;

			cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
			rotacao = new Quaternion(0, 0, 1, 0);

			return true;
		}
		return false;
	}

	void FixedUpdate()
	{
		if (GyroEnable)
		{
			transform.localRotation = Quaternion.Slerp(transform.localRotation, Gyro.attitude * rotacao, 0.5f);
		}
	}

}
