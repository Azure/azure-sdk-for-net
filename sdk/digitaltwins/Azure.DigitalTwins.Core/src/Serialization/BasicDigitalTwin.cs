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
    /// <code snippet="Snippet:DigitalTwinsSampleDigitalTwinsLifecycle">
    /// // Create digital twin with component payload using the BasicDigitalTwin serialization helper,
    /// // based on the model defined at https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples/DigitalTwinsClientSample/SamplesConstants.cs#L66.
    ///
    /// var basicTwin = new BasicDigitalTwin
    /// {
    ///     Id = &quot;basicDigitalTwin-123-Id&quot;,
    ///     Metadata = { ModelId = &quot;sampleModel-123-Id&quot; },
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
    /// Response&lt;string&gt; createBasicDtResponse = await client.CreateDigitalTwinAsync(&quot;basicDigitalTwin-123-Id&quot;, basicDtPayload);
    /// Console.WriteLine($&quot;Created digital twin with Id &apos;basicDigitalTwin-123-Id&apos;. Response status: {createBasicDtResponse.GetRawResponse().Status}.&quot;);
    ///
    /// // You can also get a digital twin and deserialize it into a BasicDigitalTwin.
    /// // It works well for basic stuff, but as you can see it gets more difficult when delving into
    /// // more complex properties, like components.
    ///
    /// Response&lt;string&gt; getBasicDtResponse = await client.GetDigitalTwinAsync(&quot;basicDigitalTwin-123-Id&quot;);
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
    ///
    /// // Alternatively, you can create your own custom data types to serialize and deserialize your digital twins.
    /// // By specifying your properties and types directly, it requires less code or knowledge of the type for
    /// // interaction.
    ///
    /// var customTwin = new CustomDigitalTwin
    /// {
    ///     Id = &quot;customDigitalTwin-123-Id&quot;,
    ///     Metadata = { ModelId = &quot;sampleModel-123-Id&quot; },
    ///     Prop1 = &quot;Prop1 val&quot;,
    ///     Prop2 = 987,
    ///     Component1 = new Component1
    ///     {
    ///         ComponentProp1 = &quot;Component prop1 val&quot;,
    ///         ComponentProp2 = 123,
    ///     }
    /// };
    /// string customDtPayload = JsonSerializer.Serialize(customTwin);
    ///
    /// Response&lt;string&gt; createCustomDtResponse = await client.CreateDigitalTwinAsync(&quot;customDigitalTwin-123-Id&quot;, customDtPayload);
    /// Console.WriteLine($&quot;Created digital twin with Id &apos;customDigitalTwin-123-Id&apos;. Response status: {createCustomDtResponse.GetRawResponse().Status}.&quot;);
    ///
    /// // Getting and deserializing a digital twin into a custom data type is extremely easy.
    /// // Custom types provide the best possible experience.
    /// Response&lt;string&gt; getCustomDtResponse = await client.GetDigitalTwinAsync(&quot;customDigitalTwin-123-Id&quot;);
    /// if (getCustomDtResponse.GetRawResponse().Status == (int)HttpStatusCode.OK)
    /// {
    ///     CustomDigitalTwin customDt = JsonSerializer.Deserialize&lt;CustomDigitalTwin&gt;(getCustomDtResponse.Value);
    ///     Console.WriteLine($&quot;Retrieved and deserialized digital twin {customDt.Id}:\n\t&quot; +
    ///         $&quot;ETag: {customDt.ETag}\n\t&quot; +
    ///         $&quot;Prop1: {customDt.Prop1}\n\t&quot; +
    ///         $&quot;Prop2: {customDt.Prop2}\n\t&quot; +
    ///         $&quot;ComponentProp1: {customDt.Component1.ComponentProp1}\n\t&quot; +
    ///         $&quot;ComponentProp2: {customDt.Component1.ComponentProp2}&quot;);
    /// }
    ///
    /// // Update Component1 by replacing the property ComponentProp1 value
    /// var componentUpdateUtility = new UpdateOperationsUtility();
    /// componentUpdateUtility.AppendReplaceOp(&quot;/ComponentProp1&quot;, &quot;Some new value&quot;);
    /// string updatePayload = componentUpdateUtility.Serialize();
    /// Response&lt;string&gt; response = await client.UpdateComponentAsync(&quot;customDigitalTwin-123-Id&quot;, &quot;Component1&quot;, updatePayload);
    /// Console.WriteLine($&quot;Updated component for digital twin with Id &apos;customDigitalTwin-123-Id&apos;. Response status: {response.GetRawResponse().Status}&quot;);
    ///
    /// // Get Component
    /// response = await client.GetComponentAsync(&quot;basicDigitalTwin-123-Id&quot;, SamplesConstants.ComponentPath);
    /// Console.WriteLine($&quot;Retrieved component for digital twin with Id &apos;basicDigitalTwin-123-Id&apos;. Response status: {response.GetRawResponse().Status}&quot;);
    ///
    /// // Clean up
    ///
    /// try
    /// {
    ///     await client.DeleteDigitalTwinAsync(&quot;basicDigitalTwin-123-Id&quot;);
    ///     await client.DeleteDigitalTwinAsync(&quot;customDigitalTwin-123-Id&quot;);
    /// }
    /// catch (RequestFailedException ex)
    /// {
    ///     Console.WriteLine($&quot;Failed to delete digital twin due to {ex}&quot;);
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
