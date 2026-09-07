// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Sql;

internal partial class SensitivityLabelProperties
{
    private BicepValue<string> _writableLabelName;
    private BicepValue<string> _writableLabelId;
    private BicepValue<string> _writableInformationType;
    private BicepValue<string> _writableInformationTypeId;
    private BicepValue<SensitivityLabelRank> _writableRank;
    private BicepValue<ClientClassificationSource> _writableClientClassificationSource;

    // These properties are writable in the effective PUT body, but the response model can cause
    // the provisioning generator to define them as output-only. Replace their definitions until
    // https://github.com/Azure/azure-sdk-for-net/issues/62742 provides a metadata override.
    [CodeGenMember("LabelName")]
    public BicepValue<string> LabelName
    {
        get
        {
            Initialize();
            return _writableLabelName;
        }
    }

    [CodeGenMember("LabelId")]
    public BicepValue<string> LabelId
    {
        get
        {
            Initialize();
            return _writableLabelId;
        }
    }

    [CodeGenMember("InformationType")]
    public BicepValue<string> InformationType
    {
        get
        {
            Initialize();
            return _writableInformationType;
        }
    }

    [CodeGenMember("InformationTypeId")]
    public BicepValue<string> InformationTypeId
    {
        get
        {
            Initialize();
            return _writableInformationTypeId;
        }
    }

    [CodeGenMember("Rank")]
    public BicepValue<SensitivityLabelRank> Rank
    {
        get
        {
            Initialize();
            return _writableRank;
        }
    }

    [CodeGenMember("ClientClassificationSource")]
    public BicepValue<ClientClassificationSource> ClientClassificationSource
    {
        get
        {
            Initialize();
            return _writableClientClassificationSource;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _writableLabelName = DefineProperty<string>(nameof(LabelName), new string[] { "labelName" });
        _writableLabelId = DefineProperty<string>(nameof(LabelId), new string[] { "labelId" });
        _writableInformationType = DefineProperty<string>(nameof(InformationType), new string[] { "informationType" });
        _writableInformationTypeId = DefineProperty<string>(nameof(InformationTypeId), new string[] { "informationTypeId" });
        _writableRank = DefineProperty<SensitivityLabelRank>(nameof(Rank), new string[] { "rank" });
        _writableClientClassificationSource = DefineProperty<ClientClassificationSource>(nameof(ClientClassificationSource), new string[] { "clientClassificationSource" });
    }
}
