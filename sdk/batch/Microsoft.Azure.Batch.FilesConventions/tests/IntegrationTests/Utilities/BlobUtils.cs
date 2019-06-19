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

﻿using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Utilities
{
    internal static class BlobUtils
    {
        internal static async Task<byte[]> ReadAsByteArrayAsync(this OutputFileReference blob, int maxSize = 16 * 1024 /* more than enough for our test files */)
        {
            var buffer = new byte[maxSize];
            var byteCount = await blob.DownloadToByteArrayAsync(buffer, 0);

            var blobContent = new byte[byteCount];
            Array.Copy(buffer, blobContent, byteCount);
            return blobContent;
        }
    }
}
