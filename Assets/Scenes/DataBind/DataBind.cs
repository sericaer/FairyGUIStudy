using FairyGUI;
using FairyGUI.DataBind;
using System.ComponentModel;
using UnityEngine;

public class DataBind : MonoBehaviour
{
    TestData testData;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        testData = new TestData();

        UIPackage.AddPackage("DataBind");

        GObject gObject = UIPackage.CreateObject("DataBind", "Component1");
        gObject.BindDataSource(testData);

        GRoot.inst.AddChild(gObject.asCom);
    }

    // Update is called once per frame
    void Update()
    {
        testData.name = count.ToString();
        count++;
    }
}

public class TestData : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public string name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;

            OnPropertyChanged("name");
        }
    }

    private string _name;

    public TestData()
    {
        _name = "Init";
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
