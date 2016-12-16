// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;

    internal partial class ConnectionStringImpl 
    {
        string Microsoft.Azure.Management.AppService.Fluent.IConnectionString.Name
        {
            get
            {
                return this.Name();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringType Microsoft.Azure.Management.AppService.Fluent.IConnectionString.Type
        {
            get
            {
                return this.Type();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IConnectionString.Value
        {
            get
            {
                return this.Value();
            }
        }

        bool Microsoft.Azure.Management.AppService.Fluent.IConnectionString.Sticky
        {
            get
            {
                return this.Sticky();
            }
        }
    }
}