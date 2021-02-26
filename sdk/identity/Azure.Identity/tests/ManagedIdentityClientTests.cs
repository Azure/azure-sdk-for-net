// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity.Tests;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ManagedIdentityClientTests
    {
        public const string ClientIdFromCtor = "1234";
        public const string ClientIdFromEnvironment = "4567";

        [Test]
        public void ClientIdIsReadFromEnvironmentVariableWhenAvailable(
            [Values(null, ClientIdFromCtor)] string clientIdFromCtor,
            [Values(null, ClientIdFromEnvironment)] string clientIdFromEnvironment)
        {
            using (new TestEnvVar(new ()
            {
                { "AZURE_CLIENT_ID", clientIdFromEnvironment }}))
            {
                var client = new ManagedIdentityClient(default, clientIdFromCtor);

                string expectedClientId = clientIdFromCtor switch
                {
                    null when clientIdFromEnvironment is null => null,
                    null when clientIdFromEnvironment is not null => clientIdFromEnvironment,
                    _ => clientIdFromCtor,
                };

                Assert.That(client.ClientId, Is.EqualTo(expectedClientId));
            }
        }
    }
}
