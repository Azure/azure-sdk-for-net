// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Testing;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Test
{
    public abstract class KeyVaultTestBase : RecordedTestBase
    {
        public const string AzureKeyVaultUrlEnvironmentVariable = "AZURE_KEYVAULT_URL";

        protected KeyVaultTestBase(bool isAsync) : base(isAsync)
        {
        }

        internal SecretClient GetClient(TestRecording recording = null)
        {
            recording ??= Recording;

            return InstrumentClient
                (new SecretClient(
                    new Uri(recording.GetVariableFromEnvironment(AzureKeyVaultUrlEnvironmentVariable)),
                    recording.GetCredential(AzureCredential.Default),
                    recording.InstrumentClientOptions(new SecretClientOptions())));
        }

        protected void AssertSecretsEqual(Secret exp, Secret act)
        {
            Assert.AreEqual(exp.Value, act.Value);
            AssertSecretsEqual((SecretBase)exp, (SecretBase)act);
        }

        protected void AssertSecretsEqual(SecretBase exp, SecretBase act)
        {
            Assert.AreEqual(exp.Id, act.Id);
            Assert.AreEqual(exp.ContentType, act.ContentType);
            Assert.AreEqual(exp.KeyId, act.KeyId);
            Assert.AreEqual(exp.Managed, act.Managed);

            Assert.AreEqual(exp.Enabled, act.Enabled);
            Assert.AreEqual(exp.Expires, act.Expires);
            Assert.AreEqual(exp.NotBefore, act.NotBefore);
        }
    }
}