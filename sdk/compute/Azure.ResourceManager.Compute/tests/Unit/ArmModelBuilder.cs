// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Tests.Unit
{
    // Prototype only: this type represents the intended public API.
    public sealed class ArmModelBuilder<T>
    {
        private readonly Dictionary<string, object> _values = new();
        private readonly T _model;
        private readonly IReadOnlyDictionary<string, string> _paths;

        private ArmModelBuilder(T model, IReadOnlyDictionary<string, string> paths)
        {
            _model = model;
            _paths = paths ?? throw new ArgumentNullException(nameof(paths));
        }

        public static ArmModelBuilder<T> For(IReadOnlyDictionary<string, string> paths) => new(default, paths);

        public static ArmModelBuilder<T> For(T model, IReadOnlyDictionary<string, string> paths) => new(model, paths);

        public ArmModelBuilder<T> Set<TValue>(Expression<Func<T, TValue>> property, TValue value)
        {
            if (property.Body is not MemberExpression { Member: PropertyInfo propertyInfo })
            {
                throw new ArgumentException("The expression must select a property.", nameof(property));
            }

            if (!_paths.TryGetValue(propertyInfo.Name, out string path))
            {
                throw new InvalidOperationException($"No JSON wire path was provided for {typeof(T).FullName}.{propertyInfo.Name}.");
            }

            _values.Add(path, value);
            return this;
        }

        public T Build(ModelReaderWriterContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            ModelJsonBuilder json = _model is null
                ? new ModelJsonBuilder()
                : new ModelJsonBuilder(ModelReaderWriter.Write(_model, ModelReaderWriterOptions.Json, context));

            foreach (KeyValuePair<string, object> item in _values)
            {
                switch (item.Value)
                {
                    case ResourceIdentifier id:
                        json.Set(Encoding.UTF8.GetBytes(item.Key), id.ToString());
                        break;
                    case ResourceType resourceType:
                        json.Set(Encoding.UTF8.GetBytes(item.Key), resourceType.ToString());
                        break;
                    case AzureLocation location:
                        json.Set(Encoding.UTF8.GetBytes(item.Key), location.ToString());
                        break;
                    case string stringValue:
                        json.Set(Encoding.UTF8.GetBytes(item.Key), stringValue);
                        break;
                    case int intValue:
                        json.Set(Encoding.UTF8.GetBytes(item.Key), intValue);
                        break;
                    default:
                        throw new NotSupportedException($"Values of type {item.Value.GetType()} are not supported.");
                }
            }

            return ModelReaderWriter.Read<T>(json.ToBinaryData(), ModelReaderWriterOptions.Json, context)!;
        }
    }
}
