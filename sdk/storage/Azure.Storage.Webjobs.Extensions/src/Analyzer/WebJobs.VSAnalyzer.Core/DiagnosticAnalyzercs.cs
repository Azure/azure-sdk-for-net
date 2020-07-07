// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.Azure.WebJobs.Host;
using System.Text;
using System.Reflection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Analyzer
{
    // Can't access the workspace. 
    // https://stackoverflow.com/questions/23203206/roslyn-current-workspace-in-diagnostic-with-code-fix-project

    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class MyAnalyzerAnalyzer : DiagnosticAnalyzer
    {
        // $$$ -  This should be scoped to per-project 
        JobHostMetadataProvider _tooling;

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ErrorList.SupportedDiagnostics;

        // Test we can load webjobs types staticly without needing any assembly resolves.
        // The VSIX should have all the dependencies upfront. 
        public static void VerifyWebJobsLoaded()
        {
            var x = new JobHostConfiguration();
        }

        public override void Initialize(AnalysisContext context)
        {
            VerifyWebJobsLoaded();
                        
            // Analyze method signatures, 
            context.RegisterSyntaxNodeAction(AnalyzeMethodDeclarationNode, SyntaxKind.MethodDeclaration);

            // Hook compilation to get the assemblies references and build the WebJob tooling interfaces. 
            context.RegisterCompilationStartAction(compilationAnalysisContext =>
            {
                var compilation = compilationAnalysisContext.Compilation;

                AssemblyCache.Instance.Build(compilation);
                this._tooling = AssemblyCache.Instance.Tooling;

                // cast to PortableExecutableReference which has a file path
                var x1 = compilation.References.OfType<PortableExecutableReference>().ToArray();
                var webJobsPath = (from reference in x1
                                   where IsWebJobsSdk(reference)
                                   select reference.FilePath).SingleOrDefault();

                if (webJobsPath == null)
                {
                    return; // Not a WebJobs project. 
                }
            });
        }

        private bool IsWebJobsSdk(PortableExecutableReference reference)
        {
            if (reference.FilePath.EndsWith("Microsoft.Azure.WebJobs.dll"))
            {
                return true;
            }
            return false;
        }

        //  This is called extremely frequently 
        // Analyze the method signature to validate binding attributes + types on the parameters.
        private void AnalyzeMethodDeclarationNode(SyntaxNodeAnalysisContext context)
        {
            if (_tooling == null) // Not yet initialized 
            {
                return;
            }
            var methodDecl = (MethodDeclarationSyntax)context.Node;
            var methodName = methodDecl.Identifier.ValueText;

            if (!HasFunctionNameAttribute(context, methodDecl))
            {
                return;
            }

            // Go through 
            var parameterList = methodDecl.ParameterList;

            foreach (ParameterSyntax parameterSyntax in parameterList.Parameters)
            {
                // No symbol for the parameter; just the parameter's type
                // Lazily do this - only do this if we're actually looking at a webjobs parameter.
                Type parameterType = null;

                // Now validate each parameter in the method. 
                foreach (var attrListSyntax in parameterSyntax.AttributeLists)
                {
                    foreach (AttributeSyntax attributeSyntax in attrListSyntax.Attributes)
                    {
                        var sym = context.SemanticModel.GetSymbolInfo(attributeSyntax);

                        var sym2 = sym.Symbol;
                        if (sym2 == null)
                        {
                            return; // compilation error
                        }

                        try
                        {                           
                            // Major call to instantiate a reflection Binding attribute from a symbol. 
                            // Need this so we can pass the attribute to the WebJob's binding engine. 
                            // throws if fails to instantiate
                            Attribute attribute = Helpers.MakeAttr(_tooling, context.SemanticModel, attributeSyntax); 
                            if (attribute == null)
                            {
                                continue;
                            }

                            // At this point, we know we're looking at a webjobs parameter. 
                            if (parameterType == null)
                            {
                                parameterType = Helpers.GetParameterType(context, parameterSyntax);
                                if (parameterType == null)
                                {
                                    return; // errors in signature
                                }
                            }

                            // Report errors from invalid attribute properties. 
                            ValidateAttribute(context, attribute, attributeSyntax);

                            // This is the major call into the WebJobs' binding engine to check for binding errors. 
                            // Returns null if success, else a list of possible fixes. 
                            var diagnosticHelper = new DiagnosticHelper(_tooling);
                            ErrorSuggestions[] errors = diagnosticHelper.CheckBindingErrors(attribute, parameterType);

                            if (errors != null && errors.Length > 0)
                            {                                  
                                var diagnostic = ErrorList.IllegalBindingType(
                                    parameterSyntax, 
                                    attribute,
                                    parameterType, 
                                    errors);

                                context.ReportDiagnostic(diagnostic);
                            }
                        }
                        catch (Exception e)
                        {
                            return;
                        }
                    }
                }
            }
        }

        // First argument to the FunctionName ctor. 
        private string GetFunctionNameFromAttribute(SemanticModel semantics, AttributeSyntax attributeSyntax)
        {
            foreach (var arg in attributeSyntax.ArgumentList.Arguments)
            {
                var val = semantics.GetConstantValue(arg.Expression);
                if (!val.HasValue)
                {
                    return null;
                }
                return val.Value as string;
            }
            return null;
        }


        // Does the method have a [FunctionName] attribute?
        // This provides a quick check before we get into the more intensive analysis work. 
        private bool HasFunctionNameAttribute(SyntaxNodeAnalysisContext context, MethodDeclarationSyntax methodDeclarationSyntax)
        {
            foreach (var attrListSyntax in methodDeclarationSyntax.AttributeLists)
            {
                foreach (AttributeSyntax attributeSyntax in attrListSyntax.Attributes)
                {
                    // Perf - Can we get the name without doing a symbol resolution?
                    var symAttributeCtor = context.SemanticModel.GetSymbolInfo(attributeSyntax).Symbol;
                    if (symAttributeCtor != null)
                    {
                        var attrType = symAttributeCtor.ContainingType;
                        if (attrType.Name == nameof(FunctionNameAttribute))
                        {
                            // Validate the FunctionName.
                            var functionName = GetFunctionNameFromAttribute(context.SemanticModel, attributeSyntax);

                            bool match = FunctionNameAttribute.FunctionNameValidationRegex.IsMatch(functionName);
                            if (!match)
                            {
                                var error = ErrorList.IllegalFunctionName(attributeSyntax, functionName);
                                context.ReportDiagnostic(error);
                            }

                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // Given an instantiated attribute, run the validators on it and report back any errors. 
        // Attribute is the live attribute, constructed from the attributeSyntax node in the user's source code. 
        private void ValidateAttribute(SyntaxNodeAnalysisContext context, Attribute attribute, AttributeSyntax attributeSyntax)
        {
            SemanticModel semantics = context.SemanticModel;
            Type attributeType = attribute.GetType();

            IMethodSymbol symAttributeCtor = (IMethodSymbol)semantics.GetSymbolInfo(attributeSyntax).Symbol;
            var syntaxParams = symAttributeCtor.Parameters;

            int idx = 0;
            if (attributeSyntax.ArgumentList != null)
            {
                foreach (AttributeArgumentSyntax arg in attributeSyntax.ArgumentList.Arguments)
                {
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

                    PropertyInfo propInfo = attributeType.GetProperty(argName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                    if (propInfo != null)
                    {
                        ValidateAttributeProperty(context, attribute, propInfo, arg);
                    }

                    idx++;
                }
            }
        }

        // Validate an individual property on the attribute 
        // propInfo is a property on the attribute. 
        private void ValidateAttributeProperty(SyntaxNodeAnalysisContext context, Attribute attribute, PropertyInfo propInfo, AttributeArgumentSyntax attributeSyntax)
        {
            var value = propInfo.GetValue(attribute);
            var propertyAttributes = propInfo.GetCustomAttributes();

            // First validate [AutoResolve] and [AppSetting]. 
            // Then do validators. 
            bool isAutoResolve = false;
            bool isAppSetting = false;
            MethodInfo validator = null;
            Attribute validatorAttribute = null;

            foreach (Attribute propertyAttribute in propertyAttributes)
            {
                // AutoResolve and AppSetting are exclusive. 
                if (propertyAttribute.GetType() == typeof(Microsoft.Azure.WebJobs.Description.AutoResolveAttribute))
                {
                    isAutoResolve = true;
                }  
                if (propertyAttribute.GetType() == typeof(Microsoft.Azure.WebJobs.Description.AppSettingAttribute))
                {
                    isAppSetting = true;
                }

                if (validator == null)
                {
                    validator = propertyAttribute.GetType().GetMethod("Validate", new Type[] { typeof(object), typeof(string) });
                    validatorAttribute = propertyAttribute;
                }              
            }

            // Now apply error checks in order. 
            if (isAutoResolve)
            {
                // Value should parse with { } and %% 
                try
                {
                    if (value is string valueStr)
                    {
                        var template = Microsoft.Azure.WebJobs.Host.Bindings.Path.BindingTemplate.FromString(valueStr);
                        if (template.HasParameters)
                        {
                            // The validator runs after the { } and %% are substituted. 
                            // But {} and %% may be illegal characters, so we can't validate with them.
                            // So skip validation. 
                            // TODO - could we have some "dummy" substitution so that we can still do validation?
                            return;
                        }
                    }
                }
                catch (FormatException e)
                {
                    // Parse error 
                    var diagnostic = ErrorList.BadBindingExpressionSyntax(attributeSyntax, propInfo, value, e);
                    context.ReportDiagnostic(diagnostic);
                    return;
                }
            }
            else if (isAppSetting)
            {
                // TODO - validate the appsetting. In local.json? etc? 
            }

            if (validator != null)
            {
                // Run Validators. 
                //  If this is an autoresolve/appsetting, technically we should do the runtime substitution
                // for the %appsetting% and {key} tokens. 

                // We'd like to get all attributes deriving from ValidationAttribute.
                // But that's net20, and the analyzer is net451, so we can't reference the right type. 
                // Need to do a dynamic dispatch to ValidationAttribute.Validate(object,string). 

                try
                {
                    //attr.Validate(value, propInfo.Name);
                    validator.Invoke(validatorAttribute, new object[] { value, propInfo.Name });
                }
                catch (TargetInvocationException te)
                {
                    var ex = te.InnerException;
                    var diagnostic = ErrorList.FailedValidation(attributeSyntax, propInfo, value, ex);
                    context.ReportDiagnostic(diagnostic);
                }
            }

        }
    }
}
