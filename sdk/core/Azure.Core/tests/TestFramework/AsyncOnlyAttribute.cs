// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Azure.Core.Testing
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, Inherited = false)]
    public class AsyncOnlyAttribute : Attribute, ITestAttribute
    {
        public void Apply(Test test, TestProperties testProperties)
        {
            if (!testProperties.IsAsync)
            {
                test.RunState = RunState.Ignored;
                test.Properties.Set("_SKIPREASON", $"Test ignored in sync run because it's marked with {nameof(AsyncOnlyAttribute)}");
            }
        }
    }
}
