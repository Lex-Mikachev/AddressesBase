using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Addresses.Model;

public class Apartment : INotifyPropertyChanged
{
    private int _id;
    private int _buildingId;
    private Building? _building;
    private int _apartmentNumber;
    private List<Owner> _owners = new();
    private List<ApartmentOwner> _apartmentOwners = new();

    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged("Id");
        }
    }

    public int BuildingId
    {
        get => _buildingId;
        set
        {
            _buildingId = value;
            OnPropertyChanged("BuildingId");
        }
    }

    public Building? Building
    {
        get => _building;
        set
        {
            _building = value;
            OnPropertyChanged("Building");
        } 
    }

    public int ApartmentNumber
    {
        get => _apartmentNumber;
        set
        {
            _apartmentNumber = value;
            OnPropertyChanged("ApartmentNumber");
        }
    }

    public List<Owner> Owners
    {
        get => _owners;
        set
        {
            _owners = value;
            OnPropertyChanged("Owners");
        }
    }

    public List<ApartmentOwner> ApartmentOwners
    {
        get => _apartmentOwners;
        set
        {
            _apartmentOwners = value;
            OnPropertyChanged("ApartmentOwners");
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