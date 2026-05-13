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
        options.AddProxy(new InputModelProxy());

        BinaryData data = ModelReaderWriter.Write(model, options);
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
        options.AddProxy(new OutputModelProxy());

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

        // Base library registers a proxy
        options.AddProxy(new OutputModelProxy());

        // Consumer registers a higher-priority proxy — this one is used
        options.AddProxy(new OutputModelProxyOverride());

        OutputModel? model = ModelReaderWriter.Read<OutputModel>(BinaryData.FromString(json), options);
        #endregion
    }

    #region Snippet:Readme_Read_Proxy_ClassStub
    public class OutputModelProxy : ModelProxy<OutputModel>, IJsonModel<OutputModel>
    #endregion
    {
        public override bool CanHandle(OutputModel model) => true;

        void IJsonModel<OutputModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        OutputModel IJsonModel<OutputModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        protected override OutputModel PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        protected override string PersistableModelGetFormatFromOptionsCore(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }

    public class OutputModelProxyOverride : ModelProxy<OutputModel>, IJsonModel<OutputModel>
    {
        public override bool CanHandle(OutputModel model) => true;

        void IJsonModel<OutputModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        OutputModel IJsonModel<OutputModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        protected override OutputModel PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        protected override string PersistableModelGetFormatFromOptionsCore(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }

    #region Snippet:Readme_Write_Proxy_ClassStub
    public class InputModelProxy : ModelProxy<InputModel>, IJsonModel<InputModel>
    #endregion
    {
        public override bool CanHandle(InputModel model) => true;

        void IJsonModel<InputModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        InputModel IJsonModel<InputModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        protected override InputModel PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        protected override string PersistableModelGetFormatFromOptionsCore(ModelReaderWriterOptions options)
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
