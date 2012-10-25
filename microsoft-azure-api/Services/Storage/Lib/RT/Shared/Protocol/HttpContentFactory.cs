// -----------------------------------------------------------------------------------------
// <copyright file="HttpContentFactory.cs" company="Microsoft">
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Shared.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;

    internal class HttpContentFactory
    {
        public static HttpContent BuildContentFromStream<T>(Stream stream, long offset, long? length, string md5, StorageCommandBase<T> cmd, OperationContext operationContext)
        {
            stream.Seek(offset, SeekOrigin.Begin);
            HttpContent retContent = new RetryableStreamContent(stream);
            retContent.Headers.ContentLength = length;
            if (md5 != null)
            {
                retContent.Headers.ContentMD5 = Convert.FromBase64String(md5);
            }

            return retContent;
        }
    }
}
