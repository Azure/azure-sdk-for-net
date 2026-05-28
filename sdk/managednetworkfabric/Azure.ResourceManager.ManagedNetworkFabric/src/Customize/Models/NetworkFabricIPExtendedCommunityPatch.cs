// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> The IP Extended Communities patch resource definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkFabricIPExtendedCommunityPatchContent instead.")]
    public partial class NetworkFabricIPExtendedCommunityPatch : NetworkRackPatch
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricIPExtendedCommunityPatch"/>. </summary>
        public NetworkFabricIPExtendedCommunityPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricIPExtendedCommunityPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> IP Extended Community patchable properties. </param>
        internal NetworkFabricIPExtendedCommunityPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, IpExtendedCommunityPatchProperties properties) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
        }

        /// <summary> IP Extended Community patchable properties. </summary>
        internal IpExtendedCommunityPatchProperties Properties { get; set; }

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
                    Properties = new IpExtendedCommunityPatchProperties();
                }
                Properties.Annotation = value;
            }
        }

        /// <summary> List of IP Extended Community Rules. </summary>
        public IList<IPExtendedCommunityRule> IPExtendedCommunityRules
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new IpExtendedCommunityPatchProperties();
                }
                return Properties.IPExtendedCommunityRules;
            }
        }
    }
}
