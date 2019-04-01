// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿using System;
using System.Threading;

namespace Microsoft.Azure.Batch
{
    /// <summary>
    /// Stores options that configure the operation of methods on Batch client parallel operations.
    /// </summary>
    public class BatchClientParallelOptions
    {
        private int _maxDegreeOfParallelism;

        /// <summary>
        /// Gets or sets the maximum number of concurrent tasks enabled by this <see cref="BatchClientParallelOptions"/> instance.
        /// The default value is 1.
        /// </summary>
        public int MaxDegreeOfParallelism
        {
            get { return this._maxDegreeOfParallelism; }
            set
            {
                if (value > 0)
                {
                    this._maxDegreeOfParallelism = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }

        /// <summary>
        /// Gets or sets the <see cref=" System.Threading.CancellationToken"/> associated with this <see cref="BatchClientParallelOptions"/> instance.
        /// The default is <see cref=" System.Threading.CancellationToken.None"/>.
        /// </summary>
        public CancellationToken CancellationToken { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchClientParallelOptions"/> class.
        /// </summary>
        public BatchClientParallelOptions()
        {
            this.MaxDegreeOfParallelism = 1;
        }
    }
}
