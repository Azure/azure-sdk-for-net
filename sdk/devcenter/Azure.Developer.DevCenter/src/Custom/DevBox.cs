// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Developer.DevCenter.Models
{
    [CodeGenSuppress("DevBox", typeof(string))]
    public partial class DevBox
    {
        /// <summary> Initializes a new instance of <see cref="DevBox"/>. </summary>
        /// <param name="name"> Display name for the Dev Box. </param>
        /// <param name="poolName"> The name of the Dev Box pool this machine belongs to. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="poolName"/> is null. </exception>
        public DevBox(string name, string poolName) : this(
            name: name,
            projectName: null,
            poolName: poolName,
            hibernateSupport: null,
            provisioningState: null,
            actionState: null,
            powerState: null,
            uniqueId: null,
            error: null,
            location: null,
            osType: null,
            userId: null,
            hardwareProfile: null,
            storageProfile: null,
            imageReference: null,
            createdTime: null,
            localAdministratorStatus: null,
            additionalBinaryDataProperties: new Dictionary<string, BinaryData>())
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(poolName, nameof(poolName));
        }

        internal RequestContent ToRequestContent()
        {
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }

        /// <summary> Indicates whether the owner of the Dev Box is a local administrator. </summary>
        public LocalAdministratorStatus? LocalAdministratorStatus { get; set; }
    }
}
