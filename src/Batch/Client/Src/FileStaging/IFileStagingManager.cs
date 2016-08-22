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

﻿using System;
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
