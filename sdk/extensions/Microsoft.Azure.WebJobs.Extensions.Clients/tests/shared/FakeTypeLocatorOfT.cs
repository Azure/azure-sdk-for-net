// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
#pragma warning disable SA1649 // File name should match first type name
    public class FakeTypeLocator<T> : ITypeLocator
#pragma warning restore SA1649 // File name should match first type name
    {
        public IReadOnlyList<Type> GetTypes()
        {
            return new Type[] { typeof(T) };
        }
    }
}
