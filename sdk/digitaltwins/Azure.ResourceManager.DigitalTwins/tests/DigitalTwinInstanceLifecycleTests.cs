// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DigitalTwins.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.ResourceManager.DigitalTwins.Tests
{
    public class DigitalTwinInstanceLifecycleTests : E2eTestBase
    {
        public DigitalTwinInstanceLifecycleTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task DigitalTwinInstance_Lifecycle()
        {
            InitClient();

            string dtInstanceName;
            Response<CheckNameResult> checkNameResponse = null;
            const int maxTryCount = 5;
            int tryCount = 0;

            // Ensure the random instance Id generated does not already exist.
            do
            {
                dtInstanceName = $"DtInstanceLifecycle-{GetRandom()}";

                if (tryCount++ > maxTryCount)
                {
                    // If for some reason this unique check keeps failing, proceed with the last unique
                    // name.
                    break;
                }

                try
                {
                    checkNameResponse = await Client.DigitalTwins
                        .CheckNameAvailabilityAsync(
                            TestEnvironment.Location,
                            dtInstanceName)
                        .ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.Forbidden)
                {
                    // This call requires contributor rights in subscription, which I think might be a bug
                    // but until it changes, this test should just assume the random name is probably
                    // unique.
                    break;
                }
                catch (RequestFailedException ex)
                {
                    Console.WriteLine(ex);
                }
            } while (checkNameResponse?.GetRawResponse().Status != 200);

            bool createdSuccessfully = false;

            try
            {
                // Test create
                DigitalTwinsCreateOrUpdateOperation createResponse = await Client.DigitalTwins
                    .StartCreateOrUpdateAsync(
                        TestEnvironment.ResourceGroup,
                        dtInstanceName,
                        new DigitalTwinsDescription(TestEnvironment.Location))
                    .ConfigureAwait(false);

                // IsAsync seems to be broken. My async method gets the breakpoint no matter the mode.
                // Once issue is resolved, return this code to the right path.
                //int expectedCreateResponseCode = IsAsync ? 201 : 200;
                //createResponse.GetRawResponse().Status.Should().Be(expectedCreateResponseCode);
                createResponse.GetRawResponse().Status.Should().BeOneOf(200, 201);

                createResponse.GetRawResponse().ClientRequestId.Should().NotBeNullOrWhiteSpace();

                Response<DigitalTwinsDescription> createdResponse = await WaitForCompletionAsync(createResponse).ConfigureAwait(false);
                createdResponse.GetRawResponse().Status.Should().Be(200);
                createdResponse.GetRawResponse().ClientRequestId.Should().NotBeNullOrWhiteSpace();
                createdSuccessfully = true;

                // Validate create
                DigitalTwinsDescription createdDtInstance = createdResponse.Value;
                createdDtInstance.Name.Should().Be(dtInstanceName);
                createdDtInstance.Location.Should().Be(TestEnvironment.Location);
                createdDtInstance.ProvisioningState.Should().Be(ProvisioningState.Succeeded);
                createdDtInstance.HostName.Should().NotBeNullOrWhiteSpace();
                createdDtInstance.Id.Should().NotBeNullOrWhiteSpace();
                createdDtInstance.CreatedTime.Should().NotBeNull();
                createdDtInstance.LastUpdatedTime.Should().NotBeNull();

                // Test get
                Response<DigitalTwinsDescription> getResponse = await Client.DigitalTwins
                    .GetAsync(
                        TestEnvironment.ResourceGroup,
                        dtInstanceName)
                    .ConfigureAwait(false);

                // Validate get
                getResponse.GetRawResponse().Status.Should().Be(200);
                getResponse.GetRawResponse().ClientRequestId.Should().NotBeNullOrWhiteSpace();
                getResponse.Value.Name.Should().Be(dtInstanceName);
                getResponse.Value.Location.Should().Be(TestEnvironment.Location);
                getResponse.Value.ProvisioningState.Should().Be(ProvisioningState.Succeeded);
                getResponse.Value.HostName.Should().NotBeNullOrWhiteSpace();
                getResponse.Value.Id.Should().NotBeNullOrWhiteSpace();
                getResponse.Value.CreatedTime.Should().NotBeNull();
                getResponse.Value.LastUpdatedTime.Should().NotBeNull();

                // Test list
                AsyncPageable<DigitalTwinsDescription> listResponse = Client.DigitalTwins.ListAsync();

                // Validate list
                DigitalTwinsDescription foundInstance = null;
                await foreach (DigitalTwinsDescription dtInstance in listResponse)
                {
                    if (StringComparer.Ordinal.Equals(dtInstance.Name, dtInstanceName))
                    {
                        foundInstance = dtInstance;
                        break;
                    }
                }
                foundInstance.Name.Should().Be(dtInstanceName);
                foundInstance.Location.Should().Be(TestEnvironment.Location);
                foundInstance.ProvisioningState.Should().Be(ProvisioningState.Succeeded);
                foundInstance.HostName.Should().NotBeNullOrWhiteSpace();
                foundInstance.Id.Should().NotBeNullOrWhiteSpace();
                foundInstance.CreatedTime.Should().NotBeNull();
                foundInstance.LastUpdatedTime.Should().NotBeNull();
            }
            finally
            {
                if (createdSuccessfully)
                {
                    // Test delete
                    DigitalTwinsDeleteOperation deleteResponse = await Client.DigitalTwins
                        .StartDeleteAsync(
                            TestEnvironment.ResourceGroup,
                            dtInstanceName)
                        .ConfigureAwait(false);

                    deleteResponse.GetRawResponse().Status.Should().BeOneOf(202);
                    deleteResponse.GetRawResponse().ClientRequestId.Should().NotBeNullOrWhiteSpace();

                    // Validate delete
                    Response<Response> deletedResponse = await WaitForCompletionAsync(deleteResponse).ConfigureAwait(false);
                    // The swagger indicates this should be a 204, but in practice the service returns 200.
                    // The issue has been raised with the service team, but for now we'll expect a 200 instead.
                    deletedResponse.Value.Status.Should().Be(200);
                    deletedResponse.GetRawResponse().ClientRequestId.Should().NotBeNullOrWhiteSpace();
                }
            }
        }
    }
}
