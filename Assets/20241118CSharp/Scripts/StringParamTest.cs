using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringParamTest : MonoBehaviour
{
	public void Start()
	{
		printLines("��", "��", "��", "��", "��");
	}
	public void printLines(params string[] lines)
	{
		foreach (string line in lines)
		{
			print(line);
		}
	}
}
