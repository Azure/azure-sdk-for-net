// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

namespace ClientModel.Tests.Paging;

internal static class Argument
{
    public static void AssertNotNull<T>(T? value, string name)
    {
        if (value is null)
        {
            throw new ArgumentNullException(name);
        }
    }
}
