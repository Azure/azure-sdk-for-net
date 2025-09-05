// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.ClientModel.TestFramework.Tests.MockClient;

/// <summary>
/// Result of a file upload operation
/// </summary>
public class UploadResult
{
    public string Id { get; set; } = string.Empty;
    public int FilesProcessed { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CompletedAt { get; set; }
}
