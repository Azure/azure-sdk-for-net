// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Compute.Batch
{
    public partial class BatchError
    {
        /// <summary>
        /// Extracts a <see cref="BatchError"/> from a <see cref="Azure.RequestFailedException"/>.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static BatchError ExtractBatchErrorFromException(RequestFailedException e)
        {
            return BatchError.FromResponse(e.GetRawResponse());
        }
    }
}
