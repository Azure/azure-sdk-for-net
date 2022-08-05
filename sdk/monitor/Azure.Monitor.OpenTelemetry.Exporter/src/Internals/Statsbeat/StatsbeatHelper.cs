// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class StatsbeatHelper
    {
        internal static void InitializeStatsbeat(string connectionString)
        {
            // Race condition is not taken in to account here
            // If the exporters have different connection string
            // only one of them will be used.
            if (Statsbeat.Customer_Ikey == null)
            {
                ConnectionStringParser.GetValues(connectionString, out string instrumentationKey, out _);
                Statsbeat.Customer_Ikey = instrumentationKey;

                // TODO: set statsbeat connectionstring based on customer's connectionstring endpoint.
            }
        }
    }
}
