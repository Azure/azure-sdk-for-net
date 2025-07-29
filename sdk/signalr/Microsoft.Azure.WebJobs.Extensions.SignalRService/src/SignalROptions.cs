// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

using Azure.Core.Serialization;

using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.WebJobs.Hosting;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#nullable enable

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Configuration options for SignalR extensions.
    /// </summary>
    /// <remarks>
    /// The properties in `local.settings.json` or application settings will override the properties here.
    /// </remarks>
    public class SignalROptions : IOptionsFormatter
    {
        private IHubProtocol? _messagePackHubProtocol;

        /// <summary>
        /// Gets the list of SignalR service.
        /// </summary>
        public IList<ServiceEndpoint> ServiceEndpoints { get; } = new List<ServiceEndpoint>();

        /// <summary>
        /// Gets or sets the service transport type.
        /// </summary>
        public ServiceTransportType ServiceTransportType { get; set; } = ServiceTransportType.Transient;

        /// <summary>
        /// Gets or sets the JSON object serializer.
        /// </summary>
        public ObjectSerializer? JsonObjectSerializer { get; set; }

        /// <summary>
        /// Gets or sets the retry options.
        /// </summary>
        public ServiceManagerRetryOptions? RetryOptions { get; set; } = new();

        /// <summary>
        /// Gets or sets the timespan for HttpClient timeout.
        /// </summary>
        public TimeSpan? HttpClientTimeout { get; set; }

        /// <summary>
        /// Gets or sets the MessagePack hub <see cref="IHubProtocol"/>. Defaults to null and MessagePack hub protocol is not used.
        /// </summary>
        public IHubProtocol? MessagePackHubProtocol
        {
            get => _messagePackHubProtocol; set
            {
                if (value != null && !string.Equals(value.Name, "messagepack", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Only protocol named \"messagepack\"(case-insensitive) is allowed.");
                }
                _messagePackHubProtocol = value;
            }
        }

        /// <summary>
        /// Returns a string representation of this <see cref="SignalROptions"/> instance.
        /// </summary>
        string IOptionsFormatter.Format()
        {
            var options = new JObject
            {
                {nameof(ServiceEndpoints), JArray.FromObject(ServiceEndpoints.Select( e => e.ToString())) },
                {nameof(ServiceTransportType), ServiceTransportType.ToString()},
                {nameof(JsonObjectSerializer),  JsonObjectSerializer?.GetType().FullName}
            };
            return options.ToString(Formatting.Indented);
        }
    }
}
