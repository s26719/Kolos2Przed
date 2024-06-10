﻿namespace zad9NaCodeFirst.Models;

public class Client_Trip
{
    public int IdClient { get; set; }
    public int IdTrip { get; set; }
    public int RegisteredAt { get; set; }
    public int? PaymentDate { get; set; }

    public virtual Client IdClientNavigation { get; set; }
    public virtual Trip IdTripNavigation { get; set; }
}