// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Identity;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Core.Tests.Identity
{
    public class MsalManagedIdentityClientReflectionTests
    {
        [Test]
        public void TryCreateWithAttestationSupport_DoesNotThrow_AndReturnsConsistentResult()
        {
            Assert.DoesNotThrow(() =>
            {
                bool success = MsalManagedIdentityClient.TryCreateWithAttestationSupport(out Func<AcquireTokenForManagedIdentityParameterBuilder, AcquireTokenForManagedIdentityParameterBuilder> withAttestationSupport);

                if (success)
                {
                    Assert.NotNull(withAttestationSupport, "Delegate must be non-null when reflection contract resolves successfully.");
                }
                else
                {
                    Assert.IsNull(withAttestationSupport, "Delegate must be null when reflection contract is unavailable.");
                }
            });
        }
    }
}
