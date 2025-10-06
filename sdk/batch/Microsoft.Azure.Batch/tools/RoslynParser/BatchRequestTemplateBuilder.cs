// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace ProxyLayerParser
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.MSBuild;

    public static class BatchRequestTemplateBuilder
    {
        static void OnWorkspaceFailed(object sender, WorkspaceDiagnosticEventArgs e)
        {
            System.Console.WriteLine(e.Diagnostic.Message);
        }

        public static async Task<IEnumerable<BatchRequestGroup>> GetBatchRequestTemplatesAsync(string projectFilePath)
        {
            using (MSBuildWorkspace workspace = MSBuildWorkspace.Create())
            {
                workspace.WorkspaceFailed += OnWorkspaceFailed;
                workspace.SkipUnrecognizedProjects = false;
                Project p = await workspace.OpenProjectAsync(projectFilePath).ConfigureAwait(false);

                IDictionary<string, HashSet<MethodDeclarationSyntax>> methods = await GetOperationsMethods(p).ConfigureAwait(false);

                IEnumerable<BatchRequestGroup> groups = methods.Select(kvp => new BatchRequestGroup(kvp.Key, kvp.Value.Select(GetClassSignature)));

                return groups;
            }
        }

        private static async Task<IDictionary<string, HashSet<MethodDeclarationSyntax>>> GetOperationsMethods(Project project)
        {
            var compilation = await project.GetCompilationAsync().ConfigureAwait(false);
            OperationsMethodFinder operationsMethodFinder = new OperationsMethodFinder();

            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                operationsMethodFinder.Visit(await syntaxTree.GetRootAsync().ConfigureAwait(false));
            }

            return operationsMethodFinder.Methods;
        }

        private static bool IsFixedParameter(string identifierText)
        {
            return identifierText.Equals("customHeaders") ||
                identifierText.Equals("cancellationToken") ||
                identifierText.Equals("nextPageLink") ||
                identifierText.Equals("filePath") ||
                identifierText.EndsWith("Id") ||
                identifierText.EndsWith("Name") ||
                identifierText.Contains("thumbprint");
        }

        private static BatchRequestTypeGenerationInfo GetClassSignature(MethodDeclarationSyntax method)
        {
            string operationVerb = method.Identifier.Text.Replace("WithHttpMessagesAsync", string.Empty);

            //The methods which we are examining have a return type of "IAzureOperationResponse<Foo>" -- so we are extracting the "Foo" as the return type.
            TypeSyntax methodReturnSyntax = GetTaskTypeSyntax(method.ReturnType)?.TypeArgumentList.Arguments.Single();
            string methodReturnTypeName = RemoveCommonNameSpace(methodReturnSyntax).ToString();
            
            string optionsTypeName = method.ParameterList.Parameters.Single(parameter => parameter.Type.ToString().EndsWith("Options")).Type.ToString();

            //Select the parameter type based on excluding parameters which we know are not "body" types. For example we want to end up
            //selecting "AddPoolParameter" for the AddPool operation.
            var possibleBatchRequestParameterTypes = method.ParameterList.Parameters.Where(methodParameter =>
                !methodParameter.Type.ToString().Equals(optionsTypeName) &&
                !IsFixedParameter(methodParameter.Identifier.Text)
                ).Select(parameter => parameter.Type.ToString());

            string parameterTypeName = possibleBatchRequestParameterTypes.SingleOrDefault();

            return new BatchRequestTypeGenerationInfo(
                operationVerb,
                parameterTypeName,
                optionsTypeName,
                methodReturnTypeName);
        }

        private static TypeSyntax RemoveCommonNameSpace(TypeSyntax typeSyntax)
        {
            var qualifiedNameSyntax = typeSyntax as QualifiedNameSyntax;
            if(qualifiedNameSyntax != null)
            {
                return RemoveCommonNameSpace(qualifiedNameSyntax.Right);
            }
            
            var genericNameSyntax = typeSyntax as GenericNameSyntax;
            if (genericNameSyntax != null)
            {
                var  list = genericNameSyntax.TypeArgumentList.Arguments.Select(RemoveCommonNameSpace);
                return SyntaxFactory.GenericName(genericNameSyntax.Identifier, SyntaxFactory.TypeArgumentList(SyntaxFactory.SeparatedList(list)));
            }

            return typeSyntax;
        }

        private static GenericNameSyntax GetTaskTypeSyntax(TypeSyntax typeSyntax)
        {
            var genericNameSyntax = typeSyntax as GenericNameSyntax;
            if (genericNameSyntax != null)
            {
                return genericNameSyntax;
            }
            return (typeSyntax as QualifiedNameSyntax)?.Right as GenericNameSyntax;
        }

        private class OperationsMethodFinder : CSharpSyntaxWalker
        {
            private readonly Dictionary<string, HashSet<MethodDeclarationSyntax>> methods = new Dictionary<string, HashSet<MethodDeclarationSyntax>>();
            private const string TargetClassSuffix = "Operations";

            public ReadOnlyDictionary<string, HashSet<MethodDeclarationSyntax>> Methods
            {
                get { return new ReadOnlyDictionary<string, HashSet<MethodDeclarationSyntax>>(this.methods); }
            }

            public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
            {
                if (node.Name.ToString() == "Microsoft.Azure.Batch.Protocol")
                {
                    base.VisitNamespaceDeclaration(node);
                }
            }

            public override void VisitClassDeclaration(ClassDeclarationSyntax node)
            {
                if (node.Identifier.Text.EndsWith(TargetClassSuffix))
                {
                    base.VisitClassDeclaration(node);
                }
            }

            public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
            {
                if (node.Modifiers.Any(val => val.ToString() == SyntaxFactory.Token(SyntaxKind.PublicKeyword).ToString()))
                {
                    ClassDeclarationSyntax classInfo = (ClassDeclarationSyntax)node.Parent;
                    string containingClassPrefix = classInfo.Identifier.Text.Replace(TargetClassSuffix, string.Empty);
                    this.AddToValuesCollection(containingClassPrefix, node);
                }
            }

            private void AddToValuesCollection(string classPrefix, MethodDeclarationSyntax method)
            {
                if (!this.methods.ContainsKey(classPrefix))
                {
                    this.methods.Add(classPrefix, new HashSet<MethodDeclarationSyntax>());
                }
                this.methods[classPrefix].Add(method);
            }
        }
    }
}
