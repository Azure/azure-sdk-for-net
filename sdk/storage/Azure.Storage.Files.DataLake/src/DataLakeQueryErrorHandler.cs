// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    internal class DataLakeQueryErrorHandler : BlobQueryErrorHandler
    {
        private IDataLakeQueryErrorHandler _errorHandler;

        public DataLakeQueryErrorHandler(IDataLakeQueryErrorHandler errorHandler)
        {
            _errorHandler = errorHandler;
        }

        public override void Handle(BlobQueryError blobQueryError)
            => _errorHandler.ReportError(blobQueryError.ToDataLakeQueryError());


        public override Task HandleAsync(BlobQueryError blobQueryError)
        {
            throw new System.NotImplementedException();
        }
    }
}
