// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.HDInsight.Job.Models
{
    using System.IO;

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
