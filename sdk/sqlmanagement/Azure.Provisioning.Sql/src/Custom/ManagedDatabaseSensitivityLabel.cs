// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Sql;

public partial class ManagedDatabaseSensitivityLabel
{
    private BicepValue<string> _labelName;
    private BicepValue<string> _labelId;
    private BicepValue<string> _informationType;
    private BicepValue<string> _informationTypeId;
    private BicepValue<SensitivityLabelRank> _rank;
    private BicepValue<ClientClassificationSource> _clientClassificationSource;

    partial void DefineAdditionalProperties()
    {
        // Define these writable properties directly until
        // https://github.com/Azure/azure-sdk-for-net/issues/62742 provides a metadata override.
        _labelName = DefineProperty<string>(nameof(LabelName), new string[] { "properties", "labelName" });
        _labelId = DefineProperty<string>(nameof(LabelId), new string[] { "properties", "labelId" });
        _informationType = DefineProperty<string>(nameof(InformationType), new string[] { "properties", "informationType" });
        _informationTypeId = DefineProperty<string>(nameof(InformationTypeId), new string[] { "properties", "informationTypeId" });
        _rank = DefineProperty<SensitivityLabelRank>(nameof(Rank), new string[] { "properties", "rank" });
        _clientClassificationSource = DefineProperty<ClientClassificationSource>(nameof(ClientClassificationSource), new string[] { "properties", "clientClassificationSource" });
    }

    // This resource is writable, but its PUT operation is not currently associated with the
    // resource. See https://github.com/Azure/azure-sdk-for-net/issues/62598.
    /// <summary> Creates a new ManagedDatabaseSensitivityLabel. </summary>
    /// <param name="bicepIdentifier"> The bicep identifier name. </param>
    /// <param name="resourceVersion"> The resource API version. </param>
    public ManagedDatabaseSensitivityLabel(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, "Microsoft.Sql/managedInstances/databases/schemas/tables/columns/sensitivityLabels", resourceVersion ?? "2025-01-01")
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
        get
        {
            Initialize();
            return _labelName;
        }
        set
        {
            Initialize();
            _labelName.Assign(value);
        }
    }

    /// <summary> Gets or sets the label ID. </summary>
    [CodeGenMember("LabelId")]
    public BicepValue<string> LabelId
    {
        get
        {
            Initialize();
            return _labelId;
        }
        set
        {
            Initialize();
            _labelId.Assign(value);
        }
    }

    /// <summary> Gets or sets the information type. </summary>
    [CodeGenMember("InformationType")]
    public BicepValue<string> InformationType
    {
        get
        {
            Initialize();
            return _informationType;
        }
        set
        {
            Initialize();
            _informationType.Assign(value);
        }
    }

    /// <summary> Gets or sets the information type ID. </summary>
    [CodeGenMember("InformationTypeId")]
    public BicepValue<string> InformationTypeId
    {
        get
        {
            Initialize();
            return _informationTypeId;
        }
        set
        {
            Initialize();
            _informationTypeId.Assign(value);
        }
    }

    /// <summary> Gets or sets the sensitivity label rank. </summary>
    [CodeGenMember("Rank")]
    public BicepValue<SensitivityLabelRank> Rank
    {
        get
        {
            Initialize();
            return _rank;
        }
        set
        {
            Initialize();
            _rank.Assign(value);
        }
    }

    /// <summary> Gets or sets the client classification source. </summary>
    [CodeGenMember("ClientClassificationSource")]
    public BicepValue<ClientClassificationSource> ClientClassificationSource
    {
        get
        {
            Initialize();
            return _clientClassificationSource;
        }
        set
        {
            Initialize();
            _clientClassificationSource.Assign(value);
        }
    }
}
