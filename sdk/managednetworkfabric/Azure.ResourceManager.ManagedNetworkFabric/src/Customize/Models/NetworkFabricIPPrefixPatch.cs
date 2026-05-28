// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // 1. The TypeSpec patch model now keeps the Swagger-compatible TagsUpdate base and the generated
    //    C# patch shape is renamed to NetworkFabricIPPrefixPatchContent.
    // 2. We keep this obsolete compatibility type with the shipped NetworkFabricIPPrefixPatch name and original
    //    NetworkRackPatch inheritance, then adapt it to the generated content type at operation boundaries.
    // 3. Without this custom code, the public NetworkFabricIPPrefixPatch type and Update overloads that accept it would be
    //    removed or would have the wrong base type, breaking existing callers.
    /// <summary> The IP Prefix patch resource definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkFabricIPPrefixPatchContent instead.")]
    public partial class NetworkFabricIPPrefixPatch : NetworkRackPatch
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricIPPrefixPatch"/>. </summary>
        public NetworkFabricIPPrefixPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricIPPrefixPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> IP Prefix patchable properties. </param>
        internal NetworkFabricIPPrefixPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, IpPrefixPatchProperties properties) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
        }

        /// <summary> IP Prefix patchable properties. </summary>
        internal IpPrefixPatchProperties Properties { get; set; }

        /// <summary> Switch configuration description. </summary>
        public string Annotation
        {
            get
            {
                return Properties is null ? default : Properties.Annotation;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new IpPrefixPatchProperties();
                }
                Properties.Annotation = value;
            }
        }

        /// <summary> The list of IP Prefix Rules. </summary>
        public IList<IPPrefixRule> IPPrefixRules
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new IpPrefixPatchProperties();
                }
                return Properties.IPPrefixRules;
            }
        }
    }
}
