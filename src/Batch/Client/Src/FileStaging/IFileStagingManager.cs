using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.Azure.Batch.FileStaging
{
    internal interface IFileStagingManager : IDisposable
    {
        /// <summary>
        /// Begins asychronous call to list all the blobs in the current container.
        /// </summary>
        /// <returns></returns>
        System.Threading.Tasks.Task<List<ICloudBlob>> ListBlobsAsync();

        /// <summary>
        /// Blocking call to list all the blobs in the current container.
        /// </summary>
        /// <returns></returns>
        List<ICloudBlob> ListBlobs();

        /// <summary>
        /// Creates a SAS for a blob that already exists.
        /// </summary>
        /// <param name="blob"></param>
        /// <param name="ttl"></param>
        /// <returns></returns>
        string CreateSASForBlob(ICloudBlob blob, TimeSpan ttl);
    }
}
