// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

            return command;
        }
    }
}
