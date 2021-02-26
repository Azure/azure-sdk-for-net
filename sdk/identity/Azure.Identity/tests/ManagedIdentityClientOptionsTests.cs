// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity.Tests;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ManagedIdentityClientOptionsTests
    {
        public const string ExplicitClientId = "1234";
        public const string ClientIdFromEnvironment = "4567";

        [Test]
        public void ClientIdIsReadFromEnvironmentVariableWhenAvailable(
            [Values(null, ExplicitClientId)] string explicitClientId,
            [Values(null, ClientIdFromEnvironment)] string clientIdFromEnvironment)
        {
            using (new TestEnvVar(new ()
            {
                { "AZURE_CLIENT_ID", clientIdFromEnvironment }
            }))
            {
                var options = new ManagedIdentityClientOptions();
                if (explicitClientId != null)
                {
                    options.ClientId = explicitClientId;
                }

                string expectedClientId = explicitClientId switch
                {
                    null when clientIdFromEnvironment is null => null,
                    null when clientIdFromEnvironment is not null => clientIdFromEnvironment,
                    _ => explicitClientId,
                };

                Assert.That(options.ClientId, Is.EqualTo(expectedClientId));
            }
        }
    }
}
