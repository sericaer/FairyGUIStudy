using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIPackage.AddPackage("HelloWorld");

        GComponent view = UIPackage.CreateObject("HelloWorld", "Component1").asCom;

        GRoot.inst.AddChild(view);

        var testField = view.GetChild("n0") as GTextField;

        //Class1 c1 = new Class1();
        //testField.text = c1.name;
        testField.text = "HelloWord";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
