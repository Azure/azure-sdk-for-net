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
    //
    // The [CodeGenSerialization] read hooks in DataFactoryExpressionSerialization also call
    // ModelReaderWriter.Read for the concrete Azure.Core.Expressions.DataFactory types
    // DataFactoryLinkedServiceReference, DataFactorySecret (abstract, proxied by UnknownSecret) and
    // DataFactorySecretString. These types live in a referenced assembly, so the source generator
    // does not emit builders for them into this assembly's context and [ModelReaderWriterBuildable]
    // is ignored for cross-assembly types. We therefore register them manually as well. Because
    // IPersistableModel<out T> is covariant, an instance of any concrete subtype satisfies the
    // framework's IPersistableModel<object> requirement; its Create(BinaryData, options) performs the
    // (polymorphic, for DataFactorySecret) deserialization.
    public partial class AzureResourceManagerDataFactoryContext : ModelReaderWriterContext
    {
        // UnknownSecret is the internal [PersistableModelProxy] concrete type for the abstract
        // DataFactorySecret; resolve it via reflection from the same assembly as DataFactorySecret.
        private static readonly Type UnknownSecretType =
            typeof(DataFactorySecret).Assembly.GetType("Azure.Core.Expressions.DataFactory.UnknownSecret", throwOnError: true)!;

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

            factories[typeof(DataFactoryLinkedServiceReference)] =
                () => new PersistableModelBuilder(typeof(DataFactoryLinkedServiceReference), typeof(DataFactoryLinkedServiceReference));
            factories[typeof(DataFactorySecretString)] =
                () => new PersistableModelBuilder(typeof(DataFactorySecretString), typeof(DataFactorySecretString));
            factories[typeof(DataFactorySecret)] =
                () => new PersistableModelBuilder(typeof(DataFactorySecret), UnknownSecretType);
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

        // Builder for concrete IPersistableModel types whose constructors are internal. BuilderType is
        // the type requested by ModelReaderWriter; instanceType is the concrete type to instantiate
        // (equal to BuilderType, except for the abstract DataFactorySecret which uses its UnknownSecret proxy).
        private sealed class PersistableModelBuilder : ModelReaderWriterTypeBuilder
        {
            private readonly Type _builderType;
            private readonly Type _instanceType;

            public PersistableModelBuilder(Type builderType, Type instanceType)
            {
                _builderType = builderType;
                _instanceType = instanceType;
            }

            protected override Type BuilderType => _builderType;

            protected override object CreateInstance() => Activator.CreateInstance(_instanceType, nonPublic: true)!;
        }
    }
}
