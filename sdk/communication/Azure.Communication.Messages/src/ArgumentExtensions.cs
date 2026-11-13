// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Messages
{
    internal static partial class Argument
    {
        public static T CheckNotNull<T>(T value, string name) where T : class
        {
            AssertNotNull(value, name);
            return value;
        }
    }
}
