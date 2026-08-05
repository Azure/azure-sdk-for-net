// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CostManagement
{
    // The resource is an extension resource and must expose the root Bicep
    // 'scope' property. The payload also has a properties.scope field, so suppress
    // the generated duplicate and keep only the extension-resource Scope API.
    [CodeGenSuppress("Scope")]
    public partial class ScheduledAction
    {
        /// <summary> Gets or sets the Scope. </summary>
        public ProvisionableResource Scope
        {
            get
            {
                Initialize();
                return _scope.Value;
            }
            set
            {
                Initialize();
                _scope.Value = value;
            }
        }

        // The generated flattened properties.scope member also used the name Scope,
        // which collides with the root extension-resource Scope above. Keep the root
        // Bicep scope as Scope and expose the payload field with a resource-specific name.
        /// <summary> Gets or sets the scheduled action data scope. </summary>
        public BicepValue<ResourceIdentifier> ScheduledActionScope
        {
            get
            {
                return Properties is null ? default : Properties.Scope;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new ScheduledActionProperties();
                }
                Properties.Scope = value;
            }
        }
    }
}
