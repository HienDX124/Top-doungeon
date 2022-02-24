using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EditorManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ClearLog();
    }

    public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}
