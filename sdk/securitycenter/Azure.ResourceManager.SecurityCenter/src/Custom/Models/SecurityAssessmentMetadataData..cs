// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    /// <summary>
    /// A class representing the SecurityAssessmentMetadata data model.
    /// Security assessment metadata response
    /// Serialized Name: SecurityAssessmentMetadataResponse
    /// </summary>
    public partial class SecurityAssessmentMetadataData : ResourceData
    {
        /// <summary> Azure resource ID of the policy definition that turns this assessment calculation on. </summary>
        [CodeGenMemberSerializationHooks(DeserializationValueHook = nameof(DeserializePolicyDefinitionId))]
        public ResourceIdentifier PolicyDefinitionId { get; }
    }
}
