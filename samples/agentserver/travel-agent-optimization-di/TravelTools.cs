// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Microsoft.Extensions.AI;

namespace Azure.AI.AgentServer.Optimization.Configuration.Samples;

/// <summary>
/// Tool implementations exposed to the Microsoft Agent Framework agent via
/// <see cref="AIFunctionFactory"/>. The function names and parameter shapes
/// match the optimization config's <c>tools.json</c>, plus the upstream MAF
/// travel sample's destination picker.
/// </summary>
internal static class TravelTools
{
    private static readonly Random s_random = new();

    [Description("Provides a random vacation destination for travel planning.")]
    public static string GetRandomDestination()
    {
        string[] destinations =
        {
            "Paris, France", "Tokyo, Japan", "New York City, USA",
            "Sydney, Australia", "Rome, Italy", "Barcelona, Spain",
            "Cape Town, South Africa", "Rio de Janeiro, Brazil",
            "Bangkok, Thailand", "Vancouver, Canada"
        };
        return destinations[s_random.Next(destinations.Length)];
    }

    [Description("Search for flights between two cities on a given date.")]
    public static string SearchFlights(
        [Description("Departure city or airport code")] string origin,
        [Description("Arrival city or airport code")] string destination,
        [Description("Travel date in YYYY-MM-DD format")] string date)
    {
        // Stubbed demo data — wire to your real flight provider here.
        int basePrice = 300 + s_random.Next(0, 400);
        return $$"""
        [
          { "carrier": "Contoso Airlines", "from": "{{origin}}", "to": "{{destination}}", "date": "{{date}}", "depart": "08:15", "arrive": "11:40", "priceUsd": {{basePrice}} },
          { "carrier": "Fabrikam Air",     "from": "{{origin}}", "to": "{{destination}}", "date": "{{date}}", "depart": "13:05", "arrive": "16:25", "priceUsd": {{basePrice + 75}} }
        ]
        """;
    }

    [Description("Get hotel prices for a destination on given dates.")]
    public static string GetHotelPrices(
        [Description("City name")] string city,
        [Description("Check-in date YYYY-MM-DD")] string checkin,
        [Description("Check-out date YYYY-MM-DD")] string checkout)
    {
        int nightly = 120 + s_random.Next(0, 250);
        return $$"""
        [
          { "hotel": "Contoso Grand {{city}}", "checkin": "{{checkin}}", "checkout": "{{checkout}}", "pricePerNightUsd": {{nightly}} },
          { "hotel": "Fabrikam Boutique {{city}}", "checkin": "{{checkin}}", "checkout": "{{checkout}}", "pricePerNightUsd": {{nightly + 40}} }
        ]
        """;
    }
}
