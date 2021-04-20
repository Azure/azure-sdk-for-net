// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace Azure.Storage.Tests.Shared
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class RetryOnFailedRequestAttribute : NUnitAttribute, IRepeatTest
    {
        private readonly int _tryCount;
        private readonly int _delaySeconds;
        private string _errorMessage;

        public RetryOnFailedRequestAttribute(int tryCount, int delaySeconds, string errorMessage)
        {
            _tryCount = tryCount;
            _delaySeconds = delaySeconds;
            _errorMessage = errorMessage;
        }

        public TestCommand Wrap(TestCommand command)
        {
            return new RetryOnFailedRequestAttributeCommand(command, _tryCount, _delaySeconds, _errorMessage);
        }

        public class RetryOnFailedRequestAttributeCommand : DelegatingTestCommand
        {
            private readonly int _tryCount;
            private readonly int _delaySeconds;
            private readonly string _errorMessage;

            public RetryOnFailedRequestAttributeCommand(TestCommand innerCommand, int tryCount, int delaySeconds, string errorMessage)
                : base(innerCommand)
            {
                _tryCount = tryCount;
                _delaySeconds = delaySeconds;
                _errorMessage = errorMessage;
            }

            public override TestResult Execute(TestExecutionContext context)
            {
                int count = _tryCount;

                while (count-- > 0)
                {
                    context.CurrentResult = innerCommand.Execute(context);

                    // Clear result for retry
                    if (count > 0 && ShouldRetry(context.CurrentResult))
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(_delaySeconds));
                        context.CurrentResult = context.CurrentTest.MakeTestResult();
                        context.CurrentRepeatCount++; // increment Retry count for next iteration. will only happen if we are guaranteed another iteration
                    }
                    else
                    {
                        break;
                    }
                }

                return context.CurrentResult;
            }

            private bool ShouldRetry(TestResult testResult)
            {
                var failed = testResult.ResultState.Status switch
                {
                    TestStatus.Passed => false,
                    TestStatus.Skipped => false,
                    _ => true
                };

                return failed
                    && testResult.Message.Contains(typeof(RequestFailedException).FullName)
                    && testResult.Message.Contains(_errorMessage);
            }
        }
    }
}
