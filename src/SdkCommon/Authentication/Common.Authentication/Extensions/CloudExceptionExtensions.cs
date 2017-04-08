// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
