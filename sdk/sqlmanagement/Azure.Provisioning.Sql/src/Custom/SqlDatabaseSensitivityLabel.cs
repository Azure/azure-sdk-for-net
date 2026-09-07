// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Sql;

public partial class SqlDatabaseSensitivityLabel
{
    private SensitivityLabelProperties _writableProperties;

    // The missing PUT association also makes the generated properties construct read-only.
    // Replace its definition until https://github.com/Azure/azure-sdk-for-net/issues/62742
    // provides a supported metadata override.
    [CodeGenMember("Properties")]
    internal SensitivityLabelProperties Properties
    {
        get
        {
            Initialize();
            return _writableProperties;
        }
        set
        {
            Initialize();
            AssignOrReplace(ref _writableProperties, value);
        }
    }

    private SensitivityLabelProperties WritableProperties
    {
        get
        {
            if (Properties is null)
            {
                Properties = new SensitivityLabelProperties();
            }
            return Properties;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _writableProperties = DefineModelProperty<SensitivityLabelProperties>(nameof(Properties), new string[] { "properties" });
    }

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
        get => WritableProperties.LabelName;
        set => WritableProperties.LabelName.Assign(value);
    }

    /// <summary> Gets or sets the label ID. </summary>
    [CodeGenMember("LabelId")]
    public BicepValue<string> LabelId
    {
        get => WritableProperties.LabelId;
        set => WritableProperties.LabelId.Assign(value);
    }

    /// <summary> Gets or sets the information type. </summary>
    [CodeGenMember("InformationType")]
    public BicepValue<string> InformationType
    {
        get => WritableProperties.InformationType;
        set => WritableProperties.InformationType.Assign(value);
    }

    /// <summary> Gets or sets the information type ID. </summary>
    [CodeGenMember("InformationTypeId")]
    public BicepValue<string> InformationTypeId
    {
        get => WritableProperties.InformationTypeId;
        set => WritableProperties.InformationTypeId.Assign(value);
    }

    /// <summary> Gets or sets the sensitivity label rank. </summary>
    [CodeGenMember("Rank")]
    public BicepValue<SensitivityLabelRank> Rank
    {
        get => WritableProperties.Rank;
        set => WritableProperties.Rank.Assign(value);
    }

    /// <summary> Gets or sets the client classification source. </summary>
    [CodeGenMember("ClientClassificationSource")]
    public BicepValue<ClientClassificationSource> ClientClassificationSource
    {
        get => WritableProperties.ClientClassificationSource;
        set => WritableProperties.ClientClassificationSource.Assign(value);
    }
}
