// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Azure.Core.TestFramework
{
    /// <summary>
    /// Attribute on test assemblies, classes, or methods that run only against live resources.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = false, Inherited = true)]
    public class LiveOnlyAttribute : NUnitAttribute, IApplyToTest
    {
        private readonly bool _alwaysRunLocally;

        /// <summary>
        /// Optional reason that the test is marked LiveOnly.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Creates a new LiveOnlyAttribute instance.
        /// </summary>
        /// <param name="alwaysRunLocally">If true, the test will still be run even if the Mode is not Live.
        /// This can be used to allow tests that do not depend on RecordedTestMode to run locally, while still being skipped in CI.</param>
        public LiveOnlyAttribute(bool alwaysRunLocally = false)
        {
            _alwaysRunLocally = alwaysRunLocally;
        }

        /// <summary>
        /// Modifies the <paramref name="test"/> by adding categories to it and changing the run state as needed.
        /// </summary>
        /// <param name="test">The <see cref="Test"/> to modify.</param>
        public void ApplyToTest(Test test)
        {
            test.Properties.Add("Category", "Live");

            if (test.RunState != RunState.NotRunnable)
            {
                RecordedTestMode mode = TestEnvironment.GlobalTestMode;
                if (mode != RecordedTestMode.Live && !_alwaysRunLocally)
                {
                    test.RunState = RunState.Ignored;
                    test.Properties.Set("_SKIPREASON", $"Live tests will not run when AZURE_TEST_MODE is {mode}");
                }
            }
        }
    }
}
