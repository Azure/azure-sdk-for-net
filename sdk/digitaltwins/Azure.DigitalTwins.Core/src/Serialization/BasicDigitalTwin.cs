// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core.Serialization
{
    /// <summary>
    /// An optional, helper class for deserializing a digital twin.
    /// </summary>
    /// <example>
    /// <code snippet="Snippet:DigitalTwinsSampleCreateBasicTwin">
    /// // Create digital twin with Component payload using the BasicDigitalTwin serialization helper
    ///
    /// var basicDigitalTwin = new BasicDigitalTwin();
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
    /// string dtPayload = JsonSerializer.Serialize(basicDigitalTwin, new JsonSerializerOptions { IgnoreNullValues = true });
    ///
    /// Response&lt;string&gt; createDtResponse = await DigitalTwinsClient.CreateDigitalTwinAsync(dtId, dtPayload).ConfigureAwait(false);
    /// Console.WriteLine($&quot;Created digital twin {dtId} with response {createDtResponse.GetRawResponse().Status}.&quot;);
    /// </code>
    /// </example>
    public class BasicDigitalTwin : ModelProperties
    {
        /// <summary>
        /// The unique Id of the digital twin in a digital twins instance. This field is present on every digital twin.
        /// </summary>
        [JsonPropertyName("$dtId")]
        public string Id { get; set; }
    }
}
