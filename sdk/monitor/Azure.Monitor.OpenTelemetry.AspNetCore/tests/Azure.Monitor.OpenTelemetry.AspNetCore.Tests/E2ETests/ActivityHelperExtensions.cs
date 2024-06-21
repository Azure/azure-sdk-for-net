// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// COPIED FROM OPENTELEMETRY. TODO: INCLUDE LINK

#nullable enable

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OpenTelemetry.Trace;

internal static class ActivityHelperExtensions
{
    /// <summary>
    /// Gets the value of a specific tag on an <see cref="Activity"/>.
    /// </summary>
    /// <param name="activity">Activity instance.</param>
    /// <param name="tagName">Case-sensitive tag name to retrieve.</param>
    /// <returns>Tag value or null if a match was not found.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static object? GetTagValue(this Activity activity, string? tagName)
    {
        Debug.Assert(activity != null, "Activity should not be null");

        foreach (ref readonly var tag in activity!.EnumerateTagObjects())
        {
            if (tag.Key == tagName)
            {
                return tag.Value;
            }
        }

        return null;
    }

    /// <summary>
    /// Checks if the user provided tag name is the first tag of the <see cref="Activity"/> and retrieves the tag value.
    /// </summary>
    /// <param name="activity">Activity instance.</param>
    /// <param name="tagName">Tag name.</param>
    /// <param name="tagValue">Tag value.</param>
    /// <returns><see langword="true"/> if the first tag of the supplied Activity matches the user provide tag name.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryCheckFirstTag(this Activity activity, string tagName, out object? tagValue)
    {
        Debug.Assert(activity != null, "Activity should not be null");

        var enumerator = activity!.EnumerateTagObjects();

        if (enumerator.MoveNext())
        {
            ref readonly var tag = ref enumerator.Current;

            if (tag.Key == tagName)
            {
                tagValue = tag.Value;
                return true;
            }
        }

        tagValue = null;
        return false;
    }
}
