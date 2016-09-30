// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{


    /// <summary>
    /// An interface representing a model's ability to references a load balancer frontend.
    /// </summary>
    public interface IHasFrontend 
    {
        /// <returns>the associated frontend</returns>
        IFrontend Frontend ();

    }
}