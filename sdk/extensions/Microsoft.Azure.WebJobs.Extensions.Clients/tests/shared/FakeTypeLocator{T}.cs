// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
    public class FakeTypeLocator<T> : ITypeLocator
    {
        public IReadOnlyList<Type> GetTypes()
        {
            return new Type[] { typeof(T) };
        }
    }
}
