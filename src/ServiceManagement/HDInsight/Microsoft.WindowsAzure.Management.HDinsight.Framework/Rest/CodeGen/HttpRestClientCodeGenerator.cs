namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.CodeGen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.IO;
    using System.CodeDom;
    using System.Reflection;
    using System.CodeDom.Compiler;
    using Microsoft.CSharp;

    /// <summary>
    /// This is the class responsible for creating the concrete implementations of interface types.
    /// </summary>
    internal class HttpRestClientCodeGenerator
    {
        private readonly Type _serviceInterface;
       
        public HttpRestClientCodeGenerator(Type serviceInterfaceType)
        {
            Contract.Requires<ArgumentNullException>(serviceInterfaceType != null);
            HttpRestInterfaceValidator.ValidateInterface(serviceInterfaceType, true);

            this._serviceInterface = serviceInterfaceType;
        }

        private void GenerateContructors(CodeTypeDeclaration targetClass, Type baseClass)
        {
            foreach (var constructor in baseClass.GetConstructors(BindingFlags.Public | BindingFlags.Instance))
            {
                CodeConstructor genConstructor = new CodeConstructor();
                foreach (var param in constructor.GetParameters())
                {
                    genConstructor.Parameters.Add(new CodeParameterDeclarationExpression(param.ParameterType, param.Name));
                    genConstructor.BaseConstructorArgs.Add(new CodeVariableReferenceExpression(param.Name));
                }
                genConstructor.Attributes = MemberAttributes.Public;
                targetClass.Members.Add(genConstructor);
            }
        }

        private bool IsAsync(MethodInfo method)
        {
            return method.ReturnType == typeof(Task) || (method.ReturnType.IsGenericType && method.ReturnType.BaseType == typeof(Task));
        }

        private CodeMemberMethod GenerateInterfaceImplementationForOperationContract(MethodInfo method)
        {
            var genMethod = new CodeMemberMethod();
            genMethod.ReturnType = new CodeTypeReference(method.ReturnType);
            genMethod.Name = method.Name;
            genMethod.Attributes = MemberAttributes.Public;

            foreach (var parameter in method.GetParameters())
            {
                var genParam = new CodeParameterDeclarationExpression(parameter.ParameterType, parameter.Name);
                genMethod.Parameters.Add(genParam);
            }

            PreventInliningOfGeneratedMethod(genMethod);
            
            //Now generate the implementation, we just want to call into the base.CreateRestRequestForparentMethod(new object[]{arg0, arg1, arg2} )
            CodeMethodInvokeExpression invokeExpression = null;

            if (this.IsAsync(method))
            {
                if (method.ReturnType.IsGenericType)
                {
                    invokeExpression = new CodeMethodInvokeExpression(
                        new CodeMethodReferenceExpression(new CodeBaseReferenceExpression(),
                                                          "CreateAndInvokeRestRequestForParentMethodAsync",
                                                          new CodeTypeReference(
                                                              method.ReturnType.GetGenericArguments().Single())));
                }
                else
                {
                    invokeExpression = new CodeMethodInvokeExpression(
                        new CodeMethodReferenceExpression(new CodeBaseReferenceExpression(),
                                                          "CreateAndInvokeRestRequestForParentMethodAsync"));
                }
            }
            else
            {
                invokeExpression = new CodeMethodInvokeExpression(new CodeBaseReferenceExpression(), "CreateAndInvokeRestRequestForParentMethod");
            }

            //Now add the arguments of parent method in the same order in the end of the invocation
            foreach (ParameterInfo parameter in method.GetParameters())
            {
                invokeExpression.Parameters.Add(new CodeVariableReferenceExpression(parameter.Name));
            }

            GenerateAddReturnStatementFromInvokeExpressionIfNeeded(method, genMethod, invokeExpression);

            return genMethod;
        }

        private static void PreventInliningOfGeneratedMethod(CodeMemberMethod genMethod)
        {
            CodeAttributeDeclaration nomethodinlining =
                new CodeAttributeDeclaration(new CodeTypeReference(typeof(System.Runtime.CompilerServices.MethodImplAttribute)));
            nomethodinlining.Arguments.Add(
                //8 == NoInlining
                //64 = NoOptimization
                new CodeAttributeArgument(new CodePrimitiveExpression(8 | 64)));
            genMethod.CustomAttributes.Add(nomethodinlining);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "Used for codegeneration", MessageId = "System.String.Format(System.String,System.Object)")]
        private static void MarkCodeMemberMethodAsAsync(CodeMemberMethod method)
        {
            var returnTypeArgumentReferences = method.ReturnType.TypeArguments.OfType<CodeTypeReference>().ToArray();

            var asyncReturnType = new CodeTypeReference(String.Format("async {0}", method.ReturnType.BaseType), returnTypeArgumentReferences);
            method.ReturnType = asyncReturnType;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "Used for codegeneration", MessageId = "System.String.Format(System.String,System.Object)")]
        private static void MarkCodeMethodInvokeExpressionAsAwait(CodeMethodInvokeExpression expression)
        {
            var variableExpression = expression.Method.TargetObject as CodeVariableReferenceExpression;
            if (variableExpression != null)
            {
                expression.Method.TargetObject = new CodeVariableReferenceExpression(String.Format("await {0}", variableExpression.VariableName));
            }
        }

        private static void GenerateAddReturnStatementFromInvokeExpressionIfNeeded(MethodInfo method, CodeMemberMethod genMethod, CodeMethodInvokeExpression invokeExpression)
        {
            MarkCodeMethodInvokeExpressionAsAwait(invokeExpression);

            //If the interface method has a return type return the result of the invocation
            if (method.ReturnType != typeof(void))
            {
                CodeCastExpression cast = new CodeCastExpression(method.ReturnType, invokeExpression);
                CodeMethodReturnStatement returnStatement = new CodeMethodReturnStatement(cast);
                genMethod.Statements.Add(returnStatement);
            }
            else
            {
                genMethod.Statements.Add(invokeExpression);
            }
        }

        private static CodeThrowExceptionStatement GenerateThrowNotImplementedExceptionStatement()
        {
            CodeThrowExceptionStatement exceptionStatement = new CodeThrowExceptionStatement();
            exceptionStatement.ToThrow = new CodeObjectCreateExpression(typeof(NotImplementedException));
            return exceptionStatement;
        }

        private static CodeMemberMethod GenerateDummyImplemention(MethodInfo interfaceMethod)
        {
            CodeMemberMethod genMethod = new CodeMemberMethod();
            genMethod.ReturnType = new CodeTypeReference(interfaceMethod.ReturnType);
            genMethod.Name = interfaceMethod.Name;
            foreach (var parameter in interfaceMethod.GetParameters())
            {
                var genParam = new CodeParameterDeclarationExpression(parameter.ParameterType, parameter.Name);
                genMethod.Parameters.Add(genParam);
            }
            genMethod.Statements.Add(GenerateThrowNotImplementedExceptionStatement());
            return genMethod;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "Not localized.", MessageId = "System.String.Format(System.String,System.Object,System.Object)")]
        public CodeCompileUnit GenerateCodeDomCode(string targetNamespace, string className)
        {
            CodeCompileUnit targetUnit = new CodeCompileUnit();
            CodeNamespace samples = new CodeNamespace(targetNamespace);
            string restProxyNameSpace = typeof(HttpRestClient<>).Namespace;
            samples.Imports.Add(new CodeNamespaceImport(this._serviceInterface.Namespace));
            var targetClass = new CodeTypeDeclaration(className);
            targetClass.BaseTypes.Add(string.Format("{0}.HttpRestClient<{1}>", restProxyNameSpace, this._serviceInterface.Name));
            targetClass.BaseTypes.Add(this._serviceInterface);
            
            AddGeneratedCodeAttribute(targetClass);

            samples.Types.Add(targetClass);

            targetUnit.Namespaces.Add(samples);

            //Create a public overload for every constructor in the base class, in our case RestProxy
            this.GenerateContructors(targetClass, typeof(HttpRestClient<>));

            //for each interface method that is tagged with [OperationContract] and [WebInvoke] or [WebGet] generate
            //the proxy implementation. else generate a dummy not implemented exception
            foreach (var method in this._serviceInterface.GetMethods()
                        .Where(meth => !meth.IsSpecialName))
            {
                if (HttpRestInterfaceValidator.ValidateInterfaceMethod(method))
                {
                    //Generate the interface implementation 
                    var interfaceImplementation = this.GenerateInterfaceImplementationForOperationContract(method);
                    targetClass.Members.Add(interfaceImplementation);
                }
                else
                {
                    targetClass.Members.Add(GenerateDummyImplemention(method));
                }
            }

            return targetUnit;
        }

        private static void AddGeneratedCodeAttribute(CodeTypeDeclaration targetClass)
        {
            GeneratedCodeAttribute generatedCodeAttribute =
                new GeneratedCodeAttribute(typeof(HttpRestClientCodeGenerator).FullName, "1.0.0.0");

            // Use the generated code attribute members in the attribute declaration
            CodeAttributeDeclaration codeAttrDecl =
                new CodeAttributeDeclaration(generatedCodeAttribute.GetType().FullName,
                                             new CodeAttributeArgument(
                                                 new CodePrimitiveExpression(generatedCodeAttribute.Tool)),
                                             new CodeAttributeArgument(
                                                 new CodePrimitiveExpression(generatedCodeAttribute.Version)));
            targetClass.CustomAttributes.Add(codeAttrDecl);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "Used for codegeneration", MessageId = "System.String.Format(System.String,System.Object)")]
        private static string ResolveAssemblyLocation(AssemblyName assemblyName)
        {
            //Try to load the assembly and see if it has a non empty location
            Assembly loadAssembly = Assembly.Load(assemblyName);
            if (File.Exists(loadAssembly.Location))
            {
                return loadAssembly.Location;
            }
            throw new ArgumentException(string.Format("Assembly '{0}' location cannot be found!", assemblyName.Name));
        }

        private static IEnumerable<string> GetReferenceAssemblyPaths(Type type)
        {
            //CLR or Gacced assembies can be referenced by assemblyName.dll the other assemblies are assumed be in the same directory as the code generator
            List<string> referencedAssembies = type.Assembly.GetReferencedAssemblies().Select(
                ResolveAssemblyLocation).ToList();
            referencedAssembies.Add(type.Assembly.Location);
            return referencedAssembies;
        }

        /// <summary>
        /// Compiles the codedom compile unit into C#. If the output <paramref name="outputAssemblyPath"/> is null the the code assembly is generated in memory.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="outputAssemblyPath">The output assembly path.</param>
        /// <returns>The results of compilation.</returns>
        /// <exception cref="CompileException">Is thrown when the compiler has encountered an error.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", Justification = "Used for codegeneration", MessageId = "CompilerErrors")]
        private CompilerResults CompileCode(CodeDomProvider provider, CodeCompileUnit unit,  string outputAssemblyPath = null)
        {
            CompilerParameters cp = new CompilerParameters();

            cp.ReferencedAssemblies.AddRange(GetReferenceAssemblyPaths(this._serviceInterface).ToArray());
            cp.ReferencedAssemblies.AddRange(GetReferenceAssemblyPaths(typeof(HttpRestClient<>)).ToArray());
            cp.GenerateInMemory = outputAssemblyPath == null;
            if (!string.IsNullOrEmpty(outputAssemblyPath))
            {
                cp.OutputAssembly = outputAssemblyPath;
            }

            CompilerResults results = provider.CompileAssemblyFromDom(cp, unit);
            if (results.Errors.Count > 0)
            {
                throw new CompileException("Compilation failed: Please look at the CompilerErrors property for more details!", results);
            }
            return results;
        }

        /// <summary>
        /// Generates the C sharp code that concretely implements the proxy.
        /// </summary>
        /// <param name="targetNamespace">The target namespace.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="outputFilePath">The output file path.</param>
        public void GenerateCSharpCode(string targetNamespace, string className,  string outputFilePath)
        {
            using (var codeOutputStream = new FileStream(outputFilePath, FileMode.OpenOrCreate))
            {
                var writer = new StreamWriter(codeOutputStream);
                this.GenerateCSharpCode(targetNamespace, className, writer);
            }
        }

        /// <summary>
        /// Generates the C sharp code that conretely implements the proxy.
        /// </summary>
        /// <param name="targetNamespace">The target namespace.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="outputWriter">The output writer.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Justified because other objects may hold a handle to these variables")]
        public void GenerateCSharpCode(string targetNamespace, string className, StreamWriter outputWriter)
        {
            CodeCompileUnit targetUnit = this.GenerateCodeDomCode(targetNamespace, className);
            
            CodeDomProvider provider = new CSharpCodeProvider();
            
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            options.VerbatimOrder = true;
            //Compile the code verify that it does indeed compile
            //The method Compile() will throw if errors are encountered
            this.CompileCode(provider, targetUnit);
            //Generate the code from compile unit
            provider.GenerateCodeFromCompileUnit(targetUnit, outputWriter, options);
            
        }

        /// <summary>
        /// Generates the assembly containing the proxy.
        /// </summary>
        /// <param name="targetNamespace">The target namespace.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="assemblyOutpath">The assembly outpath. Defaults to null.</param>
        /// <returns>An assembly containing the generated type.</returns>
        /// <remarks>
        /// If null, the assembly is generated in memory.
        /// </remarks>
        public Assembly GenerateAssembly(string targetNamespace, string className, string assemblyOutpath = null)
        {
            CodeCompileUnit targetUnit = this.GenerateCodeDomCode(targetNamespace, className);
            using (CodeDomProvider provider = new CSharpCodeProvider())
            {
                CompilerResults results = this.CompileCode(provider, targetUnit, assemblyOutpath);
                return results.CompiledAssembly;
            }
        }
    }
}
