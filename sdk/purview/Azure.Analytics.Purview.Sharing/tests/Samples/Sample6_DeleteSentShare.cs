// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using System;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples
{
    public class Sample6_DeleteSentShare : SentSharesClientTestBase
    {
        public Sample6_DeleteSentShare(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task DeleteSentShareTest()
        {
            #region Snippet:SentSharesClientSample_DeleteSentShare

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
            var sentShareClient = new SentSharesClient(endPoint, credential);

            Operation operation = await sentShareClient.DeleteSentShareAsync(WaitUntil.Completed, "sentShareId", new());
#else
            var sentShareClient = GetSentSharesClient();

            Operation operation = await sentShareClient.DeleteSentShareAsync(WaitUntil.Completed, "016eb068-ddaa-41be-8804-8bef566663a5", new());
#endif

            #endregion
        }
    }
}
