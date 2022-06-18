// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using Azure.Data.Tables;

namespace Azure.Core
{
    internal abstract class TypeBinder<TExchange>
    {
        private readonly ConcurrentDictionary<Type, BoundTypeInfo> _cache = new();
        private Func<Type, BoundTypeInfo> _valueFactory;
        //Since ITableEntity is intrinsic to the correct operation of types in table storage, we need to track these specially in case they
        //are implemented on the exchange type in a way that's not directly visible through TExchange.
        //Most often, this is due to an explicit interface implementation, which is common in F# and may be present in other scenarios
        //migrating from other table storage SDKs.
        //NOTE: this functionality is only triggered bindITableEntityProperties is true
        private static readonly PropertyInfo s_iTableEntityPartitionKey = typeof(ITableEntity).GetProperty(nameof(ITableEntity.PartitionKey)) ?? throw new InvalidOperationException($"Could not find property {nameof(ITableEntity.PartitionKey)}");
        private static readonly PropertyInfo s_iTableEntityRowKey = typeof(ITableEntity).GetProperty(nameof(ITableEntity.RowKey)) ?? throw new InvalidOperationException($"Could not find property {nameof(ITableEntity.RowKey)}");
        private static readonly PropertyInfo s_iTableEntityETag = typeof(ITableEntity).GetProperty(nameof(ITableEntity.ETag)) ?? throw new InvalidOperationException($"Could not find property {nameof(ITableEntity.ETag)}");
        private static readonly PropertyInfo s_iTableEntityTimestamp = typeof(ITableEntity).GetProperty(nameof(ITableEntity.Timestamp)) ?? throw new InvalidOperationException($"Could not find property {nameof(ITableEntity.Timestamp)}");

        protected TypeBinder(bool bindITableEntityProperties)
        {
            _valueFactory = t => new(t, this, bindITableEntityProperties);
        }

        public T Deserialize<T>(TExchange source)
        {
            var info = GetBinderInfo(typeof(T));
            return info.Deserialize<T>(source);
        }

        public void Serialize<T>(T value, TExchange destination)
        {
            var info = GetBinderInfo(typeof(T));
            info.Serialize(value, destination);
        }

        public void Serialize(object value, Type type, TExchange destination)
        {
            var info = GetBinderInfo(type);
            info.Serialize(value, destination);
        }

        public BoundTypeInfo GetBinderInfo(Type type)
        {
            return _cache.GetOrAdd(type,  _valueFactory);
        }

        protected abstract void Set<T>(TExchange destination, T value, BoundMemberInfo memberInfo);
        protected abstract bool TryGet<T>(BoundMemberInfo memberInfo, TExchange source, out T value);

        public class BoundTypeInfo
        {
            private readonly TypeBinder<TExchange> _binderImplementation;
            private readonly bool _isPrimitive;
            private readonly BoundMemberInfo[] _members;

            public BoundTypeInfo(Type type, TypeBinder<TExchange> binderImplementation, bool bindITableEntityProperties)
            {
                _binderImplementation = binderImplementation;
                Type innerType = type;
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    innerType = type.GetGenericArguments()[0];
                }

                _isPrimitive = innerType == typeof(string) ||
                               innerType == typeof(DateTimeOffset) ||
                               innerType == typeof(TimeSpan) ||
                               innerType == typeof(Guid) ||
                               innerType == typeof(decimal) ||
                               innerType.IsPrimitive;

                if (!_isPrimitive)
                {
                    bool foundPartitionKey = false;
                    bool foundRowKey = false;
                    bool foundETag = false;
                    bool foundTimeStamp = false;
                    List<BoundMemberInfo> members = new List<BoundMemberInfo>();
                    foreach (var memberInfo in type.GetMembers(BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (memberInfo.IsDefined(typeof(IgnoreDataMemberAttribute)))
                        {
                            continue;
                        }

                        switch (memberInfo)
                        {
                            case PropertyInfo propertyInfo:
                                if (propertyInfo.GetIndexParameters().Length > 0)
                                {
                                    continue;
                                }
                                //track whether we have found any of the special ITableEntity properties
                                if (memberInfo.Name == nameof(ITableEntity.PartitionKey))
                                    foundPartitionKey = true;
                                if (memberInfo.Name == nameof(ITableEntity.RowKey))
                                    foundRowKey = true;
                                if (memberInfo.Name == nameof(ITableEntity.ETag))
                                    foundETag = true;
                                if (memberInfo.Name == nameof(ITableEntity.Timestamp))
                                    foundTimeStamp = true;

                                members.Add((BoundMemberInfo) Activator.CreateInstance(typeof(BoundMemberInfo<>).MakeGenericType(typeof(TExchange), propertyInfo.PropertyType), propertyInfo));
                                break;
                            case FieldInfo fieldInfo:
                                members.Add((BoundMemberInfo) Activator.CreateInstance(typeof(BoundMemberInfo<>).MakeGenericType(typeof(TExchange), fieldInfo.FieldType), fieldInfo));
                                break;
                        }
                    }
                    //if the type implements ITableEntity, this is a declaration that it intends to participate
                    //in table storage as part of its binding. If we didn't find any of the ITableEntity properties,
                    //bind these to the interface so it works correctly.
                    //It should be noted that even prior to this change, types could hide any of these with "same-named"
                    //properties, and they would be used instead of the actual implementations.
                    if (bindITableEntityProperties && typeof(ITableEntity).IsAssignableFrom(type))
                    {
                        if (!foundPartitionKey)
                            members.Add((BoundMemberInfo)Activator.CreateInstance(typeof(BoundMemberInfo<>).MakeGenericType(typeof(TExchange), s_iTableEntityPartitionKey.PropertyType), s_iTableEntityPartitionKey));
                        if (!foundRowKey)
                            members.Add((BoundMemberInfo)Activator.CreateInstance(typeof(BoundMemberInfo<>).MakeGenericType(typeof(TExchange), s_iTableEntityRowKey.PropertyType), s_iTableEntityRowKey));
                        if (!foundETag)
                            members.Add((BoundMemberInfo)Activator.CreateInstance(typeof(BoundMemberInfo<>).MakeGenericType(typeof(TExchange), s_iTableEntityETag.PropertyType), s_iTableEntityETag));
                        if (!foundTimeStamp)
                            members.Add((BoundMemberInfo)Activator.CreateInstance(typeof(BoundMemberInfo<>).MakeGenericType(typeof(TExchange), s_iTableEntityTimestamp.PropertyType), s_iTableEntityTimestamp));
                    }

                    _members = members.ToArray();
                }
            }

