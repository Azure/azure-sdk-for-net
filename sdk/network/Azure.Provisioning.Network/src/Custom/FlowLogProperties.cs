// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

[CodeGenType("FlowLogFormatParameters")]
public partial class FlowLogProperties
{
    private BicepValue<FlowLogFormatType> _formatType;

    /// <summary> Gets or sets the format type. </summary>
    [CodeGenMember("Type")]
    public BicepValue<FlowLogFormatType> FormatType
    {
        get
        {
            Initialize();
            return _formatType;
        }
        set
        {
            Initialize();
            _formatType.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _formatType = DefineProperty<FlowLogFormatType>(nameof(FormatType), new string[] { "type" });
    }
}
