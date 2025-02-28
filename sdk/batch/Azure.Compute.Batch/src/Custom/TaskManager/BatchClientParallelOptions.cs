// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Compute.Batch
{
    /// <summary>
    /// Stores options that configure the operation of methods on Batch client parallel operations.
    /// </summary>
    public class BatchClientParallelOptions
    {
        private int _maxDegreeOfParallelism;
        private int _maxTimeBetweenCallsInSeconds;

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
        /// Gets or sets the maximum time between calls in seconds. This can
        /// be used to throttle the number of calls made to the Batch service.
        /// </summary>
        public int MaxTimeBetweenCallsInSeconds
        {
            get { return this._maxTimeBetweenCallsInSeconds; }
            set
            {
                if (value >= 0)
                {
                    this._maxTimeBetweenCallsInSeconds = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchClientParallelOptions"/> class.
        /// </summary>
        public BatchClientParallelOptions()
        {
            this.MaxDegreeOfParallelism = 1;
            this.MaxTimeBetweenCallsInSeconds = 30;
        }
    }
}
