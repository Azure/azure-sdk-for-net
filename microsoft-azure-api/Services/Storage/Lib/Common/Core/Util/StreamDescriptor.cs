//-----------------------------------------------------------------------
// <copyright file="StreamDescriptor.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    using System.Threading;

    /// <summary>
    /// Provides properties to keep track of Md5 / Length of a stream as it is being copied.
    /// </summary>
    internal class StreamDescriptor
    {
        private long length = 0;

        public long Length
        {
            get { return Interlocked.Read(ref this.length); }
            set { Interlocked.Exchange(ref this.length, value); }
        }

        private volatile string md5 = null;

        public string Md5
        {
            get { return this.md5; }
            set { this.md5 = value; }
        }

        private volatile MD5Wrapper md5HashRef = null;

        public MD5Wrapper Md5HashRef
        {
            get { return this.md5HashRef; }
            set { this.md5HashRef = value; }
        }
    }
}
