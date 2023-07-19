using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch
{
    public partial class ResourceFile
    {
        /// <summary>
        /// Creates a new <see cref="ResourceFile"/> from the specified HTTP URL.
        /// </summary>
        /// <param name='httpUrl'>The URL of the file to download.</param>
        /// <param name='filePath'>The location on the compute node to which to download the file(s), relative to the task's working directory.</param>
        /// <param name='fileMode'>The file permission mode attribute in octal format.</param>
        /// <returns>A <see cref="ResourceFile"/> from the specified HTTP URL.</returns>
        public static ResourceFile FromUrl(string httpUrl, string filePath, string fileMode = null)
        {
            return new ResourceFile(httpUrl: httpUrl, filePath: filePath, fileMode: fileMode);
        }

        /// <summary>
        /// Creates a new <see cref="ResourceFile"/> from the specified HTTP URL.
        /// </summary>
        /// <param name='httpUrl'>The URL of the file to download.</param>
        /// <param name='identityReference'>The identity to use for accessing the file in Azure Storage</param>
        /// <param name='filePath'>The location on the compute node to which to download the file(s), relative to the task's working directory.</param>
        /// <param name='fileMode'>The file permission mode attribute in octal format.</param>
        /// <returns>A <see cref="ResourceFile"/> from the specified HTTP URL.</returns>
        public static ResourceFile FromUrl(string httpUrl, ComputeNodeIdentityReference identityReference, string filePath, string fileMode = null)
        {
            return new ResourceFile(httpUrl: httpUrl, filePath: filePath, fileMode: fileMode, identityReference: identityReference);
        }

        /// <summary>
        /// Creates a new <see cref="ResourceFile"/> from the specified Azure Storage container URL.
        /// </summary>
        /// <param name='storageContainerUrl'>The URL of the blob container within Azure Blob Storage.</param>
        /// <param name='filePath'>The location on the compute node to which to download the file(s), relative to the task's working directory.</param>
        /// <param name='blobPrefix'>The blob prefix to use when downloading blobs from an Azure Storage container. Only the blobs whose names begin 
        /// with the specified prefix will be downloaded.</param>
        /// <param name='fileMode'>The file permission mode attribute in octal format.</param>
        /// <returns>A <see cref="ResourceFile"/> from the specified Azure Storage container URL.</returns>
        public static ResourceFile FromStorageContainerUrl(string storageContainerUrl, string filePath = null, string blobPrefix = null, string fileMode = null)
        {
            return new ResourceFile(storageContainerUrl: storageContainerUrl, filePath: filePath, blobPrefix: blobPrefix, fileMode: fileMode);
        }

        /// <summary>
        /// Creates a new <see cref="ResourceFile"/> from the specified Azure Storage container URL.
        /// </summary>
        /// <param name='storageContainerUrl'>The URL of the blob container within Azure Blob Storage.</param>
        /// <param name='identityReference'>The identity to use for accessing the container in Azure Storage</param>
        /// <param name='filePath'>The location on the compute node to which to download the file(s), relative to the task's working directory.</param>
        /// <param name='blobPrefix'>The blob prefix to use when downloading blobs from an Azure Storage container. Only the blobs whose names begin 
        /// with the specified prefix will be downloaded.</param>
        /// <param name='fileMode'>The file permission mode attribute in octal format.</param>
        /// <returns>A <see cref="ResourceFile"/> from the specified Azure Storage container URL.</returns>
        public static ResourceFile FromStorageContainerUrl(string storageContainerUrl, ComputeNodeIdentityReference identityReference, string filePath = null, string blobPrefix = null, string fileMode = null)
        {
            return new ResourceFile(storageContainerUrl: storageContainerUrl, filePath: filePath, blobPrefix: blobPrefix, fileMode: fileMode, identityReference: identityReference);
        }

        /// <summary>
        /// Creates a new <see cref="ResourceFile"/> from the specified auto storage container name.
        /// </summary>
        /// <param name='autoStorageContainerName'>The storage container name in the auto storage account.</param>
        /// <param name='filePath'>The location on the compute node to which to download the file(s), relative to the task's working directory.</param>
        /// <param name='blobPrefix'>The blob prefix to use when downloading blobs from an Azure Storage container. Only the blobs whose names begin 
        /// with the specified prefix will be downloaded.</param>
        /// <param name='fileMode'>The file permission mode attribute in octal format.</param>
        /// <returns>A <see cref="ResourceFile"/> from the specified auto storage container name.</returns>
        public static ResourceFile FromAutoStorageContainer(string autoStorageContainerName, string filePath = null, string blobPrefix = null, string fileMode = null)
        {
            return new ResourceFile(autoStorageContainerName: autoStorageContainerName, filePath: filePath, blobPrefix: blobPrefix, fileMode: fileMode);
        }
    }
}
