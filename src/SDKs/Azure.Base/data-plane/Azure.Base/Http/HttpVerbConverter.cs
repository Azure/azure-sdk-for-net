// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Base.Http
{
    public static class HttpVerbConverter
    {
        public static string ToString(HttpVerb verb)
        {
            switch (verb)
            {
                case HttpVerb.Get:
                    return "GET";
                case HttpVerb.Post:
                    return "POST";
                case HttpVerb.Put:
                    return "PUT";
                case HttpVerb.Patch:
                    return "PATCH";
                case HttpVerb.Delete:
                    return "DELETE";
                default:
                    throw new ArgumentOutOfRangeException(nameof(verb), verb, null);
            }
        }

        public static HttpVerb Parse(string verb)
        {
            if (verb == null)
            {
                throw new ArgumentNullException(nameof(verb));
            }

            // Fast-path common values
            if (verb.Length == 3)
            {
                if (string.Equals(verb, "GET", StringComparison.InvariantCultureIgnoreCase))
                {
                    return HttpVerb.Get;
                }

                if (string.Equals(verb, "PUT", StringComparison.InvariantCultureIgnoreCase))
                {
                    return HttpVerb.Put;
                }
            }
            else if (verb.Length == 4)
            {
                if (string.Equals(verb, "POST", StringComparison.InvariantCultureIgnoreCase))
                {
                    return HttpVerb.Post;
                }
            }
            else
            {
                if (string.Equals(verb, "PATCH", StringComparison.InvariantCultureIgnoreCase))
                {
                    return HttpVerb.Patch;
                }
                if (string.Equals(verb, "DELETE", StringComparison.InvariantCultureIgnoreCase))
                {
                    return HttpVerb.Delete;
                }
            }

            throw new ArgumentException($"'{verb}' is not a known HTTP verb");
        }
    }
}