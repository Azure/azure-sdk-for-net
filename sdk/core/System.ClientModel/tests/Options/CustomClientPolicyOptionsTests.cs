// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.ReferenceClients.PagerPolicyClient;
using ClientModel.ReferenceClients.PagerClient;

using NUnit.Framework;

namespace System.ClientModel.Tests.Options;

// Scenarios where a client provides a custom policy -- how does it expose
// options to configure the policy's behavior?
public class CustomClientPolicyOptionsTests
{
    [Test]
    public void CanSetPublicPolicyBehaviorsFromClientOptions()
    {
        PagerPolicyClientOptions clientOptions = new();
        clientOptions.Pager.PhoneNumber = "555-555-1234";

        PagerPolicyClient client = new PagerPolicyClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("fake key"),
            clientOptions);
    }

    [Test]
    public void CanSetPublicPolicyBehaviorsToOverrideClientOptions()
    {
        PagerPolicyOptions policyOptions = new();
        policyOptions.PhoneNumber = "555-555-1234";

        PagerPolicyClientOptions clientOptions = new();
        clientOptions.PagerPolicy = new PagerPolicy(policyOptions);

        PagerPolicyClient client = new PagerPolicyClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("fake key"),
            clientOptions);
    }

    [Test]
    public void CanSetInternalPolicyBehaviorsFromClientOptions()
    {
        // Why would a client use one or another approach?
        // ... We could say ...
        //   - Expose a public property on client options to set the policy
        //     if you want client users to be able to provide their own policy
        //     implementation
        //   - Expose the policy as a public type if you want users to be able
        //     to extend your policy implementation functionality
        //   - If none of these things are in the future, consider making the
        //     policy internal and exposing client options to configure it in
        //     the client's internal pipeline.
        //

        // Note that there is not a good evolution path with this approach - if
        // public options aren't added to client options, if you later want to
        // make the policy public to take the options type as a required
        // parameter, you'd need to EBN the prior properties.

        PagerClientOptions clientOptions = new();
        clientOptions.PagerNumber = "555-555-1234";

        PagerClient client = new(
            new Uri("https://example.com"),
            new ApiKeyCredential("fake key"),
            clientOptions);
    }
}
