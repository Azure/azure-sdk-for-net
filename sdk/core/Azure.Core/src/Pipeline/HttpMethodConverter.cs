// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Pipeline
{
    public static class HttpPipelineMethodConverter
    {
        public static string ToString(HttpPipelineMethod method)
        {
            switch (method)
            {
                case HttpPipelineMethod.Get:
                    return "GET";
                case HttpPipelineMethod.Post:
                    return "POST";
                case HttpPipelineMethod.Put:
                    return "PUT";
                case HttpPipelineMethod.Patch:
                    return "PATCH";
                case HttpPipelineMethod.Delete:
                    return "DELETE";
                case HttpPipelineMethod.Head:
                    return "HEAD";
                default:
                    throw new ArgumentOutOfRangeException(nameof(method), method, null);
            }
        }

        public static HttpPipelineMethod Parse(string method)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            // Fast-path common values
            if (method.Length == 3)
            {
                if (string.Equals(method, "GET", StringComparison.OrdinalIgnoreCase))
                {
                    return HttpPipelineMethod.Get;
                }

                if (string.Equals(method, "PUT", StringComparison.OrdinalIgnoreCase))
                {
                    return HttpPipelineMethod.Put;
                }
            }
            else if (method.Length == 4)
            {
                if (string.Equals(method, "POST", StringComparison.OrdinalIgnoreCase))
                {
                    return HttpPipelineMethod.Post;
                }
                if (string.Equals(method, "HEAD", StringComparison.OrdinalIgnoreCase))
                {
                    return HttpPipelineMethod.Head;
                }
            }
            else
            {
                if (string.Equals(method, "PATCH", StringComparison.OrdinalIgnoreCase))
                {
                    return HttpPipelineMethod.Patch;
                }
                if (string.Equals(method, "DELETE", StringComparison.OrdinalIgnoreCase))
                {
                    return HttpPipelineMethod.Delete;
                }
            }

            throw new ArgumentException($"'{method}' is not a known HTTP method");
        }
    }
}
