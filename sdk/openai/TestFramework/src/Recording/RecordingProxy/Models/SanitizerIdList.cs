// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording.RecordingProxy.Models;

/// <summary>
/// Request to remove sanitizers for the test proxy.
/// </summary>
public class SanitizerIdList
{
    /// <summary>
    /// The IDs of the sanitizers to remove.
    /// </summary>
    public ICollection<string>? Sanitizers { get; set; }
}
