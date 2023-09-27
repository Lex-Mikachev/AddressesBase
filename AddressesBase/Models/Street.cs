using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AddressesBase.Models;

public class Street
{
    public int Id { get; set; }
    public string StreetName { get; set; } = string.Empty;
    public int StreetPrefixId { get; set; }
    public StreetPrefix? StreetPrefix { get; set; }
    public int LocalityId { get; set; }
    public Locality? Locality { get; set; }
    public List<Building> Buildings { get; set; } = new();

}