// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json.Nodes;
using System.Text.Json;
using Azure.Provisioning.CloudMachine;

namespace Azure.CloudMachine;

public partial class CloudMachineClient
{
    public static bool Configure(string[] args, Action<CloudMachineInfrastructure>? configure = default)
    {
        if (args.Length < 1 || args[0] != "--init")
        {
            return false;
        }

        CloudMachineInfrastructure cmi = new();
        if (configure != default)
        {
            configure(cmi);
        }

        string infraDirectory = Path.Combine(".", "infra");
        Azd.Init(infraDirectory, cmi);
        return true;
    }
}
