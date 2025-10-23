// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Attribute used to specify that a test must be retried in the specific case of a known error. If the test
/// continues to fail due to this particular issue after reaching the specified limit of tries, the test result is
/// marked as inconclusive.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public abstract class RetryOnErrorAttribute : NUnitAttribute, IRepeatTest
{
    private readonly int _tryCount;

    private readonly Func<TestExecutionContext, bool> _shouldRetry;

    /// <summary>
    /// Initializes a <see cref="RetryOnErrorAttribute"/> instance.
    /// </summary>
    /// <param name="tryCount">The number of times that the test can be executed.</param>
    /// <param name="shouldRetry">The function that determines whether the test should be retried.</param>
    protected RetryOnErrorAttribute(int tryCount, Func<TestExecutionContext, bool> shouldRetry)
    {
        _tryCount = tryCount;
        _shouldRetry = shouldRetry;
    }

    #region IRepeatTest Members

    /// <summary>
    /// Wrap a command and return the result.
    /// </summary>
    /// <param name="command">The command to wrap.</param>
    /// <returns>The wrapped command.</returns>
    public TestCommand Wrap(TestCommand command)
    {
        return new RetryOnErrorCommand(command, _tryCount, _shouldRetry);
    }

    #endregion

    /// <summary>
    /// The test command for the <see cref="RetryOnErrorAttribute"/>.
    /// </summary>
    public class RetryOnErrorCommand : DelegatingTestCommand
    {
        private readonly int _tryCount;

        private Func<TestExecutionContext, bool> _shouldRetry;

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryOnErrorCommand"/> class.
        /// </summary>
        public RetryOnErrorCommand(TestCommand innerCommand, int tryCount, Func<TestExecutionContext, bool> shouldRetry)
            : base(innerCommand)
        {
            _tryCount = tryCount;
            _shouldRetry = shouldRetry;
        }

        /// <summary>
        /// Runs the test, saving a <see cref="TestResult"/> in the supplied <see cref="TestExecutionContext"/>.
        /// </summary>
        public override TestResult Execute(TestExecutionContext context)
        {
            int count = _tryCount;

            while (count-- > 0)
            {
                try
                {
                    context.CurrentResult = innerCommand.Execute(context);
                }
                catch (Exception ex)
                {
                    context.CurrentResult ??= context.CurrentTest.MakeTestResult();
                    context.CurrentResult.RecordException(ex);
                }

                if (!ShouldRetry(context))
                {
                    break;
                }

                if (count > 0)
                {
                    // Clear result for retry.
                    context.CurrentResult = context.CurrentTest.MakeTestResult();
                    context.CurrentRepeatCount++;
                }
                else
                {
                    context.CurrentResult = context.CurrentTest.MakeTestResult();
                    context.CurrentResult.SetResult(ResultState.Inconclusive);
                }
            }

            return context.CurrentResult;
        }

        private bool ShouldRetry(TestExecutionContext context)
        {
            return
                context.CurrentResult.ResultState.Status == TestStatus.Failed
                && context.CurrentResult.ResultState.Label == "Error"
                && _shouldRetry(context);
        }
    }
}