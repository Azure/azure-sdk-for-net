// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.VoiceServices.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.VoiceServices.Tests
{
    public class CommunicationsGatewayCRUDTests : VoiceServicesManagementTestBase
    {
        public CommunicationsGatewayCRUDTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task CRUD()
        {
            var rg = await CreateResourceGroup();
            var resourceName = Recording.GenerateAssetName("SDKTest");

            // PUT - Create
            var createOperation = await rg.GetVoiceServicesCommunicationsGateways().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, GetDefaultCommunicationsGatewayData());
            Assert.That(createOperation.HasCompleted, Is.True);
            Assert.That(createOperation.HasValue, Is.True);

            // GET - check it exists
            var getResponse = await rg.GetVoiceServicesCommunicationsGatewayAsync(resourceName);
            var communicationsGateway = getResponse.Value;
            Assert.IsNotNull(communicationsGateway);

            // PUT - Update

            // First, assert that we have only a single codec
            CollectionAssert.AreEquivalent(new List<VoiceServicesTeamsCodec> { VoiceServicesTeamsCodec.Pcma }, communicationsGateway.Data.Codecs);

            var updatedCommunicationsGatewayData = GetDefaultCommunicationsGatewayData();
            updatedCommunicationsGatewayData.Codecs.Add(VoiceServicesTeamsCodec.Pcmu);
            var putOperation = await rg.GetVoiceServicesCommunicationsGateways().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, updatedCommunicationsGatewayData);
            Assert.That(putOperation.HasCompleted, Is.True);
            Assert.That(putOperation.HasValue, Is.True);

            // GET - check the updated Codecs
            getResponse = await rg.GetVoiceServicesCommunicationsGatewayAsync(resourceName);
            communicationsGateway = getResponse.Value;
            Assert.IsNotNull(communicationsGateway);
            CollectionAssert.AreEquivalent(new List<VoiceServicesTeamsCodec> { VoiceServicesTeamsCodec.Pcma, VoiceServicesTeamsCodec.Pcmu }, communicationsGateway.Data.Codecs);

            // PATCH
            var patch = new VoiceServicesCommunicationsGatewayPatch();
            patch.Tags.Add("tagKey", "tagValue");
            var patchOperation = await communicationsGateway.UpdateAsync(patch);
            Assert.IsNotNull(patchOperation.Value);

            // GET - check the updated tags
            getResponse = await rg.GetVoiceServicesCommunicationsGatewayAsync(resourceName);
            communicationsGateway = getResponse.Value;
            Assert.IsNotNull(communicationsGateway);
            Assert.That(communicationsGateway.Data.Tags["tagKey"], Is.EqualTo("tagValue"));

            // Delete
            var deleteOperation = await communicationsGateway.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();
            Assert.That(deleteOperation.HasCompleted, Is.True);
        }
    }
}
