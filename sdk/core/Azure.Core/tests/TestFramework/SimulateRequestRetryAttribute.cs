// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Azure.Core.Testing
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, Inherited = false)]
    public class SimulateRequestRetryAttribute : NUnitAttribute, ITestAction
    {
        private static readonly AsyncLocal<SimulateRequestRetryAttribute> s_current = new AsyncLocal<SimulateRequestRetryAttribute>();

        internal static SimulateRequestRetryAttribute Current => s_current.Value;

        private readonly bool _simulateRetry;

        public ActionTargets Targets => ActionTargets.Default;

        public virtual bool CanRetry(HttpMessage message) => _simulateRetry;

        public virtual void Retry(HttpMessage message) => message.Response = new MockResponse(503);

        public SimulateRequestRetryAttribute(bool simulate) => _simulateRetry = simulate;

        public SimulateRequestRetryAttribute() : this(true) { }

        public void BeforeTest(ITest test) => s_current.Value = this;
        public void AfterTest(ITest test) => s_current.Value = null;
    }
}
