// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording;

/// <summary>
/// Header condition to apply.
/// </summary>
public class HeaderCondition
{
    /// <summary> Gets or sets the key. </summary>
    public string? Key { get; set; }
    /// <summary> Gets or sets the value regex. </summary>
    public string? ValueRegex { get; set; }
}
