// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    internal class DataLakeQueryErrorHandler
    {
        private Action<DataLakeQueryError> _errorHandler;

        public DataLakeQueryErrorHandler(Action<DataLakeQueryError> errorHandler)
        {
            _errorHandler = errorHandler;
        }

        public void Handle(BlobQueryError blobQueryError)
            => _errorHandler(blobQueryError.ToDataLakeQueryError());
    }
}
