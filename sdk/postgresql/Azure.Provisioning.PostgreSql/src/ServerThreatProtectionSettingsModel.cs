// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Customizations;

#nullable disable

namespace Azure.Provisioning.PostgreSql;

public partial class ServerThreatProtectionSettingsModel
{
    private BicepValue<string> _name;

    /// <summary>
    /// Name of the advanced threat protection settings.
    /// </summary>
    [CodeGenMember("Name")]
    public BicepValue<string> Name
    {
        get
        {
            Initialize();
            return _name;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _name = DefineProperty<string>(nameof(Name), ["name"], isRequired: true, defaultValue: "Default");
    }
}
