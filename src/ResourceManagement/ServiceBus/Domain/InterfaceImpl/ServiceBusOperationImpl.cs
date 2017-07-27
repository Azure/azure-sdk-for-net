// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Models;

    internal partial class ServiceBusOperationImpl 
    {
        /// <summary>
        /// Gets the description of the operation.
        /// </summary>
        Models.OperationDisplay Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusOperation.DisplayInformation
        {
            get
            {
                return this.DisplayInformation() as Models.OperationDisplay;
            }
        }

        /// <summary>
        /// Gets the operation name.
        /// </summary>
        string Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusOperation.Name
        {
            get
            {
                return this.Name();
            }
        }
    }
}