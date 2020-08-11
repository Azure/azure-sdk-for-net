// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.TestFramework;
using Castle.DynamicProxy;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    // TODO: Remove this implementation when https://github.com/Azure/azure-sdk-for-net/issues/8575 is fixed.
    internal class DelayCreateKeyInterceptor : IInterceptor
    {
        private const string DelayEnvironmentVariableName = "AZURE_KEYVAULT_TEST_DELAY";
        private const int DefaultMaxDelay = 1000;

        private readonly int _maxDelay = DefaultMaxDelay;
        private readonly RecordedTestMode _mode;

        private DateTimeOffset _last = DateTimeOffset.Now;

        internal DelayCreateKeyInterceptor(RecordedTestMode mode)
        {
            _mode = mode;

            if (int.TryParse(Environment.GetEnvironmentVariable(DelayEnvironmentVariableName), out int maxDelay))
            {
                if (maxDelay >= 0)
                {
                    _maxDelay = maxDelay;
                }
            }
        }

        public void Intercept(IInvocation invocation)
        {
            if (_mode != RecordedTestMode.Playback && _maxDelay > 0)
            {
                string name = invocation.Method.Name;
                switch (name)
                {
                    case nameof(KeyClient.CreateEcKeyAsync):
                    case nameof(KeyClient.CreateKeyAsync):
                    case nameof(KeyClient.CreateRsaKeyAsync):
                        Delay(name);
                        break;
                }
            }

            invocation.Proceed();
        }

        private void Delay(string name)
        {
            try
            {
                TimeSpan ellapsed = DateTimeOffset.Now - _last;
                int delay = Math.Max(0, _maxDelay - (int)ellapsed.TotalMilliseconds);

                if (delay > 0)
                {
                    TestContext.WriteLine("Delaying {0} by {1}ms", name, delay);
                    Thread.Sleep(delay);
                }
            }
            finally
            {
                _last = DateTimeOffset.Now;
            }
        }
    }
}
