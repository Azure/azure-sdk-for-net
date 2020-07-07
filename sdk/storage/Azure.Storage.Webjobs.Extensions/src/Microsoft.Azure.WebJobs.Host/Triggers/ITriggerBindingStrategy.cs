// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Host.Triggers
{
    /// <summary>
    /// Strategy pattern to describe how to bind a core trigger type to various parameter.
    /// The strategy supports:
    /// <list>
    /// <item>dispatching items one at time (Single) or an array of items in a single a batch (Multiple). Multiple dispatch may allow faster throughput.</item> 
    /// <item>core binding, string, poco w/ Binding Contracts</item>
    /// </list>
    /// For example, a single QueueTriggerInput -->  can bind to 
    ///  CloudQueueMessage, CloudQueueMessage[], string, string[], Poco, Poco[]    
    /// </summary>
    /// <typeparam name="TMessage">The native message type. For Azure Queues, this would be CloudQueueMessage.</typeparam>
    /// <typeparam name="TTriggerValue">The type of the trigger object that the listener returns. This could represent a single message or a batch of messages.</typeparam>
    [Obsolete("Not ready for public consumption.")]
    public interface ITriggerBindingStrategy<TMessage, TTriggerValue>
    {
        /// <summary>
        /// Given a raw string, convert to a TTriggerValue.
        /// This is primarily used in the "invoke from dashboard" path. 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        TTriggerValue ConvertFromString(string message);

        /// <summary>
        /// Get the static route-parameter contract for the TMessage. 
        /// For example, if we bind a queue message to a POCO, 
        /// then the properties on that type are route parameters that can feed into other bindings. 
        /// Intentionally make this mutable so that callers can add more items to it and override defaults. 
        /// </summary>
        /// <param name="isSingleDispatch">true if this is the BindSingle contract; false if it's the BindMultiple contract</param>
        /// <returns>A map of the names of items in the binding contract and their types.</returns>
        Dictionary<string, Type> GetBindingContract(bool isSingleDispatch);

        /// <summary>
        /// Get the values of the route-parameters given an instance of the trigger value. 
        /// This should match the structure in GetStaticBindingContract. 
        /// Intentionally make this mutable so that callers can add more items to it. 
        /// </summary>
        /// <param name="value">The instance of the trigger object.</param>
        /// <returns>Runtime values based on the trigger value for the binding contract.</returns>
        Dictionary<string, object> GetBindingData(TTriggerValue value);

        /// <summary>
        /// Bind as a single-item dispatch. 
        /// This gets called when somebody has a function like:
        ///     MyTrigger([Trigger] TMessage item)
        /// </summary>
        /// <param name="value">the trigger value</param>
        /// <param name="context">runtime binding information</param>
        /// <returns>the single message instance to bind to the user's function</returns>
        TMessage BindSingle(TTriggerValue value, ValueBindingContext context);

        /// <summary>
        /// Bind as a multiple-item dispatch. 
        /// This gets called when somebody has a function like:
        ///     MyTrigger([Trigger] TMessage[] items )
        /// </summary>
        /// <param name="value">the trigger value</param>
        /// <param name="context">runtime binding information</param>
        /// <returns>the batch of instances to bind to the user's function</returns>
        TMessage[] BindMultiple(TTriggerValue value, ValueBindingContext context);
    }
}