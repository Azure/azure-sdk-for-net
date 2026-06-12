// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Compatibility shim preserving the GA constructor for SDK-only DscCompilationJob create content.
    [CodeGenSuppress("DscCompilationJobCreateOrUpdateContent")]
    public partial class DscCompilationJobCreateOrUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="DscCompilationJobCreateOrUpdateContent"/>. </summary>
        /// <param name="configuration"> Gets or sets the configuration. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="configuration"/> is null. </exception>
        public DscCompilationJobCreateOrUpdateContent(DscConfigurationAssociationProperty configuration)
        {
            Argument.AssertNotNull(configuration, nameof(configuration));

            Properties = new DscCompilationJobCreateOrUpdateProperties(configuration, new ChangeTrackingDictionary<string, string>(), default, default);
            Tags = new ChangeTrackingDictionary<string, string>();
        }
    }
}
