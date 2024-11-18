using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringParamTest : MonoBehaviour
{
	public void Start()
	{
		printLines("¾È", "³ç", "ÇÏ", "¼¼", "¿ä");
	}
	public void printLines(params string[] lines)
	{
		foreach (string line in lines)
		{
			print(line);
		}
	}
}
