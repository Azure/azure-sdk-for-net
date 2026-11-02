// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.ProvisioningTypeSpec;

public partial class ExtensionAssignment
{
    /// <summary> Gets or sets the resource scope. </summary>
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

public partial class KeyValue
{
    /// <summary> Gets or sets the parent configuration store. </summary>
    public ConfigurationStore Parent
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
}
