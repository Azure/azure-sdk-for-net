// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Sql;

public partial class SqlDatabaseSensitivityLabel
{
    // This resource is writable, but its PUT operation is not currently associated with the
    // resource. See https://github.com/Azure/azure-sdk-for-net/issues/62598.
    /// <summary> Creates a new SqlDatabaseSensitivityLabel. </summary>
    /// <param name="bicepIdentifier"> The bicep identifier name. </param>
    /// <param name="resourceVersion"> The resource API version. </param>
    public SqlDatabaseSensitivityLabel(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, "Microsoft.Sql/servers/databases/schemas/tables/columns/sensitivityLabels", resourceVersion ?? "2025-01-01")
    {
    }

    // The effective PUT body has writable properties that must be combined with the response
    // resource model (https://github.com/Azure/azure-sdk-for-net/issues/61011). In addition,
    // the PUT is not associated with this resource because its fixed enum path differs from
    // the GET path (https://github.com/Azure/azure-sdk-for-net/issues/62598). Preserve the
    // setters shipped before the TypeSpec migration until both generator issues are resolved.
    /// <summary> Gets or sets the label name. </summary>
    [CodeGenMember("LabelName")]
    public BicepValue<string> LabelName
    {
        get => Properties.LabelName;
        set => Properties.LabelName.Assign(value);
    }

    /// <summary> Gets or sets the label ID. </summary>
    [CodeGenMember("LabelId")]
    public BicepValue<string> LabelId
    {
        get => Properties.LabelId;
        set => Properties.LabelId.Assign(value);
    }

    /// <summary> Gets or sets the information type. </summary>
    [CodeGenMember("InformationType")]
    public BicepValue<string> InformationType
    {
        get => Properties.InformationType;
        set => Properties.InformationType.Assign(value);
    }

    /// <summary> Gets or sets the information type ID. </summary>
    [CodeGenMember("InformationTypeId")]
    public BicepValue<string> InformationTypeId
    {
        get => Properties.InformationTypeId;
        set => Properties.InformationTypeId.Assign(value);
    }

    /// <summary> Gets or sets the sensitivity label rank. </summary>
    [CodeGenMember("Rank")]
    public BicepValue<SensitivityLabelRank> Rank
    {
        get => Properties.Rank;
        set => Properties.Rank.Assign(value);
    }

    /// <summary> Gets or sets the client classification source. </summary>
    [CodeGenMember("ClientClassificationSource")]
    public BicepValue<ClientClassificationSource> ClientClassificationSource
    {
        get => Properties.ClientClassificationSource;
        set => Properties.ClientClassificationSource.Assign(value);
    }
}
