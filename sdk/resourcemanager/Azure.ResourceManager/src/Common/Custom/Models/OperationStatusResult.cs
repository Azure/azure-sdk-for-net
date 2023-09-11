// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Azure.Core;

namespace Azure.ResourceManager.Models
{
    public partial class OperationStatusResult
    {
        /// <summary> Initializes a new instance of OperationStatusResult. </summary>
        /// <param name="id"> Fully qualified ID for the async operation. </param>
        /// <param name="name"> Name of the async operation. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentComplete"> Percent of the operation that is complete. </param>
        /// <param name="startOn"> The start time of the operation. </param>
        /// <param name="endOn"> The end time of the operation. </param>
        /// <param name="operations"> The operations list. </param>
        /// <param name="error"> If present, details of the operation error. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [SerializationConstructor]
        protected OperationStatusResult(ResourceIdentifier id, string name, string status, float? percentComplete, DateTimeOffset? startOn, DateTimeOffset? endOn, IReadOnlyList<OperationStatusResult> operations, ResponseError error)
            : this(id, name, status, percentComplete, startOn, endOn, operations, error, new Dictionary<string, BinaryData>())
        {
        }
    }
}
