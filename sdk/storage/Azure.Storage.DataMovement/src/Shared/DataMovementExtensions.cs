// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.Storage.DataMovement.Shared
{
    internal static class DataMovementExtensions
    {
        public static string ToLocalPathString(this List<string> path)
        {
            return string.Join(@"\", path);
        }

        public static string ToBlobPathString(this List<string> path)
        {
            return string.Join("/", path);
        }
    }
}
