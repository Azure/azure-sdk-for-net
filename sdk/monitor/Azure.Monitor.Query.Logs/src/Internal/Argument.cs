// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Azure.Monitor.Query.Logs
{
    internal static partial class Argument
    {
        public static void AssertNotNullOrWhiteSpace(string value, string name)
        {
            if (value is null)
            {
                throw new ArgumentNullException(name);
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value cannot be empty or contain only white-space characters.", name);
            }
        }
    }
}
