using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AddressesBase.Models;

public class Apartment
{
    public int Id { get; set; }
    public int BuildingId { get; set; }
    public Building? Building { get; set; }
    public int ApartmentNumber { get; set; }
    public List<Owner> Owners { get; set; } = new();
    public List<ApartmentOwner> ApartmentOwners { get; set; } = new();

}