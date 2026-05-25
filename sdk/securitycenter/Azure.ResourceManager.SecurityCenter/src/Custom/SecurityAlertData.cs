// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.SecurityCenter.Models;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter
{
    [CodeGenSuppress("SecurityAlertData")]
    public partial class SecurityAlertData
    {
        /// <summary> Initializes a new instance of <see cref="SecurityAlertData"/>. </summary>
        public SecurityAlertData()
        {
            Properties = new AlertProperties();
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Changing set of properties depending on the supportingEvidence type. </summary>
        public SecurityAlertSupportingEvidence SupportingEvidence
        {
            get => Properties is null ? default : Properties.SupportingEvidence;
            set => Properties.SupportingEvidence = value;
        }
    }
}
