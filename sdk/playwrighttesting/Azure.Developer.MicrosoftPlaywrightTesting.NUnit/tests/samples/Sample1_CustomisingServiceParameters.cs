// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Sample1_CustomisingServiceParameters
using Azure.Core;
using Azure.Developer.MicrosoftPlaywrightTesting.NUnit;
using Azure.Identity;

namespace PlaywrightTests;

[SetUpFixture]
#if SNIPPET
public class PlaywrightServiceSetup : PlaywrightServiceNUnit
#else
public class Sample2ServiceSetup : PlaywrightServiceNUnit
#endif
{
    public static readonly TokenCredential managedIdentityCredential = new ManagedIdentityCredential();

#if SNIPPET
    public PlaywrightServiceSetup() : base(managedIdentityCredential) {}
#else
    public Sample2ServiceSetup() : base(managedIdentityCredential) {}
#endif
}
#endregion