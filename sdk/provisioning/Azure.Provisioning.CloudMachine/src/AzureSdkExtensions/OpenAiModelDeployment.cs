// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

public class OpenAiModelDeployment
{
    public OpenAiModelDeployment(string model, string modelVersion) { Model = model; ModelVersion = modelVersion; }
    public string Model { get; }
    public string ModelVersion { get; }
}
