using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AddressesBase.Models;

public class StreetPrefix
{
    public int Id { get; set; }
    public string StreetPrefixName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Street> Streets { get; set; } = new();
    
}