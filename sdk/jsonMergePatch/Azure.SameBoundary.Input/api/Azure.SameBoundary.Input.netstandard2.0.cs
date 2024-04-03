namespace Azure.SameBoundary.Input
{
    public partial class InputAddAnotherLevelToInheritanceModel : Azure.SameBoundary.Input.InputInheritanceModel, System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputAddAnotherLevelToInheritanceModel>, System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputAddAnotherLevelToInheritanceModel>
    {
        public InputAddAnotherLevelToInheritanceModel(int baseProperty2) : base (default(int)) { }
        public string AnotherLevelProperty { get { throw null; } set { } }
        Azure.SameBoundary.Input.InputAddAnotherLevelToInheritanceModel System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputAddAnotherLevelToInheritanceModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputAddAnotherLevelToInheritanceModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SameBoundary.Input.InputAddAnotherLevelToInheritanceModel System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputAddAnotherLevelToInheritanceModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputAddAnotherLevelToInheritanceModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputAddAnotherLevelToInheritanceModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputArrayModel : System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputArrayModel>, System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputArrayModel>
    {
        public InputArrayModel(System.Collections.Generic.IEnumerable<string> requiredStringArray, System.Collections.Generic.IEnumerable<int> requiredIntArray, System.Collections.Generic.IEnumerable<Azure.SameBoundary.Input.InputDummy> requiredModelArray, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<Azure.SameBoundary.Input.InputDummy>> requiredArrayArray, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, Azure.SameBoundary.Input.InputDummy>> requiredDictionaryArray) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<Azure.SameBoundary.Input.InputDummy>> OptionalArrayArray { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, Azure.SameBoundary.Input.InputDummy>> OptionalDictionaryArray { get { throw null; } }
        public System.Collections.Generic.IList<int> OptionalIntArray { get { throw null; } }
        public System.Collections.Generic.IList<Azure.SameBoundary.Input.InputDummy> OptionalModelArray { get { throw null; } }
        public System.Collections.Generic.IList<string> OptionalStringArray { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<Azure.SameBoundary.Input.InputDummy>> RequiredArrayArray { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, Azure.SameBoundary.Input.InputDummy>> RequiredDictionaryArray { get { throw null; } }
        public System.Collections.Generic.IList<int> RequiredIntArray { get { throw null; } }
        public System.Collections.Generic.IList<Azure.SameBoundary.Input.InputDummy> RequiredModelArray { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredStringArray { get { throw null; } }
        Azure.SameBoundary.Input.InputArrayModel System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputArrayModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputArrayModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SameBoundary.Input.InputArrayModel System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputArrayModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputArrayModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputArrayModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputBaseModel : System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputBaseModel>, System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputBaseModel>
    {
        public InputBaseModel(int baseProperty2) { }
        public string BaseProperty1 { get { throw null; } set { } }
        public int BaseProperty2 { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> BaseProperty3 { get { throw null; } }
        Azure.SameBoundary.Input.InputBaseModel System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputBaseModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputBaseModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SameBoundary.Input.InputBaseModel System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputBaseModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputBaseModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputBaseModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputDictionaryModel : System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputDictionaryModel>, System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputDictionaryModel>
    {
        public InputDictionaryModel(System.Collections.Generic.IDictionary<string, string> requiredStringDictionary, System.Collections.Generic.IDictionary<string, int> requiredIntDictionary, System.Collections.Generic.IDictionary<string, Azure.SameBoundary.Input.InputDummy> requiredModelDictionary, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.SameBoundary.Input.InputDummy>> requiredDictionaryDictionary, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.SameBoundary.Input.InputDummy>> requiredArrayDictionary) { }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.SameBoundary.Input.InputDummy>> OptionalArrayDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.SameBoundary.Input.InputDummy>> OptionalDictionaryDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, int> OptionalIntDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.SameBoundary.Input.InputDummy> OptionalModelDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> OptionalStringDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.SameBoundary.Input.InputDummy>> RequiredArrayDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.SameBoundary.Input.InputDummy>> RequiredDictionaryDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, int> RequiredIntDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.SameBoundary.Input.InputDummy> RequiredModelDictionary { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> RequiredStringDictionary { get { throw null; } }
        Azure.SameBoundary.Input.InputDictionaryModel System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputDictionaryModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputDictionaryModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SameBoundary.Input.InputDictionaryModel System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputDictionaryModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputDictionaryModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputDictionaryModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputDummy : System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputDummy>, System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputDummy>
    {
        public InputDummy() { }
        public string Property { get { throw null; } set { } }
        Azure.SameBoundary.Input.InputDummy System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputDummy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputDummy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SameBoundary.Input.InputDummy System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputDummy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputDummy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputDummy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputInheritanceModel : Azure.SameBoundary.Input.InputBaseModel, System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputInheritanceModel>, System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputInheritanceModel>
    {
        public InputInheritanceModel(int baseProperty2) : base (default(int)) { }
        public string ExtendedProperty { get { throw null; } set { } }
        Azure.SameBoundary.Input.InputInheritanceModel System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputInheritanceModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputInheritanceModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SameBoundary.Input.InputInheritanceModel System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputInheritanceModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputInheritanceModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputInheritanceModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputNestedModel : System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputNestedModel>, System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputNestedModel>
    {
        public InputNestedModel(Azure.SameBoundary.Input.InputDummy requiredModel) { }
        public Azure.SameBoundary.Input.InputDummy OptionalModel { get { throw null; } set { } }
        public Azure.SameBoundary.Input.InputDummy RequiredModel { get { throw null; } }
        Azure.SameBoundary.Input.InputNestedModel System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputNestedModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputNestedModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SameBoundary.Input.InputNestedModel System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputNestedModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputNestedModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputNestedModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputPrimitiveModel : System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputPrimitiveModel>, System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputPrimitiveModel>
    {
        public InputPrimitiveModel(string requiredString, int requiredInt) { }
        public int? OptionalInt { get { throw null; } set { } }
        public string OptionalString { get { throw null; } set { } }
        public int RequiredInt { get { throw null; } }
        public string RequiredString { get { throw null; } }
        Azure.SameBoundary.Input.InputPrimitiveModel System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputPrimitiveModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SameBoundary.Input.InputPrimitiveModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SameBoundary.Input.InputPrimitiveModel System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputPrimitiveModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputPrimitiveModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SameBoundary.Input.InputPrimitiveModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JsonMergePatchClient
    {
        protected JsonMergePatchClient() { }
        public JsonMergePatchClient(System.Uri endpoint) { }
        public JsonMergePatchClient(System.Uri endpoint, Azure.SameBoundary.Input.JsonMergePatchClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DummyOperation(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DummyOperationAsync(Azure.RequestContext context = null) { throw null; }
    }
    public partial class JsonMergePatchClientOptions : Azure.Core.ClientOptions
    {
        public JsonMergePatchClientOptions(Azure.SameBoundary.Input.JsonMergePatchClientOptions.ServiceVersion version = Azure.SameBoundary.Input.JsonMergePatchClientOptions.ServiceVersion.V1_1) { }
        public enum ServiceVersion
        {
            V1_1 = 1,
        }
    }
    public static partial class SameBoundaryInputModelFactory
    {
        public static Azure.SameBoundary.Input.InputAddAnotherLevelToInheritanceModel InputAddAnotherLevelToInheritanceModel(string baseProperty1 = null, int baseProperty2 = 0, System.Collections.Generic.IDictionary<string, string> baseProperty3 = null, string extendedProperty = null, string anotherLevelProperty = null) { throw null; }
        public static Azure.SameBoundary.Input.InputBaseModel InputBaseModel(string baseProperty1 = null, int baseProperty2 = 0, System.Collections.Generic.IDictionary<string, string> baseProperty3 = null) { throw null; }
        public static Azure.SameBoundary.Input.InputInheritanceModel InputInheritanceModel(string baseProperty1 = null, int baseProperty2 = 0, System.Collections.Generic.IDictionary<string, string> baseProperty3 = null, string extendedProperty = null) { throw null; }
        public static Azure.SameBoundary.Input.InputNestedModel InputNestedModel(Azure.SameBoundary.Input.InputDummy requiredModel = null, Azure.SameBoundary.Input.InputDummy optionalModel = null) { throw null; }
        public static Azure.SameBoundary.Input.InputPrimitiveModel InputPrimitiveModel(string requiredString = null, string optionalString = null, int requiredInt = 0, int? optionalInt = default(int?)) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class SameBoundaryInputClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.SameBoundary.Input.JsonMergePatchClient, Azure.SameBoundary.Input.JsonMergePatchClientOptions> AddJsonMergePatchClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.SameBoundary.Input.JsonMergePatchClient, Azure.SameBoundary.Input.JsonMergePatchClientOptions> AddJsonMergePatchClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
