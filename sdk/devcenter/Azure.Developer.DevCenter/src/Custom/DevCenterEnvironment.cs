// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;

namespace Azure.Developer.DevCenter
{
    [CodeGenSuppress("DevCenterEnvironment", typeof(string), typeof(string), typeof(string))]
    public partial class DevCenterEnvironment
    {
        /// <summary> Initializes a new instance of <see cref="DevCenterEnvironment"/>. </summary>
        /// <param name="environmentName"> Environment name. </param>
        /// <param name="environmentTypeName"> Environment type. </param>
        /// <param name="catalogName"> Name of the catalog. </param>
        /// <param name="environmentDefinitionName"> Name of the environment definition. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="environmentName"/>, <paramref name="environmentTypeName"/>, <paramref name="catalogName"/> or <paramref name="environmentDefinitionName"/> is null. </exception>
        public DevCenterEnvironment(string environmentName, string environmentTypeName, string catalogName, string environmentDefinitionName) : this(
            parameters: new ChangeTrackingDictionary<string, BinaryData>(),
            name: environmentName,
            environmentTypeName: environmentTypeName,
            userId: null,
            provisioningState: null,
            resourceGroupId: null,
            catalogName: catalogName,
            environmentDefinitionName: environmentDefinitionName,
            error: null,
            additionalBinaryDataProperties: new Dictionary<string, BinaryData>())
        {
            Argument.AssertNotNull(environmentName, nameof(environmentName));
            Argument.AssertNotNull(environmentTypeName, nameof(environmentTypeName));
            Argument.AssertNotNull(catalogName, nameof(catalogName));
            Argument.AssertNotNull(environmentDefinitionName, nameof(environmentDefinitionName));
        }

        internal RequestContent ToRequestContent()
        {
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
