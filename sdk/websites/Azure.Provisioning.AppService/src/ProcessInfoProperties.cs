// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.AppService;

internal partial class ProcessInfoProperties
{
    private BicepValue<string> _parentProcess;

    /// <summary> Gets the parent process. </summary>
    [CodeGenMember("Parent")]
    public BicepValue<string> ParentProcess
    {
        get
        {
            Initialize();
            return _parentProcess;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _parentProcess = DefineProperty<string>(nameof(ParentProcess), new string[] { "parent" });
    }
}
