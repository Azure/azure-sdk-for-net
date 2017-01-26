// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Filters
{
    /// <summary>
    /// Represents the filter actions which are allowed for the transformation
    /// of a message that have been matched by a filter expression.
    /// </summary>
    /// <remarks>
    /// Filter actions allow for the transformation of a message that have been matched by a filter expression.
    /// The typical use case for filter acions is to append or update the properties that are attached to a message,
    /// for example assigning a group ID based on the correlation ID of a message.
    /// </remarks>
    /// <seealso cref="SqlRuleAction"/>
    public abstract class RuleAction
    {
        internal RuleAction()
        {
            // This is intentionally left blank. This constructor exists
            // only to prevent external assemblies inheriting from it.
        }
    }
}