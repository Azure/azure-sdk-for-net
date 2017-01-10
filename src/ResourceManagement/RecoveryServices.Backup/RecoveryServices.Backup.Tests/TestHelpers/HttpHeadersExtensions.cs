//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Linq;
using System.Net.Http.Headers;

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Tests
{
    public static class HttpHeadersExtensions
    {
        public static Uri GetAzureAsyncOperationHeader(this HttpResponseHeaders headers)
        {
            var asyncHeader = headers.GetValues("Azure-AsyncOperation").FirstOrDefault();
            return new Uri(asyncHeader);
        }

        public static string GetAzureAsyncOperationId(this HttpResponseHeaders headers)
        {
            var asyncHeader = headers.GetAzureAsyncOperationHeader();
            return asyncHeader.Segments.Last();
        }
    }
}
