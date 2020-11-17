// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    internal static class AzMonListExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static object GetTagValue(this AzMonList tagObjects, string tagName)
        {
            for (int i = 0; i < tagObjects.Length; i++)
            {
                if (tagObjects[i].Key == tagName)
                {
                    return tagObjects[i].Value;
                }
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static object[] GetTagValues(this AzMonList tagObjects, params string[] tagNames)
        {
            int? length = tagNames?.Count();
            if (length == null || length == 0)
            {
                return null;
            }

            object[] values = new object[(int)length];

            for (int i = 0; i < tagObjects.Length; i++)
            {
                var index = Array.IndexOf(tagNames, tagObjects[i].Key);
                if (index >= 0)
                {
                    values[index] = tagObjects[i].Value;
                    length--;

                    if (length == 0)
                    {
                        break;
                    }
                }
            }

            return values;
        }
    }
}
