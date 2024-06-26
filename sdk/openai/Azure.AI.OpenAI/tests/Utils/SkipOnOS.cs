// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Runtime.InteropServices;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OSPlatform = System.Runtime.InteropServices.OSPlatform;

namespace Azure.AI.OpenAI.Tests.Utils
{
    /// <summary>
    /// Skips a test on the specified OS.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true, Inherited = true)]
    public class SkipOnOS : NUnitAttribute, IApplyToTest
    {
        private readonly OSPlatform _skipOn;

        /// <summary>
        /// Optional reason that this test is skipped.
        /// </summary>
        public string? Reason { get; set; }

        /// <summary>
        /// Skips the test on the specified OS.
        /// </summary>
        /// <param name="skip">The OSs to skip this test on.</param>
        public SkipOnOS(string skipOn)
        {
            _skipOn = OSPlatform.Create(skipOn);
        }

        /// <summary>
        /// Modifies the <paramref name="test"/> by adding categories to it and changing the run state as needed.
        /// </summary>
        /// <param name="test">The <see cref="Test"/> to modify.</param>
        public void ApplyToTest(Test test)
        {
            test.Properties.Add("Category", "OS Specific");

            if (test.RunState != RunState.NotRunnable)
            {
                if (RuntimeInformation.IsOSPlatform(_skipOn))
                {
                    test.RunState = RunState.Ignored;
                    test.Properties.Set("_SKIPREASON", $"Test does not run on the current OS ({RuntimeInformation.OSDescription}). {Reason}");
                }
            }
        }
    }
}
