// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Data.Batch.Models
{
    public class BaseHeaders
    {
        internal Response Response { get; set; }

        public BaseHeaders()
        {
        }

        public BaseHeaders(Response response)
        {
            Response = response;
        }

        public Guid? ClientRequestId => Response.Headers.TryGetValue("client-request-id", out Guid? value) ? value : null;
        public Guid? RequestId => Response.Headers.TryGetValue("request-id", out Guid? value) ? value : null;
        public DateTimeOffset? LastModified => Response.Headers.TryGetValue("Last-Modified", out DateTimeOffset? value) ? value : null;
        public string DataServiceId => Response.Headers.TryGetValue("DataServiceId", out string value) ? value : null;
    }
}
