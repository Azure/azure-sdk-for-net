// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Communication.PhoneNumbers;

namespace Azure.Core.Pipeline
{
    internal sealed class CommunicationRequestFailedDetailsParser : RequestFailedDetailsParser
    {
        public override bool TryParse(Response response, out ResponseError error, out IDictionary<string, string> data)
        {
            if (response.ContentStream is { CanSeek: true })
            {
                var position = response.ContentStream.Position;
                try
                {
                    response.ContentStream.Position = 0;
                    using var document = JsonDocument.Parse(response.ContentStream);

                    if (document.RootElement.TryGetProperty("error", out var errorValue))
                    {
                        var communicationError = CommunicationError.DeserializeCommunicationError(errorValue);
                        data = new Dictionary<string, string> { ["target"] = communicationError.Target };
                        error = new ResponseError(communicationError.Code, communicationError.Message);
                    }
                    else
                    {
                        error = default;
                        data = default;
                    }

                    return true;
                }
                catch
                { }
                finally
                {
                    response.ContentStream.Position = position;
                }
            }

            error = default;
            data = default;
            return false;
        }
    }
}
