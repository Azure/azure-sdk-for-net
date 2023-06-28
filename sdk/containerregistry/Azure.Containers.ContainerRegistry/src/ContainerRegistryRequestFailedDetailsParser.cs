// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
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

            if (response.ContentStream is not MemoryStream)
            {
                // Buffer the stream to enable content logging in the exception message.
                // See: https://github.com/Azure/azure-sdk-for-net/issues/35355
                BufferResponse(response);
            }

            BinaryData content = response.Content;

            // Optimistic check for JSON error object
            if (content.ToMemory().Length == 0 || content.ToMemory().Span[0] != (byte)'{')
            {
                return false;
            }

            try
            {
                using JsonDocument doc = JsonDocument.Parse(content);
                AcrErrors errors = AcrErrors.DeserializeAcrErrors(doc.RootElement);
                if (errors?.Errors?.Count > 0)
                {
                    AcrErrorInfo first = errors.Errors[0];
                    error = new ResponseError(first.Code, first.Message);
                }
            }
            catch
            {
                // Content should be logged in exception message.
            }

            return error != null;
        }

        private static void BufferResponse(Response response)
        {
            Stream responseContentStream = response.ContentStream;

            BinaryData content = BinaryData.FromStream(responseContentStream);

            responseContentStream.Dispose();

            response.ContentStream = new MemoryStream(content.ToArray());
        }
    }
}
