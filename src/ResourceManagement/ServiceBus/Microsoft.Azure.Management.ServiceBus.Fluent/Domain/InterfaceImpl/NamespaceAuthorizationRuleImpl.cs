// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using NamespaceAuthorizationRule.Definition;
    using NamespaceAuthorizationRule.Update;

    internal partial class NamespaceAuthorizationRuleImpl 
    {
        /// <summary>
        /// Gets the name of the parent namespace name.
        /// </summary>
        string Microsoft.Azure.Management.Servicebus.Fluent.INamespaceAuthorizationRule.NamespaceName
        {
            get
            {
                return this.NamespaceName();
            }
        }
    }
}