// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Base.Http
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
                if (string.Equals(method, "GET", StringComparison.InvariantCultureIgnoreCase))
                {
                    return HttpPipelineMethod.Get;
                }

                if (string.Equals(method, "PUT", StringComparison.InvariantCultureIgnoreCase))
                {
                    return HttpPipelineMethod.Put;
                }
            }
            else if (method.Length == 4)
            {
                if (string.Equals(method, "POST", StringComparison.InvariantCultureIgnoreCase))
                {
                    return HttpPipelineMethod.Post;
                }
            }
            else
            {
                if (string.Equals(method, "PATCH", StringComparison.InvariantCultureIgnoreCase))
                {
                    return HttpPipelineMethod.Patch;
                }
                if (string.Equals(method, "DELETE", StringComparison.InvariantCultureIgnoreCase))
                {
                    return HttpPipelineMethod.Delete;
                }
            }

            throw new ArgumentException($"'{method}' is not a known HTTP method");
        }
    }
}