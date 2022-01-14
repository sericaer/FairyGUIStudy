using FairyGUI;
using FairyGUI.DataBind;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ButtonBind : MonoBehaviour
{
    TestData testData;

    // Start is called before the first frame update
    void Start()
    {
        testData = new TestData();

        UIPackage.AddPackage("ButtonBind");

        var gComponent = UIPackage.CreateObject("ButtonBind", "Component1").asCom;
        gComponent.BindDataSource(testData);

        GRoot.inst.AddChild(gComponent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class TestData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public void onClick()
        {
            Debug.Log("onClick");
        }

        public TestData()
        {

        }

    }
}
