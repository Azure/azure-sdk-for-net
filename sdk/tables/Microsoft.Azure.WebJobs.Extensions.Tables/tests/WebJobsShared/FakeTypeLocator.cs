// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System;
using System.Collections.Generic;
namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
    public class FakeTypeLocator : ITypeLocator
    {
        private readonly Type[] _types;
        public FakeTypeLocator(params Type[] types)
        {
            _types = types;
        }
        public IReadOnlyList<Type> GetTypes()
        {
            return _types;
        }
    }
}