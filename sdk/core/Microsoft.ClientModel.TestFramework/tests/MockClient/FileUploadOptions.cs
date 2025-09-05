// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Microsoft.ClientModel.TestFramework.Tests.MockClient;

/// <summary>
/// Options for creating a file upload operation
/// </summary>
public class FileUploadOptions
{
    public string Purpose { get; set; } = "test";
    public Dictionary<string, string> Metadata { get; } = new();
}
