// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace TrackOne.Primitives
{
    internal static class Guard
    {
        internal static void ArgumentNotNull(string argumentName, object value)
        {
            if (value == null)
            {
                throw Fx.Exception.ArgumentNull(argumentName);
            }
        }

        internal static void ArgumentNotNullOrWhiteSpace(string argumentName, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw Fx.Exception.ArgumentNull(argumentName);
            }
        }
    }
}
