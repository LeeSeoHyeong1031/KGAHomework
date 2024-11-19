using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AttributeController : MonoBehaviour
{
    private void Start()
    {
        BindingFlags bind = BindingFlags.Public | BindingFlags.Instance; //���ε� �� ���� ����
        MonoBehaviour[] monoBehaviours = FindObjectsOfType<MonoBehaviour>();

        foreach (MonoBehaviour monoBehaviour in monoBehaviours)
        {
            Type type = monoBehaviour.GetType();

            IEnumerable<FieldInfo> transformAttachedFields =
                type.GetFields(bind).Where(x => x.HasAttribute<ScaleAttribute>());

            foreach (FieldInfo fieldInfo in transformAttachedFields)
            {
                ScaleAttribute att = fieldInfo.GetCustomAttribute<ScaleAttribute>(); //������ null�� ��.
                object value = fieldInfo.GetValue(monoBehaviour);

                //value�� RendererŸ���̸� rend�� �Ҵ�
                if (value is Transform trans)
                {
                    //Renderer rend = value as Renderer; //�̰� ��� �ϴ°� ���� if���� ����س��� ��.
                    trans.localScale = new Vector3(att.x, att.y, att.z);
                }
                else if (value is RectTransform rect)
                {
                    rect.sizeDelta = new Vector2(att.x, att.y);
                }
                else
                {
                    Debug.LogError("��Ʈ����Ʈ�� �߸��� ���� �پ��ֳ׿�!");
                }
            }
        }

    }
}
public static class AttributeHelper
{
    public static bool HasAttribute<T>(this MemberInfo Info) where T : Attribute
    {
        return Info.GetCustomAttributes(typeof(T), true).Length > 0;
    }
}
