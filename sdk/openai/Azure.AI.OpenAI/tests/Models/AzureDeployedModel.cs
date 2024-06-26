// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.AI.OpenAI.Tests.Models;

public class AzureDeployedModel
{
    required public string ID { get; init; }
    required public string Name { get; init; }
    required public Props Properties { get; init; }

    public class Props
    {
        required public ModelInfo Model { get; init; }
        required public string ProvisioningState { get; init; }
    }

    public class ModelInfo
    {
        public string? Model { get; init; }
        required public string Name { get; init; }
        required public string Version { get; init; }
    }
}
