// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.ReferenceClients.CustomPolicyClient;
using NUnit.Framework;

namespace System.ClientModel.Tests.Options;

public class CustomClientPolicyOptionsTests
{
    [Test]
    public void CanSetClientPolicyBehaviorsFromClientOptions()
    {
        CustomPolicyClientOptions clientOptions = new();
        clientOptions.Pager.PhoneNumber = "555-555-1234";

        CustomPolicyClient client = new CustomPolicyClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("fake key"),
            clientOptions);
    }

    [Test]
    public void CanSetCustomClientPolicyBehaviorsToOverrideClientOptions()
    {
        PagerPolicyOptions policyOptions = new();
        policyOptions.PhoneNumber = "555-555-1234";

        CustomPolicyClientOptions clientOptions = new();
        clientOptions.PagerPolicy = new PagerPolicy(policyOptions);

        CustomPolicyClient client = new CustomPolicyClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("fake key"),
            clientOptions);
    }
}
