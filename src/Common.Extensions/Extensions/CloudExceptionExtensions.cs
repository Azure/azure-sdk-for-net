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

using Hyak.Common;
using System.Linq;

namespace Microsoft.Azure.Common
{
    public static class CloudExceptionExtensions
    {
        public static string GetRequestId(this CloudException exception)
        {
            if(exception == null || 
               exception.Response == null || 
               exception.Response.Headers == null ||
               !exception.Response.Headers.Keys.Contains("x-ms-request-id"))
            {
                return null;
            }

            return exception.Response.Headers["x-ms-request-id"].FirstOrDefault();

        }
        public static string GetRoutingRequestId(this CloudException exception)
        {
            if (exception == null ||
               exception.Response == null ||
               exception.Response.Headers == null ||
               !exception.Response.Headers.Keys.Contains("x-ms-routing-request-id"))
            {
                return null;
            }

            return exception.Response.Headers["x-ms-routing-request-id"].FirstOrDefault();

        }
    }
}
