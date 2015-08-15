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
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.HadoopAppliance.Client.HadoopStorageRestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class HadoopApplianceStoragePocoClient : IHadoopApplianceStoragePocoClient
    {
        private StorageClientBasicAuthCredential credentials;
        private readonly bool ignoreSslErrors;
        private readonly TimeSpan timeout;

        /// <summary>
        ///     Initializes a new instance of the <see cref="HadoopApplianceStoragePocoClient"/> class.
        /// </summary>
        /// <param name="credentials">
        ///     The connection credentials to use when connecting to the instance.
        /// </param>
        /// <param name="ignoreSslErrors">
        ///     Specifies that server side SSL errors should be ignored.
        /// </param>
        /// <param name="timeout">Maximum time span for storage commands.</param>
        public HadoopApplianceStoragePocoClient(IStorageClientCredential credentials, bool ignoreSslErrors, TimeSpan timeout)
        {
            this.credentials = (StorageClientBasicAuthCredential)credentials;
            this.ignoreSslErrors = ignoreSslErrors;
            this.timeout = timeout;
        }

        /// <inheritdoc />
        public async Task<DirectoryListing> GetDirectoryStatusAsync(string path)
        {
            var client = ServiceLocator.Instance.Locate<IHadoopApplianceStorageRestClientFactory>()
                .Create(this.credentials, this.ignoreSslErrors, this.timeout);
            var result = await client.ListStatus(path);
            return this.DeserializeJsonResult<DirectoryListingContainer>(result.Content).Listing;
        }

        /// <inheritdoc />
        public async Task<DirectoryEntry> GetFileStatusAsync(string path)
        {
            var client = ServiceLocator.Instance.Locate<IHadoopApplianceStorageRestClientFactory>()
                .Create(this.credentials, this.ignoreSslErrors, this.timeout);
            var result = await client.GetFileStatus(path);
            return this.DeserializeJsonResult<DirectoryEntryContainer>(result.Content).Entry;
        }

        /// <inheritdoc />
        public async Task<bool> ExistsAsync(string path)
        {
            var client = ServiceLocator.Instance.Locate<IHadoopApplianceStorageRestClientFactory>()
                .Create(this.credentials, this.ignoreSslErrors, this.timeout);
            var result = await client.Exists(path);
            return result.StatusCode != HttpStatusCode.NotFound;
        }

        /// <inheritdoc />
        public async Task<bool> CreateDirectoryAsync(string path)
        {
            var client = ServiceLocator.Instance.Locate<IHadoopApplianceStorageRestClientFactory>()
                .Create(this.credentials, this.ignoreSslErrors, this.timeout);
            var result = await client.CreateDirectory(path);
            return this.GetOperationStatus(result.Content);
        }

        /// <inheritdoc />
        public async Task<string> WriteAsync(Stream content, string path, bool? overwrite)
        {
            var client = ServiceLocator.Instance.Locate<IHadoopApplianceStorageRestClientFactory>()
                .Create(this.credentials, this.ignoreSslErrors, this.timeout);
            var result = await client.Write(path, content, overwrite);
            return result.Headers.GetValues("Location").First();
        }

        /// <inheritdoc />
        public async Task<bool> AppendAsync(Stream content, string path)
        {
            var client = ServiceLocator.Instance.Locate<IHadoopApplianceStorageRestClientFactory>()
                .Create(this.credentials, this.ignoreSslErrors, this.timeout);
            var result = await client.Append(path, content);
            return true;
        }

        /// <inheritdoc />
        public async Task<Stream> ReadAsync(string path, int? offset, int? length, int? buffersize)
        {
            var client = ServiceLocator.Instance.Locate<IHadoopApplianceStorageRestClientFactory>()
                .Create(this.credentials, this.ignoreSslErrors, this.timeout);
            var result = await client.Read(path, offset, length, buffersize);
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(result.Content);
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(string path, bool? recursive)
        {
            var client = ServiceLocator.Instance.Locate<IHadoopApplianceStorageRestClientFactory>()
                .Create(this.credentials, this.ignoreSslErrors, this.timeout);
            var result = await client.Delete(path, recursive);
            return this.GetOperationStatus(result.Content);
        }

        /// <inheritdoc />
        public async Task<bool> RenameAsync(string path, string newPath)
        {
            var client = ServiceLocator.Instance.Locate<IHadoopApplianceStorageRestClientFactory>()
                .Create(this.credentials, this.ignoreSslErrors, this.timeout);
            var result = await client.Rename(path, newPath);
            return this.GetOperationStatus(result.Content);
        }

        /// <inheritdoc />
        public async Task<ContentSummary> GetContentSummaryAsync(string path)
        {
            var client =
                (IHadoopApplianceStorageRestClient)
                    ServiceLocator.Instance.Locate<IHadoopApplianceStorageRestClientFactory>().Create(this.credentials, this.ignoreSslErrors, this.timeout);
            var result = await client.GetContentSummary(path);
            return DeserializeJsonResult<ContentSummaryContainer>(result.Content).Summary;
        }

        /// <inheritdoc />
        public async Task<string> GetHomeDirectoryAsync()
        {
            var client =
                (IHadoopApplianceStorageRestClient)
                    ServiceLocator.Instance.Locate<IHadoopApplianceStorageRestClientFactory>().Create(this.credentials, this.ignoreSslErrors, this.timeout);
            var result = await client.GetHomeDirectory();
            return DeserializeJsonResult<JObject>(result.Content).Value<string>("Path");
        }

        /// <inheritdoc />
        public async Task<bool> SetReplicationFactorAsync(string path, short replicationFactor)
        {
            var client =
                (IHadoopApplianceStorageRestClient)
                    ServiceLocator.Instance.Locate<IHadoopApplianceStorageRestClientFactory>().Create(this.credentials, this.ignoreSslErrors, this.timeout);
            var result = await client.SetReplication(path, replicationFactor);
            return this.GetOperationStatus(result.Content);
        }

        /// <inheritdoc />
        public async Task<bool> SetPermissionsAsync(string path, string permissions)
        {
            var client =
                (IHadoopApplianceStorageRestClient)
                    ServiceLocator.Instance.Locate<IHadoopApplianceStorageRestClientFactory>().Create(this.credentials, this.ignoreSslErrors, this.timeout);
            var result = await client.SetPermission(path, permissions);
            return true;
        }

        /// <inheritdoc />
        public async Task<bool> SetOwnerAsync(string path, string owner, string group)
        {
            var client =
                (IHadoopApplianceStorageRestClient)
                    ServiceLocator.Instance.Locate<IHadoopApplianceStorageRestClientFactory>().Create(this.credentials, this.ignoreSslErrors, this.timeout);
            var result = await client.SetOwner(path, owner, group);
            return true;
        }

        private T DeserializeJsonResult<T>(string content)
        {
            return (T)JsonConvert.DeserializeObject(content, typeof(T));
        }

        private bool GetOperationStatus(string content)
        {
            var status = DeserializeJsonResult<JObject>(content);
            return status.Value<bool>("boolean");
        }
    }
}
