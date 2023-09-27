using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Addresses.Model;

public class StreetPrefix : INotifyPropertyChanged
{
    private int _id;
    private string _streetPrefixName = string.Empty;
    private string _description = string.Empty;
    private List<Street> _streets = new();

    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged("Id");
        }
    }

    public string StreetPrefixName
    {
        get => _streetPrefixName;
        set
        {
            _streetPrefixName = value;
            OnPropertyChanged("StreetPrefixName");
        }
    }

    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChanged("Description");
        }
    }

    public List<Street> Streets
    {
        get => _streets;
        set
        {
            _streets = value;
            OnPropertyChanged("Streets");
        }
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}