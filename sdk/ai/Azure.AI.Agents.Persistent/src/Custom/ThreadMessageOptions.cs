// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Azure.AI.Agents.Persistent;

namespace Azure.AI.Agents.Persistent
{
    /// <summary>
    /// Represents the options for creating or adding a message in an agent thread. This class provides
    /// convenient ways to specify the message role (e.g., user or assistant) and the message content,
    /// which can be either plain text or one or more structured content blocks (e.g., text, images).
    /// </summary>
    /// <remarks>
    /// This partial class builds on the generated code, offering two primary ways to define a message:
    /// <list type="bullet">
    ///   <item>
    ///     <description>A single string for simple textual content.</description>
    ///   </item>
    ///   <item>
    ///     <description>
    ///       A list of <see cref="MessageInputContentBlock"/> items for more advanced scenarios, such
    ///       as including multiple blocks of text, images, or other media.
    ///     </description>
    ///   </item>
    /// </list>
    /// </remarks>
    public partial class ThreadMessageOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThreadMessageOptions"/> class, setting
        /// the message content to a single, plain-text string.
        /// </summary>
        /// <param name="role">
        /// The role of the entity creating the message (e.g., user or agent).
        /// Valid values typically include <see cref="MessageRole.User"/> or <see cref="MessageRole.Agent"/>.
        /// </param>
        /// <param name="content">
        /// The plain-text content of the message. If <paramref name="content"/> is <c>null</c>,
        /// an <see cref="ArgumentNullException"/> is thrown.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="content"/> is <c>null</c>.</exception>
        /// <remarks>
        /// The string is internally converted into a <see cref="BinaryData"/> structure for further processing.
        /// This overload suits simple scenarios where only a single text block is needed.
        /// </remarks>
        public ThreadMessageOptions(MessageRole role, string content)
            : this(
                role,
                content is null
                    ? throw new ArgumentNullException(nameof(content))
                    : BinaryData.FromObjectAsJson(content))
        {
            // Calls the generated constructor (MessageRole, BinaryData).
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreadMessageOptions"/> class, converting
        /// one or more structured blocks into JSON and storing them as <see cref="Content"/>.
        /// </summary>
        /// <param name="role">
        /// The role of the entity creating the message (e.g., user or agent).
        /// Valid values typically include <see cref="MessageRole.User"/> or <see cref="MessageRole.Agent"/>.
        /// </param>
        /// <param name="contentBlocks">
        /// A collection of specialized content blocks (e.g., <see cref="MessageInputTextBlock"/>,
        /// <see cref="MessageInputImageFileBlock"/>, <see cref="MessageInputImageUriBlock"/>)
        /// that can include text, images, or other media.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="contentBlocks"/> is <c>null</c>.</exception>
        /// <remarks>
        /// Each block expresses a particular piece of message content or media. This overload is best for advanced
        /// scenarios where messages contain multiple text segments, embedded images, or a mix of different content types.
        /// </remarks>
        public ThreadMessageOptions(MessageRole role, IEnumerable<MessageInputContentBlock> contentBlocks)
            : this(
                role,
                contentBlocks is null
                    ? throw new ArgumentNullException(nameof(contentBlocks))
                    : SerializeContentBlocks(contentBlocks))
        {
            // Invokes the generated constructor (MessageRole, BinaryData).
        }

        /// <summary>
        /// Converts a collection of <see cref="MessageInputContentBlock"/> instances into
        /// a JSON array, storing the resulting JSON as <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="contentBlocks">The collection of content blocks to be serialized.</param>
        /// <returns>A <see cref="BinaryData"/> instance containing the JSON array.</returns>
        private static BinaryData SerializeContentBlocks(IEnumerable<MessageInputContentBlock> contentBlocks)
        {
            var jsonElements = new List<JsonElement>();

            foreach (MessageInputContentBlock block in contentBlocks)
            {
                using var memStream = new MemoryStream();

                // Convert the block into a JSON payload by writing to a MemoryStream.
                block.ToRequestContent().WriteTo(memStream, default);

                // Reset stream position to the beginning.
                memStream.Position = 0;

                // Parse to a JsonDocument, then clone the root element for safe reuse.
                using var tempDoc = JsonDocument.Parse(memStream);
                jsonElements.Add(tempDoc.RootElement.Clone());
            }

            // Serialize the array of JsonElements into a single BinaryData.
            return BinaryData.FromObjectAsJson(jsonElements);
        }

        /// <summary>
        /// Deserializes the underlying message content (stored as <see cref="BinaryData"/>) into a plain string.
        /// </summary>
        /// <returns>The original text string if the content was provided in that format; otherwise, a JSON parsing error may occur.</returns>
        /// <exception cref="System.Text.Json.JsonException">
        /// Thrown if the binary content cannot be deserialized as a string (e.g., it was originally a collection of blocks).
        /// </exception>
        /// <remarks>
        /// Use this method when you know or expect that <see cref="Content"/> was originally provided as a single plain-text string.
        /// For richer content, see <see cref="GetContentBlocks()"/>.
        /// </remarks>
        public string GetTextContent() => Content.ToObjectFromJson<string>();

        /// <summary>
        /// Deserializes the underlying message content (stored as <see cref="BinaryData"/>) into a
        /// collection of <see cref="MessageInputContentBlock"/> objects.
        /// </summary>
        /// <returns>
        /// A sequence of content blocks if the original data was supplied as multiple structured elements.
        /// </returns>
        /// <exception cref="System.Text.Json.JsonException">
        /// Thrown if the binary content cannot be deserialized as a collection of <see cref="MessageInputContentBlock"/>.
        /// </exception>
        /// <remarks>
        /// Use this method when you know or expect that <see cref="Content"/> was provided as
        /// one or more structured content blocks. If the message content was just a single string,
        /// this may cause a deserialization error.
        /// </remarks>
        public IEnumerable<MessageInputContentBlock> GetContentBlocks()
            => Content.ToObjectFromJson<IEnumerable<MessageInputContentBlock>>();
    }
}
