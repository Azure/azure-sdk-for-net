// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;

namespace Azure.Core
{
    internal abstract class TypeBinder<TExchange>
    {
        private readonly ConcurrentDictionary<Type, BoundTypeInfo> _cache = new();
        private Func<Type, BoundTypeInfo> _valueFactory;
        //these are "other interfaces of interest" that we will use when binding
        private readonly List<Type> _otherInterfacesOfInterest = new();
        /// <summary>
        /// Call this from the constructor of a subclass to add additional interfaces of interest for binding
        /// </summary>
        /// <param name="interfaceType">An interface type whose properties will be bound if implemented explicitly</param>
        protected void AddInterfaceOfInterest(Type interfaceType)
        {
            if (!interfaceType.IsInterface)
                throw new ArgumentException("The type must be an interface", nameof(interfaceType));
            _otherInterfacesOfInterest.Add(interfaceType);
        }

        protected TypeBinder()
        {
            _valueFactory = t => new(t, this);
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

            public BoundTypeInfo(Type type, TypeBinder<TExchange> binderImplementation)
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
                    //Go through the "other interfaces of interest", and make a list of the property names we're interested in.
                    var memberNamesFromInterfaces = new Dictionary<string, bool>();
                    foreach (var iface in binderImplementation._otherInterfacesOfInterest)
                    {
                        foreach (var prop in iface.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                        {
                            memberNamesFromInterfaces.Add(prop.Name, false);
                        }
                    }
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
                                //if the name matches one of the members from our "other interfaces of interest", then note that we've found it
                                //NOTE: this only supports properties due to the nature of interfaces
                                if (memberNamesFromInterfaces.ContainsKey(memberInfo.Name))
                                    memberNamesFromInterfaces[memberInfo.Name] = true;
                                members.Add((BoundMemberInfo)Activator.CreateInstance(typeof(BoundMemberInfo<>).MakeGenericType(typeof(TExchange), propertyInfo.PropertyType), propertyInfo));
                                break;
                            case FieldInfo fieldInfo:
                                members.Add((BoundMemberInfo)Activator.CreateInstance(typeof(BoundMemberInfo<>).MakeGenericType(typeof(TExchange), fieldInfo.FieldType), fieldInfo));
                                break;
                        }
                    }
                    //for each of the "other interfaces of interest", we need to shore up any properties that are "missing"
                    //from the declared surface area of the type
                    foreach (var iface in binderImplementation._otherInterfacesOfInterest)
                    {
                        //if the interface isn't assignable from the type, ignore it
                        if (!iface.IsAssignableFrom(type))
                            continue;
                        foreach (var prop in iface.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                        {
                            //if we're still tracking the name, and we haven't found it, add it
                            if (memberNamesFromInterfaces.ContainsKey(prop.Name) && !memberNamesFromInterfaces[prop.Name])
                            {
                                members.Add((BoundMemberInfo)Activator.CreateInstance(typeof(BoundMemberInfo<>).MakeGenericType(typeof(TExchange), prop.PropertyType), prop));
                                //remove the name from what we're tracking so we don't collide with another interface
                                //NOTE: this means that the first interface with a property name "wins" (just like a property declared by type wins over explicit interfaces
                                memberNamesFromInterfaces.Remove(prop.Name);
                            }
                        }
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
