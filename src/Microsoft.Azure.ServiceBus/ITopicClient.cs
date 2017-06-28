// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using Core;

    /// <summary>
    /// Interface used to access a Topic to perform run-time operations.
    /// </summary>
    /// <example>
    /// <code>
    /// // Create the TopicClient
    /// ITopicClient myTopicClient = new TopicClient(
    ///     serviceBusConnectionString,
    ///     topicName);
    ///
    /// // Send messages to topic
    /// List &lt;byte[]&gt; Issues = GetIssues();
    /// foreach (var issue in Issues)
    /// {
    ///    await myTopicClient.SendAsync(new Message(issue));
    /// }
    /// </code>
    /// </example>
    public interface ITopicClient : ISenderClient
    {
        /// <summary>
        /// Gets the name of the topic.
        /// </summary>
        string TopicName { get; }
    }
}