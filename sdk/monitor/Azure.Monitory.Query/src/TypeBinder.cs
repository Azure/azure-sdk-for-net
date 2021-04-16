// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;

#pragma warning disable SA1402

namespace Azure.Monitory.Query
{
    internal class TypeBinder
    {
        private Dictionary<Type, BoundTypeInfo> _cache = new();

        public T Deserialize<T>(IBinderImplementation binderImplementation)
        {
            var info = GetBinderInfo(typeof(T));
            var instance = Activator.CreateInstance<T>();
            info.Deserialize(instance, binderImplementation);
            return instance;
        }

        public void Serialize<T>(T value, IBinderImplementation binderImplementation)
        {
            var info = GetBinderInfo(typeof(T));
            info.Serialize(value, binderImplementation);
        }

        private BoundTypeInfo GetBinderInfo(Type type)
        {
            if (!_cache.TryGetValue(type, out BoundTypeInfo info))
            {
                _cache[type] = info = new BoundTypeInfo(type);
            }

            return info;
        }
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

        public void Serialize(object o, IBinderImplementation binderImplementation)
        {
            foreach (var member in Members)
            {
                member.Serialize(o, binderImplementation);
            }
        }

        public void Deserialize(object o, IBinderImplementation binderImplementation)
        {
            foreach (var member in Members)
            {
                member.Deserialize(o, binderImplementation);
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
        public bool CanRead { get; protected set; }
        public bool CanWrite { get; protected set; }
        public abstract void Serialize(object o, IBinderImplementation binderImplementation);
        public abstract void Deserialize(object o, IBinderImplementation binderImplementation);
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

        public override void Serialize(object o, IBinderImplementation binderImplementation)
        {
            binderImplementation.Set(Getter(o), this);
        }

        public override void Deserialize(object o, IBinderImplementation binderImplementation)
        {
            if (binderImplementation.TryGet<T>(this, out T value))
            {
                Setter(o, value);
            }
        }
    }

    internal interface IBinderImplementation
    {
        void Set<T>(T value, BoundMemberInfo memberInfo);
        bool TryGet<T>(BoundMemberInfo memberInfo, out T value);
    }
}