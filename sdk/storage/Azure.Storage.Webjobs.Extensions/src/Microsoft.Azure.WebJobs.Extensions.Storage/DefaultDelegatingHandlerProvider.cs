// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
