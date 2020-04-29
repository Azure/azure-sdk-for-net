// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    internal class DataLakeQueryErrorHandler : IBlobQueryErrorHandler
    {
        private IDataLakeQueryErrorHandler _errorHandler;

        public DataLakeQueryErrorHandler(IDataLakeQueryErrorHandler errorHandler)
        {
            _errorHandler = errorHandler;
        }

        public void ReportError(BlobQueryError blobQueryError)
            => _errorHandler.ReportError(blobQueryError.ToDataLakeQueryError());
    }
}
