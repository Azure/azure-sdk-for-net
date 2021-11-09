// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Web PubSub function global options.
    /// </summary>
    public class WebPubSubFunctionsOptions : IOptionsFormatter
    {
        /// <summary>
        /// Golbal hub name.
        /// </summary>
        public string Hub { get; set; }

        /// <summary>
        /// Global connection string works for output binding and input validations.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Formats the options as JSON objects for display.
        /// </summary>
        /// <returns>Options formatted as JSON.</returns>
        string IOptionsFormatter.Format()
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
