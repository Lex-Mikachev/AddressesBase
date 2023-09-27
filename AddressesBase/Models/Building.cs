using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AddressesBase.Models;

public class Building
{
    public int Id { get; set; }
    public int StreetId { get; set; }
    public Street? Street { get; set; }
    public string HouseNumber { get; set; } = string.Empty;
    public int ApartmentAmount { get; set; }
    public List<Apartment> Apartments { get; set; } = new();

}