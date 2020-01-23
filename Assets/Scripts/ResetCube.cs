using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCube : MonoBehaviour
{
	public GameObject cubo;

	public void ResetaCubo()
	{
		cubo.transform.position = gameObject.transform.position;
		cubo.transform.rotation = Quaternion.Euler(Vector3.zero);

	}
}
