// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Batch
{
    using System;

    public partial class PoolSpecification
    {
        /// <summary>
        /// This property is an alias for <see cref="TargetDedicatedComputeNodes"/> and is supported only for backward compatibility.
        /// </summary>
        [Obsolete("Obsolete after 05/2017, use TargetDedicatedComputeNodes instead.")]
        public int? TargetDedicated
        {
            get { return this.TargetDedicatedComputeNodes; }
            set { this.TargetDedicatedComputeNodes = value; }
        }
    }
}
