// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.WebPubSub.AspNetCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    public class WebPubSubOptions : IOptionsFormatter
    {
        public string Hub { get; set; }

        public string ConnectionString { get; set; }

        internal WebPubSubValidationOptions ValidationOptions { get; set; }

        /// <summary>
        /// Formats the options as JSON objects for display.
        /// </summary>
        /// <returns>Options formatted as JSON.</returns>
        public string Format()
        {
            // Not expose ConnectionString in logging.
            JObject options = new()
            {
                { nameof(Hub), Hub }
            };

            return options.ToString(Formatting.Indented);
        }
    }
}
