// -----------------------------------------------------------------------------------------
// <copyright file="HttpResponseParsersBase.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Xml;

#if !COMMON
    using System.Xml.Linq;
#endif

    internal static partial class HttpResponseParsers
    {
        internal static T ProcessExpectedStatusCodeNoException<T>(HttpStatusCode expectedStatusCode, HttpStatusCode actualStatusCode, T retVal, StorageCommandBase<T> cmd, Exception ex, OperationContext operationContext)
        {
            if (ex != null)
            {
                throw ex;
            }

            if (actualStatusCode != expectedStatusCode)
            {
                throw new StorageException(cmd.CurrentResult, string.Format(SR.UnexpectedResponseCode, expectedStatusCode, actualStatusCode), null);
            }

            return retVal;
        }

        internal static T ProcessExpectedStatusCodeNoException<T>(HttpStatusCode[] expectedStatusCodes, HttpStatusCode actualStatusCode, T retVal, StorageCommandBase<T> cmd, Exception ex, OperationContext operationContext)
        {
            if (ex != null)
            {
                throw ex;
            }

            bool foundExpectedStatusCode = false;
            foreach (var expectedStatusCode in expectedStatusCodes)
            {
                if (actualStatusCode == expectedStatusCode)
                {
                    foundExpectedStatusCode = true;
                    break;
                }
            }

            if (!foundExpectedStatusCode)
            {
                throw new StorageException(cmd.CurrentResult, SR.UnexpectedResponseCode, null);
            }

            return retVal;
        }

        internal static void ValidateResponseStreamMd5AndLength<T>(long? length, string md5, StorageCommandBase<T> cmd, StreamDescriptor streamCopyState)
        {
            if (streamCopyState == null)
            {
                throw new StorageException(
                    cmd.CurrentResult,
                    SR.ContentMD5NotCalculated,
                    null)
                {
                    IsRetryable = false
                };
            }

            if (streamCopyState.Length != length)
            {
                throw new StorageException(
                    cmd.CurrentResult,
                    string.Format(SR.BlobDataCorruptedIncorrectNumberOfBytes, streamCopyState.Length, length),
                    null)
                    {
                        IsRetryable = false
                    };
            }

            if (md5 != null && streamCopyState.Md5 != null && streamCopyState.Md5 != md5)
            {
                throw new StorageException(cmd.CurrentResult, SR.MD5MismatchError, null) { IsRetryable = false };
            }
        }

#if !COMMON
        /// <summary>
        /// Reads service properties from a stream.
        /// </summary>
        /// <param name="inputStream">The stream from which to read the service properties.</param>
        /// <returns>The service properties stored in the stream.</returns>
        internal static ServiceProperties ReadServiceProperties(Stream inputStream)
        {
            using (XmlReader reader = XmlReader.Create(inputStream))
            {
                XDocument servicePropertyDocument = XDocument.Load(reader);

                return ServiceProperties.FromServiceXml(servicePropertyDocument);
            }
        }
#endif

        /// <summary>
        /// Reads a collection of shared access policies from the specified <see cref="AccessPolicyResponseBase&lt;T&gt;"/> object.
        /// </summary>
        /// <param name="sharedAccessPolicies">A collection of shared access policies to be filled.</param>
        /// <param name="policyResponse">A policy response object for reading the stream.</param>
        /// <typeparam name="T">The type of policy to read.</typeparam>
        internal static void ReadSharedAccessIdentifiers<T>(IDictionary<string, T> sharedAccessPolicies, AccessPolicyResponseBase<T> policyResponse)
            where T : new()
        {
            foreach (KeyValuePair<string, T> pair in policyResponse.AccessIdentifiers)
            {
                sharedAccessPolicies.Add(pair.Key, pair.Value);
            }
        }
    }
}
