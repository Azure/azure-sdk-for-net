// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.TestCommon
{
    public class MockUtil
    {
        public static void AssertPublicMethodsAreVirtual<T>()
        {
            foreach (MethodInfo methodInfo in typeof(T).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
            {
                Assert.True(methodInfo.IsVirtual, $"Method {methodInfo.Name} is not virtual");
            }
        }
    }
}