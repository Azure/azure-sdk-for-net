// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core.Serialization
{
    /// <summary>
    /// An optional, helper class for deserializing a digital twin.
    /// </summary>
    /// <remarks>
    /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
    /// </remarks>
    /// <example>
    /// Here's an example of  how to use the BasicDigitalTwin helper class to serialize and create a digital twin.
    ///
    /// <code snippet="Snippet:DigitalTwinsSampleCreateBasicTwin">
    /// // Create digital twin with component payload using the BasicDigitalTwin serialization helper
    ///
    /// var basicTwin = new BasicDigitalTwin
    /// {
    ///     Id = basicDtId,
    ///     // model Id of digital twin
    ///     Metadata = { ModelId = modelId },
    ///     CustomProperties =
    ///     {
    ///         // digital twin properties
    ///         { &quot;Prop1&quot;, &quot;Value1&quot; },
    ///         { &quot;Prop2&quot;, 987 },
    ///         // component
    ///         {
    ///             &quot;Component1&quot;,
    ///             new ModelProperties
    ///             {
    ///                 // component properties
    ///                 CustomProperties =
    ///                 {
    ///                     { &quot;ComponentProp1&quot;, &quot;Component value 1&quot; },
    ///                     { &quot;ComponentProp2&quot;, 123 },
    ///                 },
    ///             }
    ///         },
    ///     },
    /// };
    ///
    /// string basicDtPayload = JsonSerializer.Serialize(basicTwin);
    ///
    /// Response&lt;string&gt; createBasicDtResponse = await client.CreateDigitalTwinAsync(basicDtId, basicDtPayload);
    /// Console.WriteLine($&quot;Created digital twin with Id {basicDtId}. Response status: {createBasicDtResponse.GetRawResponse().Status}.&quot;);
    /// </code>
    ///
    /// Here's an example of  how to use the BasicDigitalTwin helper class to get and deserialize a digital twin.
    ///
    /// <code snippet="Snippet:DigitalTwinsSampleGetBasicDigitalTwin">
    /// Response&lt;string&gt; getBasicDtResponse = await client.GetDigitalTwinAsync(basicDtId);
    /// if (getBasicDtResponse.GetRawResponse().Status == (int)HttpStatusCode.OK)
    /// {
    ///     BasicDigitalTwin basicDt = JsonSerializer.Deserialize&lt;BasicDigitalTwin&gt;(getBasicDtResponse.Value);
    ///
    ///     // Must cast Component1 as a JsonElement and get its raw text in order to deserialize it as a dictionary
    ///     string component1RawText = ((JsonElement)basicDt.CustomProperties[&quot;Component1&quot;]).GetRawText();
    ///     IDictionary&lt;string, object&gt; component1 = JsonSerializer.Deserialize&lt;IDictionary&lt;string, object&gt;&gt;(component1RawText);
    ///
    ///     Console.WriteLine($&quot;Retrieved and deserialized digital twin {basicDt.Id}:\n\t&quot; +
    ///         $&quot;ETag: {basicDt.ETag}\n\t&quot; +
    ///         $&quot;Prop1: {basicDt.CustomProperties[&quot;Prop1&quot;]}\n\t&quot; +
    ///         $&quot;Prop2: {basicDt.CustomProperties[&quot;Prop2&quot;]}\n\t&quot; +
    ///         $&quot;ComponentProp1: {component1[&quot;ComponentProp1&quot;]}\n\t&quot; +
    ///         $&quot;ComponentProp2: {component1[&quot;ComponentProp2&quot;]}&quot;);
    /// }
    /// </code>
    /// </example>
    public class BasicDigitalTwin
    {
        /// <summary>
        /// The unique Id of the digital twin in a digital twins instance. This field is present on every digital twin.
        /// </summary>
        [JsonPropertyName("$dtId")]
        public string Id { get; set; }

        /// <summary>
        /// A string representing a weak ETag for the entity that this request performs an operation against, as per RFC7232.
        /// </summary>
        [JsonPropertyName("$etag")]
        public string ETag { get; set; }

        /// <summary>
        /// Information about the model a digital twin conforms to. This field is present on every digital twin.
        /// </summary>
        [JsonPropertyName("$metadata")]
        public DigitalTwinMetadata Metadata { get; set; } = new DigitalTwinMetadata();

        /// <summary>
        /// Additional properties of the digital twin. This field will contain any properties of the digital twin that are not already defined by the other strong types of this class.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> CustomProperties { get; set; } = new Dictionary<string, object>();
    }
}
