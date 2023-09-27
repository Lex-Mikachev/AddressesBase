using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Addresses.Model;

public class Owner : INotifyPropertyChanged
{
    private int _id;
    private string _name = string.Empty;
    private string _surname = string.Empty;
    private string _patronymic = string.Empty;
    private List<Apartment> _apartments = new();
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

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged("Name");
        }
    }

    public string Surname
    {
        get => _surname;
        set
        {
            _surname = value;
            OnPropertyChanged("Surname");
        }
    }

    public string? Patronymic
    {
        get => _patronymic;
        set
        {
            _patronymic = value;
            OnPropertyChanged("Patronymic");
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