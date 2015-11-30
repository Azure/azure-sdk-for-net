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

namespace Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.RestSimulator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.Storage;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    internal class WabStorageAbstractionSimulator : StorageAbstractionSimulator, IStorageAbstraction
    {
        private readonly WindowsAzureStorageAccountCredentials credentials;

        public WabStorageAbstractionSimulator(WindowsAzureStorageAccountCredentials credentials)
        {
            this.credentials = credentials;
            this.RootPath = this.credentials.Name;
            this.ChosenProtocol = Constants.WabsProtocol;
            this.ChosenProtocolScheme = Constants.WabsProtocolSchemeName;
            this.Root = new StorageSimulatorItem(this.Account, string.Empty);
        }

        public Task CreateContainerIfNotExists(string containerName)
        {
            containerName.ArgumentNotNullOrEmpty("containerName");
            var containerUri = new Uri(string.Format("{0}://{1}@{2}", Constants.WabsProtocol, containerName, this.Account.Host));
            var pathInfo = new PathInfo(containerUri);
            this.AssertIsValidWabsUri(pathInfo);
            this.CreateTree(pathInfo);

            return Task.Delay(0);
        }

        public void Delete(Uri path)
        {
            var pathInfo = new PathInfo(path);

            if (pathInfo.Path.IsNullOrEmpty())
            {
                throw new InvalidOperationException("An attempt was made to delete a container.  Containers can not be deleted via this API.");
            }
            this.AssertIsValidWabsUri(pathInfo);

            StorageSimulatorItem item = this.GetItem(pathInfo, true);
            if (item.IsNotNull() && item.Items.ContainsKey(pathInfo.PathParts[pathInfo.PathParts.Length - 1]))
            {
                item.Items.Remove(pathInfo.PathParts[pathInfo.PathParts.Length - 1]);
            }
        }

        public Task<bool> Exists(Uri path)
        {
            var pathInfo = new PathInfo(path);
            this.AssertIsValidWabsUri(pathInfo);

            StorageSimulatorItem result = this.GetItem(pathInfo);
            return Task.FromResult(result.IsNotNull());
        }

        public Task<IEnumerable<Uri>> List(Uri path, bool recursive)
        {
            var items = new List<Uri>();
            var queue = new Queue<StorageSimulatorItem>();
            var pathInfo = new PathInfo(path);
            this.AssertIsValidWabsUri(pathInfo);
            StorageSimulatorItem item = this.GetItem(pathInfo, pathInfo.Path.IsNullOrEmpty());
            if (item.IsNotNull())
            {
                queue.Enqueue(item);
                while (queue.Count > 0)
                {
                    item = queue.Remove();
                    queue.AddRange(item.Items.Values);
                    items.Add(item.Path);
                }
            }
            return Task.FromResult((IEnumerable<Uri>)items);
        }

        public Task<Stream> Read(Uri path)
        {
            var pathInfo = new PathInfo(path);
            this.AssertIsValidWabsUri(pathInfo);
            StorageSimulatorItem item = this.GetItem(pathInfo);
            if (item.IsNull())
            {
                throw new InvalidOperationException("Attempt to read an item that was not present in the container.");
            }
            Stream stream = Help.SafeCreate<MemoryStream>();
            stream.Write(item.Data, 0, item.Data.Length);
            stream.Position = 0;
            return Task.FromResult(stream);
        }

        public Task Write(Uri path, Stream stream)
        {
            var pathInfo = new PathInfo(path);
            if (pathInfo.Path.IsNullOrEmpty())
            {
                throw new InvalidOperationException("An attempt was made write but no path was provided.  Data can not be written without a path.");
            }
            this.AssertIsValidWabsUri(pathInfo);
            StorageSimulatorItem item = this.CreateTree(pathInfo);
            using (var mem = new MemoryStream())
            {
                stream.CopyTo(mem);
                item.Data = new byte[mem.Length];
                mem.Position = 0;
                mem.Read(item.Data, 0, item.Data.Length);
            }
            return Task.Delay(0);
        }

        public Task DownloadToFile(Uri path, string localFileName)
        {
            throw new NotImplementedException();
        }

        private void AssertIsValidWabsUri(PathInfo pathInfo)
        {
            if (!pathInfo.IsAbsolute || pathInfo.Protocol != Constants.WabsProtocol || pathInfo.Container.IsNullOrEmpty() ||
                pathInfo.Server.IsNullOrEmpty() || this.Account.Host != pathInfo.Server)
            {
                throw new InvalidOperationException(
                    "An attempt was made to access content from an invalid storage location or a location not relative to this account.");
            }
        }
    }
}
