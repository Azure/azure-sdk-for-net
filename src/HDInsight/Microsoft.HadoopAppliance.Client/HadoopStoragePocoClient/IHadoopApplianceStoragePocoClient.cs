// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.HadoopAppliance.Client.HadoopStoragePocoClient
{
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.HadoopStoragePocoClient;

    internal interface IHadoopApplianceStoragePocoClient : IHadoopStoragePocoClient
    {
        /// <summary>
        ///     Get content summary of a given path.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <returns>Content summary of a given path.</returns>
        Task<ContentSummary> GetContentSummaryAsync(string path);

        /// <summary>
        /// Get the current user's home directory in the file system.
        /// </summary>
        /// <returns>Home directory of the current user.</returns>
        Task<string> GetHomeDirectoryAsync();

        /// <summary>
        ///     Set replication factor for an existing file.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <param name="replicationFactor">Replication factor.</param>
        /// <returns>Returns true if operation completed successfully, otherwise false.</returns>
        Task<bool> SetReplicationFactorAsync(string path, short replicationFactor);

        /// <summary>
        ///     Set permissions of a path.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <param name="permissions">Permissions to be set.</param>
        /// <returns>True if the operation succeded.</returns>
        Task<bool> SetPermissionsAsync(string path, string permissions);

        /// <summary>
        ///     Set owner of a path (i.e. a file or a directory). The parameters owner and group cannot both be null.
        /// </summary>
        /// <param name="path">Path to file/directory.</param>
        /// <param name="owner">New owner of file. If it is null, the original owner name remains unchanged.</param>
        /// <param name="group">New group owner of file. If it is null, the original group name remains unchanged.</param>
        /// <returns>True if the operation succeded.</returns>
        Task<bool> SetOwnerAsync(string path, string owner, string group);
    }
}
