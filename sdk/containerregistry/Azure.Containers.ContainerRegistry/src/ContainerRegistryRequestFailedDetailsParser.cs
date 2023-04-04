// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    internal class ContainerRegistryRequestFailedDetailsParser : RequestFailedDetailsParser
    {
        public override bool TryParse(Response response, out ResponseError error, out IDictionary<string, string> data)
        {
            error = null;
            data = null;

            if (response.ContentStream == null)
            {
                return false;
            }

            BinaryData content = BinaryData.FromStream(response.ContentStream);
            try
            {
                JsonDocument doc = JsonDocument.Parse(content);
                AcrErrors errors = AcrErrors.DeserializeAcrErrors(doc.RootElement);
                if (errors?.Errors?.Count > 0)
                {
                    AcrErrorInfo first = errors.Errors[0];
                    error = new ResponseError(first.Code, first.Message);
                }
            }
            catch
            {
                // We won't get default logging of content since stream is unbuffered,
                // so provide the message as an error message to surface it in the exception.
                error = new(code: null, message: content.ToString());
            }

            return error != null;
        }
    }
}
