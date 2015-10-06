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
    using System.Linq;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    internal abstract class StorageAbstractionSimulatorBase
    {
        protected class PathInfo
        {
            public PathInfo(Uri path)
            {
                this.Protocol = path.Scheme;
                this.Server = path.Host;
                this.Container = path.UserInfo;
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

            public string Container { get; private set; }
            public bool IsAbsolute { get; private set; }
            public string Path { get; private set; }
            public string[] PathParts { get; private set; }
            public string Protocol { get; private set; }
            public string Server { get; private set; }
        }

        protected abstract class StorageSimulatorItemBase
        {

        }

        protected string FixUriEnding(Uri uri)
        {
            string asString = uri.ToString();
            if (asString.EndsWith("/"))
            {
                asString = asString.Substring(0, asString.Length - 1);
            }
            return asString;
        }
    }

    internal class StorageAbstractionSimulator : StorageAbstractionSimulatorBase
    {
        protected string ChosenProtocol;
        protected string ChosenProtocolScheme;
        protected StorageSimulatorItem Root;
        protected string RootPath;

        internal Uri Account
        {
            get
            {
                string rootPath = this.RootPath;
                if (!rootPath.Contains("://") && !rootPath.StartsWith(this.ChosenProtocol))
                {
                    rootPath = string.Format("{0}://{1}", this.ChosenProtocol, rootPath);
                }

                return new Uri(rootPath);
            }
        }

        protected StorageSimulatorItem CreateTree(PathInfo pathInfo)
        {
            StorageSimulatorItem dir = this.Root;
            StorageSimulatorItem child = this.Root;
            var currentUri = new Uri(string.Format("{0}{1}@{2}", this.ChosenProtocolScheme, pathInfo.Container, this.Account.Host));
            if (!dir.Items.TryGetValue(pathInfo.Container, out dir))
            {
                string containerUri = currentUri.Scheme + "://" + pathInfo.Container + "@" + currentUri.Host;
                dir = new StorageSimulatorItem(new Uri(containerUri), pathInfo.Container);
                this.Root.Items.Add(pathInfo.Container, dir);
            }
            foreach (string pathPart in pathInfo.PathParts)
            {
                string uri = this.FixUriEnding(currentUri);
                currentUri = new Uri(uri + "/" + pathPart);
                if (!dir.Items.TryGetValue(pathPart, out child))
                {
                    child = new StorageSimulatorItem(currentUri, pathPart);
                    dir.Items.Add(pathPart, child);
                    dir = child;
                }
                else
                {
                    dir = child;
                }
            }
            return dir;
        }

        protected StorageSimulatorItem GetItem(PathInfo pathInfo, bool parent = false)
        {
            StorageSimulatorItem dir = this.Root;
            this.Root.Items.TryGetValue(pathInfo.Container, out dir);

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
            while (dir.IsNotNull() && dir.Items.TryGetValue(pathParts[loc], out dir) && loc < pathParts.Length)
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

        

        protected class StorageSimulatorItem : StorageSimulatorItemBase
        {
            internal StorageSimulatorItem(Uri path, string Name)
            {
                this.Path = path;
                this.Name = Name;
                this.Items = new Dictionary<string, StorageSimulatorItem>();
            }

            internal byte[] Data { get; set; }
            internal IDictionary<string, StorageSimulatorItem> Items { get; private set; }
            internal string Name { get; private set; }
            internal Uri Path { get; private set; }

            //internal bool TryGetChildItem(string key, out StorageSimulatorItem value)
            //{
            //    return ChildItems.TryGetValue(key, out value);
            //}

            //internal virtual void AddChildItem(string key, StorageSimulatorItem value)
            //{
            //    this.ChildItems.Add(key, value);
            //}

            //internal bool ContainsChildItemKey(string key)
            //{
            //    return this.ChildItems.ContainsKey(key);
            //}

            //internal virtual void RemoveChildItem(string key)
            //{
            //    this.ChildItems.Remove(key);
            //}

            //internal ICollection<StorageSimulatorItem> GetChildItems()
            //{
            //    return this.ChildItems.Values;
            //}
        }
    }
}
