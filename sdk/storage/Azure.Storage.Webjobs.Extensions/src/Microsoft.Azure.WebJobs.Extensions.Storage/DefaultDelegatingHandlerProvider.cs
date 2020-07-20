// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using Microsoft.Azure.WebJobs.Storage;
using Microsoft.Azure.WebJobs.Storage.Common;

namespace Microsoft.Azure.WebJobs.Extensions.Storage
{
    internal class DefaultDelegatingHandlerProvider : IDelegatingHandlerProvider
    {
        public DelegatingHandler Create()
        {
            return CommonUtility.IsDynamicSku ? new WebJobsStorageDelegatingHandler() : null;
        }
    }
}
