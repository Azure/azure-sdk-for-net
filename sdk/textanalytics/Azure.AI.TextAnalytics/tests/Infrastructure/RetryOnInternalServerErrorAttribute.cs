// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace Azure.AI.TextAnalytics.Tests.Infrastructure
{
    /// <summary>
    /// Attribute used to specify that a test must be retried in the specific case of a known transient issue where the
    /// server returns a successful 200 OK response status but reports an internal server error in the response body
    /// for one or more text analysis tasks. If the test continues to fail due to this particular issue after reaching
    /// the retry limit, the test result is marked as inconclusive.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class RetryOnInternalServerErrorAttribute : NUnitAttribute, IRepeatTest
    {
        /// <summary>
        /// The maximum number of times that the test will be retried.
        /// </summary>
        internal const int TryCount = 3;

        #region IRepeatTest Members

        /// <summary>
        /// Wrap a command and return the result.
        /// </summary>
        public TestCommand Wrap(TestCommand command)
        {
            return new RetryOnInternalServerErrorCommand(command, TryCount);
        }

        #endregion

        /// <summary>
        /// The test command for the <see cref="RetryOnInternalServerErrorAttribute"/>.
        /// </summary>
        public class RetryOnInternalServerErrorCommand : DelegatingTestCommand
        {
            private readonly int _tryCount;

            /// <summary>
            /// Initializes a new instance of the <see cref="RetryOnInternalServerErrorCommand"/> class.
            /// </summary>
            public RetryOnInternalServerErrorCommand(TestCommand innerCommand, int tryCount)
                : base(innerCommand)
            {
                _tryCount = tryCount;
            }

            /// <summary>
            /// Runs the test, saving a  <see cref="TestResult"/> in the supplied <see cref="TestExecutionContext"/>.
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
                        break;

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

            /// <summary>
            /// Indicates whether the encountered exception corresponds to the issue in question.
            /// </summary>
            private bool ShouldRetry(TestExecutionContext context)
            {
                return
                    context.CurrentResult.ResultState.Status == TestStatus.Failed
                    && context.CurrentResult.ResultState.Label == "Error"
                    && context.CurrentResult.Message.Contains("Azure.RequestFailedException")
                    && context.CurrentResult.Message.Contains("Status: 200 (OK)")
                    && context.CurrentResult.Message.Contains("ErrorCode: InternalServerError");
            }
        }
    }
}
