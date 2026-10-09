// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

public partial class CosmosDBSqlContainerResourceInfo
{
    private MaterializedViewDefinition _materializedViewDefinition;

    // CUSTOMIZATION: Restore the entire preview-only property exposed by the previous GA package
    // because the selected stable TypeSpec version does not include it.
    /// <summary>
    /// The configuration for defining Materialized Views. This must be specified only for creating
    /// a Materialized View container.
    /// </summary>
    /// <remarks>
    /// This property is supported only by preview API versions such as
    /// <c>2026-04-01-preview</c>. When assigning it through a
    /// <see cref="CosmosDBSqlContainer"/>, explicitly select a supporting preview resource version;
    /// the default stable resource version does not support this property.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public MaterializedViewDefinition MaterializedViewDefinition
    {
        get
        {
            Initialize();
            return _materializedViewDefinition;
        }
        set
        {
            Initialize();
            AssignOrReplace(ref _materializedViewDefinition, value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _materializedViewDefinition = DefineModelProperty<MaterializedViewDefinition>(
            nameof(MaterializedViewDefinition),
            new string[] { "materializedViewDefinition" });
    }
}
