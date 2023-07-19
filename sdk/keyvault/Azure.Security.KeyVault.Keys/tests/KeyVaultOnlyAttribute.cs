// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyVaultOnlyAttribute : NUnitAttribute, IWrapSetUpTearDown
    {
        public TestCommand Wrap(TestCommand command)
        {
            ITest test = command.Test;
            while (test.Fixture == null && test.Parent != null)
            {
                test = test.Parent;
            }

            if (test is Test t && test.Fixture is KeysTestBase fixture && fixture.IsManagedHSM)
            {
                t.RunState = RunState.Skipped;
                test.Properties.Set(PropertyNames.SkipReason, $"This test can only run on Key Vault.");

                return new SkipCommand(t);
            }

            return new CheckSupportedCommand(command);
        }

        private class CheckSupportedCommand : DelegatingTestCommand
        {
            public CheckSupportedCommand(TestCommand innerCommand) : base(innerCommand)
            {
            }

            public override TestResult Execute(TestExecutionContext context)
            {
                context.CurrentResult = innerCommand.Execute(context);

                if (context.CurrentResult.ResultState.Status == TestStatus.Failed &&
                    context.CurrentResult.Message.Contains(typeof(RequestFailedException).FullName) &&
                    context.CurrentResult.Message.Contains("Status: 400") &&
                    context.CurrentResult.Message.Contains("ErrorCode: NotSupported"))
                {
                    string line = context.CurrentResult.Message.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)?[0];
                    context.CurrentResult.SetResult(ResultState.Ignored, "The feature under test is not supported." + Environment.NewLine + line ?? string.Empty);
                }

                return context.CurrentResult;
            }
        }
    }
}
