// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Hosting;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    public class WebPubSubOptions : IOptionsFormatter
    {
        public string Hub { get; set; }

        internal string ConnectionString { get; set; }

        internal HashSet<string> AllowedHosts { get; set; } = new HashSet<string>();

        internal HashSet<string> AccessKeys { get; set; } = new HashSet<string>();

        /// <summary>
        /// Formats the options as JSON objects for display.
        /// </summary>
        /// <returns>Options formatted as JSON.</returns>
        public string Format()
        {
            // Not expose ConnectionString in logging.
            JObject options = new JObject
            {
                { nameof(Hub), Hub }
            };

            return options.ToString(Formatting.Indented);
        }
    }
}
