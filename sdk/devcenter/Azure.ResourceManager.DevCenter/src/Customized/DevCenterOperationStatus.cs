// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DevCenter.Models
{
    // Backward compatibility: restore OperationStatusResult as the base class,
    // provide the correct BinaryData Properties type, and ensure ResourceId is
    // inherited from the base class.
    [CodeGenSuppress("DevCenterOperationStatus")]
    [CodeGenSuppress("DevCenterOperationStatus", typeof(IReadOnlyDictionary<string, BinaryData>), typeof(IDictionary<string, BinaryData>))]
    public partial class DevCenterOperationStatus : OperationStatusResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="DevCenterOperationStatus"/>. </summary>
        /// <param name="status"> Operation status. </param>
        internal DevCenterOperationStatus(string status) : base(status)
        {
        }

        /// <summary> Initializes a new instance of <see cref="DevCenterOperationStatus"/>. </summary>
        /// <param name="id"> Fully qualified ID for the async operation. </param>
        /// <param name="name"> Name of the async operation. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentComplete"> Percent of the operation that is complete. </param>
        /// <param name="startOn"> The start time of the operation. </param>
        /// <param name="endOn"> The end time of the operation. </param>
        /// <param name="operations"> The operations list. </param>
        /// <param name="error"> If present, details of the operation error. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> Custom operation properties, populated only for a successful operation. </param>
        internal DevCenterOperationStatus(ResourceIdentifier id, string name, string status, float? percentComplete, DateTimeOffset? startOn, DateTimeOffset? endOn, IReadOnlyList<OperationStatusResult> operations, ResponseError error, IDictionary<string, BinaryData> additionalBinaryDataProperties, BinaryData properties) : base(id, name, status, percentComplete, startOn, endOn, operations, error)
        {
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
            Properties = properties;
        }

        /// <summary> Custom operation properties, populated only for a successful operation. </summary>
        public BinaryData Properties { get; }

        /// <summary> Fully qualified ID of the resource against which the original async operation was started. </summary>
        public ResourceIdentifier ResourceId
        {
            get
            {
                if (_additionalBinaryDataProperties != null && _additionalBinaryDataProperties.TryGetValue("resourceId", out BinaryData value) && value != null)
                {
                    using var doc = System.Text.Json.JsonDocument.Parse(value);
                    string resourceIdStr = doc.RootElement.GetString();
                    return resourceIdStr != null ? new ResourceIdentifier(resourceIdStr) : null;
                }
                return null;
            }
        }
    }
}
