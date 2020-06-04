// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core.Serialization
{
    /// <summary>
    /// An optional, helper class for deserializing a digital twin.
    /// </summary>
    /// <example>
    /// Here's an example of  how to use the BasicDigitalTwin helper class to serialize and create a digital twin.
    ///
    /// <code snippet="Snippet:DigitalTwinsSampleCreateBasicTwin">
    /// // Create digital twin with component payload using the BasicDigitalTwin serialization helper
    ///
    /// var basicDigitalTwin = new BasicDigitalTwin
    /// {
    ///     Id = basicDtId
    /// };
    /// basicDigitalTwin.Metadata.ModelId = modelId;
    /// basicDigitalTwin.CustomProperties.Add(&quot;Prop1&quot;, &quot;Value1&quot;);
    /// basicDigitalTwin.CustomProperties.Add(&quot;Prop2&quot;, &quot;Value2&quot;);
    ///
    /// var componentMetadata = new ModelProperties();
    /// componentMetadata.Metadata.ModelId = componentModelId;
    /// componentMetadata.CustomProperties.Add(&quot;ComponentProp1&quot;, &quot;ComponentValue1&quot;);
    /// componentMetadata.CustomProperties.Add(&quot;ComponentProp2&quot;, &quot;ComponentValue2&quot;);
    ///
    /// basicDigitalTwin.CustomProperties.Add(&quot;Component1&quot;, componentMetadata);
    ///
    /// string basicDtPayload = JsonSerializer.Serialize(basicDigitalTwin);
    ///
    /// Response&lt;string&gt; createBasicDtResponse = await client.CreateDigitalTwinAsync(basicDtId, basicDtPayload);
    /// Console.WriteLine($&quot;Created digital twin {basicDtId} with response {createBasicDtResponse.GetRawResponse().Status}.&quot;);
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
    ///     var component1 = JsonSerializer.Deserialize&lt;IDictionary&lt;string, object&gt;&gt;(component1RawText);
    ///
    ///     Console.WriteLine($&quot;Retrieved and deserialized digital twin {basicDt.Id}  with ETag {basicDt.ETag} &quot; +
    ///         $&quot;and Prop1 &apos;{basicDt.CustomProperties[&quot;Prop1&quot;]}&apos;, Prop2 &apos;{basicDt.CustomProperties[&quot;Prop2&quot;]}&apos;, &quot; +
    ///         $&quot;ComponentProp1 &apos;{component1[&quot;ComponentProp1&quot;]}&apos;, ComponentProp2 &apos;{component1[&quot;ComponentProp2&quot;]}&apos;&quot;);
    /// }
    /// </code>
    /// </example>
    public class BasicDigitalTwin : ModelProperties
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
    }
}
