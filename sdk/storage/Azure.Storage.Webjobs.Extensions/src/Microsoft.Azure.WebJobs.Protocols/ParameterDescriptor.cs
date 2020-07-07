// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents a parameter to an Azure WebJobs SDK function.</summary>
    [JsonConverter(typeof(ParameterDescriptorConverter))]
#if PUBLICPROTOCOL
    public class ParameterDescriptor
#else
    public class ParameterDescriptor
#endif
    {
        /// <summary>
        /// Gets or sets the parameter type. This property shouldn't be set explicitly.
        /// It is automatically set based on application of <see cref="JsonTypeNameAttribute"/>
        /// to derived types.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the parameter name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the parameter display hints.
        /// </summary>
        public ParameterDisplayHints DisplayHints { get; set; }

        /// <summary>
        /// Dictionary of all properties that were in a deserialized
        /// json payload but didn't have corresponding properties on
        /// the deserialized type. This ensures that we don't lose any
        /// data provided by extension bindings.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonExtensionData]
        public Dictionary<string, JToken> ExtendedProperties { get; set; }

        private class ParameterDescriptorConverter : PolymorphicJsonConverter
        {
            public ParameterDescriptorConverter()
                : base("Type", PolymorphicJsonConverter.GetTypeMapping<ParameterDescriptor>())
            {
            }
        }
    }
}
