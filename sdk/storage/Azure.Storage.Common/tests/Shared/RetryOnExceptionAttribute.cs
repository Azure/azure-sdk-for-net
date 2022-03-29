// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace Azure.Storage.Tests.Shared
{
    /// <summary>
    /// This is clone of Retry from NUnit. Except it retries on exception. NUnit version retries on assertion error only.
    /// Use only to deal with flaky live tests.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class RetryOnExceptionAttribute : NUnitAttribute, IRepeatTest
    {
        private readonly int _tryCount;
        private readonly Type _exceptionType;

        public RetryOnExceptionAttribute(int tryCount, Type exceptionType)
        {
            _tryCount = tryCount;
            _exceptionType = exceptionType;
        }

        #region IRepeatTest Members
        public TestCommand Wrap(TestCommand command)
        {
            return new RetryCommand(command, _tryCount, _exceptionType);
        }

        #endregion

        #region Nested RetryCommand Class

        public class RetryCommand : DelegatingTestCommand
        {
            private readonly int _tryCount;
            private readonly Type _exceptionType;

            public RetryCommand(TestCommand innerCommand, int tryCount, Type exceptionType)
                : base(innerCommand)
            {
                _tryCount = tryCount;
                _exceptionType = exceptionType;
            }

            public override TestResult Execute(TestExecutionContext context)
            {
                int count = _tryCount;

                while (count-- > 0)
                {
                    try
                    {
                        context.CurrentResult = innerCommand.Execute(context);
                    }
                    // Commands are supposed to catch exceptions, but some don't
                    // and we want to look at restructuring the API in the future.
                    catch (Exception ex)
                    {
                        if (context.CurrentResult == null)
                            context.CurrentResult = context.CurrentTest.MakeTestResult();
                        context.CurrentResult.RecordException(ex);
                    }

                    // Clear result for retry
                    if (count > 0 && IsTestFailedWithExpectedException(context))
                    {
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

            private bool IsTestFailedWithExpectedException(TestExecutionContext context)
            {
                var failed = context.CurrentResult.ResultState.Status switch
                {
                    TestStatus.Passed => false,
                    TestStatus.Skipped => false,
                    _ => true
                };

                return failed && context.CurrentResult.Message.Contains(_exceptionType.FullName);
            }
        }

        #endregion
    }
}
