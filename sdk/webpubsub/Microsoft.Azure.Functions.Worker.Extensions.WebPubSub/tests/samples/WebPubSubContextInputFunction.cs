// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace SampleApp;

internal class WebPubSubContextInputFunction
{
    [Function("connect")]
    public static HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req,
        [WebPubSubContextInput] WebPubSubContext wpsReq)
    {
        var response = req.CreateResponse();
        if (wpsReq.Request is PreflightRequest || wpsReq.ErrorMessage != null)
        {
            return BuildHttpResponseData(req, wpsReq.Response);
        }

        var request = wpsReq.Request as ConnectEventRequest;
        // assign the properties if needed.
        response.WriteAsJsonAsync(request.CreateResponse(request.ConnectionContext.UserId, null, null, null));
        return response;
    }

    #region Snippet:WebPubSubContextInputFunction
    // validate method when upstream set as http://<func-host>/api/{event}
    [Function("validate")]
    public static HttpResponseData Validate(
        [HttpTrigger(AuthorizationLevel.Anonymous, "options")] HttpRequestData req,
        [WebPubSubContextInput] WebPubSubContext wpsReq)
    {
        return BuildHttpResponseData(req, wpsReq.Response);
    }

    // Respond AbuseProtection to put header correctly.
    private static HttpResponseData BuildHttpResponseData(HttpRequestData request, SimpleResponse wpsResponse)
    {
        var response = request.CreateResponse();
        response.StatusCode = (HttpStatusCode)wpsResponse.Status;
        response.Body = response.Body;
        foreach (var header in wpsResponse.Headers)
        {
            response.Headers.Add(header.Key, header.Value);
        }
        return response;
    }
    #endregion
}