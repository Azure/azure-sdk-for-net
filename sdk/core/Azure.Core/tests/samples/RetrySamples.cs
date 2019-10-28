// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class RetrySamples
    {
        [Test]
        public void RetryOptions()
        {
            #region Snippet:RetryOptions

            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                {
                    Delay = TimeSpan.FromSeconds(2),
                    MaxRetries = 10,
                    Mode = RetryMode.Fixed
                }
            };

            #endregion
        }
    }
}
