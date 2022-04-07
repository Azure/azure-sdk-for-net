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
    public class PartiallyDeployedAttribute : NUnitAttribute, IWrapTestMethod
    {
        public TestCommand Wrap(TestCommand command) => new PartiallyDeployedCommand(command);

        private class PartiallyDeployedCommand : DelegatingTestCommand
        {
            public PartiallyDeployedCommand(TestCommand innerCommand) : base(innerCommand)
            {
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
                    context.CurrentResult.Message.Contains("Status: 400") &&
                    context.CurrentResult.Message.Contains("ErrorCode: BadParameter"))
                {
                    context.CurrentResult.SetResult(
                        ResultState.Inconclusive,
                        $"The feature under test may not be deployed to this environment. Original message follows:\n\n{context.CurrentResult.Message}",
                        context.CurrentResult.StackTrace);
                }

                return context.CurrentResult;
            }
        }
    }
}
