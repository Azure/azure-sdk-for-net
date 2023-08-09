﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private const int DefaultMaxDequeueCount = 5;

        private int _maxDegreeOfParallelism;
        private int _maxDequeueCount = DefaultMaxDequeueCount;

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

        /// <summary>
        /// Gets or sets the number of times to try processing a given blob before adding a message to a
        /// storage queue named `webjobs-blobtrigger-poison`.
        ///
        /// If not specified, will default to 5.
        ///
        /// See <see href="https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-blob-trigger#poison-blobs">
        /// Poison Blobs
        /// </see>.
        /// </summary>
        public int MaxDequeueCount
        {
            get { return _maxDequeueCount; }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("MaxDequeueCount must not be less than 1.", nameof(value));
                }

                _maxDequeueCount = value;
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string IOptionsFormatter.Format()
        {
            JObject options = new JObject
            {
                { nameof(MaxDegreeOfParallelism), MaxDegreeOfParallelism },
                { nameof(MaxDequeueCount), MaxDequeueCount }
            };

            return options.ToString(Formatting.Indented);
        }
    }
}
