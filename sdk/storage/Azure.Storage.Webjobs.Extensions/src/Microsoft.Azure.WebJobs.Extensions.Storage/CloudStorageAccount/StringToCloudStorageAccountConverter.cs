// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.Storage;

namespace Microsoft.Azure.WebJobs.Host.Bindings.StorageAccount
{
    internal class StringToCloudStorageAccountConverter : IConverter<string, CloudStorageAccount>
    {
        public CloudStorageAccount Convert(string input)
        {
            return CloudStorageAccount.Parse(input);
        }
    }
}
