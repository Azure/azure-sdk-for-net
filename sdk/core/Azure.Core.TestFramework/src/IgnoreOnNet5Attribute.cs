// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Azure.Core.TestFramework
{
    /// <summary>
    /// Marks that a test should not be executed in NET5 test runs.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public class IgnoreOnNet5Attribute : NUnitAttribute, IApplyToTest
    {
        private readonly string _issueLink;

        public IgnoreOnNet5Attribute(string issueLink)
        {
            Argument.AssertNotNullOrWhiteSpace(issueLink, nameof(issueLink));
            _issueLink = issueLink;
        }

        public void ApplyToTest(Test test)
        {
            if (test.RunState != RunState.NotRunnable && Environment.Version.Major == 5)
            {
                test.RunState = RunState.Ignored;
                test.Properties.Set(PropertyNames.SkipReason, $"This test can't' run on .NET 5. {_issueLink}");
            }
        }
    }
}