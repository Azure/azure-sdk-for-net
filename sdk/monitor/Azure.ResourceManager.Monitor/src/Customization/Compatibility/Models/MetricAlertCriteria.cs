// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Monitor.Models
{
    // Work around https://github.com/microsoft/typespec/issues/10996: the back-compat generator keeps this
    // discriminator base concrete but exposes the discriminator value in a public constructor.
    [CodeGenSuppress("MetricAlertCriteria")]
    [CodeGenSuppress("MetricAlertCriteria", typeof(Odatatype))]
    public partial class MetricAlertCriteria
    {
        /// <summary> Initializes a new instance of <see cref="MetricAlertCriteria"/>. </summary>
        public MetricAlertCriteria()
        {
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }

        internal MetricAlertCriteria(Odatatype odataType)
        {
            OdataType = odataType;
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }
    }
}
