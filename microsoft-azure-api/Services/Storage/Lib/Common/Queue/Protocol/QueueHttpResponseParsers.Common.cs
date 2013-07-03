// -----------------------------------------------------------------------------------------
// <copyright file="QueueHttpResponseParsers.Common.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Queue.Protocol
{
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System.IO;

#if WINDOWS_RT
    internal
#else
    public
#endif
        static partial class QueueHttpResponseParsers
    {
        /// <summary>
        /// Reads service properties from a stream.
        /// </summary>
        /// <param name="inputStream">The stream from which to read the service properties.</param>
        /// <returns>The service properties stored in the stream.</returns>
        public static ServiceProperties ReadServiceProperties(Stream inputStream)
        {
            return HttpResponseParsers.ReadServiceProperties(inputStream);
        }

        /// <summary>
        /// Reads the share access policies from a stream in XML.
        /// </summary>
        /// <param name="inputStream">The stream of XML policies.</param>
        /// <param name="permissions">The permissions object to which the policies are to be written.</param>
        public static void ReadSharedAccessIdentifiers(Stream inputStream, QueuePermissions permissions)
        {
            CommonUtility.AssertNotNull("permissions", permissions);

            Response.ReadSharedAccessIdentifiers(permissions.SharedAccessPolicies, new QueueAccessPolicyResponse(inputStream));
        }
    }
}
