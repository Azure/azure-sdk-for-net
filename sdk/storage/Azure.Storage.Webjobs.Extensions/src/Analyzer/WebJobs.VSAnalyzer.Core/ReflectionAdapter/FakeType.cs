// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Analyzer
{
    // ToSTring() Microsoft.Azure.WebJobs.IAsyncCollector`1[System.String]

    // Represent an bound generic type like: 
    //   IEnumerable<string> 
    // definition is  IEnumerable`1, and TypeArgs are [string] 
    class GenericFakeType : FakeType
    {
        private readonly Type _typeDefinition; // This can be a real type
        private readonly Type[] _typeArgs;

        public GenericFakeType(Type typeDefinition, Type[] typeArgs)
            : base(null, null, null)
        {
            _typeDefinition = typeDefinition;
            _typeArgs = typeArgs;
        }

        public override bool IsGenericType => true;

        public override Type GetGenericTypeDefinition()
        {
            return _typeDefinition;
        }
        public override Type[] GetGenericArguments()
        {
            return _typeArgs; 
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_typeDefinition.Name);
            sb.Append('<');

            bool first = true;
            foreach(var x in _typeArgs)
            {
                if (!first)
                {
                    sb.Append(",");
                }
                first = false;
                sb.Append(x.ToString());
            }
            sb.Append('>');
            return sb.ToString();
        }
    }


    class ArrayType  : FakeType
    {
        private readonly Type _inner;
        public ArrayType(Type inner)
            : base( null, null, null)
        {
            _inner = inner;
        }

        protected override bool IsArrayImpl()
        {
            return true;
        }

        public override Type GetElementType()
        {
            return _inner;
        }

        public override string ToString()
        {
            return _inner + "[]";
        }
    }

    class ByRefType : FakeType
    {
        private readonly Type _inner;
        public ByRefType(Type inner)
            : base(null, null, null)
        {
            _inner = inner;
        }

        protected override bool IsByRefImpl()
        {
            return true;
        }

        public override Type GetElementType()
        {
            return _inner;
        }

        public override string ToString()
        {
            return _inner.ToString() + "&";
        }
    }


    class FakeType : Type
    {
        public override Guid GUID => throw new NotImplementedException();

        public override Module Module => throw new NotImplementedException();

        public override Assembly Assembly => throw new NotImplementedException();

        public override string FullName => _namespace + "." + _name;

        public override string Namespace => _namespace;

        public override string AssemblyQualifiedName => throw new NotImplementedException();

        public override Type BaseType => throw new NotImplementedException();

        public override Type UnderlyingSystemType => throw new NotImplementedException();

        public override string Name => _name;

        private string _name;
        private string _namespace;
        private readonly INamedTypeSymbol _typeSymbol;

        public FakeType(string ns, string name, INamedTypeSymbol typeSymbol)
        {
            _name = name;
            _namespace = ns;
            _typeSymbol = typeSymbol;
        }

        public override string ToString()
        {
            return _name;
        }
        public override bool IsGenericType => false;
        
        public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
        {
            throw new NotImplementedException();
        }

        public override object[] GetCustomAttributes(bool inherit)
        {
            throw new NotImplementedException();
        }

        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            throw new NotImplementedException();
        }

        public override Type GetElementType()
        {
            return null;
        }

        public override EventInfo GetEvent(string name, BindingFlags bindingAttr)
        {
            throw new NotImplementedException();
        }

        public override EventInfo[] GetEvents(BindingFlags bindingAttr)
        {
            throw new NotImplementedException();
        }

        public override FieldInfo GetField(string name, BindingFlags bindingAttr)
        {
            throw new NotImplementedException();
        }

        public override FieldInfo[] GetFields(BindingFlags bindingAttr)
        {
            throw new NotImplementedException();
        }

        public override Type GetInterface(string name, bool ignoreCase)
        {
            if (this._typeSymbol == null)
            {
                return null;
            }
            foreach(var iface in this._typeSymbol.AllInterfaces)
            {
                var fullname = Helpers.GetFullMetadataName(iface);
                if (name == fullname)
                {
                    string @namespace = Helpers.GetFullMetadataName(iface.ContainingNamespace);
                    return new FakeType(@namespace, iface.MetadataName, iface);
                }
            }

            return null;
        }

        public override Type[] GetInterfaces()
        {
            throw new NotImplementedException();
        }

        public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
        {
            throw new NotImplementedException();
        }

        public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
        {
            throw new NotImplementedException();
        }

        public override Type GetNestedType(string name, BindingFlags bindingAttr)
        {
            throw new NotImplementedException();
        }

        public override Type[] GetNestedTypes(BindingFlags bindingAttr)
        {
            throw new NotImplementedException();
        }

        public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
        {
            throw new NotImplementedException();
        }

        public override object InvokeMember(string name, BindingFlags invokeAttr, System.Reflection.Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
        {
            throw new NotImplementedException();
        }

        public override bool IsDefined(Type attributeType, bool inherit)
        {
            throw new NotImplementedException();
        }

        protected override TypeAttributes GetAttributeFlagsImpl()
        {
            throw new NotImplementedException();
        }

        protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, System.Reflection.Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotImplementedException();
        }

        protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, System.Reflection.Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotImplementedException();
        }

        protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, System.Reflection.Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotImplementedException();
        }

        protected override bool HasElementTypeImpl()
        {
            throw new NotImplementedException();
        }

        protected override bool IsArrayImpl()
        {
            return false;
        }

        protected override bool IsByRefImpl()
        {
            return false;
        }

        protected override bool IsCOMObjectImpl()
        {
            throw new NotImplementedException();
        }

        protected override bool IsPointerImpl()
        {
            throw new NotImplementedException();
        }

        protected override bool IsPrimitiveImpl()
        {
            if (_namespace == "System")
            {
                // https://msdn.microsoft.com/en-us/library/system.type.isprimitive%28v=vs.110%29.aspx
                if (_name == "Boolean" ||
                    _name == "Byte" || 
                    _name == "SByte" || 
                    _name == "Int16" ||
                    _name == "Int32" ||
                    _name == "Int64" || 
                    _name == "UInt32" || 
                    _name == "UInt16" || 
                    _name == "UInt64" || 
                    _name == "IntPtr" || 
                    _name == "UIntPtr" || 
                    _name == "Char" || 
                    _name == "Double" || 
                    _name == "Single")
                {
                    return true;
                }
            }
            return false;
        }

        public override Type MakeByRefType()
        {
            return new ByRefType(this);
        }

        public override Type MakeArrayType()
        {
            return new ArrayType(this);
        }
    }
}
