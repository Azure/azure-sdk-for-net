// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Sample1_CustomisingServiceParameters
using Azure.Core;
using Azure.Developer.MicrosoftPlaywrightTesting.NUnit;
using Azure.Identity;

namespace PlaywrightTests.Sample1; // Remember to change this as per your project namespace

[SetUpFixture]
#if SNIPPET
public class PlaywrightServiceSetup : PlaywrightServiceNUnit
#else
public class Sample1ServiceSetup : PlaywrightServiceNUnit
#endif
{
    public static readonly TokenCredential managedIdentityCredential = new ManagedIdentityCredential();

#if SNIPPET
    public PlaywrightServiceSetup() : base(managedIdentityCredential) {}
#else
    public Sample1ServiceSetup() : base(managedIdentityCredential) {}
#endif
}
#endregion
