// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace Azure.Core.TestFramework
{
    /// <summary>
    /// <see cref="MaxTimeCommand" /> adjusts the result of a successful test
    /// to a failure if the elapsed time has exceeded the specified maximum
    /// time allowed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly)]
    public class MaxTestTimeAttribute : PropertyAttribute, IWrapTestMethod, IApplyToContext
    {
        private const int GLOBAL_TEST_MAX_TIME = 5000;

        public MaxTestTimeAttribute()
        {
            if (GLOBAL_TEST_MAX_TIME > 0)
            {
            }
        }

        public TestCommand Wrap(TestCommand command)
        {
            ITest test = command.Test;
            while (test.Fixture == null && test.Parent != null)
            {
                test = test.Parent;
            }

            bool isPlaybackModeTest = test.Fixture is RecordedTestBase fixture && fixture.Mode == RecordedTestMode.Playback;
            bool isNotLiveCategoryTest = test.Properties.Get(PropertyNames.Category) is string s && s != "Live";
            bool applyMaxTime = isPlaybackModeTest && isNotLiveCategoryTest;

            if (applyMaxTime)
            {
                return new MaxTimeCommand(command, GLOBAL_TEST_MAX_TIME);
            }
            return command;
        }

        public void ApplyToContext(TestExecutionContext context)
        {
        }
    }
}
