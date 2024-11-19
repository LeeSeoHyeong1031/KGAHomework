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
        BindingFlags bind = BindingFlags.Public | BindingFlags.Instance; //바인딩 할 범위 제한
        MonoBehaviour[] monoBehaviours = FindObjectsOfType<MonoBehaviour>();

        foreach (MonoBehaviour monoBehaviour in monoBehaviours)
        {
            Type type = monoBehaviour.GetType();

            IEnumerable<FieldInfo> transformAttachedFields =
                type.GetFields(bind).Where(x => x.HasAttribute<ScaleAttribute>());

            foreach (FieldInfo fieldInfo in transformAttachedFields)
            {
                ScaleAttribute att = fieldInfo.GetCustomAttribute<ScaleAttribute>(); //없으면 null이 옴.
                object value = fieldInfo.GetValue(monoBehaviour);

                //value가 Renderer타입이면 rend에 할당
                if (value is Transform trans)
                {
                    //Renderer rend = value as Renderer; //이걸 써야 하는걸 위에 if문에 축약해놓은 것.
                    trans.localScale = new Vector3(att.x, att.y, att.z);
                }
                else if (value is RectTransform rect)
                {
                    rect.sizeDelta = new Vector2(att.x, att.y);
                }
                else
                {
                    Debug.LogError("어트리뷰트가 잘못된 곳에 붙어있네요!");
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
