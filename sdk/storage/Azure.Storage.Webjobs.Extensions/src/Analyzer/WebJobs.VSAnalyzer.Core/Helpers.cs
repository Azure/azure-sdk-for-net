// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Analyzer
{
    // Reflection-Roslyn Helpers.    
    static class Helpers
    {
        private static bool TryMapAssembly(IAssemblySymbol asm, out System.Reflection.Assembly asmRef)
        {
            asmRef = null;
#if false
            var t = typeof(Microsoft.Azure.WebJobs.BlobAttribute);
            var asmName = asm.Identity.Name;

            if (asmName == "Microsoft.Azure.WebJobs")
            {
                asmRef = t.Assembly; 
            }
            return (asmRef != null);
#else                        
            return AssemblyCache.Instance.TryMapAssembly(asm, out asmRef);
#endif
        }

        // Convert from a Roslyn Assembly reference to a .NET Reflection Assembly. 
        // This can't work on the user's source code (which may not even yet compile).
        // This is just used for references from the user's source code, 
        // specifically for getting the assemblies containing the WebJobs binding attributes so they can 
        // be passed off to the WebJobs analyzer. 
        private static Assembly MapAssembly(IAssemblySymbol asm)
        {
            Assembly asmRef;
            if (TryMapAssembly(asm, out asmRef))
            {
                return asmRef;
            }

            var asmName = asm.Identity.Name;
            throw new InvalidOperationException("Can't load assembly: " + asmName);
        }

        // Get a Reflection type from a Roslyn type. 
        // Throws on error. 
        private static Type GetAttributeType(ITypeSymbol symType)
        {
            IAssemblySymbol assemblySymbol = symType.ContainingAssembly;

            Assembly asmReflection = MapAssembly(assemblySymbol);

            var fullname = symType.GetFullMetadataName();

            var typeRef = asmReflection.GetType(fullname);

            return typeRef;
        }

        static string BindingAttributeNamespace = "Microsoft.Azure.WebJobs.Description";
        static string BindingAttributeName = nameof(Microsoft.Azure.WebJobs.Description.BindingAttribute);

        // Does the attribute have a [Binding] attribute on it? 
        private static bool IsBindingAttribute(INamedTypeSymbol attributeTypeSymbol)
        {
            var attr2 = attributeTypeSymbol.GetAttributes();
            foreach (AttributeData attributeData in attr2)
            {
                INamedTypeSymbol @class = attributeData.AttributeClass;
                var @namespace = @class.ContainingNamespace.ToString();
                var @name = @class.Name;

                // If "Binding", then ok. 
                if (name == BindingAttributeName && @namespace == BindingAttributeNamespace)
                {
                    return true;
                }
            }

            return false;
        }

        // Instantiate a binding attribute
        public static Attribute MakeAttr(IJobHostMetadataProvider tooling, SemanticModel semantics, AttributeSyntax attrSyntax)
        {
            IMethodSymbol symAttributeCtor = (IMethodSymbol) semantics.GetSymbolInfo(attrSyntax).Symbol;
            var syntaxParams = symAttributeCtor.Parameters;

            INamedTypeSymbol attrType = symAttributeCtor.ContainingType;

            if (!IsBindingAttribute(attrType))
            {
                return null;
            }            

            Type typeReflection = GetAttributeType(attrType);

            JObject args = new JObject();

            int idx = 0;
            if (attrSyntax.ArgumentList != null)
            {
                foreach (var arg in attrSyntax.ArgumentList.Arguments)
                {
                    var val = semantics.GetConstantValue(arg.Expression);
                    if (!val.HasValue)
                    {
                        return null;
                    }
                    var v2 = val.Value;

                    string argName = null;
                    if (arg.NameColon != null)
                    {
                        argName = arg.NameColon.Name.ToString();
                    }
                    else if (arg.NameEquals != null)
                    {
                        argName = arg.NameEquals.Name.ToString();
                    }
                    else
                    {
                        argName = syntaxParams[idx].Name; // Positional 
                    }

                    args[argName] = JToken.FromObject(v2);

                    idx++;
                }
            }

            var attr = tooling.GetAttribute(typeReflection, args);

            return attr;
        }
                             

        // https://stackoverflow.com/questions/27105909/get-fully-qualified-metadata-name-in-roslyn
        internal static string GetFullMetadataName(this INamespaceOrTypeSymbol symbol)
        {
            ISymbol s = symbol;
            var sb = new StringBuilder(s.MetadataName);

            var last = s;
            s = s.ContainingSymbol;
            while (!IsRootNamespace(s))
            {
                if (s is ITypeSymbol && last is ITypeSymbol)
                {
                    sb.Insert(0, '+');
                }
                else
                {
                    sb.Insert(0, '.');
                }
                sb.Insert(0, s.MetadataName);
                s = s.ContainingSymbol;
            }

            return sb.ToString();
        }

        // Try to convert a symbol in to a reflection type. 
        // Throw if can't convert. 
        private static Type MakeFakeType(ISymbol p2)
        {
            if (p2.Kind == SymbolKind.ErrorType)
            {
                // The IDE already has at least one error here that the type is undefined. 
                // So no value in trying to find additional possible WebJobs errors. 
                throw new InvalidOperationException("Error symbol. Can't convert symbol type:" + p2.ToString());
            }
            if (p2.Kind == SymbolKind.ArrayType)
            {
                IArrayTypeSymbol arrayType = p2 as IArrayTypeSymbol;
                var inner = arrayType.ElementType;

                var innerRef = MakeFakeType(inner);

                return innerRef.MakeArrayType();
            }

            if (p2.Kind == SymbolKind.NamedType)
            {
                string name = p2.Name;
                string @namespace = GetFullMetadataName(p2.ContainingNamespace);
                                
                var type = p2 as INamedTypeSymbol;

                if (type.IsGenericType)
                {
                    var typeArgs = new Type[type.TypeArguments.Length];
                    for(int i = 0; i < type.TypeArguments.Length; i++)
                    {
                        typeArgs[i] = MakeFakeType(type.TypeArguments[i]);
                    }

                    // Get Type Definition
                    var asm = p2.ContainingAssembly;

                    Type definition;
                    Assembly asmRef;
                    if (TryMapAssembly(asm, out asmRef))
                    {
                        // Reflection type. Important for unficiation with the binders
                        var metadataName = type.GetFullMetadataName();
                        definition = asmRef.GetType(metadataName);
                    } else
                    {
                        // User generic type. 
                        definition = new FakeType(@namespace, p2.MetadataName, type);
                    }

                    return new GenericFakeType(
                        definition, typeArgs);
                }

                Type result = new FakeType(@namespace, name, type);
         
                return result;
            }

            throw new InvalidOperationException("Can't convert symbol type:" + p2.ToString());
        }   

        private static bool IsRootNamespace(ISymbol s)
        {
            return s is INamespaceSymbol && ((INamespaceSymbol)s).IsGlobalNamespace;
        }

        // Get a Reflection adapter over the Roslyn symbol.
        // This does not actually load the type via the CLR Loader.
        // Return null on failure to create (likely a compiler error).
        public static Type GetParameterType(SyntaxNodeAnalysisContext context, ParameterSyntax parameterSyntax)
        {
            SymbolInfo parameterSymbol = context.SemanticModel.GetSymbolInfo(parameterSyntax.Type);
            ISymbol p2 = parameterSymbol.Symbol;

            if (p2 == null)
            {
                return null;
            }

            try
            {
                Type parameterType = Helpers.MakeFakeType(p2); // throws if can't convert. 

                if (parameterSyntax.IsOutParameter())
                {
                    parameterType = parameterType.MakeByRefType();
                }
                return parameterType;
            }
            catch
            {
                return null; // Likely a compiler error
            }
        }

        private static bool IsOutParameter(this ParameterSyntax syntax)
        {
            foreach(var mod in syntax.Modifiers)
            {
                if (mod.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.OutKeyword))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
