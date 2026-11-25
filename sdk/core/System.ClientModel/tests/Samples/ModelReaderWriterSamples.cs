// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace System.ClientModel.Tests.Samples;

internal class ModelReaderWriterSamples
{
    public void Write_Simple()
    {
        #region Snippet:Readme_Write_Simple
        InputModel model = new InputModel();
        BinaryData data = ModelReaderWriter.Write(model);
        #endregion
    }

    public void Read_Simple()
    {
        #region Snippet:Readme_Read_Simple
        string json = @"{
              ""x"": 1,
              ""y"": 2,
              ""z"": 3
            }";
        OutputModel? model = ModelReaderWriter.Read<OutputModel>(BinaryData.FromString(json));
        #endregion
    }

    public void Stj_Write_Simple()
    {
        #region Snippet:Readme_Stj_Write_Sample
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            Converters = { new JsonModelConverter() }
        };

        InputModel model = new InputModel();
        string data = JsonSerializer.Serialize(model);
        #endregion
    }

    public void Stj_Read_Simple()
    {
        #region Snippet:Readme_Stj_Read_Sample
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            Converters = { new JsonModelConverter() }
        };

        string json = @"{
              ""x"": 1,
              ""y"": 2,
              ""z"": 3
            }";
        OutputModel? model = JsonSerializer.Deserialize<OutputModel>(json, options);
        #endregion
    }

    public void Write_Proxy()
    {
        #region Snippet:Readme_Write_Proxy
        InputModel model = new InputModel();

        ModelReaderWriterOptions options = new ModelReaderWriterOptions("W");
        options.Proxies.Add(new InputModelProxy());

        // ResolveProxy returns the proxy if one is registered, otherwise the model itself.
        IJsonModel<InputModel> resolved = options.ResolveProxy((IJsonModel<InputModel>)model);
        BinaryData data = ((IPersistableModel<InputModel>)resolved).Write(options);
        #endregion
    }

    public void Read_Proxy()
    {
        #region Snippet:Readme_Read_Proxy
        string json = @"{
              ""x"": 1,
              ""y"": 2,
              ""z"": 3
            }";

        ModelReaderWriterOptions options = new ModelReaderWriterOptions("W");
        options.Proxies.Add(new OutputModelProxy());

        OutputModel? model = ModelReaderWriter.Read<OutputModel>(BinaryData.FromString(json), options);
        #endregion
    }

    public void Read_Proxy_Chain()
    {
        #region Snippet:Readme_Proxy_Chain
        string json = @"{
              ""x"": 1,
              ""y"": 2,
              ""z"": 3
            }";
        ModelReaderWriterOptions options = new ModelReaderWriterOptions("W");

        // Higher-priority proxy added first — consulted first in the chain
        options.Proxies.Add(new OutputModelProxyOverride());

        // Base library adds a fallback proxy
        options.Proxies.Add(new OutputModelProxy());

        OutputModel? model = ModelReaderWriter.Read<OutputModel>(BinaryData.FromString(json), options);
        #endregion
    }

    #region Snippet:Readme_Read_Proxy_ClassStub
    public class OutputModelProxy : ModelProxy<OutputModel>, IJsonModel<OutputModel>
    #endregion
    {
        void IJsonModel<OutputModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        OutputModel IJsonModel<OutputModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public override OutputModel Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public override BinaryData Write(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public override string GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }

    public class OutputModelProxyOverride : ModelProxy<OutputModel>, IJsonModel<OutputModel>
    {
        void IJsonModel<OutputModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        OutputModel IJsonModel<OutputModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public override OutputModel Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public override BinaryData Write(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public override string GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }

    #region Snippet:Readme_Write_Proxy_ClassStub
    public class InputModelProxy : ModelProxy<InputModel>, IJsonModel<InputModel>
    #endregion
    {
        void IJsonModel<InputModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        InputModel IJsonModel<InputModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public override InputModel Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public override BinaryData Write(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public override string GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }

    public void ModelReaderWriterContext_Usage()
    {
        var myObject = new MyPersistableModel();
        #region Snippet:ModelReaderWriterContext_Usage
        ModelReaderWriter.Write<MyPersistableModel>(myObject, ModelReaderWriterOptions.Json, MyProjectContext.Default);
        #endregion
    }

    #region Snippet:ModelReaderWriterContext_AttributeUsage
    [ModelReaderWriterBuildable(typeof(List<MyPersistableModel>))]
    [ModelReaderWriterBuildable(typeof(MyOtherPersistableModel))]
    #region Snippet:ModelReaderWriterContext_ContextClass
    public partial class MyContext : ModelReaderWriterContext { }
    #endregion
    #endregion

    #region Snippet:ModelReaderWriterContext_Example
    public partial class MyProjectContext : ModelReaderWriterContext { }
    #endregion

    private class MyOtherPersistableModel : IPersistableModel<MyOtherPersistableModel>
    {
        MyOtherPersistableModel IPersistableModel<MyOtherPersistableModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        string IPersistableModel<MyOtherPersistableModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        BinaryData IPersistableModel<MyOtherPersistableModel>.Write(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }

    public partial class MyProjectContext : ModelReaderWriterContext
    {
        public static MyProjectContext Default => new MyProjectContext();
    }

    private class MyPersistableModel : IPersistableModel<MyPersistableModel>
    {
        MyPersistableModel IPersistableModel<MyPersistableModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        string IPersistableModel<MyPersistableModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        BinaryData IPersistableModel<MyPersistableModel>.Write(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }

    public void ClientOptions_ModelProxies()
    {
        #region Snippet:Readme_ClientOptions_ModelProxies
        var clientOptions = new ClientPipelineOptions();
        clientOptions.ModelProxies.Add(new OutputModelProxy());
        // Pass clientOptions to the generated client constructor.
        #endregion
    }

    public void Conditional_Proxy_WithExplicitContext()
    {
        BaseModel model = new DerivedModel();
        #region Snippet:Readme_Proxy_Explicit_Context
        var options = new ModelReaderWriterOptions("J");
        options.Proxies.Add(new DerivedModelProxy());
        BinaryData data = ModelReaderWriter.Write(model, options, MyProjectContext.Default);
        #endregion
    }

    public void Conditional_Proxy_CopyForRequestBody()
    {
        var clientOptions = new ClientPipelineOptions();
        clientOptions.ModelProxies.Add(new DerivedModelProxy());
        BaseModel model = new DerivedModel();

        #region Snippet:Readme_Options_Copy_For_Body
        var options = new ModelReaderWriterOptions("J");
        foreach (ModelProxy proxy in clientOptions.ModelProxies)
        {
            options.Proxies.Add(proxy);
        }
        using BinaryContent content = BinaryContent.Create(model, options);
        #endregion
    }

    internal class BaseModel : IPersistableModel<BaseModel>
    {
        BaseModel IPersistableModel<BaseModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        string IPersistableModel<BaseModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        BinaryData IPersistableModel<BaseModel>.Write(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }

    internal class DerivedModel : BaseModel
    {
    }

    #region Snippet:Readme_Conditional_Proxy
    public class DerivedModelProxy : ModelProxy<BaseModel>, IJsonModel<BaseModel>
    {
        // Only handle if the JSON contains "kind": "derived"
        public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return doc.RootElement.TryGetProperty("kind", out var kind)
                && kind.GetString() == "derived";
        }

        public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            Utf8JsonReader copy = reader;
            using var doc = JsonDocument.ParseValue(ref copy);
            return doc.RootElement.TryGetProperty("kind", out var kind)
                && kind.GetString() == "derived";
        }

        public override bool CanHandle(BaseModel model, ModelReaderWriterOptions options) => model is DerivedModel;

        public override BaseModel Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return new DerivedModel();
        }

        BaseModel IJsonModel<BaseModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return new DerivedModel();
        }

        void IJsonModel<BaseModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            // options.ProxiedModel is the original DerivedModel being written.
            writer.WriteStartObject();
            writer.WriteString("kind", "derived");
            writer.WriteEndObject();
        }

        public override BinaryData Write(ModelReaderWriterOptions options) => BinaryData.FromString("{\"kind\":\"derived\"}");
        public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
    #endregion

    internal class Node : IJsonModel<Node>
    {
        public string Name { get; set; } = "";

        public Node? Child { get; set; }

        Node IJsonModel<Node>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        void IJsonModel<Node>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        Node IPersistableModel<Node>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        string IPersistableModel<Node>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        BinaryData IPersistableModel<Node>.Write(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }

    public class NodeProxy : ModelProxy<Node>, IJsonModel<Node>
    {
        #region Snippet:Readme_Nested_Proxy_Write
        void IJsonModel<Node>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            Node parent = (Node)options.ProxiedModel!;

            writer.WriteStartObject();
            writer.WritePropertyName("child");
            if (parent.Child is null)
            {
                writer.WriteNullValue();
            }
            else
            {
                options.ResolveProxy((IJsonModel<Node>)parent.Child).Write(writer, options);
            }

            // Use the captured parent: ProxiedModel may now refer to the child or be null.
            writer.WriteString("name", parent.Name);
            writer.WriteEndObject();
        }
        #endregion

        Node IJsonModel<Node>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public override Node Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public override string GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public override BinaryData Write(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }

    internal class OutputModel : IJsonModel<OutputModel>
    {
        OutputModel IJsonModel<OutputModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        OutputModel IPersistableModel<OutputModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        string IPersistableModel<OutputModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        void IJsonModel<OutputModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        BinaryData IPersistableModel<OutputModel>.Write(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }

    internal class InputModel : IJsonModel<InputModel>
    {
        void IJsonModel<InputModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        InputModel IJsonModel<InputModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        BinaryData IPersistableModel<InputModel>.Write(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        InputModel IPersistableModel<InputModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        string IPersistableModel<InputModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
