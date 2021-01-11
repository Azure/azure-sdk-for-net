//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Microsoft.Azure.Storage.Blob.Perf.Scenarios
{
    public class UploadBlob : RandomBlobTest<SizeOptions>
    {
        public UploadBlob(SizeOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
            using Stream stream = RandomStream.Create(Options.Size);
            CloudBlockBlob.UploadFromStream(stream);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            using Stream stream = RandomStream.Create(Options.Size);
            await CloudBlockBlob.UploadFromStreamAsync(stream, cancellationToken);
        }
    }
}
