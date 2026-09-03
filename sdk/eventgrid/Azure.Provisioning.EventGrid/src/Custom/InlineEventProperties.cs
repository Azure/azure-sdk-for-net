// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

public partial class InlineEventProperties
{
    private BicepValue<Uri> _customDocumentationUri;
    private BicepValue<Uri> _customDataSchemaUri;

    /// <summary> Gets or sets the documentation URI. </summary>
    [CodeGenMember("DocumentationUri")]
    public BicepValue<Uri> DocumentationUri
    {
        get
        {
            Initialize();
            return _customDocumentationUri;
        }
        set
        {
            Initialize();
            _customDocumentationUri.Assign(value);
        }
    }

    /// <summary> Gets or sets the data schema URI. </summary>
    [CodeGenMember("DataSchemaUri")]
    public BicepValue<Uri> DataSchemaUri
    {
        get
        {
            Initialize();
            return _customDataSchemaUri;
        }
        set
        {
            Initialize();
            _customDataSchemaUri.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _customDocumentationUri = DefineProperty<Uri>(nameof(DocumentationUri), ["documentationUrl"]);
        _customDataSchemaUri = DefineProperty<Uri>(nameof(DataSchemaUri), ["dataSchemaUrl"]);
    }
}
