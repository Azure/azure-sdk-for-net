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
namespace Microsoft.HadoopAppliance.Client
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.HadoopAppliance.Client.HadoopStorageClientLayer;
    using Microsoft.HadoopAppliance.Client.HadoopStoragePocoClient;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    internal class HadoopApplianceStorageClient : DisposableObject, IHadoopApplianceStorageClient
    {
        private StorageClientBasicAuthCredential credentials;

        /// <inheritdoc />
        public bool IgnoreSslErrors { get; set; }

        /// <inheritdoc />
        public TimeSpan Timeout { get; set; }

        /// <summary>
        /// Default timout period.
        /// </summary>
        internal static TimeSpan DefaultTimeout = new TimeSpan(0, 5, 0);

        /// <summary>
        ///     Initializes a new instance of the <see cref="HadoopApplianceStorageClient"/> class.
        /// </summary>
        /// <param name="credentials">The connection credentials to use when connecting to the instance.</param>
        public HadoopApplianceStorageClient(IStorageClientCredential credentials)
        {
            this.credentials = (StorageClientBasicAuthCredential)credentials;
            this.Timeout = DefaultTimeout;
            this.IgnoreSslErrors = false;
        }

        /// <inheritdoc />
        public Task<DirectoryListing> GetDirectoryStatusAsync(string path)
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplianceStoragePocoClientFactory>();
            var pocoClient = factory.Create(this.credentials, this.IgnoreSslErrors, this.Timeout);
            return pocoClient.GetDirectoryStatusAsync(path);
        }

        /// <inheritdoc />
        public Task<DirectoryEntry> GetFileStatusAsync(string path)
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplianceStoragePocoClientFactory>();
            var pocoClient = factory.Create(this.credentials, this.IgnoreSslErrors, this.Timeout);
            return pocoClient.GetFileStatusAsync(path);
        }

        /// <inheritdoc />
        public Task<bool> ExistsAsync(string path)
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplianceStoragePocoClientFactory>();
            var pocoClient = factory.Create(this.credentials, this.IgnoreSslErrors, this.Timeout);
            return pocoClient.ExistsAsync(path);
        }

        /// <inheritdoc />
        public Task<bool> CreateDirectoryAsync(string path)
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplianceStoragePocoClientFactory>();
            var pocoClient = factory.Create(this.credentials, this.IgnoreSslErrors, this.Timeout);
            return pocoClient.CreateDirectoryAsync(path);
        }

        /// <inheritdoc />
        public Task<string> WriteAsync(Stream content, string path, bool? overwrite)
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplianceStoragePocoClientFactory>();
            var pocoClient = factory.Create(this.credentials, this.IgnoreSslErrors, this.Timeout);
            return pocoClient.WriteAsync(content, path, overwrite);
        }

        /// <inheritdoc />
        public Task<string> WriteAsync(Stream content, string path)
        {
            return this.WriteAsync(content, path, null);
        }

        /// <inheritdoc />
        public Task<bool> AppendAsync(Stream content, string path)
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplianceStoragePocoClientFactory>();
            var pocoClient = factory.Create(this.credentials, this.IgnoreSslErrors, this.Timeout);
            return pocoClient.AppendAsync(content, path);
        }

        /// <inheritdoc />
        public Task<Stream> ReadAsync(string path, int? offset, int? length, int? buffersize)
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplianceStoragePocoClientFactory>();
            var pocoClient = factory.Create(this.credentials, this.IgnoreSslErrors, this.Timeout);
            return pocoClient.ReadAsync(path, offset, length, buffersize);
        }

        /// <inheritdoc />
        public Task<Stream> ReadAsync(string path)
        {
            return this.ReadAsync(path, null, null, null);
        }

        /// <inheritdoc />
        public Task<Stream> ReadAsync(string path, int? offset)
        {
            return this.ReadAsync(path, offset, null, null);
        }

        /// <inheritdoc />
        public Task<Stream> ReadAsync(string path, int? offset, int? length)
        {
            return this.ReadAsync(path, offset, length, null);
        }

        /// <inheritdoc />
        public Task<bool> DeleteAsync(string path, bool? recursive)
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplianceStoragePocoClientFactory>();
            var pocoClient = factory.Create(this.credentials, this.IgnoreSslErrors, this.Timeout);
            return pocoClient.DeleteAsync(path, recursive);
        }

        /// <inheritdoc />
        public Task<bool> DeleteAsync(string path)
        {
            return this.DeleteAsync(path, null);
        }

        /// <inheritdoc />
        public Task<bool> RenameAsync(string path, string newPath)
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplianceStoragePocoClientFactory>();
            var pocoClient = factory.Create(this.credentials, this.IgnoreSslErrors, this.Timeout);
            return pocoClient.RenameAsync(path, newPath);
        }

        /// <inheritdoc />
        public Task<ContentSummary> GetContentSummaryAsync(string path)
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplianceStoragePocoClientFactory>();
            var pocoClient = (IHadoopApplianceStoragePocoClient)factory.Create(this.credentials, this.IgnoreSslErrors, this.Timeout);
            return pocoClient.GetContentSummaryAsync(path);
        }

        /// <inheritdoc />
        public Task<string> GetHomeDirectoryAsync()
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplianceStoragePocoClientFactory>();
            var pocoClient = (IHadoopApplianceStoragePocoClient)factory.Create(this.credentials, this.IgnoreSslErrors, this.Timeout);
            return pocoClient.GetHomeDirectoryAsync();
        }

        /// <inheritdoc />
        public Task<bool> SetReplicationFactorAsync(string path, short replicationFactor)
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplianceStoragePocoClientFactory>();
            var pocoClient = (IHadoopApplianceStoragePocoClient)factory.Create(this.credentials, this.IgnoreSslErrors, this.Timeout);
            return pocoClient.SetReplicationFactorAsync(path, replicationFactor);
        }

        /// <inheritdoc />
        public Task<bool> SetPermissionsAsync(string path, string permissions)
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplianceStoragePocoClientFactory>();
            var pocoClient = (IHadoopApplianceStoragePocoClient)factory.Create(this.credentials, this.IgnoreSslErrors, this.Timeout);
            return pocoClient.SetPermissionsAsync(path, permissions);
        }

        /// <inheritdoc />
        public Task<bool> SetOwnerAsync(string path, string owner, string group)
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplianceStoragePocoClientFactory>();
            var pocoClient = (IHadoopApplianceStoragePocoClient)factory.Create(this.credentials, this.IgnoreSslErrors, this.Timeout);
            return pocoClient.SetOwnerAsync(path, owner, group);
        }

        /// <inheritdoc />
        public DirectoryListing GetDirectoryStatus(string path)
        {
            return this.GetDirectoryStatusAsync(path).WaitForResult();
        }

        /// <inheritdoc />
        public DirectoryEntry GetFileStatus(string path)
        {
            return this.GetFileStatusAsync(path).WaitForResult();
        }

        /// <inheritdoc />
        public bool Exists(string path)
        {
            return this.ExistsAsync(path).WaitForResult();
        }

        /// <inheritdoc />
        public bool CreateDirectory(string path)
        {
            return this.CreateDirectoryAsync(path).WaitForResult();
        }

        /// <inheritdoc />
        public string Write(Stream content, string path, bool? overwrite)
        {
            return this.WriteAsync(content, path, overwrite).WaitForResult();
        }

        /// <inheritdoc />
        public string Write(Stream content, string path)
        {
            return this.Write(content, path, null);
        }

        /// <inheritdoc />
        public bool Append(Stream content, string path)
        {
            return this.AppendAsync(content, path).WaitForResult();
        }

        /// <inheritdoc />
        public Stream Read(string path, int? offset, int? length, int? buffersize)
        {
            return this.ReadAsync(path, offset, length, buffersize).WaitForResult();
        }

        /// <inheritdoc />
        public Stream Read(string path)
        {
            return this.Read(path, null, null, null);
        }

        /// <inheritdoc />
        public Stream Read(string path, int? offset)
        {
            return this.Read(path, offset, null, null);
        }

        /// <inheritdoc />
        public Stream Read(string path, int? offset, int? length)
        {
            return this.Read(path, offset, length, null);
        }

        /// <inheritdoc />
        public bool Delete(string path, bool? recursive)
        {
            return this.DeleteAsync(path, recursive).WaitForResult();
        }

        /// <inheritdoc />
        public bool Delete(string path)
        {
            return this.Delete(path, null);
        }

        /// <inheritdoc />
        public bool Rename(string path, string newPath)
        {
            return this.RenameAsync(path, newPath).WaitForResult();
        }

        /// <inheritdoc />
        public ContentSummary GetContentSummary(string path)
        {
            return this.GetContentSummaryAsync(path).WaitForResult();
        }

        /// <inheritdoc />
        public string GetHomeDirectory()
        {
            return this.GetHomeDirectoryAsync().WaitForResult();
        }

        /// <inheritdoc />
        public bool SetReplicationFactor(string path, short replicationFactor)
        {
            return this.SetReplicationFactorAsync(path, replicationFactor).WaitForResult();
        }

        /// <inheritdoc />
        public bool SetPermissions(string path, string permissions)
        {
            return this.SetPermissionsAsync(path, permissions).WaitForResult();
        }

        /// <inheritdoc />
        public bool SetOwner(string path, string owner, string group)
        {
            return this.SetOwnerAsync(path, owner, group).WaitForResult();
        }
    }
}
