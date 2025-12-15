// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// This attribute replaces the [Test] attribute and will dynamically re-record recorded tests on failure when run in Playback mode.
/// Tests that are re-recorded will complete with a error status and indicate that copying the updated recording to SessionRecords is needed.
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class RecordedTestAttribute : TestAttribute, IWrapSetUpTearDown
{
    /// <summary>
    /// Wraps the test command to provide recorded test functionality, including automatic re-recording on playback failures.
    /// </summary>
    /// <param name="command">The test command to wrap.</param>
    /// <returns>A wrapped test command that handles recorded test execution, or the original command if not applicable.</returns>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordedTestAttributeCommand"/> class.
        /// </summary>
        /// <param name="innerCommand">The inner test command to delegate to.</param>
        /// <param name="mode">The recorded test mode (Live, Record, or Playback).</param>
        public RecordedTestAttributeCommand(TestCommand innerCommand, RecordedTestMode mode) : base(innerCommand)
        {
            _mode = mode;
        }

        /// <summary>
        /// Executes the test command with recorded test functionality, including automatic re-recording on playback failures
        /// and retry logic for timeout exceptions.
        /// </summary>
        /// <param name="context">The test execution context.</param>
        /// <returns>The test result after execution and any necessary re-recording or retry attempts.</returns>
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
                string? resultMessage = context.CurrentResult.Message;
                TestResult originalResult = context.CurrentResult;

                if (resultMessage?.Contains(typeof(TestRecordingMismatchException).FullName!) ?? false /*TODO-default*/ &&
                    !TestEnvironment.GlobalDisableAutoRecording)
                {
                    context.CurrentResult = context.CurrentTest.MakeTestResult();
                    // Run the test again after setting the RecordedTestMode to Record
                    SetRecordMode((context.TestObject as RecordedTestBase)!, RecordedTestMode.Record);
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
                    SetRecordMode((context.TestObject as RecordedTestBase)!, RecordedTestMode.Playback);
                    return context.CurrentResult;
                }

                if (resultMessage?.Contains(typeof(TestTimeoutException).FullName!) == true)
                {
                    HandleTestTimeout(context, originalResult);
                }
            }

            return context.CurrentResult;
        }

        private TestResult HandleTestTimeout(TestExecutionContext context, TestResult originalResult)
        {
            var results = new List<TestResult> { originalResult };

            for (int retryCount = 0; retryCount < 2; retryCount++)
            {
                // Create a new TestResult instance
                context.CurrentResult = context.CurrentTest.MakeTestResult();
                // Run the test again
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
                    $"Attempt {i + 1}: {r.Message ?? "Passed"}"));

            return header + ":" + Environment.NewLine + attemptDetails + Environment.NewLine;
        }

        /// <summary>
        /// Sets the recording mode for the specified recorded test fixture.
        /// </summary>
        /// <param name="fixture">The recorded test base fixture to modify.</param>
        /// <param name="mode">The recording mode to set (Live, Record, or Playback).</param>
        private static void SetRecordMode(RecordedTestBase fixture, RecordedTestMode mode)
        {
            fixture.Mode = mode;
        }

        /// <summary>
        /// Determines whether a test has failed based on its execution result status.
        /// </summary>
        /// <param name="context">The test execution context containing the result.</param>
        /// <returns><c>true</c> if the test failed; otherwise, <c>false</c>.</returns>
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
