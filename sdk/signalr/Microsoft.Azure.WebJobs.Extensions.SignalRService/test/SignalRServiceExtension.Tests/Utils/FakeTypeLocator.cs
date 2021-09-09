// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;

namespace SignalRServiceExtension.Tests.Utils
{
    public class FakeTypeLocator : ITypeLocator
    {
        private Type _type;

        public FakeTypeLocator(Type type)
        {
            _type = type;
        }

        public IReadOnlyList<Type> GetTypes()
        {
            return new Type[] { _type };
        }
    }
}