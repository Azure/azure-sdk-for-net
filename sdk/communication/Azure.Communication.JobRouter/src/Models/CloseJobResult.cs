// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Response received after successful job closure.
    /// </summary>
    public class CloseJobResult: EmptyPlaceholderObject
    {
        /// <inheritdoc />
        public CloseJobResult(object value) : base(value)
        {
        }
    }
}
