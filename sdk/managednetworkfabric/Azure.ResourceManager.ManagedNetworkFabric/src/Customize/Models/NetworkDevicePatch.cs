// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // 1. The TypeSpec patch model now keeps the Swagger-compatible TagsUpdate base and the generated
    //    C# patch shape is renamed to NetworkDevicePatchContent.
    // 2. We keep this obsolete compatibility type with the shipped NetworkDevicePatch name and original
    //    NetworkRackPatch inheritance, then adapt it to the generated content type at operation boundaries.
    // 3. Without this custom code, the public NetworkDevicePatch type and Update overloads that accept it would be
    //    removed or would have the wrong base type, breaking existing callers.
    /// <summary> The Network Device Patch Parameters defines the patch parameters of the resource. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkDevicePatchContent instead.")]
    public partial class NetworkDevicePatch : NetworkRackPatch
    {
        /// <summary> Initializes a new instance of <see cref="NetworkDevicePatch"/>. </summary>
        public NetworkDevicePatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkDevicePatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> Network Device Patch properties. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        internal NetworkDevicePatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, NetworkDevicePatchParametersProperties properties, NetworkFabricManagedServiceIdentityPatch identity) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
            Identity = identity;
        }

        /// <summary> Network Device Patch properties. </summary>
        internal NetworkDevicePatchParametersProperties Properties { get; set; }

        /// <summary> The managed service identities assigned to this resource. </summary>
        public NetworkFabricManagedServiceIdentityPatch Identity { get; set; }

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
                    Properties = new NetworkDevicePatchParametersProperties();
                }
                Properties.Annotation = value;
            }
        }

        /// <summary> The host name of the device. </summary>
        public string HostName
        {
            get
            {
                return Properties is null ? default : Properties.HostName;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkDevicePatchParametersProperties();
                }
                Properties.HostName = value;
            }
        }

        /// <summary> Serial number of the device. Format of serial Number - Make;Model;HardwareRevisionId;SerialNumber. </summary>
        public string SerialNumber
        {
            get
            {
                return Properties is null ? default : Properties.SerialNumber;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkDevicePatchParametersProperties();
                }
                Properties.SerialNumber = value;
            }
        }

        /// <summary> The selection of the managed identity to use with this storage account. The identity type must be either system assigned or user assigned. </summary>
        public NetworkFabricIdentitySelectorPatch IdentitySelector
        {
            get
            {
                return Properties is null ? default : Properties.IdentitySelector;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkDevicePatchParametersProperties();
                }
                Properties.IdentitySelector = value;
            }
        }
    }
}
