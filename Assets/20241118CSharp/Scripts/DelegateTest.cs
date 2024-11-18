using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelegateTest : MonoBehaviour
{

	//UI ������Ʈ ���� ����
	[SerializeField] private InputField inputField;
	[SerializeField] private InputField inputField2;
	[SerializeField] private Button operatorButton;
	[SerializeField] private Button calcButton;
	[SerializeField] private Text resultText;

	private int inputNum;
	private int inputNum2;
	private int result;

	[SerializeField] private Text[] operators;
	[SerializeField] private string curOperator;

	private int cnt = 0;

	private void Start()
	{
		operators = operatorButton.GetComponentsInChildren<Text>();
	}

	private void Update()
	{
		//�� �޾ƿ���
		if (int.TryParse(inputField.text, out int num))
		{
			inputNum = num;
		}
		if (int.TryParse(inputField2.text, out int num2))
		{
			inputNum2 = num2;
		}
	}

	public void SelectButton()
	{
		//��� ����
		foreach (Text text in operators)
		{
			text.enabled = false;
		}

		//���� operator Text Ŵ
		operators[cnt].enabled = true;
		curOperator = operators[cnt].name;
		cnt++;

		//�ִ�ġ�� �����ϸ� �ٽ� 0���� �ʱ�ȭ
		if (cnt >= operators.Length)
		{
			cnt = 0;
		}
	}

	public void Calc()
	{
		//������ ���
		//� ������ ������� �˾ƾ� ��.
		if (curOperator == "Plus") result = Plus(inputNum, inputNum2);
		else if (curOperator == "Sub") result = Sub(inputNum, inputNum2);
		else if (curOperator == "Mul") result = Mul(inputNum, inputNum2);
		else if (curOperator == "Div") result = Div(inputNum, inputNum2);

		resultText.text = result.ToString();
	}

	public int Plus(int a, int b) { return a + b; }
	public int Sub(int a, int b) { return a - b; }
	public int Mul(int a, int b) { return a * b; }
	public int Div(int a, int b) { return a / b; }
}
