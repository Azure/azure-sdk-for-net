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
    /// <summary>
    /// Provides properties to keep track of Md5 / Length of a stream as it is being copied.
    /// </summary>
    internal class StreamDescriptor
    {
        public long Length { get; set; }

        public string Md5 { get; set; }

        public MD5Wrapper Md5HashRef { get; set; }
    }
}
