// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.DocumentIntelligence
{
    public partial class OperationDetails
    {
        // CUSTOM CODE NOTE: the spec incorrectly defines the OperationId property as a GUID,
        // but it should be a string. This makes our deserialization code fail. Ideally we'll
        // get the spec fixed and this piece of custom code will be removed.

        /// <summary> Operation ID. </summary>
        public string OperationId { get; }
    }
}
