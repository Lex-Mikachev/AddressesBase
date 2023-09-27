using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Addresses.Model;

public class Street : INotifyPropertyChanged
{
    private int _id;
    private string _streetName = string.Empty;
    private int _streetPrefixId;
    private StreetPrefix? _streetPrefix;
    private int _localityId;
    private Locality? _locality;
    private List<Building> _buildings = new();

    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged("Id");
        }
    }

    public string StreetName
    {
        get => _streetName;
        set
        {
            _streetName = value;
            OnPropertyChanged("StreetName");
        }
    }

    public int StreetPrefixId
    {
        get => _streetPrefixId;
        set
        {
            _streetPrefixId = value;
            OnPropertyChanged("StreetPrefixId");
        }
    }

    public StreetPrefix? StreetPrefix
    {
        get => _streetPrefix;
        set
        {
            _streetPrefix = value;
            OnPropertyChanged("StreetPrefix");
        }
    }

    public int LocalityId
    {
        get => _localityId;
        set
        {
            _localityId = value;
            OnPropertyChanged("LocalityId");
        }
    }

    public Locality? Locality
    {
        get => _locality;
        set
        {
            _locality = value;
            OnPropertyChanged("Locality");
        }
    }

    public List<Building> Buildings
    {
        get => _buildings;
        set
        {
            _buildings = value;
            OnPropertyChanged("Buildings");
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