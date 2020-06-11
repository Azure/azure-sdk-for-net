// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.TestFramework
{
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class RunFrequencyAttribute : CategoryAttribute
    {
        public RunFrequencyAttribute(RunTestFrequency frequency)
        {
            this.categoryName = Enum.GetName(typeof(RunTestFrequency), frequency);
        }
    }
}
