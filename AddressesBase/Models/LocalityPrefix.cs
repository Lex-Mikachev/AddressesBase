using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Addresses.Model;

public class LocalityPrefix : INotifyPropertyChanged
{
    private int _id;
    private string _localityPrefixName = string.Empty;
    private string _description = string.Empty;
    private List<Locality> _localities = new();

    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged("Id");
        }
    }

    public string LocalityPrefixName
    {
        get => _localityPrefixName;
        set
        {
            _localityPrefixName = value;
            OnPropertyChanged("LocalityPrefixName");
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

    public List<Locality> Localities
    {
        get => _localities;
        set
        {
            _localities = value;
            OnPropertyChanged("Localities");
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