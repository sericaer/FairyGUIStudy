using FairyGUI;
using FairyGUI.DataBind;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class TextInputBind : MonoBehaviour
{
    TestData testData;

    // Start is called before the first frame update
    void Start()
    {
        testData = new TestData();

        UIPackage.AddPackage("TextInputBind");

        var gComponent = UIPackage.CreateObject("TextInputBind", "Component1").asCom;
        gComponent.BindDataSource(testData);

        GRoot.inst.AddChild(gComponent);
    }

    // Update is called once per frame
    void Update()
    {

    }

    class TestData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string input
        {
            get
            {
                return _input;
            }
            set
            {
                _input = value;

                Debug.Log($"input changed to {_input}");

                OnPropertyChanged(nameof(input));
            }
        }

        private string _input;

        public TestData()
        {
            input = "INIT";
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
