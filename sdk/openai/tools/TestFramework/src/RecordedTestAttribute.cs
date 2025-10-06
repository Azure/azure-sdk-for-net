// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal.Commands;
using NUnit.Framework.Internal;
using OpenAI.TestFramework.Recording;

namespace OpenAI.TestFramework;

/// <summary>
/// An attribute used to indicate that a test should be recorded (or played back from a file). When you inherit from
/// <see cref="RecordedClientTestBase"/> in your test class, and add this attribute to your test function, and then
/// make sure to call <see cref="RecordedClientTestBase.ConfigureClientOptions{TClientOptions}(TClientOptions)"/>
/// on the client options you use to configure a client, this should automatically enable the recording/playback
/// functionality. By default. this will also automatically try to re-record the test if it fails during playback.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class RecordedTestAttribute : TestAttribute, IRepeatTest
{
    /// <summary>
    /// Whether or not to automatically try to record the test again in the case of a recording mismatch, or missing
    /// test recording.
    /// </summary>
    public bool AutomaticRecord { get; set; } = true;

    public TestCommand Wrap(TestCommand command)
    {
        // For some reason, the test fixture may be set on the parent of the current test, and not the current test
        // itself. Let's handle this
        ITest? test = command.Test;
        while (test.Fixture == null && test.Parent != null)
        {
            test = test.Parent;
        }

        // If the test fixture extends RecordedClientTestBase, we are in playback mode, and auto-rerecord
        // is enabled, wrap the command to enable the retry in Record mode
        if (AutomaticRecord
            && test?.Fixture is RecordedClientTestBase testBase
            && testBase.AutomaticRecord
            && testBase.Mode == RecordedTestMode.Playback)
        {
            return new AutoRerecordCommand(command, testBase);
        }

        return command;
    }

    private class AutoRerecordCommand(TestCommand inner, RecordedClientTestBase testBase) : DelegatingTestCommand(inner)
    {
        private readonly RecordedClientTestBase _testBase = testBase ?? throw new ArgumentNullException(nameof(testBase));

        public override TestResult Execute(TestExecutionContext context)
        {
            context.CurrentResult = innerCommand.Execute(context);
            if (IsRecordingPlaybackFailure(context.CurrentResult))
            {
                try
                {
                    _testBase.Mode = RecordedTestMode.Record;
                    TestResult originalResult = context.CurrentResult;

                    context.CurrentResult = context.CurrentTest.MakeTestResult();
                    context.CurrentResult = innerCommand.Execute(context);

                    // If the recording succeeded, update the original message to reflect this
                    ResultState state;
                    string? stackTrace;
                    StringBuilder builder = new();
                    if (context.CurrentResult.ResultState?.Status == TestStatus.Passed)
                    {
                        state = originalResult.ResultState;
                        stackTrace = originalResult.StackTrace;
                        builder.AppendLine("Test failed playback, but was successfully re-recorded. It should pass if re-run.");
                    }
                    else
                    {
                        state = context.CurrentResult.ResultState ?? ResultState.Error;
                        stackTrace = context.CurrentResult.StackTrace;
                        builder.AppendLine("Re-recording attempt failed. Error: ");
                        builder.AppendLine();
                        builder.AppendLine(context.CurrentResult.Message);
                        builder.AppendLine();
                        builder.AppendLine("Original message:");
                    }

                    builder.AppendLine();
                    builder.Append(originalResult.Message);
                    context.CurrentResult.SetResult(state, builder.ToString(), stackTrace);
                }
                finally
                {
                    _testBase.Mode = RecordedTestMode.Playback;
                }
            }

            return context.CurrentResult;
        }

        private static bool IsRecordingPlaybackFailure(TestResult result)
        {
            string exceptionName = typeof(TestRecordingMismatchException).FullName
                ?? nameof(TestRecordingMismatchException);

            // 1. Check if the test passed
            bool testPassed = result.ResultState?.Status switch
            {
                TestStatus.Passed => true,
                TestStatus.Inconclusive => true,
                TestStatus.Skipped => true,
                _ => false
            };

            if (testPassed)
            {
                return false;
            }

            // 2. Check if the failure message indicates a recording playback exception. This sadly requires us to check test failure
            //    messages which can be a little fragile but there does not seem to be a way to get the exception directly
            if (result.Message?.Contains(exceptionName) == true
                || result.Message?.Contains("ClientResultException : NotFound: Recording file path") == true)
            {
                return true;
            }

            return false;
        }
    }
}
