// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Azure.DigitalTwins.Core.Serialization;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// An optional, helper class for deserializing a digital twin.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This helper class will only work with <see cref="System.Text.Json"/>. When used with the <see cref="Azure.Core.Serialization.ObjectSerializer"/>,
    /// parameter to <see cref="DigitalTwinsClientOptions" /> it will only work with the default (<see cref="Azure.Core.Serialization.JsonObjectSerializer"/>).
    /// </para>
    /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
    /// </remarks>
    /// <example>
    /// Here's an example of  how to use the BasicDigitalTwin helper class to serialize and create a digital twin.
    ///
    /// <code snippet="Snippet:DigitalTwinsSampleCreateBasicTwin" language="csharp">
    /// // Create digital twin with component payload using the BasicDigitalTwin serialization helper
    ///
    /// var basicTwin = new BasicDigitalTwin
    /// {
    ///     Id = basicDtId,
    ///     // model Id of digital twin
    ///     Metadata =
    ///     {
    ///         ModelId = modelId,
    ///         PropertyMetadata = new Dictionary&lt;string, DigitalTwinPropertyMetadata&gt;
    ///         {
    ///             {
    ///                 &quot;Prop2&quot;,
    ///                 new DigitalTwinPropertyMetadata
    ///                 {
    ///                     // must always be serialized as ISO 8601
    ///                     SourceTime = DateTimeOffset.UtcNow,
    ///                 }
    ///             }
    ///         },
    ///     },
    ///     Contents =
    ///     {
    ///         // digital twin properties
    ///         { &quot;Prop1&quot;, &quot;Value1&quot; },
    ///         { &quot;Prop2&quot;, 987 },
    ///         // component
    ///         {
    ///             &quot;Component1&quot;,
    ///             new BasicDigitalTwinComponent
    ///             {
    ///                 // writeable component metadata
    ///                 Metadata =  new Dictionary&lt;string, DigitalTwinPropertyMetadata&gt;
    ///                 {
    ///                     {
    ///                         &quot;ComponentProp2&quot;,
    ///                         new DigitalTwinPropertyMetadata
    ///                         {
    ///                             // must always be serialized as ISO 8601
    ///                             SourceTime = DateTimeOffset.UtcNow,
    ///                         }
    ///                     }
    ///                 },
    ///                 // component properties
    ///                 Contents =
    ///                 {
    ///                     { &quot;ComponentProp1&quot;, &quot;Component value 1&quot; },
    ///                     { &quot;ComponentProp2&quot;, 123 },
    ///                 },
    ///             }
    ///         },
    ///     },
    /// };
    ///
    /// Response&lt;BasicDigitalTwin&gt; createDigitalTwinResponse = await client.CreateOrReplaceDigitalTwinAsync(basicDtId, basicTwin);
    /// Console.WriteLine($&quot;Created digital twin &apos;{createDigitalTwinResponse.Value.Id}&apos;.&quot;);
    /// </code>
    ///
    /// Here's an example of  how to use the BasicDigitalTwin helper class to get and deserialize a digital twin.
    ///
    /// <code snippet="Snippet:DigitalTwinsSampleGetBasicDigitalTwin" language="csharp">
    /// Response&lt;BasicDigitalTwin&gt; getBasicDtResponse = await client.GetDigitalTwinAsync&lt;BasicDigitalTwin&gt;(basicDtId);
    /// BasicDigitalTwin basicDt = getBasicDtResponse.Value;
    ///
    /// // Must cast Component1 as a JsonElement and get its raw text in order to deserialize it as a dictionary
    /// string component1RawText = ((JsonElement)basicDt.Contents[&quot;Component1&quot;]).GetRawText();
    /// var component1 = JsonSerializer.Deserialize&lt;BasicDigitalTwinComponent&gt;(component1RawText);
    ///
    /// Console.WriteLine($&quot;Retrieved and deserialized digital twin {basicDt.Id}:\n\t&quot; +
    ///     $&quot;ETag: {basicDt.ETag}\n\t&quot; +
    ///     $&quot;ModelId: {basicDt.Metadata.ModelId}\n\t&quot; +
    ///     $&quot;LastUpdatedOn: {basicDt.LastUpdatedOn}\n\t&quot; +
    ///     $&quot;Prop1: {basicDt.Contents[&quot;Prop1&quot;]}, last updated on {basicDt.Metadata.PropertyMetadata[&quot;Prop1&quot;].LastUpdatedOn}\n\t&quot; +
    ///     $&quot;Prop2: {basicDt.Contents[&quot;Prop2&quot;]}, last updated on {basicDt.Metadata.PropertyMetadata[&quot;Prop2&quot;].LastUpdatedOn} and sourced at {basicDt.Metadata.PropertyMetadata[&quot;Prop2&quot;].SourceTime}\n\t&quot; +
    ///     $&quot;Component1.LastUpdatedOn: {component1.LastUpdatedOn}\n\t&quot; +
    ///     $&quot;Component1.Prop1: {component1.Contents[&quot;ComponentProp1&quot;]}, last updated on: {component1.Metadata[&quot;ComponentProp1&quot;].LastUpdatedOn}\n\t&quot; +
    ///     $&quot;Component1.Prop2: {component1.Contents[&quot;ComponentProp2&quot;]}, last updated on: {component1.Metadata[&quot;ComponentProp2&quot;].LastUpdatedOn} and sourced at: {component1.Metadata[&quot;ComponentProp2&quot;].SourceTime}&quot;);
    /// </code>
    /// </example>
    [JsonConverter(typeof(BasicDigitalTwinJsonConverter))]
    public class BasicDigitalTwin
    {
        /// <summary>
        /// The unique Id of the digital twin in a digital twins instance. This field is present on every digital twin.
        /// </summary>
        [JsonPropertyName(DigitalTwinsJsonPropertyNames.DigitalTwinId)]
        public string Id { get; set; }

        /// <summary>
        /// A string representing a weak ETag for the entity that this request performs an operation against, as per RFC7232.
        /// </summary>
        [JsonPropertyName(DigitalTwinsJsonPropertyNames.DigitalTwinETag)]
        [JsonConverter(typeof(OptionalETagConverter))] // TODO: Remove when #16272 is fixed
        public ETag? ETag { get; set; }

        /// <summary>
        /// The date and time the twin was last updated.
        /// </summary>
        [JsonPropertyName(DigitalTwinsJsonPropertyNames.MetadataLastUpdateTime)]
        public DateTimeOffset? LastUpdatedOn { get; internal set; }

        /// <summary>
        /// Information about the model a digital twin conforms to.
        /// This field is present on every digital twin.
        /// </summary>
        [JsonPropertyName(DigitalTwinsJsonPropertyNames.DigitalTwinMetadata)]
        public DigitalTwinMetadata Metadata { get; set; } = new DigitalTwinMetadata();

        /// <summary>
        /// This field will contain properties and components as defined in the contents section of the DTDL definition of the twin.
        /// </summary>
        /// <remarks>
        /// If the property is a component, use the <see cref="BasicDigitalTwinComponent"/> class to deserialize the payload.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleGetBasicDigitalTwin" language="csharp">
        /// Response&lt;BasicDigitalTwin&gt; getBasicDtResponse = await client.GetDigitalTwinAsync&lt;BasicDigitalTwin&gt;(basicDtId);
        /// BasicDigitalTwin basicDt = getBasicDtResponse.Value;
        ///
        /// // Must cast Component1 as a JsonElement and get its raw text in order to deserialize it as a dictionary
        /// string component1RawText = ((JsonElement)basicDt.Contents[&quot;Component1&quot;]).GetRawText();
        /// var component1 = JsonSerializer.Deserialize&lt;BasicDigitalTwinComponent&gt;(component1RawText);
        ///
        /// Console.WriteLine($&quot;Retrieved and deserialized digital twin {basicDt.Id}:\n\t&quot; +
        ///     $&quot;ETag: {basicDt.ETag}\n\t&quot; +
        ///     $&quot;ModelId: {basicDt.Metadata.ModelId}\n\t&quot; +
        ///     $&quot;LastUpdatedOn: {basicDt.LastUpdatedOn}\n\t&quot; +
        ///     $&quot;Prop1: {basicDt.Contents[&quot;Prop1&quot;]}, last updated on {basicDt.Metadata.PropertyMetadata[&quot;Prop1&quot;].LastUpdatedOn}\n\t&quot; +
        ///     $&quot;Prop2: {basicDt.Contents[&quot;Prop2&quot;]}, last updated on {basicDt.Metadata.PropertyMetadata[&quot;Prop2&quot;].LastUpdatedOn} and sourced at {basicDt.Metadata.PropertyMetadata[&quot;Prop2&quot;].SourceTime}\n\t&quot; +
        ///     $&quot;Component1.LastUpdatedOn: {component1.LastUpdatedOn}\n\t&quot; +
        ///     $&quot;Component1.Prop1: {component1.Contents[&quot;ComponentProp1&quot;]}, last updated on: {component1.Metadata[&quot;ComponentProp1&quot;].LastUpdatedOn}\n\t&quot; +
        ///     $&quot;Component1.Prop2: {component1.Contents[&quot;ComponentProp2&quot;]}, last updated on: {component1.Metadata[&quot;ComponentProp2&quot;].LastUpdatedOn} and sourced at: {component1.Metadata[&quot;ComponentProp2&quot;].SourceTime}&quot;);
        /// </code>
        /// </example>
#pragma warning disable CA2227 // Collection properties should be readonly

        [JsonExtensionData]
        public IDictionary<string, object> Contents { get; set; } = new Dictionary<string, object>();

#pragma warning restore CA2227 // Collection properties should be readonly
    }
}
