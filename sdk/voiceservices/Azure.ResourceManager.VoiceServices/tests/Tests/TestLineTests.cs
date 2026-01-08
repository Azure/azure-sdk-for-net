// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.VoiceServices.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.VoiceServices.Tests
{
    public class TestLineTests : VoiceServicesManagementTestBase
    {
        private VoiceServicesCommunicationsGatewayResource _communicationsGateway;

        public TestLineTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            _communicationsGateway = await CreateDefaultCommunicationsGateway();
        }

        private static VoiceServicesTestLineData DefaultTestLineData()
        {
            return new VoiceServicesTestLineData(Location)
            {
                PhoneNumber = "123456789",
                Purpose = VoiceServicesTestLinePurpose.Automated
            };
        }

        [RecordedTest]
        public async Task CRUDL()
        {
            var rg = await CreateResourceGroup();
            var resourceName = Recording.GenerateAssetName("SDKTest");

            // PUT - Create
            var createOperation = await _communicationsGateway.GetVoiceServicesTestLines().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, DefaultTestLineData());
            Assert.Multiple(() =>
            {
                Assert.That(createOperation.HasCompleted, Is.True);
                Assert.That(createOperation.HasValue, Is.True);
            });

            // GET - check it exists
            var getResponse = await _communicationsGateway.GetVoiceServicesTestLineAsync(resourceName);
            var testLine = getResponse.Value;
            Assert.That(testLine, Is.Not.Null);

            // PUT - Update
            var updatedTestLineData = DefaultTestLineData();
            updatedTestLineData.PhoneNumber = "123";
            var putOperation = await _communicationsGateway.GetVoiceServicesTestLines().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, updatedTestLineData);
            Assert.Multiple(() =>
            {
                Assert.That(putOperation.HasCompleted, Is.True);
                Assert.That(putOperation.HasValue, Is.True);
            });

            // GET - check the updated testLine name
            getResponse = await _communicationsGateway.GetVoiceServicesTestLineAsync(resourceName);
            testLine = getResponse.Value;
            Assert.That(testLine, Is.Not.Null);
            Assert.That(testLine.Data.PhoneNumber, Is.EqualTo("123"));

            // PATCH
            var patch = new VoiceServicesTestLinePatch();
            patch.Tags.Add("tagKey", "tagValue");
            var patchOperation = await testLine.UpdateAsync(patch);
            Assert.That(patchOperation.Value, Is.Not.Null);

            // GET - check the updated tags
            getResponse = await _communicationsGateway.GetVoiceServicesTestLineAsync(resourceName);
            testLine = getResponse.Value;
            Assert.That(testLine, Is.Not.Null);
            Assert.That(testLine.Data.Tags["tagKey"], Is.EqualTo("tagValue"));

            // List TestLines by CommunicationsGateway
            var testLines = _communicationsGateway.GetVoiceServicesTestLines().GetAllAsync();
            var testLinesResult = await testLines.ToEnumerableAsync();
            Assert.That(testLinesResult, Is.Not.Null);
            Assert.That(testLinesResult, Is.Not.Empty);

            // Delete
            var deleteOperation = await testLine.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();
            Assert.That(deleteOperation.HasCompleted, Is.True);
        }
    }
}
