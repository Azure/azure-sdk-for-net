// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class HttpMessageExtensions
    {
        private const string ConnectionVars = "AzMonExp_ConnectionVars";

        public static void SetConnectionVars(this HttpMessage httpMessage, ConnectionVars connectionVars)
        {
            httpMessage.SetProperty(ConnectionVars, connectionVars);
        }

        public static ConnectionVars? GetConnectionVars(this HttpMessage httpMessage)
        {
            if (httpMessage.TryGetProperty(ConnectionVars, out var obj) && obj != null)
            {
                return (ConnectionVars)obj;
            }
            else
            {
                return null;
            }
        }
    }
}
