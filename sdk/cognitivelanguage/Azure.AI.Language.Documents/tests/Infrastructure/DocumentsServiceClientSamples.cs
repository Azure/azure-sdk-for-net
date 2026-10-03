// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Language.Documents.Tests.Samples
{
    public partial class DocumentsServiceClientSamples : DocumentServiceTestBase<DocumentsServiceClient>
    {
        public DocumentsServiceClientSamples(bool isAsync, DocumentsServiceClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }
    }
}
