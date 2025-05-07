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
        /// <param name="e">instance of an RequestFailedException exception returned from api call</param>
        /// <returns>An instance of a BatchError object if the exception contains one, null otherwise</returns>
        public static BatchError FromException(RequestFailedException e)
        {
            return BatchError.FromResponse(e.GetRawResponse());
        }
    }
}
