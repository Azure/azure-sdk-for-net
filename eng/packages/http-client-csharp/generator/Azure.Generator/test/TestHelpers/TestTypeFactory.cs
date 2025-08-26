// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Generator.Tests.TestHelpers
{
    internal class TestTypeFactory : AzureTypeFactory
    {
        public Type? InvokeCreateFrameworkType(string typeName)
        {
            return base.CreateFrameworkType(typeName);
        }
    }
}