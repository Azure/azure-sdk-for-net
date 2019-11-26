// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿
namespace Microsoft.Azure.Batch
{
    using System;

    public partial class JobSpecification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobSpecification"/> class.
        /// </summary>
        public JobSpecification() : this(poolInformation: null)
        {
        }
    }
}
