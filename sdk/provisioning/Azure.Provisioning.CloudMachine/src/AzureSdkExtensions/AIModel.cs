// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

public class AiModel
{
    public AiModel(string model, string modelVersion) { Model = model; ModelVersion = modelVersion; }
    public string Model { get; }
    public string ModelVersion { get; }
}
