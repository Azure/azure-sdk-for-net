// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;

namespace Azure.Core
{
    internal abstract class TypeBinder<TExchange>
    {
        public const string RequiresUnreferencedCodeMessage = "TypeBinder uses MakeGenericType() to construct generic types at runtime. The resulting types and their members may be trimmed. This can be suppressed if the target type to bind to is always a primitive.";
        public const string RequiresDynamicCodeMessage = "TypeBinder uses MakeGenericType() to construct generic types at runtime. This can be suppressed if the target type to bind to is always a primitive.";
        private readonly ConcurrentDictionary<Type, BoundTypeInfo> _cache = new();
        private readonly Func<Type, BoundTypeInfo> _valueFactory;

        [RequiresUnreferencedCode(RequiresUnreferencedCodeMessage)]
        [RequiresDynamicCode(RequiresDynamicCodeMessage)]
        protected TypeBinder()
        {
            _valueFactory = t => new(t, this);
        }

        [RequiresUnreferencedCode(RequiresUnreferencedCodeMessage)]
        [RequiresDynamicCode(RequiresDynamicCodeMessage)]
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
            return _cache.GetOrAdd(type, _valueFactory);
        }

        [RequiresUnreferencedCode(RequiresUnreferencedCodeMessage)]
        [RequiresDynamicCode(RequiresDynamicCodeMessage)]
        public BoundTypeInfo GetBinderInfo(Type type, Type interfaceType)
        {
            return _cache.GetOrAdd(type, t => new BoundTypeInfo(type, interfaceType, this));
        }

        protected abstract void Set<T>(TExchange destination, T value, BoundMemberInfo memberInfo);
        protected abstract bool TryGet<T>(BoundMemberInfo memberInfo, TExchange source, out T value);

        public class BoundTypeInfo
        {
            private readonly TypeBinder<TExchange> _binderImplementation;
            private bool _isPrimitive;
            private readonly BoundMemberInfo[] _members;

            [RequiresUnreferencedCode(RequiresUnreferencedCodeMessage)]
            [RequiresDynamicCode(RequiresDynamicCodeMessage)]
            public BoundTypeInfo(Type type, TypeBinder<TExchange> binderImplementation)
            {
                _binderImplementation = binderImplementation;
                _members = GetMembers(type).ToArray();
            }

            [RequiresUnreferencedCode(RequiresUnreferencedCodeMessage)]
            [RequiresDynamicCode(RequiresDynamicCodeMessage)]
            public BoundTypeInfo(Type type, Type interfaceType, TypeBinder<TExchange> binderImplementation)
            {
                if (!interfaceType.IsInterface || !interfaceType.IsAssignableFrom(type))
                {
                    throw new InvalidOperationException($"Either {interfaceType.Name} is not an interface or {interfaceType.Name} is not assignable from {type.Name}");
                }
                _binderImplementation = binderImplementation;
                _members = GetMembers(type).Union(GetMembers(interfaceType)).ToArray();
            }

            [RequiresUnreferencedCode(RequiresUnreferencedCodeMessage)]
            [RequiresDynamicCode(RequiresDynamicCodeMessage)]
            private List<BoundMemberInfo> GetMembers(Type type)
            {
                List<BoundMemberInfo> members = new List<BoundMemberInfo>();
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
                                members.Add((BoundMemberInfo) Activator.CreateInstance(typeof(BoundMemberInfo<>).MakeGenericType(typeof(TExchange), propertyInfo.PropertyType), propertyInfo));
                                break;
                            case FieldInfo fieldInfo:
                                members.Add((BoundMemberInfo) Activator.CreateInstance(typeof(BoundMemberInfo<>).MakeGenericType(typeof(TExchange), fieldInfo.FieldType), fieldInfo));
                                break;
                        }
                    }
                }
                return members;
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

            public T Deserialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] T>(TExchange source)
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

        protected abstract class BoundMemberInfo : IEqualityComparer<BoundMemberInfo>
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

            public bool Equals(BoundMemberInfo x, BoundMemberInfo y)
            {
                if (ReferenceEquals(x, y))
                    return true;
                if (x is null || y is null)
                    return false;
                return x.Name == y.Name;
            }

            public int GetHashCode(BoundMemberInfo other)
            {
                if (other is null)
                    return 0;

                return other.Name is null ? 0 : other.Name.GetHashCode();
            }
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
