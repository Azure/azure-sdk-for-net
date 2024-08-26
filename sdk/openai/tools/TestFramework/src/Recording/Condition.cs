// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording;

/// <summary>
/// A condition used to evaluate whether or not a sanitizer should be applied.
/// </summary>
public class Condition
{
    /// <summary> Gets or sets the uri regex. </summary>
    public string? UriRegex { get; set; }

    /// <summary> Header condition to apply. </summary>
    public HeaderCondition? ResponseHeader { get; set; }
}
