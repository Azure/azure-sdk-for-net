// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace Azure.Security.KeyVault.Tests
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class IgnoreServiceErrorAttribute : NUnitAttribute, IWrapTestMethod
    {
        public TestCommand Wrap(TestCommand command) => new IgnoreServiceErrorCommand(this, command);

        /// <summary>
        /// Gets the reason the service error should be ignored.
        /// </summary>
        protected abstract string Reason { get; }

        /// <summary>
        /// Determines if the <paramref name="message"/> matches conditions to ignore the service error.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected abstract bool Matches(string message);

        private class IgnoreServiceErrorCommand : DelegatingTestCommand
        {
            private readonly IgnoreServiceErrorAttribute _attribute;

            public IgnoreServiceErrorCommand(IgnoreServiceErrorAttribute attribute, TestCommand innerCommand) : base(innerCommand)
            {
                _attribute = attribute;
            }

            public override TestResult Execute(TestExecutionContext context)
            {
                RequestFailedException rex = null;
                try
                {
                    context.CurrentResult = innerCommand.Execute(context);
                }
                catch (RequestFailedException ex)
                {
                    rex = ex;
                }
                catch (Exception ex) when (ex.InnerException is RequestFailedException _rex)
                {
                    rex = _rex;
                }

                if (rex != null)
                {
                    context.CurrentResult.SetResult(ResultState.Failure, rex.Message, rex.StackTrace);
                }

                if (context.CurrentResult.ResultState.Status == TestStatus.Failed &&
                    !string.IsNullOrEmpty(context.CurrentResult.Message) &&
                    _attribute.Matches(context.CurrentResult.Message))
                {
                    context.CurrentResult.SetResult(
                        ResultState.Inconclusive,
                        $"{_attribute.Reason}\n\nOriginal message follows:\n\n{context.CurrentResult.Message}",
                        context.CurrentResult.StackTrace);
                }

                return context.CurrentResult;
            }
        }
    }
}
