// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class ServiceConfigParser
    {
        private static readonly char[] _valueSeparator = new char[] { '=' };
        private const char _partSeparator = ';';

        public Uri Endpoint { get; }

        public string AccessKey { get; }

        public string Version { get; }

        public int Port { get; }

        public ServiceConfigParser(string connectionString)
        {
            var settings = ParseConnectionString(connectionString);

            Endpoint = settings.ContainsKey("endpoint") ?
                new Uri(settings["endpoint"]) :
                throw new ArgumentException(nameof(Endpoint));
            AccessKey = settings.ContainsKey("accesskey") ?
                settings["accesskey"] :
                throw new ArgumentException(nameof(AccessKey));

            Version = settings.ContainsKey("version") ? settings["version"] : null;
            Port = settings.ContainsKey("port") ? int.Parse(settings["port"], CultureInfo.InvariantCulture) : 80;
        }

        private static Dictionary<string, string> ParseConnectionString(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Web PubSub Service connection string is empty");
            }

            var setting = new Dictionary<string, string>();
            var items = connectionString.Split(_partSeparator);

            try
            {
                setting = items.Where(x => x.Length > 0).ToDictionary(x => x.Split(_valueSeparator, 2)[0], y => y.Split(_valueSeparator, 2)[1], StringComparer.InvariantCultureIgnoreCase);
            }
            catch (Exception)
            {
                throw new ArgumentException($"Invalid Web PubSub connection string, please check.");
            }
            return setting;
        }
    }
}
