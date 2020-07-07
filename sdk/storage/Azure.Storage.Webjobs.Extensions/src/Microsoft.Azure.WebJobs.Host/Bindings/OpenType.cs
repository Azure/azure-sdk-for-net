// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    // Ensures that Open Types match consistently 
    // For example, suppose we have a converter from T[] --> Widget<T>
    // We need to make sure that T is the same in both src and dest. 
    // So we have a "context" that is shared across both OpenTypes matches and it verifies consistency. 
    public class OpenTypeMatchContext
    {
        // The 'T' that the OpenType has matched against. 
        // We can only match against a single T. 
        internal Type _match;

        internal bool CheckArg(Type type)
        {
            if (_match == null)
            {
                _match = type;
                return true;
            }
            if (_match == type)
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// Placeholder to use with converter manager for describing generic types.
    /// Derived classes can override IsMatch to provide a constraint. 
    ///  OpenType matches any type. 
    ///  MyDerivedType matches any type where IsMatch(type) is true. 
    /// Also applies to generics such as: 
    ///  GenericClass&lt;OpenType&gt; 
    /// </summary>
    [DebuggerDisplay("{GetDisplayName()}")]
    public abstract class OpenType
    {
        /// <summary>
        /// Return true if and only if given type matches.
        /// If the OpenType represents an exact type, then this is just Type.Equals.
        /// </summary>
        /// <param name="type">Type to check</param>
        /// <returns></returns>
        public bool IsMatch(Type type)
        {
            var context = new OpenTypeMatchContext();
            return this.IsMatch(type, context);
        }

        /// <summary>
        /// Return true if and only if given type matches. 
        /// This is constrained by the current matching context. 
        /// If the OpenType represents an exact type, then this is just Type.Equals.
        /// </summary>
        /// <param name="type">Type to check</param>
        /// <returns></returns>
        public abstract bool IsMatch(Type type, OpenTypeMatchContext context);


        internal static bool IsOpenType<T>()
        {
            return typeof(OpenType).IsAssignableFrom(typeof(T));
        }

        public override bool Equals(object obj)
        {
            var other = obj as OpenType;
            if (other != null)
            {
                return this.GetDisplayName() == other.GetDisplayName();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.GetDisplayName().GetHashCode();
        }

        internal virtual string GetDisplayName()
        {
            return "?";
        }

        internal static OpenType FromType<T>()
        {
            return FromType(typeof(T));
        }

        internal static OpenType FromType(Type t)
        {
            if (t == typeof(OpenType) || t == typeof(object))
            {
                return new AnythingOpenType();
            }
            if (typeof(OpenType).IsAssignableFrom(t))
            {
                return (OpenType)Activator.CreateInstance(t);
            }

            if (t.IsArray)
            {
                var elementType = t.GetElementType();
                var innerType = FromType(elementType);
                if (innerType is ExactMatch)
                {
                    return new ExactMatch(t);
                }
                return new ArrayOpenType(innerType);
            }

            // Rewriter rule for generics so customers can say: IEnumerable<OpenType> 
            if (t.IsGenericType)
            {
                var outerType = t.GetGenericTypeDefinition();
                Type[] args = t.GetGenericArguments();
                if (args.Length == 1)
                {
                    var arg1 = FromType(args[0]);
                    if (arg1 is ExactMatch)
                    {
                        return new ExactMatch(t);
                    }
                    else 
                    {
                        return new SingleGenericArgOpenType(outerType, arg1);
                    }
                    // This is a concrete generic type, like IEnumerable<JObject>. No open types needed. 
                }
                else
                {
                    // Just to sanity check, make sure there's no OpenType buried in the argument. 
                    // This could be nested. IFoo<int, IBar<OpenType>>
                    foreach (var arg in args)
                    {
                        if (FromType(arg).GetType() != typeof(ExactMatch))
                        {
                            throw new NotSupportedException("Embedded Open Types are only supported for types with a single generic argument.");
                        }
                    }
                }
            }

            return new ExactMatch(t);
        }

        // Converter manager will automatically provide conversions for assignability. 
        // This OpenType is used by tooling. 
        internal class AssignableToOpenType : OpenType
        {
            private readonly Type _targetType;

            public AssignableToOpenType(Type targetType)
            {
                _targetType = targetType;
            }

            public override bool IsMatch(Type type, OpenTypeMatchContext context)
            {
                if (type == null)
                {
                    throw new ArgumentNullException(nameof(type));
                }
                if (ExactMatch.TypeToString(type) == ExactMatch.TypeToString(_targetType))
                {
                    return true;
                }

                // What if types are in different type universes?
                // Type is a concrete type. 
                if (_targetType.IsInterface)
                {
                    var iface = type.GetInterface(_targetType.FullName);
                    return iface != null;
                }
                
                // Fake types? 
                return false;
            }

            // Use C# covariance? 
            internal override string GetDisplayName()
            {
                return "+" + ExactMatch.TypeToString(_targetType);
            }
        }

        // Bind to any type.
        // Like 'T'
        private class AnythingOpenType : OpenType
        {
            public override bool IsMatch(Type type, OpenTypeMatchContext context)
            {
                return context.CheckArg(type);
            }
        }

        // Bind to an exact concrete Type. 
        internal class ExactMatch : OpenType
        {
            private readonly Type _type;
            public ExactMatch(Type type)
            {
                _type = type;
            }

            internal Type ExactType => _type;

            // Compare types across Type universes. 
            // Types may not both be reflection implementations. 
            public static bool TypeEquals(Type type1, Type type2)
            {
                return TypeToString(type1) == TypeToString(type2);
            }

            public override bool IsMatch(Type type, OpenTypeMatchContext context)
            {
                if (type == _type)
                {
                    return true;
                }

                if (_type.GetType() != type.GetType())
                {
                    // Doing a comparison across type-universes. Likely that:
                    // 'this._type' is a  real reflection type defined by the extension 
                    // parameter 'type' is a non-reflection implemeentation defined by the tooling.
                    // To compare equivalence across universes, compare by name. 
                    if (TypeEquals(type, _type))
                    {
                        return true;
                    }
                }
                return false;
            }

            internal override string GetDisplayName()
            {
                return TypeToString(_type);
            }
            public static string TypeToString(Type t)
            {
                if (t.IsByRef)
                {
                    var element = t.GetElementType();
                    return "out " + TypeToString(element);
                }
                if (t.IsArray)
                {
                    var element = t.GetElementType();
                    return TypeToString(element) + "[]";
                }
                if (t.IsGenericType)
                {
                    var def = t.GetGenericTypeDefinition();

                    string name = def.Name + "<";

                    int i = 0;
                    foreach (var arg in t.GetGenericArguments())
                    {
                        if (i > 0)
                        {
                            name += ",";
                        }

                        name += TypeToString(arg);
                        i++;
                    }
                    name += ">";
                    return name;
                }
                return t.Name;
            }
        }

        // Match a generic type with 1 generic arg. 
        // like IEnumerable<T>,  IQueryable<T>, etc. 
        internal class SingleGenericArgOpenType : OpenType
        {
            private readonly OpenType _inner;
            private readonly Type _outerType;

            public SingleGenericArgOpenType(Type outerType, OpenType inner)
            {
                _inner = inner;
                _outerType = outerType;
            }

            public override bool IsMatch(Type type, OpenTypeMatchContext context)
            {
                if (type == null)
                {
                    throw new ArgumentNullException(nameof(type));
                }
                if (context == null)
                {
                    throw new ArgumentNullException(nameof(context));
                }

                if (type.IsGenericType &&
                    ExactMatch.TypeEquals(type.GetGenericTypeDefinition(), _outerType))
                {
                    var args = type.GetGenericArguments();

                    return _inner.IsMatch(args[0], context);
                }

                return false;
            }
         
            internal override string GetDisplayName()
            {
                var name = _outerType.GetGenericTypeDefinition().Name;
                return name + "<" + _inner.GetDisplayName() + ">";
            }
        }


        // Matches any T& 
        internal class ByRefOpenType : OpenType
        {
            private readonly OpenType _inner;
            public ByRefOpenType(OpenType inner)
            {
                _inner = inner;
            }
            public override bool IsMatch(Type type, OpenTypeMatchContext context)
            {
                if (type == null)
                {
                    throw new ArgumentNullException(nameof(type));
                }
                if (type.IsByRef)
                {
                    var elementType = type.GetElementType();
                    return _inner.IsMatch(elementType, context);
                }
                return false;
            }

            internal override string GetDisplayName()
            {
                return _inner.GetDisplayName() + "&";
            }
        }
        // Matches any T[] 
        internal class ArrayOpenType : OpenType
        {
            private readonly OpenType _inner;
            public ArrayOpenType(OpenType inner)
            {
                _inner = inner;
            }

            public override bool IsMatch(Type type, OpenTypeMatchContext context)
            {
                if (type == null)
                {
                    throw new ArgumentNullException(nameof(type));
                }
                if (context == null)
                {
                    throw new ArgumentNullException(nameof(context));
                }
                
                if (type.IsArray)
                {
                    var elementType = type.GetElementType();
                    return _inner.IsMatch(elementType, context);
                }
                return false;
            }

            internal override string GetDisplayName()
            {
                return _inner.GetDisplayName() + "[]";
            }
        }
                 
        // Formalize definition of a "poco"
        // This can be used for general "T --> JObject" bindings. 
        // The exact definition here comes from the WebJobs v1.0 Queue binding.
        public class Poco : OpenType
        {
            public override bool IsMatch(Type type, OpenTypeMatchContext context)
            {
                if (type == null)
                {
                    throw new ArgumentNullException(nameof(type));
                }
                
                if (type.IsByRef)
                {
                    return false;
                }
                if (type.IsArray)
                {
                    return false;
                }

                if (type.IsPrimitive)
                {
                    return false;
                }
                if (type.FullName == "System.Object")
                {
                    return false;
                }
                if (type.GetInterface("System.IEnumerable`1") != null)
                {
                    return false;
                }
                if (type.GetInterface("System.IDisposable") != null)
                {
                    return false;
                }

                return true;
            }

            internal override string GetDisplayName()
            {
                return "Poco";
            }
        }
    }
}
