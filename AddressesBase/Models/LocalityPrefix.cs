using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AddressesBase.Models;

public class LocalityPrefix
{
    public int Id { get; set; }
    public string LocalityPrefixName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Locality> Localities { get; set; } = new();
    
}