// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;

namespace Azure.IoT.TimeSeriesInsights.Tests
{
    internal static class HostNameHelper
    {
        // Look for "HostName=", and then grab all the characters until just before the next semi-colon.
        private static readonly Regex s_hostNameRegex = new Regex("(?<=HostName=).*?(?=;)", RegexOptions.Compiled);

        /// <summary>
        /// Extracts the IoT Hub host name from the specified connection string
        /// </summary>
        public static string GetHostName(string iotHubConnectionString)
        {
            return s_hostNameRegex.Match(iotHubConnectionString).Value;
        }
    }
}
