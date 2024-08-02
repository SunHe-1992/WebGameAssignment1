using System;
using UnityEngine;


public class BhvApplicationQuit : MonoBehaviour
{
	private void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}
	private void OnApplicationQuit()
	{
		 
	}
}