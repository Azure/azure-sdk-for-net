using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Conventions.Files.Utilities
{
    internal static class CloudBlobContainerUtils
    {
        internal static CloudBlobContainer GetContainerReference(Uri jobOutputContainerUri)
        {
            if (jobOutputContainerUri == null)
            {
                throw new ArgumentNullException(nameof(jobOutputContainerUri));
            }

            return new CloudBlobContainer(jobOutputContainerUri);
        }

        internal static CloudBlobContainer GetContainerReference(CloudStorageAccount storageAccount, string jobId)
        {
            if (storageAccount == null)
            {
                throw new ArgumentNullException(nameof(storageAccount));
            }

            Validate.IsNotNullOrEmpty(jobId, nameof(jobId));

            var jobOutputContainerName = ContainerNameUtils.GetSafeContainerName(jobId);
            return storageAccount.CreateCloudBlobClient().GetContainerReference(jobOutputContainerName);
        }
    }
}
