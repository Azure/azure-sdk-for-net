// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Azure.Storage.Test.Shared
{
    // TODO Consider https://docs.nunit.org/articles/nunit-engine/extensions/Event-Listeners.html but that requires NUnit 3.4
    public partial class StorageTestListenerAttribute : Attribute, ITestAction
    {
        private static void LogTelemetryAfter(ITest test)
        {
            if (AppInsightsNUnitFixture.TelemetryClient != null)
            {
                var context = TestContext.CurrentContext;
                var testFullName = context.Test.FullName;
                var assertionsNumber = context.AssertCount;
                var failedAssertionsNumber = context.Result.Assertions
                    .Where(assertion => assertion.Status == AssertionStatus.Failed || assertion.Status == AssertionStatus.Error)
                    .Count();

                AppInsightsNUnitFixture.TelemetryClient.TrackTrace("Test finished", new Dictionary<string, string>()
                {
                    { "TestName", testFullName },
                    { "TestOutcome", context.Result.Outcome.Status.ToString() },
                    { "NumberOfAssertions", assertionsNumber.ToString() },
                    { "NumberOfFailedAssertions", failedAssertionsNumber.ToString() }
                });

                foreach (var assertion in context.Result.Assertions)
                {
                    AppInsightsNUnitFixture.TelemetryClient.TrackTrace("Assertion Result", new Dictionary<string, string>()
                    {
                        { "TestName", testFullName },
                        { "AssertionStatus", assertion.Status.ToString() },
                        { "AssertionMessage", assertion.Message },
                        { "AssertionStackTrace", assertion.StackTrace }
                    });
                }
            }
        }
    }
}
