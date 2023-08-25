// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class MediaPrivateEndpointConnectionTests : MediaManagementTestBase
    {
        private MediaServicesAccountResource _mediaService;

        private MediaServicesPrivateEndpointConnectionCollection mediaPrivateEndpointConnectionCollection => _mediaService.GetMediaServicesPrivateEndpointConnections();

        public MediaPrivateEndpointConnectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var mediaServiceName = Recording.GenerateAssetName(MediaServiceAccountPrefix);
            _mediaService = await CreateMediaService(ResourceGroup, mediaServiceName);
        }

        [Ignore("Depend on Network which will block the pipeline to release new Network package, disable this case temporary")]
        [RecordedTest]
        public async Task GetAll()
        {
            var list = await mediaPrivateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
