// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class QuotaTests : TestBase
    {
        [Fact]
        [Trait("owner", "vifedo")]
        public async Task TryUpdateQuota()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                try
                {

                    // try to update quota. should not be 400(bad contract) but 404(quota not found)
                    await testBase.client.QuotaByCounterKeys.UpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        "not_exist",
                        new QuotaCounterValueUpdateContract() { CallsCount = 0, KbTransferred = 0 });
                }
                catch (ErrorResponseException ex) when (ex.Body.Code == "ResourceNotFound")
                {
                    //expected, do not raise exception
                }
            }
        }
    }
}
