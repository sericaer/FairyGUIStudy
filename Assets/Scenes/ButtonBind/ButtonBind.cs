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

        public bool isBtn2Enable
        {
            get
            {
                return _isBtn2Enable;
            }
            set
            {
                _isBtn2Enable = value;
                OnPropertyChanged(nameof(isBtn2Enable));
            }
        }

        private bool _isBtn2Enable;

        public void OnBtn1Click()
        {
            Debug.Log("Button1 Clicked");
            isBtn2Enable = !isBtn2Enable;
        }

        public void OnBtn2Click()
        {
            Debug.Log("Button2 Clicked");
        }

        public TestData()
        {
            isBtn2Enable = true;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
