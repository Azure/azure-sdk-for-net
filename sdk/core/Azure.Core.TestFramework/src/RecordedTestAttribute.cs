// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace Azure.Core.TestFramework
{
    [AttributeUsage(AttributeTargets.Method)]
    /// <summary>
    /// This attribute replaces the [Test] attribute and will dynamically re-record recorded tests on failure when run in Playback mode.
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

            if (test.Fixture is RecordedTestBase fixture)
            {
                return new RecordedTestAttributeCommand(command, fixture.Mode);
            }

            return command;
        }

        private class RecordedTestAttributeCommand : DelegatingTestCommand
        {
            private readonly RecordedTestMode _mode;

            public RecordedTestAttributeCommand(TestCommand innerCommand, RecordedTestMode mode) : base(innerCommand)
            {
                _mode = mode;
            }
            public override TestResult Execute(TestExecutionContext context)
            {
                // Run the test
                context.CurrentResult = innerCommand.Execute(context);

                // Check the result
                if (!IsTestFailed(context))
                {
                    return context.CurrentResult;
                }

                if (_mode == RecordedTestMode.Playback)
                {
                    string resultMessage = context.CurrentResult.Message;
                    TestResult originalResult = context.CurrentResult;

                    if (resultMessage.Contains(typeof(TestRecordingMismatchException).FullName) &&
                        !TestEnvironment.GlobalDisableAutoRecording)
                    {
                        context.CurrentResult = context.CurrentTest.MakeTestResult();
                        // Run the test again after setting the RecordedTestMode to Record
                        SetRecordMode(context.TestObject as RecordedTestBase, RecordedTestMode.Record);
                        context.CurrentResult = innerCommand.Execute(context);

                        // If the recording succeeded, set an error result.
                        if (context.CurrentResult.ResultState.Status == TestStatus.Passed)
                        {
                            string message = "Test failed playback, but was successfully re-recorded. It should pass if re-run." +
                                Environment.NewLine +
                                Environment.NewLine +
                                originalResult.Message;

                            context.CurrentResult.SetResult(ResultState.Error, message);
                        }
                        else
                        {
                            string message = "The [RecordedTest] attribute attempted to re-record, but failed:" +
                                Environment.NewLine +
                                Environment.NewLine +
                                context.CurrentResult.Message +
                                Environment.NewLine +
                                Environment.NewLine +
                                "Original failure:" +
                                Environment.NewLine +
                                Environment.NewLine +
                                originalResult.Message;

                            context.CurrentResult.SetResult(context.CurrentResult.ResultState, message, context.CurrentResult.StackTrace);
                        }

                        // revert RecordTestMode to Playback
                        SetRecordMode(context.TestObject as RecordedTestBase, RecordedTestMode.Playback);
                        return context.CurrentResult;
                    }

                    if (resultMessage.Contains(typeof(TestTimeoutException).FullName))
                    {
                        return HandleTestTimeout(context, originalResult);
                    }
                }

                CheckForIgnoredServiceErrors(context);
                return context.CurrentResult;
            }

            private TestResult HandleTestTimeout(TestExecutionContext context, TestResult originalResult)
            {
                var results = new List<TestResult> { originalResult };

                for (int retryCount = 0; retryCount < 2; retryCount++)
                {
                    context.CurrentResult = innerCommand.Execute(context);
                    results.Add(context.CurrentResult);

                    if (!IsTestFailed(context))
                    {
                        context.CurrentResult.SetResult(
                            ResultState.Success,
                            ConstructRetryMessage("Test timed out initially, but passed on retry", results));
                        return context.CurrentResult;
                    }
                }

                context.CurrentResult.SetResult(
                    ResultState.Error,
                    ConstructRetryMessage("The test timed out on all attempts", results));

                return context.CurrentResult;
            }

            private static string ConstructRetryMessage(string header, IEnumerable<TestResult> results)
            {
                var attemptDetails = string.Join(Environment.NewLine,
                    results.Select((r, i) =>
                        $"Attempt {i + 1}: {r.Message}"));

                return header + ":" + Environment.NewLine + attemptDetails;
            }

            private void CheckForIgnoredServiceErrors(TestExecutionContext context)
            {
                // Check if there are any service errors we should ignore.
                var ignoreServiceErrorAttributes = innerCommand.Test.GetCustomAttributes<IgnoreServiceErrorAttribute>(true).ToList();

                // Check parents for service errors to ignore.
                var test = Test;
                while (test.Parent is Test t)
                {
                    ignoreServiceErrorAttributes.AddRange(t.GetCustomAttributes<IgnoreServiceErrorAttribute>(true));
                    test = t;
                }
                foreach (IgnoreServiceErrorAttribute attr in ignoreServiceErrorAttributes)
                {
                    if (attr.Matches(context.CurrentResult.Message))
                    {
                        context.CurrentResult.SetResult(
                            ResultState.Inconclusive,
                            $"{attr.Reason}\n\nOriginal message follows:\n\n{context.CurrentResult.Message}",
                            context.CurrentResult.StackTrace);
                        break;
                    }
                }
            }

            private static void SetRecordMode(RecordedTestBase fixture, RecordedTestMode mode)
            {
                fixture.Mode = mode;
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
    }
}
