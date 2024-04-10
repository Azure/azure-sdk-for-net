namespace Azure.SameBoundary.RoundTrip
{
    public partial class JsonMergePatchClient
    {
        protected JsonMergePatchClient() { }
        public JsonMergePatchClient(System.Uri endpoint) { }
        public JsonMergePatchClient(System.Uri endpoint, Azure.SameBoundary.RoundTrip.JsonMergePatchClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DummyOperation(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DummyOperationAsync(Azure.RequestContext context = null) { throw null; }
    }
    public partial class JsonMergePatchClientOptions : Azure.Core.ClientOptions
    {
        public JsonMergePatchClientOptions(Azure.SameBoundary.RoundTrip.JsonMergePatchClientOptions.ServiceVersion version = Azure.SameBoundary.RoundTrip.JsonMergePatchClientOptions.ServiceVersion.V1_1) { }
        public enum ServiceVersion
        {
            V1_1 = 1,
        }
    }
    public partial class RoundTripAddAnotherLevelToInheritanceModel : Azure.SameBoundary.RoundTrip.RoundTripInheritanceModel, System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripAddAnotherLevelToInheritanceModel>, System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripAddAnotherLevelToInheritanceModel>
    {
        public RoundTripAddAnotherLevelToInheritanceModel(int baseProperty2) : base (default(int)) { }
        public string AnotherLevelProperty { get { throw null; } set { } }
        Azure.SameBoundary.RoundTrip.RoundTripAddAnotherLevelToInheritanceModel System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripAddAnotherLevelToInheritanceModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripAddAnotherLevelToInheritanceModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SameBoundary.RoundTrip.RoundTripAddAnotherLevelToInheritanceModel System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripAddAnotherLevelToInheritanceModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripAddAnotherLevelToInheritanceModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripAddAnotherLevelToInheritanceModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoundTripArrayModel : System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripArrayModel>, System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripArrayModel>
    {
        public RoundTripArrayModel(System.Collections.Generic.IEnumerable<string> requiredStringArray, System.Collections.Generic.IEnumerable<int> requiredIntArray, System.Collections.Generic.IEnumerable<Azure.SameBoundary.RoundTrip.RoundTripDummy> requiredModelArray, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<Azure.SameBoundary.RoundTrip.RoundTripDummy>> requiredArrayArray, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, Azure.SameBoundary.RoundTrip.RoundTripDummy>> requiredDictionaryArray) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<Azure.SameBoundary.RoundTrip.RoundTripDummy>> OptionalArrayArray { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, Azure.SameBoundary.RoundTrip.RoundTripDummy>> OptionalDictionaryArray { get { throw null; } }
        public System.Collections.Generic.IList<int> OptionalIntArray { get { throw null; } }
        public System.Collections.Generic.IList<Azure.SameBoundary.RoundTrip.RoundTripDummy> OptionalModelArray { get { throw null; } }
        public System.Collections.Generic.IList<string> OptionalStringArray { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<Azure.SameBoundary.RoundTrip.RoundTripDummy>> RequiredArrayArray { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, Azure.SameBoundary.RoundTrip.RoundTripDummy>> RequiredDictionaryArray { get { throw null; } }
        public System.Collections.Generic.IList<int> RequiredIntArray { get { throw null; } }
        public System.Collections.Generic.IList<Azure.SameBoundary.RoundTrip.RoundTripDummy> RequiredModelArray { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredStringArray { get { throw null; } }
        Azure.SameBoundary.RoundTrip.RoundTripArrayModel System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripArrayModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripArrayModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SameBoundary.RoundTrip.RoundTripArrayModel System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripArrayModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripArrayModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripArrayModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoundTripBaseModel : System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripBaseModel>, System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripBaseModel>
    {
        public RoundTripBaseModel(int baseProperty2) { }
        public string BaseProperty1 { get { throw null; } set { } }
        public int BaseProperty2 { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> BaseProperty3 { get { throw null; } }
        Azure.SameBoundary.RoundTrip.RoundTripBaseModel System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripBaseModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripBaseModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SameBoundary.RoundTrip.RoundTripBaseModel System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripBaseModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripBaseModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripBaseModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoundTripDictionaryModel : System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripDictionaryModel>, System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripDictionaryModel>
    {
        public RoundTripDictionaryModel(System.Collections.Generic.IDictionary<string, string> requiredStringDictionary, System.Collections.Generic.IDictionary<string, int?> requiredIntDictionary, System.Collections.Generic.IDictionary<string, Azure.SameBoundary.RoundTrip.RoundTripDummy> requiredModelDictionary, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.SameBoundary.RoundTrip.RoundTripDummy>> requiredDictionaryDictionary, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.SameBoundary.RoundTrip.RoundTripDummy>> requiredArrayDictionary) { }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.SameBoundary.RoundTrip.RoundTripDummy>> OptionalArrayDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.SameBoundary.RoundTrip.RoundTripDummy>> OptionalDictionaryDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, int?> OptionalIntDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.SameBoundary.RoundTrip.RoundTripDummy> OptionalModelDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> OptionalStringDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.SameBoundary.RoundTrip.RoundTripDummy>> RequiredArrayDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.SameBoundary.RoundTrip.RoundTripDummy>> RequiredDictionaryDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, int?> RequiredIntDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.SameBoundary.RoundTrip.RoundTripDummy> RequiredModelDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> RequiredStringDictionary { get { throw null; } }
        Azure.SameBoundary.RoundTrip.RoundTripDictionaryModel System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripDictionaryModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripDictionaryModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SameBoundary.RoundTrip.RoundTripDictionaryModel System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripDictionaryModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripDictionaryModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripDictionaryModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoundTripDummy : System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripDummy>, System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripDummy>
    {
        public RoundTripDummy() { }
        public string Property { get { throw null; } set { } }
        Azure.SameBoundary.RoundTrip.RoundTripDummy System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripDummy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripDummy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SameBoundary.RoundTrip.RoundTripDummy System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripDummy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripDummy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripDummy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoundTripInheritanceModel : Azure.SameBoundary.RoundTrip.RoundTripBaseModel, System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripInheritanceModel>, System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripInheritanceModel>
    {
        public RoundTripInheritanceModel(int baseProperty2) : base (default(int)) { }
        public string ExtendedProperty { get { throw null; } set { } }
        Azure.SameBoundary.RoundTrip.RoundTripInheritanceModel System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripInheritanceModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripInheritanceModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SameBoundary.RoundTrip.RoundTripInheritanceModel System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripInheritanceModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripInheritanceModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripInheritanceModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoundTripNestedModel : System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripNestedModel>, System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripNestedModel>
    {
        public RoundTripNestedModel(Azure.SameBoundary.RoundTrip.RoundTripDummy requiredModel) { }
        public Azure.SameBoundary.RoundTrip.RoundTripDummy OptionalModel { get { throw null; } set { } }
        public Azure.SameBoundary.RoundTrip.RoundTripDummy RequiredModel { get { throw null; } set { } }
        Azure.SameBoundary.RoundTrip.RoundTripNestedModel System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripNestedModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripNestedModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SameBoundary.RoundTrip.RoundTripNestedModel System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripNestedModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripNestedModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripNestedModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoundTripPrimitiveModel : System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripPrimitiveModel>, System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripPrimitiveModel>
    {
        public RoundTripPrimitiveModel(string requiredString, int requiredInt) { }
        public int? OptionalInt { get { throw null; } set { } }
        public string OptionalString { get { throw null; } set { } }
        public int RequiredInt { get { throw null; } set { } }
        public string RequiredString { get { throw null; } set { } }
        Azure.SameBoundary.RoundTrip.RoundTripPrimitiveModel System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripPrimitiveModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.RoundTrip.RoundTripPrimitiveModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SameBoundary.RoundTrip.RoundTripPrimitiveModel System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripPrimitiveModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripPrimitiveModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.RoundTrip.RoundTripPrimitiveModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class SameBoundaryRoundTripClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.SameBoundary.RoundTrip.JsonMergePatchClient, Azure.SameBoundary.RoundTrip.JsonMergePatchClientOptions> AddJsonMergePatchClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.SameBoundary.RoundTrip.JsonMergePatchClient, Azure.SameBoundary.RoundTrip.JsonMergePatchClientOptions> AddJsonMergePatchClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
