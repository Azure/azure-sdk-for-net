// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.IO;

namespace Azure.Generator.Provisioning.Visitors;

/// <summary>
/// Visitor that removes the "Data" suffix from resource model names.
/// The mgmt ResourceVisitor appends "Data" to resource models (e.g., ConfigurationStore → ConfigurationStoreData).
/// Provisioning libraries do not use the "Data" suffix (e.g., AppConfigurationStore, not AppConfigurationStoreData).
/// This visitor runs after the inherited mgmt visitors and reverts the rename.
/// </summary>
internal class ResourceDataSuffixVisitor : ScmLibraryVisitor
{
    private const string DataSuffix = "Data";

    protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
    {
        if (type is not null && ((ManagementInputLibrary)ManagementClientGenerator.Instance.InputLibrary).IsResourceModel(model))
        {
            var name = type.Name;
            if (name.EndsWith(DataSuffix, StringComparison.Ordinal))
            {
                var originalName = name.Substring(0, name.Length - DataSuffix.Length);
                type.Update(
                    name: originalName,
                    relativeFilePath: Path.Combine("src", "Generated", $"{originalName}.cs"));
            }
        }
        return type;
    }
}
