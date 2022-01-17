using FairyGUI;
using FairyGUI.DataBind;
using System.ComponentModel;
using UnityEngine;

public class TextFieldBind : MonoBehaviour
{
    TestData testData;


    void Start()
    {
        testData = new TestData();

        UIPackage.AddPackage("TextFieldBind");

        var gComponent = UIPackage.CreateObject("TextFieldBind", "Component1").asCom;
        gComponent.BindDataSource(testData);

        GRoot.inst.AddChild(gComponent);
    }


    void Update()
    {
        testData.count++;
    }

    public class TestData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;

                OnPropertyChanged(nameof(count));
            }
        }

        private int _count;

        public TestData()
        {
            count = 0;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


