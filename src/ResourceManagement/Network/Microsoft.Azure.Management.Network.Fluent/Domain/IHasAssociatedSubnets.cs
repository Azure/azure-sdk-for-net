// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Collections.Generic;

    /// <summary>
    /// An interface representing a model's ability to reference a list of associated subnets.
    /// </summary>
    public interface IHasAssociatedSubnets 
    {
        /// <return>List of subnets associated with this resource.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Network.Fluent.ISubnet> ListAssociatedSubnets();
    }
}