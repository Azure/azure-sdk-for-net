// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class StatsBeatHelper
    {
        internal static void InitializeStatsBeat(string connectionString)
        {
            // Race condition is not taken in to account here
            // If the exporters have different connection string
            // only one of them will be used.
            if (StatsBeat.Customer_Ikey == null)
            {
                ConnectionStringParser.GetValues(connectionString, out string instrumentationKey, out _);
                StatsBeat.Customer_Ikey = instrumentationKey;
            }
        }
    }
}
