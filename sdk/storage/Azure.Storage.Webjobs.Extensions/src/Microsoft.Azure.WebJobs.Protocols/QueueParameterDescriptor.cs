// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Microsoft.Azure.WebJobs.Host.Protocols
{
    /// <summary>Represents a parameter bound to a queue in Azure Storage.</summary>
    [JsonTypeName("Queue")]
    public class QueueParameterDescriptor : ParameterDescriptor
    {
        /// <summary>Gets or sets the name of the storage account.</summary>
        public string AccountName { get; set; }

        /// <summary>Gets or sets the name of the queue.</summary>
        public string QueueName { get; set; }

        /// <summary>Gets or sets the kind of access the parameter has to the queue.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public FileAccess Access { get; set; }
    }
}
