using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Dice/Organizer")]
public class DiceOrganizer : ScriptableObject
{
	public GameObject[] mesh;
	public Material[] materials;
}
