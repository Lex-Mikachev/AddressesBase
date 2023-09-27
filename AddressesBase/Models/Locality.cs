using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Addresses.Model;

public class Locality : INotifyPropertyChanged
{
    private int _id;
    private string _localityName = string.Empty;
    private int _localityPrefixId;
    private LocalityPrefix? _localityPrefix;
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

    public string LocalityName
    {
        get => _localityName;
        set
        {
            _localityName = value;
            OnPropertyChanged("LocalityName");
        }
    }

    public int LocalityPrefixId
    {
        get => _localityPrefixId;
        set
        {
            _localityPrefixId = value;
            OnPropertyChanged("LocalityPrefixId");
        }
    }

    public LocalityPrefix? LocalityPrefix
    {
        get => _localityPrefix;
        set
        {
            _localityPrefix = value;
            OnPropertyChanged("LocalityPrefix");
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