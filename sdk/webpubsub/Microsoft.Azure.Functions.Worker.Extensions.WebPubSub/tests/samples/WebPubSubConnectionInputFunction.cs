// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace SampleApp;

public static class WebPubSubConnectionInputFunction
{
    #region Snippet:WebPubSubConnectionInputFunction
    [Function("Negotiate")]
    public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequestData req,
    [WebPubSubConnectionInput(Hub = "<web_pubsub_hub>", Connection = "<web_pubsub_connection_name>")] WebPubSubConnection connectionInfo)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.WriteAsJsonAsync(connectionInfo);
        return response;
    }
    #endregion
}