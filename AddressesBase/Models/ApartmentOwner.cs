using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Addresses.Model;

public class ApartmentOwner : INotifyPropertyChanged
{
    private int _apartmentId;
    private Apartment? _apartment;
    private int _ownerId;
    private Owner? _owner;

    public int ApartmentId
    {
        get => _apartmentId;
        set
        {
            _apartmentId = value;
            OnPropertyChanged("ApartmentId");
        }
    }

    public Apartment? Apartment
    {
        get => _apartment;
        set
        {
            _apartment = value;
            OnPropertyChanged("Apartment");
        }
    }

    public int OwnerId
    {
        get => _ownerId;
        set
        {
            _ownerId = value;
            OnPropertyChanged("OwnerId");
        }
    }

    public Owner? Owner
    {
        get => _owner;
        set
        {
            _owner = value;
            OnPropertyChanged("Owner");
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