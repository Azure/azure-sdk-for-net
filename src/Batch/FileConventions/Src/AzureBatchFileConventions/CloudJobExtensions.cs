using Microsoft.Azure.Batch.Conventions.Files.Utilities;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Conventions.Files
{
    /// <summary>
    /// Provides methods for working with the outputs of a <see cref="CloudJob"/>.
    /// </summary>
    public static class CloudJobExtensions
    {
        /// <summary>
        /// Gets the <see cref="JobOutputStorage"/> for a specified <see cref="CloudJob"/>.
        /// </summary>
        /// <param name="job">The job for which to get output storage.</param>
        /// <param name="storageAccount">The storage account linked to the Azure Batch account.</param>
        /// <returns>A JobOutputStorage for the specified job.</returns>
        public static JobOutputStorage OutputStorage(this CloudJob job, CloudStorageAccount storageAccount)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }
            if (storageAccount == null)
            {
                throw new ArgumentNullException(nameof(storageAccount));
            }

            return new JobOutputStorage(storageAccount, job.Id);
        }

        /// <summary>
        /// Creates an Azure blob storage container for the outputs of a <see cref="CloudJob"/>.
        /// </summary>
        /// <param name="job">The job for which to create the container.</param>
        /// <param name="storageAccount">The storage account linked to the Azure Batch account.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        public static async Task PrepareOutputStorageAsync(this CloudJob job, CloudStorageAccount storageAccount, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }
            if (storageAccount == null)
            {
                throw new ArgumentNullException(nameof(storageAccount));
            }

            var jobOutputContainerName = ContainerNameUtils.GetSafeContainerName(job.Id);
            var jobOutputContainer = storageAccount.CreateCloudBlobClient().GetContainerReference(jobOutputContainerName);

            await jobOutputContainer.CreateIfNotExistsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the name of the Azure blob storage container for the outputs of a <see cref="CloudJob"/>.
        /// </summary>
        /// <param name="job">The job for which to get the container name.</param>
        /// <returns>The name of the container in which to save the outputs of this job.</returns>
        public static string OutputStorageContainerName(this CloudJob job)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }

            var jobOutputContainerName = ContainerNameUtils.GetSafeContainerName(job.Id);

            return jobOutputContainerName;
        }
    }
}
