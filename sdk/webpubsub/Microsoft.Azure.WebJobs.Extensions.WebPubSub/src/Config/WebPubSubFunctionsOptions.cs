// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

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

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
