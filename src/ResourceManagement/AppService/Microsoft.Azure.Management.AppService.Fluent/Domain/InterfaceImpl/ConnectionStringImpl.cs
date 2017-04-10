// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;

    internal partial class ConnectionStringImpl 
    {
        /// <summary>
        /// Gets the key of the setting.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IConnectionString.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the type of the connection string.
        /// </summary>
        Models.ConnectionStringType Microsoft.Azure.Management.AppService.Fluent.IConnectionString.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// Gets if the connection string sticks to the slot during a swap.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IConnectionString.Sticky
        {
            get
            {
                return this.Sticky();
            }
        }

        /// <summary>
        /// Gets the value of the connection string.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IConnectionString.Value
        {
            get
            {
                return this.Value();
            }
        }
    }
}