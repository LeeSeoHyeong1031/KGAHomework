using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ExtensionMethodTest : MonoBehaviour
{
	private char c;
	private void Start()
	{
		StringSplitHelper.MySplit("�ȳ� �ϼ���", c);
	}
}

public static class StringSplitHelper
{
	public static char[] MySplit(this string str, char c)
	{
		char[] result = null;


		return result;
	}
}
