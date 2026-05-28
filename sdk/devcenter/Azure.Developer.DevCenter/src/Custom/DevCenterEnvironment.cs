// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Developer.DevCenter.Models
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
        public DevCenterEnvironment(string environmentName, string environmentTypeName, string catalogName, string environmentDefinitionName)
        {
            Argument.AssertNotNull(environmentName, nameof(environmentName));
            Argument.AssertNotNull(environmentTypeName, nameof(environmentTypeName));
            Argument.AssertNotNull(catalogName, nameof(catalogName));
            Argument.AssertNotNull(environmentDefinitionName, nameof(environmentDefinitionName));

            Parameters = new ChangeTrackingDictionary<string, BinaryData>();
            Name = environmentName;
            EnvironmentTypeName = environmentTypeName;
            CatalogName = catalogName;
            EnvironmentDefinitionName = environmentDefinitionName;
        }

        /// <summary> The identifier of the resource group containing the environment's resources. </summary>
        public ResourceIdentifier ResourceGroupId { get; }
    }
}
