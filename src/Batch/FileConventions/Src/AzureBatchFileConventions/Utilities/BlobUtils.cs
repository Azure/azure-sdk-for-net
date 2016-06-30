using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Conventions.Files.Utilities
{
    internal static class BlobUtils
    {
        internal static async Task EnsureExistsAsync(this CloudAppendBlob blob)
        {
            try
            {
                await blob.CreateOrReplaceAsync(AccessCondition.GenerateIfNotExistsCondition(), null, null);
            }
            catch (StorageException ex) when (ex.StorageErrorCodeIs("BlobAlreadyExists"))
            {
            }
        }

        internal static bool StorageErrorCodeIs(this StorageException ex, string errorCodeToTestFor)
        {
            var errorCode = ex?.RequestInformation?.ExtendedErrorInformation?.ErrorCode;

            return errorCodeToTestFor.Equals(errorCode, StringComparison.OrdinalIgnoreCase);
        }
    }
}