            public void Serialize<T>(T o, TExchange destination)
            {
                foreach (var member in _members)
                {
                    if (member.CanRead)
                    {
                        member.Serialize(o, destination, _binderImplementation);
                    }
                }
            }

            public T Deserialize<T>(TExchange source)
            {
                if (_isPrimitive)
                {
                    if (!_binderImplementation.TryGet(null, source, out T result))
                    {
                        throw new InvalidOperationException($"Unable to deserialize into a primitive type {typeof(T)}");
                    }

                    return result;
                }

                T o = Activator.CreateInstance<T>();
                foreach (var member in _members)
                {
                    if (member.CanWrite)
                    {
                        member.Deserialize(source, o, _binderImplementation);
                    }
                }

                return o;
            }

            public int MemberCount => _members?.Length ?? 0;
        }

        protected abstract class BoundMemberInfo
        {
            public BoundMemberInfo(MemberInfo memberInfo)
            {
                MemberInfo = memberInfo;
                Name = MemberInfo.Name;
                if (memberInfo.GetCustomAttribute<DataMemberAttribute>() is { Name: not null } dataMemberAttribute)
                {
                    Name = dataMemberAttribute.Name;
                }
            }

            public string Name { get; }
            public MemberInfo MemberInfo { get; }
            public abstract Type Type { get; }
            public abstract bool CanRead { get; }
            public abstract bool CanWrite { get; }
            public abstract void Serialize(object o, TExchange destination, TypeBinder<TExchange> binderImplementation);
            public abstract void Deserialize(TExchange source, object o, TypeBinder<TExchange> binderImplementation);
        }

        private delegate TProperty PropertyGetter<TProperty>(object o);

        private delegate void PropertySetter<TProperty>(object o, TProperty value);

        private sealed class BoundMemberInfo<TProperty> : BoundMemberInfo
        {
            private static ParameterExpression InputParameter = Expression.Parameter(typeof(object), "input");
            private static ParameterExpression ValueParameter = Expression.Parameter(typeof(TProperty), "value");

            public BoundMemberInfo(PropertyInfo propertyInfo) : this(
                propertyInfo,
                propertyInfo.CanRead && propertyInfo.GetMethod?.IsPublic == true,
                propertyInfo.CanWrite && propertyInfo.SetMethod?.IsPublic == true,
                propertyInfo.PropertyType)
            {
            }

            public BoundMemberInfo(FieldInfo fieldInfo) : this(fieldInfo, true, !fieldInfo.IsInitOnly, fieldInfo.FieldType)
            {
            }

            private BoundMemberInfo(MemberInfo memberInfo, bool canRead, bool canWrite, Type type) : base(memberInfo)
            {
                Type = type;
                CanRead = canRead;
                CanWrite = canWrite;

                if (canRead)
                {
                    Getter = Expression.Lambda<PropertyGetter<TProperty>>(
                        Expression.MakeMemberAccess(Expression.Convert(InputParameter, memberInfo.DeclaringType), memberInfo),
                        InputParameter).Compile();
                }

                if (canWrite)
                {
                    Setter = Expression.Lambda<PropertySetter<TProperty>>(
                        Expression.Assign(
                            Expression.MakeMemberAccess(
                                Expression.Convert(InputParameter, memberInfo.DeclaringType),
                                memberInfo), ValueParameter),
                        InputParameter, ValueParameter).Compile();
                }
            }

            private PropertyGetter<TProperty> Getter { get; }
            private PropertySetter<TProperty> Setter { get; }

            public override Type Type { get; }
            public override bool CanRead { get; }
            public override bool CanWrite { get; }

            public override void Serialize(object o, TExchange destination, TypeBinder<TExchange> binderImplementation)
            {
                binderImplementation.Set(destination, Getter(o), this);
            }

            public override void Deserialize(TExchange source, object o, TypeBinder<TExchange> binderImplementation)
            {
                if (binderImplementation.TryGet(this, source, out TProperty value))
                {
                    Setter(o, value);
                }
            }
        }
    }
}
