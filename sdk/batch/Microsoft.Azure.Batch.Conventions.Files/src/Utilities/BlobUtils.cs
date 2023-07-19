// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

using Azure;
using Azure.Storage.Blobs.Specialized;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Conventions.Files.Utilities
{
    internal static class BlobUtils
    {
        internal static async Task EnsureExistsAsync(this AppendBlobClient blob)
        {
            try
            {
                await blob.CreateIfNotExistsAsync().ConfigureAwait(false);
            }
            //Blob already exists
            catch (RequestFailedException rfex) when ((int)System.Net.HttpStatusCode.NotFound == rfex.Status)
            {
            }
        }
    }
}
