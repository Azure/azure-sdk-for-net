// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Storage;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Loggers;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.Storage.Blob;

namespace WebJobs.Host.Storage.Logging
{
    internal class BlobFunctionOutputLogger : IFunctionOutputLogger
    {
        private readonly CloudBlobDirectory _outputLogDirectory;

        public BlobFunctionOutputLogger(CloudBlobClient client)
            : this(client.GetContainerReference(HostContainerNames.Hosts).GetDirectoryReference(HostDirectoryNames.OutputLogs))
        {
        }

        private BlobFunctionOutputLogger(CloudBlobDirectory outputLogDirectory)
        {
            _outputLogDirectory = outputLogDirectory;
        }

        public async Task<IFunctionOutputDefinition> CreateAsync(IFunctionInstance instance, CancellationToken cancellationToken)
        {
            await _outputLogDirectory.Container.CreateIfNotExistsAsync(cancellationToken);

            string namePrefix = instance.Id.ToString("N");
            LocalBlobDescriptor outputBlob = CreateDescriptor(_outputLogDirectory, namePrefix + ".txt");
            LocalBlobDescriptor parameterLogBlob = CreateDescriptor(_outputLogDirectory, namePrefix + ".params.txt");

            return new BlobFunctionOutputDefinition(_outputLogDirectory.ServiceClient, outputBlob, parameterLogBlob);
        }

        private static LocalBlobDescriptor CreateDescriptor(CloudBlobDirectory directory, string name)
        {
            var blob = directory.SafeGetBlockBlobReference(name);

            return new LocalBlobDescriptor
            {
                ContainerName = blob.Container.Name,
                BlobName = blob.Name
            };
        }
    }
}
