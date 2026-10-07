// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

public partial class CosmosDBAccount
{
    // CUSTOMIZATION: Restore the entire preview-only property exposed by the previous GA package
    // because the selected stable TypeSpec version does not include it.
    /// <summary> Describe the level of detail with which queries are to be logged. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<EnableFullTextQuery> DiagnosticLogEnableFullTextQuery
    {
        get
        {
            return Properties is null ? default : Properties.DiagnosticLogEnableFullTextQuery;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new CosmosDBAccountProperties();
            }
            Properties.DiagnosticLogEnableFullTextQuery = value;
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
            return Properties is null ? default : Properties.EnableMaterializedViews;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new CosmosDBAccountProperties();
            }
            Properties.EnableMaterializedViews = value;
        }
    }

    /// <summary> Gets the private endpoint connections. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Use PrivateEndpointConnectionResources instead.")]
    public BicepList<CosmosDBPrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get
        {
            if (Properties is null)
            {
                Properties = new CosmosDBAccountProperties();
            }
            return Properties.PrivateEndpointConnections;
        }
    }

    // CUSTOMIZATION: Preserve the legacy listKeys convenience API, which is not projected by the
    // current provisioning generator.
    /// <summary>
    /// Get access keys for this CosmosDBAccount resource.
    /// </summary>
    /// <returns>The keys for this CosmosDBAccount resource.</returns>
    public CosmosDBAccountKeyList GetKeys()
    {
        CosmosDBAccountKeyList key = new();
        ((IBicepValue)key).Expression = new FunctionCallExpression(new MemberExpression(new IdentifierExpression(BicepIdentifier), "listKeys"));
        return key;
    }

    public static partial class ResourceVersions
    {
        /// <summary> API version "2014-04-01". </summary>
        public static readonly string V2014_04_01 = "2014-04-01";
        /// <summary> API version "2015-04-08". </summary>
        public static readonly string V2015_04_08 = "2015-04-08";
        /// <summary> API version "2015-11-06". </summary>
        public static readonly string V2015_11_06 = "2015-11-06";
        /// <summary> API version "2016-03-19". </summary>
        public static readonly string V2016_03_19 = "2016-03-19";
        /// <summary> API version "2016-03-31". </summary>
        public static readonly string V2016_03_31 = "2016-03-31";
        /// <summary> API version "2019-08-01". </summary>
        public static readonly string V2019_08_01 = "2019-08-01";
        /// <summary> API version "2019-12-12". </summary>
        public static readonly string V2019_12_12 = "2019-12-12";
        /// <summary> API version "2020-03-01". </summary>
        public static readonly string V2020_03_01 = "2020-03-01";
        /// <summary> API version "2020-04-01". </summary>
        public static readonly string V2020_04_01 = "2020-04-01";
        /// <summary> API version "2020-09-01". </summary>
        public static readonly string V2020_09_01 = "2020-09-01";
        /// <summary> API version "2021-01-15". </summary>
        public static readonly string V2021_01_15 = "2021-01-15";
        /// <summary> API version "2021-03-15". </summary>
        public static readonly string V2021_03_15 = "2021-03-15";
        /// <summary> API version "2021-04-15". </summary>
        public static readonly string V2021_04_15 = "2021-04-15";
        /// <summary> API version "2021-05-15". </summary>
        public static readonly string V2021_05_15 = "2021-05-15";
        /// <summary> API version "2021-06-15". </summary>
        public static readonly string V2021_06_15 = "2021-06-15";
        /// <summary> API version "2021-10-15". </summary>
        public static readonly string V2021_10_15 = "2021-10-15";
        /// <summary> API version "2022-05-15". </summary>
        public static readonly string V2022_05_15 = "2022-05-15";
        /// <summary> API version "2022-08-15". </summary>
        public static readonly string V2022_08_15 = "2022-08-15";
        /// <summary> API version "2022-11-15". </summary>
        public static readonly string V2022_11_15 = "2022-11-15";
        /// <summary> API version "2023-03-15". </summary>
        public static readonly string V2023_03_15 = "2023-03-15";
        /// <summary> API version "2023-04-15". </summary>
        public static readonly string V2023_04_15 = "2023-04-15";
        /// <summary> API version "2023-09-15". </summary>
        public static readonly string V2023_09_15 = "2023-09-15";
        /// <summary> API version "2023-11-15". </summary>
        public static readonly string V2023_11_15 = "2023-11-15";
        /// <summary> API version "2024-05-15". </summary>
        public static readonly string V2024_05_15 = "2024-05-15";
        /// <summary> API version "2024-08-15". </summary>
        public static readonly string V2024_08_15 = "2024-08-15";
        /// <summary> API version "2024-11-15". </summary>
        public static readonly string V2024_11_15 = "2024-11-15";
        /// <summary> API version "2025-04-15". </summary>
        public static readonly string V2025_04_15 = "2025-04-15";
    }
}
