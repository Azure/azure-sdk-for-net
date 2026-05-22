// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Reflection;
using Azure.Core.Expressions.DataFactory;
using Azure.ResourceManager.DataFactory.Models;

namespace Azure.ResourceManager.DataFactory
{
    // The MPG-generated serialization code calls
    // ModelReaderWriter.Read<DataFactoryElement<T>>(..., AzureResourceManagerDataFactoryContext.Default)
    // for several T's. DataFactoryElement<> is an open-generic IPersistableModel and the
    // System.ClientModel source generator cannot produce builders for open generics, so we register
    // them manually here. The instance returned by CreateInstance only needs to implement
    // IPersistableModel<DataFactoryElement<T>>; framework will call its Create(BinaryData, options).
    public partial class AzureResourceManagerDataFactoryContext : ModelReaderWriterContext
    {
        partial void AddAdditionalFactories(Dictionary<Type, Func<ModelReaderWriterTypeBuilder>> factories)
        {
            AddDataFactoryElementBuilder<string>(factories);
            AddDataFactoryElementBuilder<int>(factories);
            AddDataFactoryElementBuilder<bool>(factories);
            AddDataFactoryElementBuilder<BinaryData>(factories);
            AddDataFactoryElementBuilder<IList<string>>(factories);
            AddDataFactoryElementBuilder<IDictionary<string, string>>(factories);
            AddDataFactoryElementBuilder<IList<DatasetDataElement>>(factories);
            AddDataFactoryElementBuilder<IList<DatasetSchemaDataElement>>(factories);
            AddDataFactoryElementBuilder<IList<Office365TableOutputColumn>>(factories);
        }

        private static void AddDataFactoryElementBuilder<T>(Dictionary<Type, Func<ModelReaderWriterTypeBuilder>> factories)
        {
            factories[typeof(DataFactoryElement<T>)] = () => new DataFactoryElementBuilder<T>();
        }

        private sealed class DataFactoryElementBuilder<T> : ModelReaderWriterTypeBuilder
        {
            protected override Type BuilderType => typeof(DataFactoryElement<T>);

            protected override object CreateInstance()
            {
                // DataFactoryElement<T> only has internal constructors; instantiate via reflection.
                var instance = (DataFactoryElement<T>)Activator.CreateInstance(
                    typeof(DataFactoryElement<T>),
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    binder: null,
                    args: new object[] { default(T)! },
                    culture: null);
                return instance;
            }
        }
    }
}
