// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.WebPubSub;

namespace Microsoft.Azure.WebJobs.Samples
{
    #region Snippet:WebPubSubConnectionBindingFunction
    public static class WebPubSubConnectionBindingFunction
    {
        [FunctionName("WebPubSubConnectionBindingFunction")]
        public static WebPubSubConnection Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req,
            [WebPubSubConnection(Hub = "hub", UserId = "{query.userid}", Connection = "<connection-string>")] WebPubSubConnection connection)
        {
            Console.WriteLine("login");
            return connection;
        }
    }
    #endregion
}
