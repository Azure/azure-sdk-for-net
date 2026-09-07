// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.ResourceHealth
{
    // The provisioning emitter collapses the tenant and subscription projections and drops their scope-specific parent paths.
    // TODO: Remove this when https://github.com/Azure/azure-sdk-for-net/issues/62410 is fixed.
    public partial class ResourceHealthEventImpactedResource
    {
        private ResourceReference<ResourceHealthEvent> _parent;

        /// <summary> Gets or sets the parent resource health event. </summary>
        public ResourceHealthEvent Parent
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

        partial void DefineAdditionalProperties()
        {
            _parent = DefineResource<ResourceHealthEvent>(nameof(Parent), new string[] { "parent" }, isRequired: true);
        }
    }
}
