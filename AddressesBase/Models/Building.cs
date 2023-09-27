using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Addresses.Model;

public class Building : INotifyPropertyChanged
{
    private int _id;
    private int _streetId;
    private Street? _street;
    private string _houseNumber = string.Empty;
    private int _apartmentAmount;
    private List<Apartment> _apartments = new();

    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged("Id");
        }
    }

    public int StreetId
    {
        get => _streetId;
        set
        {
            _streetId = value;
            OnPropertyChanged("StreetId");
        }
    }

    public Street? Street
    {
        get => _street;
        set
        {
            _street = value;
            OnPropertyChanged("Street");
        }
    }

    public string HouseNumber
    {
        get => _houseNumber;
        set
        {
            _houseNumber = value;
            OnPropertyChanged("HouseNumber");
        }
    }

    public int ApartmentsAmount
    {
        get => _apartmentAmount;
        set
        {
            _apartmentAmount = value;
            OnPropertyChanged("ApartmentsAmount");
        }
    }

    public List<Apartment> Apartments
    {
        get => _apartments;
        set
        {
            _apartments = value;
            OnPropertyChanged("Apartments");
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