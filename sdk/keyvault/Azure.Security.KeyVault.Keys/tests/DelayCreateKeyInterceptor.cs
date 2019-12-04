// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.Testing;
using Castle.DynamicProxy;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    // TODO: Remove this implementation when https://github.com/Azure/azure-sdk-for-net/issues/8575 is fixed.
    internal class DelayCreateKeyInterceptor : IInterceptor
    {
        private const string DelayEnvironmentVariableName = "AZURE_KEYVAULT_TEST_DELAY";
        private const int DefaultDelay = 1000;

        private readonly int _delay = DefaultDelay;
        private readonly RecordedTestMode _mode;

        internal DelayCreateKeyInterceptor(RecordedTestMode mode)
        {
            _mode = mode;

            if (int.TryParse(Environment.GetEnvironmentVariable(DelayEnvironmentVariableName), out int delay))
            {
                if (delay >= 0)
                {
                    _delay = delay;
                }
            }
        }

        public void Intercept(IInvocation invocation)
        {
            if (_mode != RecordedTestMode.Playback && _delay > 0)
            {
                string name = invocation.Method.Name;
                switch (name)
                {
                    case nameof(KeyClient.CreateEcKeyAsync):
                    case nameof(KeyClient.CreateKeyAsync):
                    case nameof(KeyClient.CreateRsaKeyAsync):
                        TestContext.WriteLine("Delaying {0} by {1}ms", name, _delay);
                        Thread.Sleep(_delay);
                        break;
                }
            }

            invocation.Proceed();
        }
    }
}
