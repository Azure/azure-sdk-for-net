// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording.Transforms;

/// <summary>
/// Transform applied to headers before the response is generated during recording playback.
/// </summary>
public class HeaderTransform : BaseTransform
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="key">The response header to set.</param>
    /// <exception cref="ArgumentNullException">If the <paramref name="key"/> is null.</exception>
    public HeaderTransform(string key) : base("HeaderTransform")
    {
        Key = key ?? throw new ArgumentNullException(nameof(key));
    }

    /// <summary>
    /// Gets the header to transform.
    /// </summary>
    public string Key { get; }

    /// <summary>
    /// Gets or sets the value to set.
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// The condition to apply for this transform. If the condition is not met, no transform is performed.
    /// </summary>
    public Condition? Condition { get; set; }
}
