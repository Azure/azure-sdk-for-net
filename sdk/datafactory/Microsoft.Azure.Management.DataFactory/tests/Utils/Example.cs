// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace DataFactory.Tests.Utils
{
    public class Example
    {
        [JsonIgnore]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "parameters")]
        public Dictionary<string, object> Parameters { get; set; }

        [JsonProperty(PropertyName = "responses")]
        public Dictionary<string, Response> Responses { get; set; }

        public Example()
        {
            this.Parameters = new Dictionary<string, object>();
            this.Responses = new Dictionary<string, Response>();
        }

        public class Response
        {
            [JsonProperty(PropertyName = "headers")]
            public Dictionary<string, string> Headers { get; set; }

            [JsonProperty(PropertyName = "body")]
            public object Body { get; set; }

            public Response()
            {
                this.Headers = new Dictionary<string, string>();
            }

            public Response(HttpResponseMessage message, IEnumerable<string> uninterestingHeaders) : this()
            {
                foreach (KeyValuePair<string, IEnumerable<string>> header in message.Headers)
                {
                    if (!uninterestingHeaders.Contains(header.Key) && header.Value.Count() == 1)
                    {
                        this.Headers.Add(header.Key, header.Value.First());
                    }
                }
                string bodyString = message.Content.AsString();
                object body = SafeJsonConvert.DeserializeObject<object>(bodyString);
                this.Body = body;
            }
        }
    }
}
