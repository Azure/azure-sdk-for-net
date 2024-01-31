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
            Assert.IsTrue(createOperation.HasCompleted);
            Assert.IsTrue(createOperation.HasValue);

            // GET - check it exists
            var getResponse = await _communicationsGateway.GetVoiceServicesTestLineAsync(resourceName);
            var testLine = getResponse.Value;
            Assert.IsNotNull(testLine);

            // PUT - Update
            var updatedTestLineData = DefaultTestLineData();
            updatedTestLineData.PhoneNumber = "123";
            var putOperation = await _communicationsGateway.GetVoiceServicesTestLines().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, updatedTestLineData);
            Assert.IsTrue(putOperation.HasCompleted);
            Assert.IsTrue(putOperation.HasValue);

            // GET - check the updated testLine name
            getResponse = await _communicationsGateway.GetVoiceServicesTestLineAsync(resourceName);
            testLine = getResponse.Value;
            Assert.IsNotNull(testLine);
            Assert.AreEqual("123", testLine.Data.PhoneNumber);

            // PATCH
            var patch = new VoiceServicesTestLinePatch();
            patch.Tags.Add("tagKey", "tagValue");
            var patchOperation = await testLine.UpdateAsync(patch);
            Assert.IsNotNull(patchOperation.Value);

            // GET - check the updated tags
            getResponse = await _communicationsGateway.GetVoiceServicesTestLineAsync(resourceName);
            testLine = getResponse.Value;
            Assert.IsNotNull(testLine);
            Assert.AreEqual("tagValue", testLine.Data.Tags["tagKey"]);

            // List TestLines by CommunicationsGateway
            var testLines = _communicationsGateway.GetVoiceServicesTestLines().GetAllAsync();
            var testLinesResult = await testLines.ToEnumerableAsync();
            Assert.NotNull(testLinesResult);
            Assert.IsTrue(testLinesResult.Count >= 1);

            // Delete
            var deleteOperation = await testLine.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteOperation.HasCompleted);
        }
    }
}
