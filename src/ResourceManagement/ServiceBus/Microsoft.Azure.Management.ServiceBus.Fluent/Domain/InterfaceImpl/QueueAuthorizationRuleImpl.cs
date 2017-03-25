// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using QueueAuthorizationRule.Definition;
    using QueueAuthorizationRule.Update;

    internal partial class QueueAuthorizationRuleImpl 
    {
        /// <summary>
        /// Gets the name of the namespace that the parent queue belongs to.
        /// </summary>
        string Microsoft.Azure.Management.Servicebus.Fluent.IQueueAuthorizationRule.NamespaceName
        {
            get
            {
                return this.NamespaceName();
            }
        }

        /// <summary>
        /// Gets the name of the parent queue name.
        /// </summary>
        string Microsoft.Azure.Management.Servicebus.Fluent.IQueueAuthorizationRule.QueueName
        {
            get
            {
                return this.QueueName();
            }
        }
    }
}