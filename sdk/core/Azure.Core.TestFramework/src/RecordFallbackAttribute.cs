// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace Azure.Core.TestFramework
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RecordFallbackAttribute : Attribute, IWrapSetUpTearDown
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
                if (IsTestFailed(context))
                {
                    context.CurrentResult = context.CurrentTest.MakeTestResult();
                    // Run the test again after setting the RecordedTestMode to Record
                    SetRecordMode(context.TestObject as RecordedTestBase, RecordedTestMode.Record);
                    context.CurrentResult = innerCommand.Execute(context);

                    // If the recording succeeded, set a warning result.
                    if (!IsTestFailed(context))
                    {
                        context.CurrentResult.SetResult(ResultState.Warning, "Test failed palyback, but was successfully re-recorded. Please copy updated recording to SessionFiles.");
                    }
                }
                return context.CurrentResult;
            }

            private static bool IsTestFailed(TestExecutionContext context)
            {
                return context.CurrentResult.ResultState.Status switch
                {
                    TestStatus.Passed => false,
                    TestStatus.Skipped => false,
                    _ => true
                };
            }
        }

        private static void SetRecordMode(RecordedTestBase fixture, RecordedTestMode mode)
        {
            //TODO: Cache the reflection.
            var environmentProperty = fixture.GetType().GetProperty("TestEnvironment");
            object environmetValue = environmentProperty.GetValue(fixture, null);
            var modeProperty = environmetValue.GetType().GetProperty("Mode");
            modeProperty.SetValue(environmetValue, mode);
            fixture.Mode = mode;
        }
    }
}
