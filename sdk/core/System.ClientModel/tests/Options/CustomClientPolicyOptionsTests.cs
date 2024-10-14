// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.ReferenceClients.PagingPolicyClient;
using ClientModel.ReferenceClients.PagingClient;

using NUnit.Framework;

namespace System.ClientModel.Tests.Options;

public class CustomClientPolicyOptionsTests
{
    [Test]
    public void CanSetPublicPolicyBehaviorsFromClientOptions()
    {
        PagingPolicyClientOptions clientOptions = new();
        clientOptions.Pager.PhoneNumber = "555-555-1234";

        PagingPolicyClient client = new PagingPolicyClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("fake key"),
            clientOptions);
    }

    [Test]
    public void CanSetPublicPolicyBehaviorsToOverrideClientOptions()
    {
        PagerPolicyOptions policyOptions = new();
        policyOptions.PhoneNumber = "555-555-1234";

        PagingPolicyClientOptions clientOptions = new();
        clientOptions.PagerPolicy = new PagerPolicy(policyOptions);

        PagingPolicyClient client = new PagingPolicyClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("fake key"),
            clientOptions);
    }

    [Test]
    public void CanSetInternalPolicyBehaviorsFromClientOptions()
    {
        PagingClientOptions clientOptions = new();
        clientOptions.PagerNumber = "555-555-1234";

        PagingClient client = new PagingClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("fake key"),
            clientOptions);
    }
}
