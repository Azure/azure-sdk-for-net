// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using TopicAuthorizationRule.Definition;
    using TopicAuthorizationRule.Update;

    internal partial class TopicAuthorizationRuleImpl 
    {
        /// <summary>
        /// Gets the name of the namespace that the parent topic belongs to.
        /// </summary>
        string Microsoft.Azure.Management.Servicebus.Fluent.ITopicAuthorizationRule.NamespaceName
        {
            get
            {
                return this.NamespaceName();
            }
        }

        /// <summary>
        /// Gets the name of the parent topic name.
        /// </summary>
        string Microsoft.Azure.Management.Servicebus.Fluent.ITopicAuthorizationRule.TopicName
        {
            get
            {
                return this.TopicName();
            }
        }
    }
}