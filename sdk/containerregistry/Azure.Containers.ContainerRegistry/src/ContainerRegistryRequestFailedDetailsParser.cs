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

            BinaryData content = response.Content ?? BinaryData.FromStream(response.ContentStream);
            JsonDocument doc = JsonDocument.Parse(content);
            AcrErrors errors = AcrErrors.DeserializeAcrErrors(doc.RootElement);
            if (errors?.Errors?.Count > 0)
            {
                AcrErrorInfo first = errors.Errors[0];
                error = new ResponseError(first.Code, first.Message);
            }

            return error != null;
        }
    }
}
