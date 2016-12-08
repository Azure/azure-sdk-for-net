// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent.DeploymentSlot.Update
{
    using Microsoft.Azure.Management.Appservice.Fluent;
    using Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update;

    /// <summary>
    /// The template for a deployment slot update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot>
    {
    }
}