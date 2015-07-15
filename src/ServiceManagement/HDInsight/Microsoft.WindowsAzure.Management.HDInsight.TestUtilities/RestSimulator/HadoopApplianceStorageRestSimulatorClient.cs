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
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization.Json;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.HadoopAppliance.Client;
    using Microsoft.HadoopAppliance.Client.HadoopStorageRestClient;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;

    internal class HadoopApplianceStorageRestSimulatorClient : StorageAbstractionSimulatorBase, IHadoopApplianceStorageRestClient
    {
        private static HadoopApplianceStorageRestSimulatorClient instance = null;
        protected ApplianceStorageSimulatorItem Root;
        private const short _replicationFactor = 2;

        /// <summary>
        ///     Credentials used.
        /// </summary>
        private StorageClientBasicAuthCredential credentials;

        private HadoopApplianceStorageRestSimulatorClient(IStorageClientCredential credentials, bool ignoreSslErrors)
        {
            this.credentials = (StorageClientBasicAuthCredential)credentials;
            Root = new ApplianceStorageSimulatorItem(this.credentials.Server);
        }

        public static HadoopApplianceStorageRestSimulatorClient GetInstance(IStorageClientCredential credentials, bool ignoreSslErrors)
        {
            if (instance.IsNull())
            {
                instance = new HadoopApplianceStorageRestSimulatorClient(credentials, ignoreSslErrors);
            }
            return instance;
        }

        /// <summary>
        ///     Create file and open it for write.
        /// </summary>
        /// <param name="path">The file name to create and open.</param>
        /// <param name="data">File content</param>
        /// <returns>Confirmation message and WebHDFS URI to file location</returns>
        public Task<IHttpResponseMessageAbstraction> Write(string path, Stream data)
        {
            return this.Write(path, data, false);
        }

        /// <summary>
        ///     Append to an existing file.
        /// </summary>
        /// <param name="path">The existing file to be appended.</param>
        /// <param name="data">Data to be appended</param>
        /// <returns>Confirmation message</returns>
        public Task<IHttpResponseMessageAbstraction> Append(string path, Stream data)
        {
            ApplianceStorageSimulatorItem file = this.GetItem(path);
            if (file.IsNotNull())
            {
                var byteData = file.Data.Concat(ReadToEnd(data)).ToArray();
                this.ChangeItemData(file, byteData);
                IHttpResponseMessageAbstraction response = new HttpResponseMessageAbstraction(HttpStatusCode.OK, null, String.Empty);
                return Task.FromResult(response);
            }
            else
            {
                throw new FileNotFoundException("File to be appended is not found");
            }
        }

        /// <summary>
        ///     Create file and open it for write.
        /// </summary>
        /// <param name="path">The file name to create and open.</param>
        /// <param name="data">File content</param>
        /// <param name="overwrite">Specifies if existing file should be overwritten.</param>
        /// <returns>Confirmation message and WebHDFS URI to file location</returns>
        public Task<IHttpResponseMessageAbstraction> Write(string path, Stream data, bool? overwrite)
        {
            ApplianceStorageSimulatorItem file = this.GetItem(path);

            if (!(overwrite.HasValue && overwrite.Value))
            {
                file = this.CreateTree(path);
            }
            file.Data = ReadToEnd(data);

            // TODO: This location is not presented in format webhdfs://<HOST>:<PORT>/<PATH> by only by relative <PATH>
            //
            var header = new HttpResponseHeadersAbstraction { { "Location", path } };
            IHttpResponseMessageAbstraction response = new HttpResponseMessageAbstraction(HttpStatusCode.Created, header, String.Empty);
            return Task.FromResult(response);
        }

        /// <summary>
        ///     Delete file
        /// </summary>
        /// <param name="path">The path to delete.</param>
        /// <param name="recursive">
        ///     If path is a directory and set to true, the directory is deleted else throws an exception. In
        ///     case of a file the recursive can be set to either true or false.
        /// </param>
        /// <returns>Confirmation message with 'true' in message content if delete is successful, else 'false'.</returns>
        public Task<IHttpResponseMessageAbstraction> Delete(string path, bool? recursive)
        {
            var pathInfo = new PathInfo(new Uri(this.credentials.Server, path));

            ApplianceStorageSimulatorItem item = this.GetItem(pathInfo, true);
            if (item.IsNotNull() && item.ChildItems.ContainsKey(pathInfo.PathParts[pathInfo.PathParts.Length - 1]))
            {
                item.ChildItems.Remove(pathInfo.PathParts[pathInfo.PathParts.Length - 1]);
            }
            this.UpdateParrentContentSummary(item);
            IHttpResponseMessageAbstraction response = new HttpResponseMessageAbstraction(HttpStatusCode.OK, null, "{\"boolean\": true}");
            return Task.FromResult(response);
        }

        /// <summary>
        ///     Return the content summary of a given path.
        /// </summary>
        /// <param name="path">Path to file/directory.</param>
        /// <returns>Content summary of given path</returns>
        public Task<IHttpResponseMessageAbstraction> GetContentSummary(string path)
        {
            ApplianceStorageSimulatorItem file = this.GetItem(path);
            if (file.IsNotNull())
            {
                var result = new ContentSummaryContainer() { Summary = file.ContentSummary };
                IHttpResponseMessageAbstraction response = new HttpResponseMessageAbstraction(
                    HttpStatusCode.OK,
                    null,
                    this.ConvertToJson(result));
                return Task.FromResult(response);
            }
            else
            {
                throw new FileNotFoundException("File cannot be found.");
            }
        }

        /// <summary>
        ///     Return a file status data above given path.
        /// </summary>
        /// <param name="path">The path we want information from.</param>
        /// <returns>File status for given path</returns>
        public Task<IHttpResponseMessageAbstraction> GetFileStatus(string path)
        {
            ApplianceStorageSimulatorItem file = this.GetItem(path);
            if (file.IsNotNull())
            {
                var result = new DirectoryEntryContainer() { Entry = file.FileStatus };
                IHttpResponseMessageAbstraction response = new HttpResponseMessageAbstraction(
                    HttpStatusCode.OK,
                    null,
                    this.ConvertToJson(result));
                return Task.FromResult(response);
            }
            else
            {
                throw new FileNotFoundException("File cannot be found.");
            }
        }

        /// <summary>
        ///     Return the current user's home directory in this file system. The default implementation returns "/user/$USER/".
        /// </summary>
        /// <returns>Current home directory</returns>
        public Task<IHttpResponseMessageAbstraction> GetHomeDirectory()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     List the statuses of the files/directories in the given path if the path is a directory.
        /// </summary>
        /// <param name="path">Path to directory</param>
        /// <returns>
        ///     The statuses of the files/directories in the given path returns null, if path does not exist in the file
        ///     system
        /// </returns>
        public Task<IHttpResponseMessageAbstraction> ListStatus(string path)
        {
            ApplianceStorageSimulatorItem file = this.GetItem(path);
            if (file.IsNotNull())
            {
                var allStatuses = new DirectoryListing();
                var statuses = new List<DirectoryEntry>();

                foreach (ApplianceStorageSimulatorItem fileDetails in file.ChildItems.Values)
                {
                    statuses.Add(fileDetails.FileStatus);
                }
                allStatuses.Entries = statuses;
                var result = new DirectoryListingContainer() { Listing = allStatuses };
                IHttpResponseMessageAbstraction response = new HttpResponseMessageAbstraction(
                    HttpStatusCode.OK,
                    null,
                    this.ConvertToJson(result));
                return Task.FromResult(response);
            }
            throw new FileNotFoundException("File cannot be found.");
        }

        /// <summary>
        ///     Make the given file and all non-existent parents into directories. Has the semantics of Unix 'mkdir -p'. Existence
        ///     of the directory hierarchy is not an error.
        /// </summary>
        /// <param name="path">Path to directory</param>
        /// <returns>Confirmation message with success indicator flag.</returns>
        public Task<IHttpResponseMessageAbstraction> CreateDirectory(string path)
        {
            ApplianceStorageSimulatorItem file = this.GetItem(path);
            string message;
            if (file.IsNotNull())
            {
                message = "{\"boolean\": false}";
            }
            else
            {
                file = this.CreateTree(path, DirectoryEntryType.DIRECTORY);
                ApplianceStorageSimulatorItem parent = GetItem(path, true);
                this.UpdateParrentContentSummary(parent);
                message = "{\"boolean\": true}";
            }
            IHttpResponseMessageAbstraction response = new HttpResponseMessageAbstraction(HttpStatusCode.OK, null, message);
            return Task.FromResult(response);
        }

        /// <summary>
        ///     Opens data stream at indicated path.
        /// </summary>
        /// <param name="path">File name to open.</param>
        /// <param name="offset">The starting byte position.</param>
        /// <param name="length">The number of bytes to be processed. Null means entire file</param>
        /// <param name="buffersize">The size of the buffer to be used. NOT SIMULATED</param>
        /// <returns>Redirected exact location of chosen file</returns>
        public Task<IHttpResponseMessageAbstraction> Read(string path, long? offset, long? length, int? buffersize)
        {
            ApplianceStorageSimulatorItem file = this.GetItem(path);
            if (file.IsNotNull())
            {
                if (offset.IsNull())
                {
                    offset = 0;
                }
                if (length.IsNull())
                {
                    length = file.Data.Length;
                }
                using (var ms = new MemoryStream(file.Data, (int)offset, (int)length))
                {
                    using (var sr = new StreamReader(ms))
                    {
                        IHttpResponseMessageAbstraction response = new HttpResponseMessageAbstraction(HttpStatusCode.OK, null, sr.ReadToEnd());
                        return Task.FromResult(response);
                    }
                }
            }
            throw new FileNotFoundException("File cannot be found.");
        }

        /// <summary>
        ///     Rename file
        /// </summary>
        /// <param name="path">Source path</param>
        /// <param name="destination">Destination path</param>
        /// <returns>Confirmation message with success indicator flag.</returns>
        public Task<IHttpResponseMessageAbstraction> Rename(string path, string destination)
        {
            PathInfo sourcePathInfo = new PathInfo(new Uri(this.credentials.Server, path));
            ApplianceStorageSimulatorItem sourceFile = this.GetItem(sourcePathInfo);
            string message = String.Empty;
            if (sourceFile.IsNotNull())
            {
                PathInfo destinationPathInfo = new PathInfo(new Uri(this.credentials.Server, destination));
                ApplianceStorageSimulatorItem destinationFile = this.CreateTree(destinationPathInfo, sourceFile.FileStatus.EntryType);
                ApplianceStorageSimulatorItem destinationFileParent = GetItem(destinationPathInfo, true);
                sourceFile.FileStatus.PathSuffix = destinationFile.FileStatus.PathSuffix;
                destinationFileParent.ChildItems[destinationPathInfo.PathParts.Last()] = sourceFile;
                ApplianceStorageSimulatorItem sourceFileParent = this.GetItem(sourcePathInfo, true);
                sourceFileParent.ChildItems.Remove(sourcePathInfo.PathParts.Last());
                this.UpdateParrentContentSummary(sourceFileParent);
                this.UpdateParrentContentSummary(destinationFileParent);
                message = "{\"boolean\": true}";
            }
            else
            {
                message = "{\"boolean\": false}";
            }
            IHttpResponseMessageAbstraction response = new HttpResponseMessageAbstraction(HttpStatusCode.OK, null, message);
            return Task.FromResult(response);
        }

        /// <summary>
        ///     Checks whether given path exists in the file system.
        /// </summary>
        /// <param name="path">Path to check.</param>
        /// <returns>True if the given path exists in the file system, otherwise false.</returns>
        public Task<IHttpResponseMessageAbstraction> Exists(string path)
        {
            var item = this.GetItem(path);
            IHttpResponseMessageAbstraction response;
            if (item.IsNotNull())
            {
                response = new HttpResponseMessageAbstraction(HttpStatusCode.OK, null, "{boolean:true}");
            }
            else
            {
                response = new HttpResponseMessageAbstraction(HttpStatusCode.NotFound, null, "{boolean:false}");
            }
            return Task.FromResult(response);
        }

        /// <summary>
        ///     Set owner of a path (i.e. a file or a directory). The parameters owner and group cannot both be null.
        /// </summary>
        /// <param name="path">Path to file/directory</param>
        /// <param name="owner">New owner of file. If it is null, the original owner name remains unchanged.</param>
        /// <param name="group">New group owner of file. If it is null, the original group name remains unchanged.</param>
        /// <returns>Confirmation message</returns>
        public Task<IHttpResponseMessageAbstraction> SetOwner(string path, string owner, string group)
        {
            ApplianceStorageSimulatorItem file = this.GetItem(path);
            if (file.IsNotNull())
            {
                if (owner.IsNotNullOrEmpty())
                {
                    file.FileStatus.Owner = owner;
                }
                if (group.IsNotNullOrEmpty())
                {
                    file.FileStatus.Group = group;
                }
                IHttpResponseMessageAbstraction response = new HttpResponseMessageAbstraction(HttpStatusCode.OK, null, String.Empty);
                return Task.FromResult(response);
            }
            throw new FileNotFoundException("File cannot be found.");
        }

        /// <summary>
        ///     Set permission of a path.
        /// </summary>
        /// <param name="path">Path to file/directory.</param>
        /// <param name="permission">The permission of a file/directory in OCTAL format.</param>
        /// <returns>Confirmation message</returns>
        public Task<IHttpResponseMessageAbstraction> SetPermission(string path, string permission)
        {
            ApplianceStorageSimulatorItem file = this.GetItem(path);
            if (file.IsNotNull())
            {
                file.FileStatus.Permission = permission;
                IHttpResponseMessageAbstraction response = new HttpResponseMessageAbstraction(HttpStatusCode.OK, null, String.Empty);
                return Task.FromResult(response);
            }
            throw new FileNotFoundException("File cannot be found.");
        }

        /// <summary>
        ///     Set replication for an existing file.
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="replication">New replication factor</param>
        /// <returns>Confirmation message with success indicator flag.</returns>
        public Task<IHttpResponseMessageAbstraction> SetReplication(string path, short replication)
        {
            ApplianceStorageSimulatorItem file = this.GetItem(path);
            string message;
            if (file.IsNotNull())
            {
                if (file.FileStatus.EntryType == DirectoryEntryType.FILE)
                {
                    file.FileStatus.Replication = replication;
                    message = "{\"boolean\": true}";
                }
                else
                {
                    message = "{\"boolean\": false}";
                }
            }
            else
            {
                message = "{\"boolean\": false}";
            }
            IHttpResponseMessageAbstraction response = new HttpResponseMessageAbstraction(HttpStatusCode.OK, null, message);
            return Task.FromResult(response);
        }

        /// <summary>
        ///     Create file/folder along with its containing folders
        /// </summary>
        /// <param name="pathInfo">Path to the file/folder</param>
        /// <param name="itemType">File or folder</param>
        /// <returns></returns>
        protected ApplianceStorageSimulatorItem CreateTree(PathInfo pathInfo, DirectoryEntryType itemType = DirectoryEntryType.FILE)
        {
            ApplianceStorageSimulatorItem dir = this.Root;
            ApplianceStorageSimulatorItem child = this.Root;
            var currentUri = this.credentials.Server;

            foreach (string pathPart in pathInfo.PathParts)
            {
                string uri = this.FixUriEnding(currentUri);
                currentUri = new Uri(uri + "/" + pathPart);
                if (!dir.ChildItems.TryGetValue(pathPart, out child))
                {
                    child = new ApplianceStorageSimulatorItem(currentUri);
                    child.FileStatus.PathSuffix = pathPart;
                    if (pathPart == pathInfo.PathParts[pathInfo.PathParts.Length - 1])
                    {
                        child.FileStatus.EntryType = itemType;
                        child.FileStatus.Replication = _replicationFactor;
                        child.ContentSummary.FileCount = 1;
                    }
                    else
                    {
                        child.FileStatus.EntryType = DirectoryEntryType.DIRECTORY;
                        child.ContentSummary.DirectoryCount = 1;
                    }
                    dir.ChildItems.Add(pathPart, child);
                    dir = child;
                }
                else
                {
                    dir = child;
                }
            }
            this.UpdateParrentContentSummary(GetItem(pathInfo, true));
            return dir;
        }

        /// <summary>
        ///     Get file/folder item
        /// </summary>
        /// <param name="pathInfo">Path to file/folder</param>
        /// <param name="parent">Search for parent of target file/folder</param>
        /// <returns>Choosen file/folder</returns>
        protected ApplianceStorageSimulatorItem GetItem(PathInfo pathInfo, bool parent = false)
        {
            ApplianceStorageSimulatorItem dir = this.Root;

            string[] pathParts = pathInfo.PathParts;
            if (parent)
            {
                if (pathParts.Length > 0)
                {
                    pathParts = pathParts.Take(pathParts.Length - 1).ToArray();
                }
            }

            if (pathParts.Length == 0)
            {
                return dir;
            }

            int loc = 0;
            while (dir.IsNotNull() && dir.ChildItems.TryGetValue(pathParts[loc], out dir) && loc < pathParts.Length)
            {
                if (loc == pathParts.Length - 1)
                {
                    return dir;
                }
                if (dir.IsNull())
                {
                    return null;
                }
                loc++;
            }
            return null;
        }

        private static byte[] ReadToEnd(Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                var readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            var temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }

        /// <summary>
        ///     Change content of HDFS file
        /// </summary>
        /// <param name="item">HDFS file</param>
        /// <param name="data"></param>
        private void ChangeItemData(ApplianceStorageSimulatorItem item, byte[] data)
        {
            item.Data = data;
            ApplianceStorageSimulatorItem parent = this.GetItem(new PathInfo(item.Path), true);
            this.UpdateParrentContentSummary(parent);
        }

        /// <summary>
        /// Convert serializable object to JSON
        /// </summary>
        /// <param name="serializable">Seriazable object</param>
        /// <returns></returns>
        private string ConvertToJson(object serializable)
        {
            using (var stream = new MemoryStream())
            {
                var jsonSerializer = new DataContractJsonSerializer(serializable.GetType());
                jsonSerializer.WriteObject(stream, serializable);
                stream.Position = 0;
                var reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
        }

        private ApplianceStorageSimulatorItem CreateTree(string path, DirectoryEntryType itemType = DirectoryEntryType.FILE)
        {
            return this.CreateTree(new PathInfo(new Uri(this.credentials.Server, path)), itemType);
        }

        private ApplianceStorageSimulatorItem GetItem(string path, bool parent = false)
        {
            return this.GetItem(new PathInfo(new Uri(this.credentials.Server, path)), parent);
        }

        /// <summary>
        ///     Update content summary of parent folders when some file is changed
        /// </summary>
        /// <param name="parent">Folder where file has changed</param>
        private void UpdateParrentContentSummary(ApplianceStorageSimulatorItem parent)
        {
            do
            {
                Assert.AreEqual(DirectoryEntryType.DIRECTORY, parent.FileStatus.EntryType);
                parent.ContentSummary.DirectoryCount = 1;
                parent.ContentSummary.FileCount = 0;
                parent.ContentSummary.Length = 0;
                parent.ContentSummary.SpaceConsumed = 0;
                foreach (KeyValuePair<string, ApplianceStorageSimulatorItem> child in parent.ChildItems)
                {
                    if (child.Value.FileStatus.EntryType == DirectoryEntryType.DIRECTORY)
                    {
                        parent.ContentSummary.DirectoryCount++;
                    }
                    else
                    {
                        parent.ContentSummary.FileCount++;
                    }

                    parent.ContentSummary.Length += child.Value.ContentSummary.Length;
                    parent.ContentSummary.SpaceConsumed += child.Value.ContentSummary.SpaceConsumed;
                }
                parent = this.GetItem(new PathInfo(parent.Path), true);
            }
            while (parent != this.Root);
        }

        protected class ApplianceStorageSimulatorItem : StorageSimulatorItemBase
        {
            internal IDictionary<string, ApplianceStorageSimulatorItem> ChildItems;
            private byte[] data;

            public ApplianceStorageSimulatorItem(Uri path)
            {
                this.Path = path;
                this.ContentSummary = new ContentSummary
                {
                    DirectoryCount = 0,
                    FileCount = 0,
                    Length = 0,
                    Quota = -1,
                    SpaceConsumed = 0,
                    SpaceQuota = -1
                };

                this.FileStatus = new DirectoryEntry();
                this.FileStatus.BlockSize = 0;
                this.FileStatus.Length = 0;
                this.FileStatus.Permission = "755";
                this.FileStatus.Replication = 1;
                this.FileStatus.EntryType = DirectoryEntryType.DIRECTORY;
                
                this.ChildItems = new Dictionary<string, ApplianceStorageSimulatorItem>();
            }

            internal ContentSummary ContentSummary { get; private set; }

            internal byte[] Data
            {
                get
                {
                    this.FileStatus.AccessTime = (long)(DateTime.Now - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
                    return this.data;
                }
                set
                {
                    this.data = value;
                    this.ContentSummary.Length = this.data.Length;
                    this.ContentSummary.SpaceConsumed = this.data.Length * this.FileStatus.Replication;
                    var currentTime = (long)(DateTime.Now - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
                    this.FileStatus.AccessTime = currentTime;
                    this.FileStatus.ModificationTime = currentTime;
                    this.FileStatus.Length = this.data.Length;
                }
            }

            internal DirectoryEntry FileStatus { get; set; }
            internal Uri Path { get; private set; }
        }

        protected new class PathInfo
        {
            public PathInfo(Uri path)
            {
                this.IsAbsolute = path.IsAbsoluteUri;
                this.Path = string.Empty;
                this.PathParts = new string[0];
                string localPath = path.LocalPath;
                if (path.LocalPath.StartsWith("/") && path.LocalPath.IsNotNullOrEmpty())
                {
                    localPath = path.LocalPath.Substring(1);
                }
                if (path.LocalPath.EndsWith("/"))
                {
                    localPath = path.LocalPath.Substring(0, path.LocalPath.Length - 1);
                }
                if (localPath.IsNotNullOrEmpty())
                {
                    this.Path = localPath;
                    this.PathParts = this.Path.Split('/');
                }
            }

            public bool IsAbsolute { get; private set; }
            public string Path { get; private set; }
            public string[] PathParts { get; private set; }
        }
    }
}
