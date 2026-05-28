// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> The Access Control Lists patch resource definition. </summary>
    public partial class NetworkFabricAccessControlListPatch : NetworkRackPatch, IJsonModel<NetworkFabricAccessControlListPatch>
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricAccessControlListPatch"/>. </summary>
        public NetworkFabricAccessControlListPatch()
        {
        }

        /// <summary> Access Control Lists patch properties. </summary>
        internal AccessControlListPatchProperties Properties { get; set; }

        /// <summary> Input method to configure Access Control List. </summary>
        public NetworkFabricConfigurationType? ConfigurationType
        {
            get => Properties is null ? default : Properties.ConfigurationType;
            set
            {
                Properties ??= new AccessControlListPatchProperties();
                Properties.ConfigurationType = value;
            }
        }

        /// <summary> Access Control List file URL. </summary>
        public Uri AclsUri
        {
            get => Properties is null ? default : Properties.AclsUri;
            set
            {
                Properties ??= new AccessControlListPatchProperties();
                Properties.AclsUri = value;
            }
        }

        /// <summary> Default action that needs to be applied when no condition is matched. Example: Permit | Deny. </summary>
        public CommunityActionType? DefaultAction
        {
            get => Properties is null ? default : Properties.DefaultAction;
            set
            {
                Properties ??= new AccessControlListPatchProperties();
                Properties.DefaultAction = value;
            }
        }

        /// <summary> List of match configurations. </summary>
        public IList<AccessControlListMatchConfiguration> MatchConfigurations
        {
            get
            {
                Properties ??= new AccessControlListPatchProperties();
                return Properties.MatchConfigurations;
            }
        }

        /// <summary> List of dynamic match configurations. </summary>
        public IList<CommonDynamicMatchConfiguration> DynamicMatchConfigurations
        {
            get
            {
                Properties ??= new AccessControlListPatchProperties();
                return Properties.DynamicMatchConfigurations;
            }
        }

        /// <summary> Access Control List (ACL) configurations. </summary>
        public IList<ControlPlaneAclPatchProperties> ControlPlaneAclConfiguration
        {
            get
            {
                Properties ??= new AccessControlListPatchProperties();
                return Properties.ControlPlaneAclConfiguration;
            }
        }

        /// <summary> Access Control List (ACL) Type. </summary>
        public NetworkFabricAclType? AclType
        {
            get => Properties is null ? default : Properties.AclType;
            set
            {
                Properties ??= new AccessControlListPatchProperties();
                Properties.AclType = value;
            }
        }

        /// <summary> Device Role. </summary>
        public NetworkFabricDeviceRole? DeviceRole
        {
            get => Properties is null ? default : Properties.DeviceRole;
            set
            {
                Properties ??= new AccessControlListPatchProperties();
                Properties.DeviceRole = value;
            }
        }

        /// <summary> Global Access Control List (ACL) actions. </summary>
        public GlobalAccessControlListActionPatchProperties GlobalAccessControlListActions
        {
            get => Properties is null ? default : Properties.GlobalAccessControlListActions;
            set
            {
                Properties ??= new AccessControlListPatchProperties();
                Properties.GlobalAccessControlListActions = value;
            }
        }

        /// <summary> Switch configuration description. </summary>
        public string Annotation
        {
            get => Properties is null ? default : Properties.Annotation;
            set
            {
                Properties ??= new AccessControlListPatchProperties();
                Properties.Annotation = value;
            }
        }

        internal NetworkFabricAccessControlListPatchContent ToContent()
        {
            NetworkFabricAccessControlListPatchContent content = new NetworkFabricAccessControlListPatchContent();
            foreach (KeyValuePair<string, string> tag in Tags)
            {
                content.Tags[tag.Key] = tag.Value;
            }
            content.ConfigurationType = ConfigurationType;
            content.AclsUri = AclsUri;
            content.DefaultAction = DefaultAction;
            foreach (AccessControlListMatchConfiguration item in MatchConfigurations)
            {
                content.MatchConfigurations.Add(item);
            }
            foreach (CommonDynamicMatchConfiguration item in DynamicMatchConfigurations)
            {
                content.DynamicMatchConfigurations.Add(item);
            }
            foreach (ControlPlaneAclPatchProperties item in ControlPlaneAclConfiguration)
            {
                content.ControlPlaneAclConfiguration.Add(item);
            }
            content.AclType = AclType;
            content.DeviceRole = DeviceRole;
            content.GlobalAccessControlListActionsEnableCount = GlobalAccessControlListActions?.EnableCount;
            content.Annotation = Annotation;
            return content;
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<NetworkFabricAccessControlListPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<NetworkFabricAccessControlListPatchContent>)ToContent()).Write(writer, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        NetworkFabricAccessControlListPatch IJsonModel<NetworkFabricAccessControlListPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            NetworkFabricAccessControlListPatchContent content = ((IJsonModel<NetworkFabricAccessControlListPatchContent>)new NetworkFabricAccessControlListPatchContent()).Create(ref reader, options);
            NetworkFabricAccessControlListPatch patch = new NetworkFabricAccessControlListPatch();
            foreach (KeyValuePair<string, string> tag in content.Tags)
            {
                patch.Tags[tag.Key] = tag.Value;
            }
            patch.Properties = content.Properties;
            return patch;
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<NetworkFabricAccessControlListPatch>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<NetworkFabricAccessControlListPatchContent>)ToContent()).Write(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        NetworkFabricAccessControlListPatch IPersistableModel<NetworkFabricAccessControlListPatch>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            NetworkFabricAccessControlListPatchContent content = ((IPersistableModel<NetworkFabricAccessControlListPatchContent>)new NetworkFabricAccessControlListPatchContent()).Create(data, options);
            NetworkFabricAccessControlListPatch patch = new NetworkFabricAccessControlListPatch();
            foreach (KeyValuePair<string, string> tag in content.Tags)
            {
                patch.Tags[tag.Key] = tag.Value;
            }
            patch.Properties = content.Properties;
            return patch;
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<NetworkFabricAccessControlListPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
