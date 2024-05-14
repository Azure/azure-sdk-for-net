// <copyright file="ActivityHelperExtensions.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

#nullable enable

using System.Diagnostics;
using System.Runtime.CompilerServices;
using OpenTelemetry.Internal;

namespace OpenTelemetry.Trace;

/// <summary>
/// Extension methods on Activity.
/// </summary>
internal static class ActivityHelperExtensions
{
    /// <summary>
    /// Gets the status of activity execution.
    /// Activity class in .NET does not support 'Status'.
    /// This extension provides a workaround to retrieve Status from special tags with key name otel.status_code and otel.status_description.
    /// </summary>
    /// <param name="activity">Activity instance.</param>
    /// <param name="statusCode"><see cref="StatusCode"/>.</param>
    /// <param name="statusDescription">Status description.</param>
    /// <returns><see langword="true"/> if <see cref="Status"/> was found on the supplied Activity.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryGetStatus(this Activity activity, out StatusCode statusCode, out string? statusDescription)
    {
        Debug.Assert(activity != null, "Activity should not be null");

        bool foundStatusCode = false;
        statusCode = default;
        statusDescription = null;

        foreach (ref readonly var tag in activity!.EnumerateTagObjects())
        {
            switch (tag.Key)
            {
                case SpanAttributeConstants.StatusCodeKey:
                    foundStatusCode = StatusHelper.TryGetStatusCodeForTagValue(tag.Value as string, out statusCode);
                    if (!foundStatusCode)
                    {
                        // If status code was found but turned out to be invalid give up immediately.
                        return false;
                    }

                    break;
                case SpanAttributeConstants.StatusDescriptionKey:
                    statusDescription = tag.Value as string;
                    break;
                default:
                    continue;
            }

            if (foundStatusCode && statusDescription != null)
            {
                // If we found a status code and a description we break enumeration because our work is done.
                break;
            }
        }

        return foundStatusCode;
    }

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
