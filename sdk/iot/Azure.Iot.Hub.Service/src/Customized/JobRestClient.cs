// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using Azure.Core;

namespace Azure.Iot.Hub.Service
{
    internal partial class JobRestClient
    {
        internal Response<string> CancelImportExportJob(string id, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            using var message = CreateCancelImportExportJobRequest(id);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        string value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = document.RootElement.GetRawText();
                        }
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue<string>(null, message.Response);
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCancelImportExportJobRequest(string id)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/jobs/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            return message;
        }
    }
}
