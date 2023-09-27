using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AddressesBase.Models;

public class ApartmentOwner
{
    public int ApartmentId { get; set; }
    public Apartment? Apartment { get; set; }
    public int OwnerId { get; set; }
    public Owner? Owner { get; set; }

}