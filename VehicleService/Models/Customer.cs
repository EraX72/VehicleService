﻿using System.Collections.Generic;

public class Customer
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; }
}