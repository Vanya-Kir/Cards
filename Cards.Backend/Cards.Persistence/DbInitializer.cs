﻿namespace Cards.Persistence;

public class DbInitializer
{
    public static void Initialize(CardsDbContext context)
    {
        context.Database.EnsureCreated();
    }
}