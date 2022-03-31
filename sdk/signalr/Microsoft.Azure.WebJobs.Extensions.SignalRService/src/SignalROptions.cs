// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core.Serialization;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.WebJobs.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        /// <summary>
        /// Gets the list of SignalR service.
        /// </summary>
        public IList<ServiceEndpoint> ServiceEndpoints { get; } = new List<ServiceEndpoint>();

        /// <summary>
        /// Gets or sets the service transport type.
        /// </summary>
        public ServiceTransportType ServiceTransportType { get; set; } = ServiceTransportType.Transient;

        /// <summary>
        /// Customize the JSON serialization for sending messages.
        /// </summary>
        /// <param name="objectSerializer">The JSON object serializer to serialize parameters in messages.</param>
        public void UseJsonObjectSerializer(ObjectSerializer objectSerializer)
        {
            JsonObjectSerializer = objectSerializer;
        }

        internal ObjectSerializer JsonObjectSerializer { get; set; }

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
