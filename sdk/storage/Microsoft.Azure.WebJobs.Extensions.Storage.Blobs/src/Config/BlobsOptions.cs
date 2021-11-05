// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Represents configuration for <see cref="BlobTriggerAttribute"/>.
    /// </summary>
    public class BlobsOptions : IOptionsFormatter
    {
        private int _maxDegreeOfParallelism;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public BlobsOptions()
        {
            _maxDegreeOfParallelism = 8 * SkuUtility.ProcessorCount;
        }

        /// <summary>
        /// Gets or sets the maximum number of blob changes that may be processed by concurrently.
        /// </summary>
        public int MaxDegreeOfParallelism
        {
            get { return _maxDegreeOfParallelism; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _maxDegreeOfParallelism = value;
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string IOptionsFormatter.Format()
        {
            JObject options = new JObject
            {
                { nameof(MaxDegreeOfParallelism), MaxDegreeOfParallelism }
            };

            return options.ToString(Formatting.Indented);
        }
    }
}
