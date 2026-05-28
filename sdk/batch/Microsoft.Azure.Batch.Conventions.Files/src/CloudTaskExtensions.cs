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

using Azure.Storage.Blobs;
using Microsoft.Azure.Batch.Conventions.Files.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Conventions.Files
{
    /// <summary>
    /// Provides methods for working with the outputs of a <see cref="CloudTask"/>.
    /// </summary>
    public static class CloudTaskExtensions
    {
        /// <summary>
        /// Gets the <see cref="TaskOutputStorage"/> for a specified <see cref="CloudTask"/>.
        /// </summary>
        /// <param name="task">The task for which to get output storage.</param>
        /// <param name="blobClient">The blob service client linked to the Azure Batch storage account.</param>
        /// <returns>A TaskOutputStorage for the specified task.</returns>
        public static TaskOutputStorage OutputStorage(this CloudTask task, BlobServiceClient blobClient)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }
            if (blobClient == null)
            {
                throw new ArgumentNullException(nameof(blobClient));
            }

            return new TaskOutputStorage(blobClient, task.JobId(), task.Id);
        }

        /// <summary>
        /// Gets the Blob name prefix/folder where files of the given kind are stored
        /// </summary>
        /// <param name="task">The task to calculate the output storage destination for.</param>
        /// <param name="kind">The output kind.</param>
        /// <returns>The Blob name prefix/folder where files of the given kind are stored.</returns>
        public static string GetOutputStoragePath(this CloudTask task, TaskOutputKind kind)
            => StoragePath.TaskStoragePath.BlobNamePrefixImpl(kind, task.Id);

        private static string JobId(this CloudTask task)
        {
            // Workaround for CloudTask not knowing its parent job ID.

            if (task.Url == null)
            {
                throw new ArgumentException("Task Url property must be populated", nameof(task));
            }

            var jobId = UrlUtils.GetUrlValueSegment(task.Url, "jobs");

            if (jobId == null)
            {
                throw new ArgumentException($"Task URL is malformed: unable to obtain job ID from URL '{task.Url}'", nameof(task));
            }

            return jobId;
        }
    }
}
