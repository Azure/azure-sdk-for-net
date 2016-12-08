// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;

    internal partial class ConnectionStringImpl 
    {
        string Microsoft.Azure.Management.Appservice.Fluent.IConnectionString.Name
        {
            get
            {
                return this.Name();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringType Microsoft.Azure.Management.Appservice.Fluent.IConnectionString.Type
        {
            get
            {
                return this.Type();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IConnectionString.Value
        {
            get
            {
                return this.Value();
            }
        }

        bool Microsoft.Azure.Management.Appservice.Fluent.IConnectionString.Sticky
        {
            get
            {
                return this.Sticky();
            }
        }
    }
}