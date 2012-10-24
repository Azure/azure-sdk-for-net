//-----------------------------------------------------------------------
// <copyright file="RESTCommand.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Core.Executor
{
    using Microsoft.WindowsAzure.Storage.Auth;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

#if RT
using System.Net.Http;
using System.Threading.Tasks;
#else
    using System.Net;
#endif

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
    internal class RESTCommand<T> : StorageCommandBase<T>
    {
        #region Ctors
        public RESTCommand(StorageCredentials credentials, Uri uri)
            : this(credentials, uri, null)
        {
        }

        public RESTCommand(StorageCredentials credentials, Uri uri, UriQueryBuilder builder)
        {
            this.Uri = credentials.TransformUri(uri);
            this.Builder = builder;
        }
        #endregion    

        // Reference to hold stream from webresponse
        public Stream ResponseStream = null;

        // Stream to potentially copy response into
        public Stream DestinationStream = null;

        // if true, the inStream will be set before processresponse is called.
        public bool RetrieveResponseStream = false;

        // if true the executor will calculate the md5 on retrieved data
        public bool CalculateMd5ForResponseStream = false;

#if RT
        public Func<RESTCommand<T>, OperationContext, HttpClient> BuildClient;

        public Func<RESTCommand<T>, OperationContext, HttpContent> BuildContent;

        public Func<RESTCommand<T>, HttpContent, OperationContext, HttpRequestMessage> BuildRequest;

        // Pre-Stream Retrival func (i.e. if 409 no stream is retrieved), in some cases this method will return directly
        public Func<RESTCommand<T>, HttpResponseMessage, Exception, OperationContext, T> PreProcessResponse;

        // Post-Stream Retrieval Func ( if retreiveStream is true after ProcessResponse, the stream is retrieved and then PostProcess is called
        public Func<RESTCommand<T>, HttpResponseMessage, Exception, OperationContext, Task<T>> PostProcessResponse;
#else
        // Stream to send to server
        public Stream SendStream = null;

        // Func to construct the request
        public Func<Uri, UriQueryBuilder, int?, OperationContext, HttpWebRequest> BuildRequestDelegate = null;

        // Delegate to Set custom headers
        public Action<HttpWebRequest, OperationContext> SetHeaders = null;

        // Delegate to Sign headers - note this is important that it doesnt have a type dependency on StorageCredentials here
        // due to build issues and WinRT restrictions.  
        public Action<HttpWebRequest, OperationContext> SignRequest = null;

        // Pre-Stream Retrival func (i.e. if 409 no stream is retrieved), in some cases this method will return directly
        public Func<RESTCommand<T>, HttpWebResponse, Exception, OperationContext, T> PreProcessResponse = null;

        // Post-Stream Retrieval Func ( if retreiveStream is true after ProcessResponse, the stream is retrieved and then PostProcess is called
        public Func<RESTCommand<T>, HttpWebResponse, Exception, OperationContext, T> PostProcessResponse = null;
#endif
    }
}
