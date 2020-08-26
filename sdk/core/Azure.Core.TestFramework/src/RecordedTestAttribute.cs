// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace Azure.Core.TestFramework
{
    [AttributeUsage(AttributeTargets.Method)]
    /// <summary>
    /// This attribute replaces the [Test] attribute and will dynamically re-record recorded tests on failure.
    /// Tests that are re-recorded will complete with a error status and indicate that copying the updated recording to SessionRecords is needed.
    /// </summary>
    public class RecordedTestAttribute : TestAttribute, IWrapSetUpTearDown
    {
        public TestCommand Wrap(TestCommand command)
        {
            ITest test = command.Test;
            while (test.Fixture == null && test.Parent != null)
            {
                test = test.Parent;
            }
            if (test.Fixture is RecordedTestBase fixture && fixture.Mode == RecordedTestMode.Playback)
            {
                return new FallbackCommand(command);
            }
            else
            {
                return command;
            }
        }

        private class FallbackCommand : DelegatingTestCommand
        {
            public FallbackCommand(TestCommand innerCommand) : base(innerCommand)
            { }
            public override TestResult Execute(TestExecutionContext context)
            {
                // Run the test
                context.CurrentResult = innerCommand.Execute(context);

                // Check the result
                if (IsTestFailedWithRecordingMismatch(context))
                {
                    context.CurrentResult = context.CurrentTest.MakeTestResult();
                    // Run the test again after setting the RecordedTestMode to Record
                    SetRecordMode(context.TestObject as RecordedTestBase, RecordedTestMode.Record);
                    context.CurrentResult = innerCommand.Execute(context);

                    // If the recording succeeded, set a warning result.
                    if (!IsTestFailedWithRecordingMismatch(context))
                    {
                        context.CurrentResult.SetResult(ResultState.Error, "Test failed playback, but was successfully re-recorded (it should pass if re-run). Please copy updated recording to SessionFiles.");
                    }

                    // revert RecordTestMode to Playback
                    SetRecordMode(context.TestObject as RecordedTestBase, RecordedTestMode.Playback);
                }
                return context.CurrentResult;
            }

            private static bool IsTestFailedWithRecordingMismatch(TestExecutionContext context)
            {
                var failed = context.CurrentResult.ResultState.Status switch
                {
                    TestStatus.Passed => false,
                    TestStatus.Skipped => false,
                    _ => true
                };

                return failed && context.CurrentResult.Message.StartsWith(typeof(TestRecordingMismatchException).FullName);
            }
        }

        private static void SetRecordMode(RecordedTestBase fixture, RecordedTestMode mode)
        {
            fixture.Mode = mode;
        }
    }
}
