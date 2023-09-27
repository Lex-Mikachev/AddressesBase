using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AddressesBase.Models;

public class Locality
{
    public int Id { get; set; }
    public  string LocalityName { get; set; }  = string.Empty;
    public  int LocalityPrefixId { get; set; }
    public  LocalityPrefix? LocalityPrefix { get; set; }
    public  List<Street> Streets { get; set; } = new();

}