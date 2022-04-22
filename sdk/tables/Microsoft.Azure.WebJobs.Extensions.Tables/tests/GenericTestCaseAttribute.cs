// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class GenericTestCaseAttribute : TestCaseAttribute, ITestBuilder
    {
        private readonly Type _type;
        public GenericTestCaseAttribute(Type type, params object[] arguments) : base(arguments)
        {
            _type = type;
        }

        IEnumerable<TestMethod> ITestBuilder.BuildFrom(IMethodInfo method, Test suite)
        {
            return BuildFrom(method.MakeGenericMethod(_type), suite);
        }
    }
}