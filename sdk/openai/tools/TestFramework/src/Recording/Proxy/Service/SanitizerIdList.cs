// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording.Proxy.Service;

/// <summary>
/// Request to remove sanitizers for the test proxy.
/// </summary>
public struct SanitizerIdList
{
    /// <summary>
    /// The IDs of the sanitizers to remove.
    /// </summary>
    public string[]? Sanitizers { get; set; }
}
