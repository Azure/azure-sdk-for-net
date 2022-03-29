// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;

namespace SignalRServiceExtension.Tests.Utils
{
    public class FakeTypeLocator : ITypeLocator
    {
        private readonly Type _type;

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