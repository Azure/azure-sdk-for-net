// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class ServiceConfigParser
    {
        public string Endpoint { get; }

        public string AccessKey { get; }

        public string Version { get; }

        public string Port { get; }

        public ServiceConfigParser(string connectionString)
        {
            var settings = ParseConnectionString(connectionString);

            Endpoint = settings.ContainsKey("endpoint") ?
                settings["endpoint"] :
                throw new ArgumentNullException(nameof(Endpoint));
            AccessKey = settings.ContainsKey("accesskey") ?
                settings["accesskey"] :
                throw new ArgumentNullException(nameof(AccessKey));

            Version = settings.ContainsKey("version") ? settings["version"] : null;
            Port = settings.ContainsKey("port") ? settings["port"] : null;
        }

        private Dictionary<string, string> ParseConnectionString(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Web PubSub Service connection string is empty");
            }

            var setting = new Dictionary<string, string>();
            var items = connectionString.Split(';');

            try
            {
                setting = items.Where(x => x.Length > 0).ToDictionary(x => x.Split('=')[0].ToLower(), y => y.Split('=')[1]);
            }
            catch (Exception)
            {
                throw new ArgumentException($"Invalid Web PubSub connection string: {connectionString}");
            }
            return setting;
        }
    }
}
