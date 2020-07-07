// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Storage.Blob;
using WebJobs.Host.Storage.Logging;

namespace Microsoft.Azure.WebJobs.Host.Loggers
{
    // Wrap facilities for logging a function's output. 
    // This means capturing console out, redirecting to a TraceWriter that is available at a blob.
    // Handle incremental updates to get real-time updates for long running functions. 
    internal sealed class BlobFunctionOutputDefinition : IFunctionOutputDefinition
    {
        private readonly CloudBlobClient _client;
        private readonly LocalBlobDescriptor _outputBlob;
        private readonly LocalBlobDescriptor _parameterLogBlob;

        public BlobFunctionOutputDefinition(CloudBlobClient client, LocalBlobDescriptor outputBlob, LocalBlobDescriptor parameterLogBlob)
        {
            _client = client;
            _outputBlob = outputBlob;
            _parameterLogBlob = parameterLogBlob;
        }

        public LocalBlobDescriptor OutputBlob
        {
            get { return _outputBlob; }
        }

        public LocalBlobDescriptor ParameterLogBlob
        {
            get { return _parameterLogBlob; }
        }

        public IFunctionOutput CreateOutput()
        {
            var blob = GetBlockBlobReference(_outputBlob);
            return UpdateOutputLogCommand.Create(blob);
        }

        public IRecurrentCommand CreateParameterLogUpdateCommand(IReadOnlyDictionary<string, IWatcher> watches, ILogger logger)
        {
            return new UpdateParameterLogCommand(watches, GetBlockBlobReference(_parameterLogBlob), logger);
        }

        private CloudBlockBlob GetBlockBlobReference(LocalBlobDescriptor descriptor)
        {
            var container = _client.GetContainerReference(descriptor.ContainerName);
            return container.GetBlockBlobReference(descriptor.BlobName);
        }
    }
}
