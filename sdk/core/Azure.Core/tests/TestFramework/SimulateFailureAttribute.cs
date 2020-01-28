// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using NUnit.Framework;

namespace Azure.Core.Testing
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, Inherited = false)]
    public class SimulateFailureAttribute : NUnitAttribute
    {
        public int DelayInMs { get; set; }

        public int FailuresCount { get; set; } = 1;

        public virtual bool CanFail(HttpMessage message) => true;

        public virtual void Fail(HttpMessage message) => message.Response = new MockResponse(503);

        public static SimulateFailureAttribute Current
            => (SimulateFailureAttribute)TestContext.CurrentContext.Test.Properties[nameof(SimulateFailureAttribute)].FirstOrDefault();
    }
}
