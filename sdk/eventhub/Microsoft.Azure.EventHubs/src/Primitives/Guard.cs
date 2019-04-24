// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Primitives
{
    static class Guard
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
