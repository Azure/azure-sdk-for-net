using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.IO;
using System.Reflection;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using System.Linq;
using System.Collections.Generic;

namespace Redis.JsonRpc
{
    public static class ServiceFactory
    {
        public static void AddAllAssemblies(HashSet<string> set, Assembly assembly)
        {
            var location = assembly.Location;
            if (set.Contains(location))
            {
                return;
            }

            set.Add(location);
            foreach(var a in assembly.GetReferencedAssemblies())
            {
                AddAllAssemblies(set, Assembly.Load(a));
            }
        }

        public static QualifiedNameSyntax GetName(string[] name, int size)
            => size == 2 
                ? QualifiedName(IdentifierName(name[0]), IdentifierName(name[1]))
                : QualifiedName(GetName(name, size - 1), IdentifierName(name[size - 1]));

        public static T CreateService<T>()
            where T: class
        {
            var type = typeof(T);
            var name = typeof(T).FullName;
            var mockName = typeof(T).Name + "Mock";

            var parsedName = name.Split('.');
            SimpleBaseTypeSyntax nameTree;
            if (parsedName.Length == 1)
            {
                nameTree = SimpleBaseType(IdentifierName(parsedName[0]));
            }
            else
            {
                nameTree = SimpleBaseType(GetName(parsedName, parsedName.Length));
            }

            var class_ = ClassDeclaration(mockName)
                .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword)))
                .WithBaseList(BaseList(SingletonSeparatedList<BaseTypeSyntax>(
                    nameTree)));

            var compilationUnit = CompilationUnit()
                .WithMembers(SingletonList<MemberDeclarationSyntax>(class_));

            var typeAssembly = type.GetTypeInfo().Assembly;

            var set = new HashSet<string>();

            AddAllAssemblies(set, typeAssembly);

            var references = set
                .Select(a => MetadataReference.CreateFromFile(a))
                .ToArray();

            var assemblyName = mockName + ".dll";

            var t = compilationUnit.ToFullString();

            var compilation = CSharpCompilation.Create(
                assemblyName,
                syntaxTrees: new [] { compilationUnit.SyntaxTree },
                references: references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            Assembly assembly;
            var r = typeof(Assembly)
                .GetTypeInfo()
                .GetMethods()
                .First(m => m.Name == "Load" && m.GetParameters()[0].ParameterType == typeof(byte[]));
            using (var stream = new MemoryStream())
            {
                var compileResult = compilation.Emit(stream);
                assembly = (Assembly) r.Invoke(null, new object[] { stream.ToArray() });
            }

            var mockType = assembly.GetType(mockName);
            var x = Activator.CreateInstance(mockType);

            return (T) x;
        }
    }
}
