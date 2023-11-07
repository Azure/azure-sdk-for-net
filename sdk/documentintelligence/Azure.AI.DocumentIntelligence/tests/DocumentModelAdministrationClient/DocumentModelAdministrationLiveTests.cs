// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentIntelligence.Tests
{
    public class DocumentModelAdministrationLiveTests : DocumentIntelligenceLiveTestBase
    {
        public DocumentModelAdministrationLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task AuthorizeModelCopy()
        {
            var client = CreateDocumentModelAdministrationClient();
            var modelId = Recording.GenerateId();
            var request = new AuthorizeCopyRequest(modelId);

            CopyAuthorization copyAuthorization = await client.AuthorizeModelCopyAsync(request);

            Assert.That(copyAuthorization.TargetModelId, Is.EqualTo(modelId));
            Assert.That(copyAuthorization.TargetResourceId, Is.EqualTo(TestEnvironment.ResourceId));
            Assert.That(copyAuthorization.TargetResourceRegion, Is.EqualTo(TestEnvironment.ResourceRegion));
            Assert.That(copyAuthorization.AccessToken, Is.Not.Null);
            Assert.That(copyAuthorization.AccessToken, Is.Not.Empty);
            Assert.That(copyAuthorization.ExpirationDateTime, Is.GreaterThan(Recording.UtcNow));
        }
    }
}
