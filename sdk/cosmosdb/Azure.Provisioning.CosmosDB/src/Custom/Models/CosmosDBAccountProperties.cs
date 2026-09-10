// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Preserve the legacy private endpoint connection property while exposing
// the newly generated resource type under a distinct name.
internal partial class CosmosDBAccountProperties
{
    private BicepValue<global::Azure.Provisioning.CosmosDB.CosmosDBAccountOfferType> _databaseAccountOfferType;
    private BicepList<CosmosDBAccountLocation> _locations;
    private BicepValue<EnableFullTextQuery> _diagnosticLogEnableFullTextQuery;
    private BicepValue<bool> _enableMaterializedViews;
    private BicepList<CosmosDBPrivateEndpointConnection> _privateEndpointConnectionResources;
#pragma warning disable CS0618 // Required to store the obsolete compatibility type.
    private BicepList<CosmosDBPrivateEndpointConnectionData> _privateEndpointConnections;
#pragma warning restore CS0618

    // CUSTOMIZATION: Restore the setter lost because the provisioning generator does not yet
    // recursively combine the resource response and create body model graphs.
    // https://github.com/Azure/azure-sdk-for-net/issues/61011
    /// <summary> Gets or sets the DatabaseAccountOfferType. </summary>
    [CodeGenMember("DatabaseAccountOfferType")]
    public BicepValue<global::Azure.Provisioning.CosmosDB.CosmosDBAccountOfferType> DatabaseAccountOfferType
    {
        get
        {
            Initialize();
            return _databaseAccountOfferType;
        }
        set
        {
            Initialize();
            _databaseAccountOfferType.Assign(value);
        }
    }

    // CUSTOMIZATION: Restore the setter lost because the provisioning generator does not yet
    // recursively combine the resource response and create body model graphs.
    // https://github.com/Azure/azure-sdk-for-net/issues/61011
    /// <summary> Gets or sets the Locations. </summary>
    [CodeGenMember("Locations")]
    public BicepList<CosmosDBAccountLocation> Locations
    {
        get
        {
            Initialize();
            return _locations;
        }
        set
        {
            Initialize();
            _locations.Assign(value);
        }
    }

    // CUSTOMIZATION: Restore the entire preview-only property exposed by the previous GA package
    // because the selected stable TypeSpec version does not include it.
    /// <summary> Describe the level of detail with which queries are to be logged. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<EnableFullTextQuery> DiagnosticLogEnableFullTextQuery
    {
        get
        {
            Initialize();
            return _diagnosticLogEnableFullTextQuery;
        }
        set
        {
            Initialize();
            _diagnosticLogEnableFullTextQuery.Assign(value);
        }
    }

    // CUSTOMIZATION: Restore the entire preview-only property exposed by the previous GA package
    // because the selected stable TypeSpec version does not include it.
    /// <summary> Flag to indicate whether to enable MaterializedViews on the Cosmos DB account. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<bool> EnableMaterializedViews
    {
        get
        {
            Initialize();
            return _enableMaterializedViews;
        }
        set
        {
            Initialize();
            _enableMaterializedViews.Assign(value);
        }
    }

    /// <summary> Gets the private endpoint connection resources. </summary>
    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<CosmosDBPrivateEndpointConnection> PrivateEndpointConnectionResources
    {
        get
        {
            Initialize();
            return _privateEndpointConnectionResources;
        }
    }

    /// <summary> Gets the private endpoint connections. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Use PrivateEndpointConnectionResources instead.")]
    public BicepList<CosmosDBPrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get
        {
            Initialize();
            return _privateEndpointConnections;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _databaseAccountOfferType = DefineProperty<global::Azure.Provisioning.CosmosDB.CosmosDBAccountOfferType>(
            nameof(DatabaseAccountOfferType),
            new string[] { "databaseAccountOfferType" },
            isRequired: true);
        _locations = DefineListProperty<CosmosDBAccountLocation>(
            nameof(Locations),
            new string[] { "locations" },
            isRequired: true);
        _diagnosticLogEnableFullTextQuery = DefineProperty<EnableFullTextQuery>(
            nameof(DiagnosticLogEnableFullTextQuery),
            new string[] { "diagnosticLogSettings", "enableFullTextQuery" });
        _enableMaterializedViews = DefineProperty<bool>(
            nameof(EnableMaterializedViews),
            new string[] { "enableMaterializedViews" });
        _privateEndpointConnectionResources = DefineListProperty<CosmosDBPrivateEndpointConnection>(
            nameof(PrivateEndpointConnectionResources),
            new string[] { "privateEndpointConnections" },
            isOutput: true);

#pragma warning disable CS0618 // Required to initialize the obsolete compatibility type.
        _privateEndpointConnections = new BicepList<CosmosDBPrivateEndpointConnectionData>();
#pragma warning restore CS0618
        ((IBicepValue)_privateEndpointConnections).Expression = _privateEndpointConnectionResources.Compile();
        ((IBicepValue)_privateEndpointConnections).SetReadOnly();
    }
}
