//-----------------------------------------------------------------------
// <copyright file="StorageCommandBase.cs" company="Microsoft">
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
    using System;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

#if RT
    using System.Net.Http;
#endif
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
    internal abstract class StorageCommandBase<T>
    {
        public Uri Uri;

        // The UriQueryBuilder used to create the request
        public UriQueryBuilder Builder;

        // Server Timeout to send
        public int? ServerTimeoutInSeconds = null;

        // Max client timeout, enforced over entire operation on client side
        public TimeSpan? ClientMaxTimeout = null;

        // State- different than async state, this is used for ops to communicate state between invocations, i.e. bytes downloaded etc
        internal object OperationState = null;

        // Used to keep track of Md5 / Length of a stream as it is being copied
        private volatile StreamDescriptor streamCopyState = null;

        internal StreamDescriptor StreamCopyState
        {
            get { return this.streamCopyState; }
            set { this.streamCopyState = value; }
        }

        private volatile RequestResult currentResult = null;

        internal RequestResult CurrentResult
        {
            get { return this.currentResult; }
            set { this.currentResult = value; }
        }

#if RT
        public HttpClientHandler Handler = null;
#endif

        // Delegate that will be executed in the event of an Exception after signing
        public Action<StorageCommandBase<T>, Exception, OperationContext> RecoveryAction = null;

        internal void ApplyRequestOptions(IRequestOptions options)
        {
            if (options.ServerTimeout.HasValue)
            {
                this.ServerTimeoutInSeconds = (int)options.ServerTimeout.Value.TotalSeconds;
            }

            if (options.MaximumExecutionTime.HasValue)
            {
                this.ClientMaxTimeout = options.MaximumExecutionTime.HasValue ? options.MaximumExecutionTime.Value : Constants.MaximumAllowedTimeout;
            }
        }
    }
}
