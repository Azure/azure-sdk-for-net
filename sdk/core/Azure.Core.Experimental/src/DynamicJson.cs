// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Azure.Core
{
    /// <summary>
    ///
    /// </summary>
    public class DynamicJson : IDynamicMetaObjectProvider
    {
        private readonly JsonElement? _element;
        private readonly JsonValueKind _kind;
        private Dictionary<string, DynamicJson>? _objectRepresentation;
        private List<DynamicJson> _listRepresentation;
        private object? _value;

        /// <summary>
        ///
        /// </summary>
        /// <param name="element"></param>
        protected DynamicJson(JsonElement element)
        {
            _element = element;
            _kind = element.ValueKind;
            element.ValueKind.
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static DynamicJson Parse(string json)
        {
            return Create(JsonDocument.Parse(json).RootElement);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static DynamicJson Create(JsonElement element)
        {
            return new DynamicJson(element);
        }
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public JsonElement AsJsonElement()
        {
            return _element;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            using var memoryStream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(memoryStream))
            {
                _element.WriteTo(writer);
            }
            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        /// <inheritdoc />
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter) => new MetaObject(parameter, this);

        private object GetValue(string propertyName)
        {
            if (propertyName == "Length" && _element.ValueKind == JsonValueKind.Array)
            {
                return _element.GetArrayLength();
            }

            if (_element.TryGetProperty(propertyName, out JsonElement element))
            {
                return new DynamicJson(element);
            }

            throw new InvalidOperationException($"Property {propertyName} not found");
        }

        private object GetValueAt(int index)
        {
            return new DynamicJson(_element[index]);
        }

        private object SetValueAt(int index, object value)
        {
            return new DynamicJson(_element[index]);
        }

        private object? ConvertTo(Type type)
        {
            Debug.Assert(type != null);

            if (type == typeof(IEnumerable))
            {
                return new Enumerable(this);
            }

            if (type == typeof(long))
            {
                return _element.GetInt64();
            }
            if (type == typeof(int))
            {
                return _element.GetInt32();
            }
            if (type == typeof(bool))
            {
                return _element.GetBoolean();
            }

            if (_element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            if (type == typeof(string))
            {
                return _element.GetString();
            }

            throw new InvalidOperationException($"Unknown type {type}");
        }

        private class MetaObject : DynamicMetaObject
        {
            internal MetaObject(Expression parameter, IDynamicMetaObjectProvider value) : base(parameter, BindingRestrictions.Empty, value)
            { }


            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                var targetObject = Expression.Convert(Expression, LimitType);
                var methodIplementation = typeof(DynamicJson).GetMethod(nameof(GetValue), BindingFlags.NonPublic | BindingFlags.Instance);
                var arguments = new Expression[] { Expression.Constant(binder.Name) };

                var getPropertyCall = Expression.Call(targetObject, methodIplementation, arguments);
                var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                DynamicMetaObject getProperty = new DynamicMetaObject(getPropertyCall, restrictions);
                return getProperty;
            }

            public override DynamicMetaObject BindConvert(ConvertBinder binder)
            {
                var sourceInstance = Expression.Convert(Expression, LimitType);
                var destinationType = binder.Type;
                var destinationTypeExpression = Expression.Constant(destinationType);

                var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);

                var methodIplementation = typeof(DynamicJson).GetMethod(nameof(ConvertTo), BindingFlags.NonPublic | BindingFlags.Instance);
                Expression expression = Expression.Call(sourceInstance, methodIplementation, new Expression[] { destinationTypeExpression });
                expression = Expression.Convert(expression, binder.Type);
                return new DynamicMetaObject(expression, restrictions);
            }

            public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes)
            {
                if (indexes.Length != 1) throw new InvalidOperationException();
                var index = indexes[0].Expression;

                var targetObject = Expression.Convert(Expression, LimitType);
                var methodIplementation = typeof(DynamicJson).GetMethod(nameof(GetValueAt), BindingFlags.NonPublic | BindingFlags.Instance);
                var arguments = new[] { index };

                var getPropertyCall = Expression.Call(targetObject, methodIplementation, arguments);
                var restrictions = binder.FallbackGetIndex(this, indexes).Restrictions; // TODO: all these restrictions are a hack. Tthey need to be cleaned up.
                DynamicMetaObject getProperty = new DynamicMetaObject(getPropertyCall, restrictions);
                return getProperty;
            }

            public override DynamicMetaObject BindSetIndex(SetIndexBinder binder, DynamicMetaObject[] indexes, DynamicMetaObject value)
            {

                if (indexes.Length != 1) throw new InvalidOperationException();
                var index = indexes[0].Expression;

                var targetObject = Expression.Convert(Expression, LimitType);
                var methodIplementation = typeof(DynamicJson).GetMethod(nameof(GetValueAt), BindingFlags.NonPublic | BindingFlags.Instance);
                var arguments = new[] { index };

                var getPropertyCall = Expression.Call(targetObject, methodIplementation, arguments);
                var restrictions = binder.FallbackSetIndex(this, indexes).Restrictions; // TODO: all these restrictions are a hack. Tthey need to be cleaned up.
                DynamicMetaObject getProperty = new DynamicMetaObject(getPropertyCall, restrictions);
                return getProperty;

                return base.BindSetIndex(binder, indexes, value);
            }
        }

        private class Enumerable: IEnumerable<DynamicJson>
        {
            private readonly DynamicJson _dynamicJson;

            public Enumerable(DynamicJson dynamicJson)
            {
                _dynamicJson = dynamicJson;
            }

            IEnumerator<DynamicJson> IEnumerable<DynamicJson>.GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public IEnumerator? GetEnumerator()
            {
                return new Enumerator(_dynamicJson);
            }
        }

        private class Enumerator: IEnumerator<DynamicJson>
        {
            private readonly DynamicJson _dynamicJson;
            private int _index = -1;

            public Enumerator(DynamicJson dynamicJson)
            {
                _dynamicJson = dynamicJson;
            }

            public bool MoveNext()
            {
                _index++;
                return _index < _dynamicJson._element.GetArrayLength();
            }

            public void Reset()
            {
                _index = -1;
            }

            object IEnumerator.Current => Current;

            public DynamicJson Current => new DynamicJson(_dynamicJson._element[_index]);

            public void Dispose()
            {
            }
        }
    }

}