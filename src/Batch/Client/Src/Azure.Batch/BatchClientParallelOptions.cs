// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

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
