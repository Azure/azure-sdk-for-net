// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System.IO;

namespace Microsoft.Azure.Management.HDInsight.Job.Models
{
    /// <summary>
    /// Manages storage access details for job operations against HDInsight clusters.
    /// </summary>
    public interface IStorageAccess
    {
        /// <summary>
        /// Gets the content of input file as memory stream.
        /// </summary>
        /// <param name='file'>
        /// Required. File path which needs to be downloaded.
        /// </param>
        /// <returns>
        /// Memory stream which contains file content.
        /// </returns>
        Stream GetFileContent(string file);
    }
}
