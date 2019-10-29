// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Similar to WebActivty.cs in this folder. Generated manually due to AutoRest not 
// generating JsonObject Property when Model name === x-ms-discriminator-value

namespace Microsoft.Azure.Management.DataFactory.Models
{
    /// <summary>
    /// AzureFunction activity.
    /// </summary>
    [Newtonsoft.Json.JsonObject("AzureFunctionActivity")]
    public partial class AzureFunctionActivity : ExecutionActivity
    {
    }
}