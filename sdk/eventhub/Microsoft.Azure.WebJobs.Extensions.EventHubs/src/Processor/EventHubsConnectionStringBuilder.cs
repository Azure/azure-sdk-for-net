// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.WebJobs.EventHubs.Processor
{
    /// <summary>
    /// A simple builder which is useful for making small changes to parts of an EventHubs connection string. This class provides no validation, it is expected
    /// that if the connection string is invalid it will be detected when it is passed to the actual event hub client.
    /// </summary>
    internal class EventHubsConnectionStringBuilder
    {
        private const string EntityPathConnectionStringKeyName = "EntityPath";
        private const string EndpointConnectionStringKeyName = "Endpoint";

        private static readonly char[] ComponentsSplitChars = new char[] { ';' };
        private static readonly char[] ComponentSplitChars = new char[] { '=' };

        private Dictionary<string, string> _components;

        public string EntityPath
        {
            get
            {
                if (_components.TryGetValue(EntityPathConnectionStringKeyName, out string value))
                {
                    return value;
                }

                return null;
            }

            set
            {
                if (value == null)
                {
                    _components.Remove(EntityPathConnectionStringKeyName);
                }
                else
                {
                    _components[EntityPathConnectionStringKeyName] = value;
                }
            }
        }

        public Uri Endpoint {
            get
            {
                if (_components.TryGetValue(EndpointConnectionStringKeyName, out string value))
                {
                    return new Uri(value);
                }

                return null;
            }

            set
            {
                if (value == null)
                {
                    _components.Remove(EndpointConnectionStringKeyName);
                }
                else
                {
                    _components[EndpointConnectionStringKeyName] = value.ToString();
                }
            }
        }

        public EventHubsConnectionStringBuilder(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            _components = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (string component in connectionString.Split(ComponentsSplitChars, StringSplitOptions.RemoveEmptyEntries))
            {
                var parts = component.Split(ComponentSplitChars, 2);
                _components[parts[0]] = parts[1];
            }
        }

        public override string ToString()
        {
            return string.Join(";", _components.Select(x => { return $"{x.Key}={x.Value}"; }));
        }
    }
}
