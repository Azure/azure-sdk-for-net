// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;

namespace System.ClientModel.Tests.Samples
{
    internal class ReadmeModelReaderWriter
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

        private class OutputModel : IJsonModel<OutputModel>
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

        private class InputModel : IJsonModel<InputModel>
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
}
