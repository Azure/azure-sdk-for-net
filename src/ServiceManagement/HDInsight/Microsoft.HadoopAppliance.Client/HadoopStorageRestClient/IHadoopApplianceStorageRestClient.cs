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
namespace Microsoft.HadoopAppliance.Client.HadoopStorageRestClient
{
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client.HadoopStorageRestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;

    internal interface IHadoopApplianceStorageRestClient : IHadoopStorageRestClient
    {
        /// <summary>
        ///     Return the content summary of a given path.
        /// </summary>
        /// <param name="path">Path to file/directory.</param>
        /// <returns>Content summary of given path.</returns>
        Task<IHttpResponseMessageAbstraction> GetContentSummary(string path);

        /// <summary>
        ///     Return the current user's home directory in this file system. The default implementation returns "/user/$USER/".
        /// </summary>
        /// <returns>Current home directory.</returns>
        Task<IHttpResponseMessageAbstraction> GetHomeDirectory();

        /// <summary>
        ///     Set owner of a path (i.e. a file or a directory). The parameters owner and group cannot both be null.
        /// </summary>
        /// <param name="path">Path to file/directory.</param>
        /// <param name="owner">New owner of file. If it is null, the original owner name remains unchanged.</param>
        /// <param name="group">New group owner of file. If it is null, the original group name remains unchanged.</param>
        /// <returns>Confirmation message.</returns>
        Task<IHttpResponseMessageAbstraction> SetOwner(string path, string owner, string group);

        /// <summary>
        ///     Set permission of a path.
        /// </summary>
        /// <param name="path">Path to file/directory.</param>
        /// <param name="permission">The permission of a file/directory in OCTAL format.</param>
        /// <returns>Confirmation message.</returns>
        Task<IHttpResponseMessageAbstraction> SetPermission(string path, string permission);

        /// <summary>
        ///     Set replication for an existing file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="replication">New replication factor.</param>
        /// <returns>Confirmation message with success indicator flag.</returns>
        Task<IHttpResponseMessageAbstraction> SetReplication(string path, short replication);
    }
}
