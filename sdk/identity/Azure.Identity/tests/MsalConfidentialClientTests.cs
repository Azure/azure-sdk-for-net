// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;
using Azure.Core.TestFramework;

namespace Azure.Identity.Tests
{
    public class MsalConfidentialClientTests
    {
        private string cp1 = "CP1";

        [Test]
        [NonParallelizable]
        public void CreateClientRespectsCaeConfig(
            [Values(true, false, null)] bool? setDisableSwitch,
            [Values(true, false, null)] bool? setDisableEnvVar)
        {
            TestAppContextSwitch ctx = null;
            TestEnvVar env = null;
            try
            {
                if (setDisableSwitch != null)
                {
                    ctx = new TestAppContextSwitch(IdentityCompatSwitches.DisableCP1ExecutionSwitchName, setDisableSwitch.Value.ToString());
                }
                if (setDisableEnvVar != null)
                {
                    env = new TestEnvVar(IdentityCompatSwitches.DisableCP1ExecutionEnvVar, setDisableEnvVar.Value.ToString());
                }

                var mock = new MockMsalConfidentialClient();
                mock.ClientAppFactory = (capabilities) =>
                {
                    bool IsCp1Set = cp1 == string.Join("", capabilities);
                    if (setDisableSwitch.HasValue)
                    {
                        Assert.AreEqual(setDisableSwitch.Value, !IsCp1Set);
                    }
                    else
                    {
                        Assert.AreEqual(setDisableEnvVar.HasValue && setDisableEnvVar.Value, !IsCp1Set);
                    }
                    return Moq.Mock.Of<IConfidentialClientApplication>();
                };

                mock.CallCreateClientAsync(false, default);
            }
            finally
            {
                ctx?.Dispose();
                env?.Dispose();
            }
        }
    }
}
