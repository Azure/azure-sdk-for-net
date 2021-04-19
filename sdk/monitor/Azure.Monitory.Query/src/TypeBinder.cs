// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

#pragma warning disable SA1402

namespace Azure.Monitory.Query
{
    internal abstract class TypeBinder<TExchange>
    {
        private readonly ConcurrentDictionary<Type, BoundTypeInfo> _cache = new();

        public T Deserialize<T>(TExchange source)
        {
            var info = GetBinderInfo(typeof(T));
            var instance = Activator.CreateInstance<T>();
            info.Deserialize(source, instance, this);
            return instance;
        }

        public void Serialize<T>(T value, TExchange destination)
        {
            var info = GetBinderInfo(typeof(T));
            info.Serialize(value, destination, this);
        }

        private BoundTypeInfo GetBinderInfo(Type type)
        {
            return _cache.GetOrAdd(type, static t => new(t));
        }

        protected abstract void Set<T>(TExchange destination, T value, BoundMemberInfo memberInfo);
        protected abstract bool TryGet<T>(BoundMemberInfo memberInfo, TExchange source, out T value);

        private class BoundTypeInfo
        {
            public BoundTypeInfo(Type type)
            {
                List<BoundMemberInfo> members = new List<BoundMemberInfo>();
                foreach (var memberInfo in type.GetMembers(BindingFlags.Public | BindingFlags.Instance))
                {
                    switch (memberInfo)
                    {
                        case PropertyInfo propertyInfo:
                            members.Add((BoundMemberInfo) Activator.CreateInstance(typeof(BoundMemberInfo<>).MakeGenericType(typeof(TExchange), propertyInfo.PropertyType), propertyInfo));
                            break;
                        case FieldInfo fieldInfo:
                            members.Add((BoundMemberInfo) Activator.CreateInstance(typeof(BoundMemberInfo<>).MakeGenericType(typeof(TExchange), fieldInfo.FieldType), fieldInfo));
                            break;
                    }
                }

                Members = members.ToArray();
            }

            public BoundMemberInfo[] Members { get; }

            public void Serialize(object o, TExchange destination, TypeBinder<TExchange> binderImplementation)
            {
                foreach (var member in Members)
                {
                    if (member.CanRead)
                    {
                        member.Serialize(o, destination, binderImplementation);
                    }
                }
            }

            public void Deserialize(TExchange source, object o, TypeBinder<TExchange> binderImplementation)
            {
                foreach (var member in Members)
                {
                    if (member.CanWrite)
                    {
                        member.Deserialize(source, o, binderImplementation);
                    }
                }
            }
        }

        protected abstract class BoundMemberInfo
        {
            public BoundMemberInfo(MemberInfo memberInfo)
            {
                MemberInfo = memberInfo;
            }

            public string Name => MemberInfo.Name;
            public MemberInfo MemberInfo { get; }
            public abstract bool CanRead { get; }
            public abstract bool CanWrite { get; }
            public abstract void Serialize(object o, TExchange destination, TypeBinder<TExchange> binderImplementation);
            public abstract void Deserialize(TExchange source, object o, TypeBinder<TExchange> binderImplementation);
        }

        private delegate T PropertyGetter<T>(object o);

        private delegate void PropertySetter<T>(object o, T value);

        private sealed class BoundMemberInfo<T> : BoundMemberInfo
        {
            private static ParameterExpression InputParameter = Expression.Parameter(typeof(object), "input");
            private static ParameterExpression ValueParameter = Expression.Parameter(typeof(T), "value");

            public BoundMemberInfo(PropertyInfo propertyInfo) : this(propertyInfo, propertyInfo.CanRead, propertyInfo.CanWrite)
            {
            }

            public BoundMemberInfo(FieldInfo fieldInfo) : this(fieldInfo, true, !fieldInfo.IsInitOnly)
            {
            }

            private BoundMemberInfo(MemberInfo memberInfo, bool canRead, bool canWrite) : base(memberInfo)
            {
                CanRead = canRead;
                CanWrite = canWrite;

                if (canRead)
                {
                    Getter = Expression.Lambda<PropertyGetter<T>>(
                        Expression.MakeMemberAccess(Expression.Convert(InputParameter, memberInfo.DeclaringType), memberInfo),
                        InputParameter).Compile();
                }

                if (canWrite)
                {
                    Setter = Expression.Lambda<PropertySetter<T>>(
                        Expression.Assign(
                            Expression.MakeMemberAccess(
                                Expression.Convert(InputParameter, memberInfo.DeclaringType),
                                memberInfo), ValueParameter),
                        InputParameter, ValueParameter).Compile();
                }
            }

            private PropertyGetter<T> Getter { get; }
            private PropertySetter<T> Setter { get; }

            public override bool CanRead { get; }
            public override bool CanWrite { get; }

            public override void Serialize(object o, TExchange destination, TypeBinder<TExchange> binderImplementation)
            {
                binderImplementation.Set(destination, Getter(o), this);
            }

            public override void Deserialize(TExchange source, object o, TypeBinder<TExchange> binderImplementation)
            {
                if (binderImplementation.TryGet(this, source, out T value))
                {
                    Setter(o, value);
                }
            }
        }
    }
}