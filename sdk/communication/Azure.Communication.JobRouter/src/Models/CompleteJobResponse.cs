// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Response received after successful job completion.
    /// </summary>
    public class CompleteJobResponse: EmptyPlaceholderObject
    {
        /// <inheritdoc />
        public CompleteJobResponse(object value) : base(value)
        {
        }
    }
}
