// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.CosmosDB;

public partial class CosmosDBSqlUserDefinedFunction
{
    // This create-body-only property is not projected by the provisioning generator.
    // Remove this customization when https://github.com/Azure/azure-sdk-for-net/issues/61011 is fixed.
    /// <summary>
    /// A key-value pair of options to be applied for the request.
    /// </summary>
    public CosmosDBCreateUpdateConfig Options
    {
        get
        {
            return Properties is null ? default : Properties.Options;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new CosmosDBSqlUserDefinedFunctionProperties();
            }
            Properties.Options = value;
        }
    }
}
