// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CostManagement
{
    // The resource is an extension resource and must expose the root Bicep
    // 'scope' property. The payload also has a properties.scope field, so suppress
    // the generated duplicate and keep only the extension-resource Scope API.
    [CodeGenSuppress("Scope")]
    public partial class CostManagementView
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
    }
}
