// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// An assignment of a worker to a queue.
    /// </summary>
    public class QueueAssignment : EmptyPlaceholderObject
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public QueueAssignment(object value) : base(value)
        {
        }
    }
}
