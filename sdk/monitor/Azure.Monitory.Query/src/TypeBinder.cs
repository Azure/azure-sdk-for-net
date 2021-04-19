// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;

#pragma warning disable SA1402

namespace Azure.Monitory.Query
{
    internal abstract class TypeBinder<TExchange>
    {
        private Dictionary<Type, BoundTypeInfo> _cache = new();

        public T Deserialize<T>(TExchange source, TypeBinder<TExchange> binderImplementation)
        {
            var info = GetBinderInfo(typeof(T));
            var instance = Activator.CreateInstance<T>();
            info.Deserialize(source, instance, binderImplementation);
            return instance;
        }

        public void Serialize<T>(T value, TExchange destination, TypeBinder<TExchange> binderImplementation)
        {
            var info = GetBinderInfo(typeof(T));
            info.Serialize(value, destination, binderImplementation);
        }

        private BoundTypeInfo GetBinderInfo(Type type)
        {
            if (!_cache.TryGetValue(type, out BoundTypeInfo info))
            {
                _cache[type] = info = new BoundTypeInfo(type);
            }

            return info;
        }


        public abstract void Set<T>(TExchange destination, T value, BoundMemberInfo memberInfo);
        public abstract bool TryGet<T>(BoundMemberInfo memberInfo, TExchange source,  out T value);
    }
    internal class BoundTypeInfo
    {
        public BoundTypeInfo(Type type)
        {
            List<BoundMemberInfo> members = new List<BoundMemberInfo>();
            foreach (var memberInfo in type.GetMembers(BindingFlags.Public | BindingFlags.Instance))
            {
                switch (memberInfo)
                {
                    case PropertyInfo propertyInfo:
                        members.Add((BoundMemberInfo) Activator.CreateInstance(typeof(BoundMemberInfo<>).MakeGenericType(propertyInfo.PropertyType), propertyInfo));
                        break;
                    case FieldInfo fieldInfo:
                        members.Add((BoundMemberInfo) Activator.CreateInstance(typeof(BoundMemberInfo<>).MakeGenericType(fieldInfo.FieldType), fieldInfo));
                        break;
                }
            }

            Members = members.ToArray();
        }

        public BoundMemberInfo[] Members { get; }

        public void Serialize<TExchange>(object o, TExchange destination, TypeBinder<TExchange> binderImplementation)
        {
            foreach (var member in Members)
            {
                if (member.CanRead)
                {
                    member.Serialize(o, destination, binderImplementation);
                }
            }
        }

        public void Deserialize<TExchange>(TExchange source, object o, TypeBinder<TExchange> binderImplementation)
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

    internal abstract class BoundMemberInfo
    {
        public BoundMemberInfo(MemberInfo memberInfo)
        {
            MemberInfo = memberInfo;
        }

        public string Name => MemberInfo.Name;
        public MemberInfo MemberInfo { get; }
        public abstract bool CanRead { get; }
        public abstract bool CanWrite { get; }
        public abstract void Serialize<TExchange>(object o, TExchange destination, TypeBinder<TExchange> binderImplementation);
        public abstract void Deserialize<TExchange>(TExchange source, object o, TypeBinder<TExchange> binderImplementation);
    }

    public delegate T PropertyGetter<T>(object o);
    public delegate void PropertySetter<T>(object o, T value);

    internal sealed class BoundMemberInfo<T>: BoundMemberInfo
    {
        public BoundMemberInfo(PropertyInfo propertyInfo) : base(propertyInfo)
        {
            Getter = o => (T) propertyInfo.GetValue(o);
            Setter = (o, v) => propertyInfo.SetValue(o, v);
            CanRead = propertyInfo.CanRead;
            CanWrite = propertyInfo.CanWrite;
        }

        public BoundMemberInfo(FieldInfo fieldInfo) : base(fieldInfo)
        {
            Getter = o => (T) fieldInfo.GetValue(o);
            Setter = (o, v) => fieldInfo.SetValue(o, v);
            CanWrite = !fieldInfo.IsInitOnly;
            CanRead = true;
        }

        private PropertyGetter<T> Getter { get; }

        private PropertySetter<T> Setter { get; }

        public override bool CanRead { get; }
        public override bool CanWrite { get; }

        public override void Serialize<TExchange>(object o, TExchange destination, TypeBinder<TExchange> binderImplementation)
        {
            binderImplementation.Set(destination, Getter(o), this);
        }

        public override void Deserialize<TExchange>(TExchange source, object o, TypeBinder<TExchange> binderImplementation)
        {
            if (binderImplementation.TryGet(this, source, out T value))
            {
                Setter(o, value);
            }
        }
    }
}