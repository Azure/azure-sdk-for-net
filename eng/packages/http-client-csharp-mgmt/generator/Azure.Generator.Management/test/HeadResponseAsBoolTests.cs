// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Generator.MgmtTypeSpec.Tests;
using Azure.ResourceManager;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests;

internal class HeadResponseAsBoolTests
{
    private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";

    [Test]
    public async Task BodylessHeadUsesStatusForBooleanResult(
        [Values] bool useAsync, [Values] bool tenantScope, [Values(200, 204, 404, 403)] int status)
    {
        var sentHead = false;
        var transport = new MockTransport(request =>
        {
            var path = request.Uri.ToUri().AbsolutePath;
            if (request.Method == RequestMethod.Get && path == "/tenants")
            {
                return new MockResponse(200).SetContent($$"""{"value":[{"id":"/tenants/{{SubscriptionId}}","tenantId":"{{SubscriptionId}}"}]}""");
            }

            Assert.That(request.Method, Is.EqualTo(RequestMethod.Head));
            Assert.That(path, Does.EndWith(tenantScope ? "/configurationNames/example" : "/foos/foo/checkConfiguration"));
            Assert.That(request.Headers.TryGetValue("Accept", out _), Is.False);
            Assert.That(request.Content, Is.Null);
            sentHead = true;
            return new MockResponse(status);
        });
        var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });

        async Task<Response<bool>> SendAsync()
        {
            if (tenantScope)
            {
                var tenant = client.GetTenants().GetAll().Single();
                return useAsync ? await tenant.CheckConfigurationNameAsync("example") : tenant.CheckConfigurationName("example");
            }

            var resource = client.GetFooResource(FooResource.CreateResourceIdentifier(SubscriptionId, "group", "foo"));
            return useAsync ? await resource.CheckConfigurationAsync() : resource.CheckConfiguration();
        }

        var successStatus = tenantScope ? 204 : 200;
        if (status == successStatus || status == 404)
        {
            var result = await SendAsync();
            Assert.That(result.Value, Is.EqualTo(status == successStatus));
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(status));
            Assert.That(result.GetRawResponse().IsError, Is.False);
        }
        else
        {
            var failure = Assert.ThrowsAsync<RequestFailedException>(async () => await SendAsync())!;
            Assert.That(failure.Status, Is.EqualTo(status));
            Assert.That(failure.GetRawResponse()!.IsError, Is.True);
        }
        Assert.That(sentHead, Is.True);
    }
}
