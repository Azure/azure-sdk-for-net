// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Sample2_SetDefaultAuthenticationMechanism
using Azure.Developer.MicrosoftPlaywrightTesting.NUnit;

namespace PlaywrightTests.Sample2; // Remember to change this as per your project namespace

[SetUpFixture]
#if SNIPPET
public class PlaywrightServiceSetup : PlaywrightServiceNUnit {};
#else
public class Sample2ServiceSetup : PlaywrightServiceNUnit { };
#endif
#endregion
