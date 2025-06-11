// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel.Snippets;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal class ResourceSerializationProvider : TypeProvider
    {
        private readonly FieldProvider _dataField;
        private readonly CSharpType _resourceDataType;
        private readonly ResourceClientProvider _resoruce;
        private readonly CSharpType _jsonModelInterfaceType;
        public ResourceSerializationProvider(ResourceClientProvider resource)
        {
            _resoruce = resource;
            _resourceDataType = resource.ResourceData.Type;
            _jsonModelInterfaceType = new CSharpType(typeof(IJsonModel<>), _resourceDataType);
            _dataField = new FieldProvider(FieldModifiers.Private | FieldModifiers.Static, _jsonModelInterfaceType, "s_dataDeserializationInstance", this);
        }

        protected override string BuildName() => _resoruce.Name;

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", $"{Name}.Serialization.cs");

        protected override TypeSignatureModifiers BuildDeclarationModifiers()
            => TypeSignatureModifiers.Public | TypeSignatureModifiers.Partial;

        protected override CSharpType[] BuildImplements() => [_jsonModelInterfaceType];

        protected override FieldProvider[] BuildFields() => [_dataField];

        protected override PropertyProvider[] BuildProperties() =>
            [
                new PropertyProvider(null, MethodSignatureModifiers.Private | MethodSignatureModifiers.Static, _jsonModelInterfaceType, "DataDeserializationInstance", new ExpressionPropertyBody(new AssignmentExpression(_dataField, New.Instance(_resourceDataType), true)), this)
            ];

        protected override MethodProvider[] BuildMethods()
        {
            var options = new ParameterProvider("options", $"The client options for reading and writing models.", typeof(ModelReaderWriterOptions));
            var iModelTInterface = new CSharpType(typeof(IPersistableModel<>), _resourceDataType);
            var data = new ParameterProvider("data", $"The binary data to be processed.", typeof(BinaryData));

            // void IJsonModel<T>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            var writer = new ParameterProvider("writer", $"The writer to serialize the model to.", typeof(Utf8JsonWriter));
            var jsonModelWriteMethod = new MethodProvider(
                new MethodSignature(nameof(IJsonModel<object>.Write), null, MethodSignatureModifiers.None, null, null, [writer, options], ExplicitInterface: _jsonModelInterfaceType),
                // => ((IJsonModel<T>)Data).Write(writer, options);
                new MemberExpression(null, "Data").CastTo(_jsonModelInterfaceType).Invoke(nameof(IJsonModel<object>.Write), writer, options),
                this);

            // T IJsonModel<T>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            var reader = new ParameterProvider("reader", $"The reader for deserializing the model.", typeof(Utf8JsonReader), isRef: true);
            var jsonModelCreatemethod = new MethodProvider(
                new MethodSignature(nameof(IJsonModel<object>.Create), null, MethodSignatureModifiers.None, _resourceDataType, null, [reader, options], ExplicitInterface: _jsonModelInterfaceType),
                // => DataDeserializationInstance.Create(reader, options);
                new MemberExpression(null, "DataDeserializationInstance").Invoke(nameof(IJsonModel<object>.Create), reader, options),
                this);

            // BinaryData IPersistableModel<T>.Write(ModelReaderWriterOptions options)
            var persistableWriteMethod = new MethodProvider(
                new MethodSignature(nameof(IPersistableModel<object>.Write), null, MethodSignatureModifiers.None, typeof(BinaryData), null, [options], ExplicitInterface: iModelTInterface),
                // => ModelReaderWriter.Write<ResourceData>(Data, options);
                Static(typeof(ModelReaderWriter)).Invoke("Write", [new MemberExpression(null, "Data"), options, ModelReaderWriterContextSnippets.Default], [_resourceDataType], false),
                this);

            // T IPersistableModel<T>.Create(BinaryData data, ModelReaderWriterOptions options)
            var persistableCreateMethod = new MethodProvider(
                new MethodSignature(nameof(IPersistableModel<object>.Create), null, MethodSignatureModifiers.None, _resourceDataType, null, [data, options], ExplicitInterface: iModelTInterface),
                // => ModelReaderWriter.Read<ResourceData>(new BinaryData(reader.ValueSequence));
                Static(typeof(ModelReaderWriter)).Invoke("Read", [data, options, ModelReaderWriterContextSnippets.Default], [_resourceDataType], false),
                this);

            // ModelReaderWriterFormat IPersistableModel<T>.GetFormatFromOptions(ModelReaderWriterOptions options)
            var persistableGetFormatMethod = new MethodProvider(
                new MethodSignature(nameof(IPersistableModel<object>.GetFormatFromOptions), null, MethodSignatureModifiers.None, typeof(string), null, [options], ExplicitInterface: iModelTInterface),
                // => DataDeserializationInstance.GetFormatFromOptions(options);
                new MemberExpression(null, "DataDeserializationInstance").Invoke(nameof(IPersistableModel<object>.GetFormatFromOptions), options),
                this);

            return [jsonModelWriteMethod, jsonModelCreatemethod, persistableWriteMethod, persistableCreateMethod, persistableGetFormatMethod];
        }
    }
}