// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

#nullable disable

namespace Azure.Provisioning.CognitiveServices
{
    /// <summary> Compatibility type for the project-scoped capability host resource name exposed by previous Azure.Provisioning.CognitiveServices releases. Use <see cref="CognitiveServicesProjectScopedCapabilityHost"/> instead. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsolete and will be removed in a future release. Use CognitiveServicesProjectScopedCapabilityHost instead.")]
    public partial class CognitiveServicesProjectCapabilityHost : ProvisionableResource
    {
        private BicepValue<ResourceIdentifier> _id;
        private BicepValue<string> _name;
        private SystemData _systemData;
        private CognitiveServicesCapabilityHostProperties _properties;
        private ResourceReference<CognitiveServicesProject> _parent;

        /// <summary> Creates a new CognitiveServicesProjectCapabilityHost. </summary>
        /// <param name="bicepIdentifier"> The bicep identifier name. </param>
        /// <param name="resourceVersion"> The resource API version. </param>
        public CognitiveServicesProjectCapabilityHost(string bicepIdentifier, string resourceVersion = null) : base(bicepIdentifier, "Microsoft.CognitiveServices/accounts/projects/capabilityHosts", resourceVersion ?? "2025-09-01")
        {
        }

        /// <summary> Gets the Id. </summary>
        public BicepValue<ResourceIdentifier> Id
        {
            get
            {
                Initialize();
                return _id;
            }
        }

        /// <summary> Gets or sets the Name. </summary>
        public BicepValue<string> Name
        {
            get
            {
                Initialize();
                return _name;
            }
            set
            {
                Initialize();
                _name.Assign(value);
            }
        }

        /// <summary> Gets the SystemData. </summary>
        public SystemData SystemData
        {
            get
            {
                Initialize();
                return _systemData;
            }
        }

        /// <summary> Gets or sets the Properties. </summary>
        public CognitiveServicesCapabilityHostProperties Properties
        {
            get
            {
                Initialize();
                return _properties;
            }
            set
            {
                Initialize();
                AssignOrReplace(ref _properties, value);
            }
        }

        /// <summary> Gets or sets the Parent. </summary>
        public CognitiveServicesProject Parent
        {
            get
            {
                Initialize();
                return _parent.Value;
            }
            set
            {
                Initialize();
                _parent.Value = value;
            }
        }

        /// <summary> Define all the provisionable properties for CognitiveServicesProjectCapabilityHost. </summary>
        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" }, isOutput: true);
            _name = DefineProperty<string>(nameof(Name), new string[] { "name" }, isRequired: true);
            _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
            _properties = DefineModelProperty<CognitiveServicesCapabilityHostProperties>(nameof(Properties), new string[] { "properties" }, isRequired: true);
            _parent = DefineResource<CognitiveServicesProject>("Parent", new string[] { "parent" }, isRequired: true);
        }

        /// <summary> Creates a reference to an existing CognitiveServicesProjectCapabilityHost. </summary>
        /// <param name="bicepIdentifier"> The bicep identifier name. </param>
        /// <param name="resourceVersion"> The resource API version. </param>
        /// <returns> The existing CognitiveServicesProjectCapabilityHost resource. </returns>
        public static CognitiveServicesProjectCapabilityHost FromExisting(string bicepIdentifier, string resourceVersion = null)
        {
            CognitiveServicesProjectCapabilityHost result = new CognitiveServicesProjectCapabilityHost(bicepIdentifier, resourceVersion);
            result.IsExistingResource = true;
            return result;
        }

        /// <summary> Get the requirements for naming this resource. </summary>
        /// <returns> Naming requirements. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ResourceNameRequirements GetResourceNameRequirements() => new ResourceNameRequirements(1, 24, ResourceNameCharacters.LowercaseLetters | ResourceNameCharacters.UppercaseLetters | ResourceNameCharacters.Numbers | ResourceNameCharacters.Hyphen | ResourceNameCharacters.Underscore);

        /// <summary> Supported API versions for the CognitiveServicesProjectCapabilityHost resource. </summary>
        public static partial class ResourceVersions
        {
            /// <summary> API version "2025-06-01". Retained for compatibility with previous Azure.Provisioning.CognitiveServices releases. </summary>
            public static readonly string V2025_06_01 = "2025-06-01";
            /// <summary> API version "2025-09-01". Retained for compatibility with previous Azure.Provisioning.CognitiveServices releases. </summary>
            public static readonly string V2025_09_01 = "2025-09-01";
        }
    }
}
