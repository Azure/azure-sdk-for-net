// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.CloudMachine.OpenAI;

public class AIModel
{
    public AIModel(string model, string modelVersion) { Model = model; ModelVersion = modelVersion; }
    public string Model { get; }
    public string ModelVersion { get; }
}
