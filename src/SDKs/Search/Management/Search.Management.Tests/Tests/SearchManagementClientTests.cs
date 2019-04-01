// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Net;
    using Management.Search;
    using Management.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Xunit;

    public sealed class SearchManagementClientTests : SearchTestBase<ResourceGroupFixture>
    {
        [Fact]
        public void RequestIdIsReturnedInResponse()
        {
            Run(() =>
            {
                SearchManagementClient client = GetSearchManagementClient();

                // We need to use a constant GUID so that this test will still work in playback mode.
                var options = new SearchManagementRequestOptions(new Guid("c4cfce79-eb42-4e61-9909-84510c04706f"));

                var listResponse =
                    client.Services.ListByResourceGroupWithHttpMessagesAsync(Data.ResourceGroupName, searchManagementRequestOptions: options).Result;
                Assert.Equal(HttpStatusCode.OK, listResponse.Response.StatusCode);

                Assert.Equal(options.ClientRequestId.Value.ToString("D"), listResponse.RequestId);
            });
        }
    }
}
