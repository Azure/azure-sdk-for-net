// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers
{
    internal class ResourceCollectionClientProviderTests
    {
        [TestCase]
        public void Verify_BackCompatOverloadIsDecorated()
        {
            // The current spec adds an optional "expand" query parameter to Get; the previous contract (loaded from
            // TestData) did not, so the upstream generator synthesizes a hidden back-compat overload preserving the old
            // signature.
            var (client, models) = InputResourceData.ClientWithResource(includeGetQueryParameter: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client], lastContractCompilation: () => Helpers.GetCompilationFromDirectory());
            var provider = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().First();
            Assert.That(provider.LastContractView, Is.Not.Null);

            ManagementMockHelpers.ProcessTypeForBackCompatibility(provider);

            var backCompatMethods = new TestTypeProvider(
                name: provider.Name,
                ns: provider.Type.Namespace,
                declarationModifiers: provider.DeclarationModifiers,
                methods: provider.Methods.Where(m => m.Signature.Name == "Get" || m.Signature.Name == "GetAsync"));
            var rendered = new TypeProviderWriter(backCompatMethods).Write().Content.Replace("\r\n", "\n");
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        private static MethodProvider GetResourceCollectionClientProviderMethodByName(string methodName)
        {
            ResourceCollectionClientProvider resourceProvider = GetResourceCollectionClientProvider();
            var method = resourceProvider.Methods.FirstOrDefault(m => m.Signature.Name == methodName);
            Assert.That(method, Is.Not.Null);
            return method!;
        }

        private static ResourceCollectionClientProvider GetResourceCollectionClientProvider()
        {
            var (client, models) = InputResourceData.ClientWithResource();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceCollectionClientProvider) as ResourceCollectionClientProvider;
            Assert.That(resourceProvider, Is.Not.Null);
            return resourceProvider!;
        }

        [TestCase]
        public void Verify_ExtensionChildCollectionValidateResourceIdUsesParentResource()
        {
            var (parentClient, childClient, models) = InputResourceData.ClientWithNestedExtensionChildResource();
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [parentClient, childClient]);

            var collection = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ResourceCollectionClientProvider>()
                .SingleOrDefault(p => p.Name == "WatchlistItemCollection");
            Assert.That(collection, Is.Not.Null);

            var validateResourceId = collection!.Methods.SingleOrDefault(m => m.Signature.Name == "ValidateResourceId");
            Assert.That(validateResourceId, Is.Not.Null);

            var bodyStatements = validateResourceId!.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Does.Contain("global::Samples.WatchlistResource.ResourceType"));
            Assert.That(bodyStatements, Does.Not.Contain("\"Microsoft.OperationalInsights/workspaces\""));

            var constructor = collection.Constructors.SingleOrDefault(c => c.Signature.Parameters.Any(p => p.Name == "id"));
            Assert.That(constructor, Is.Not.Null);
            Assert.That(constructor!.BodyStatements?.ToDisplayString(), Does.Contain("global::Samples.WatchlistItemCollection.ValidateResourceId(id);"));
        }

        [TestCase]
        public void Verify_FixedChildResourceTypeIsNotPublicCollectionParameter()
        {
            var (parentClient, childClient, models) = InputResourceData.ClientWithFixedChildResourceType();
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [parentClient, childClient]);

            var collection = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ResourceCollectionClientProvider>()
                .SingleOrDefault(p => p.Name == "AzureEndpointCollection");
            Assert.That(collection, Is.Not.Null);
            var azureEndpointCollection = collection!;

            var getMethod = azureEndpointCollection.Methods.Single(m => m.Signature.Name == "Get");
            Assert.That(getMethod.Signature.Parameters.Select(p => p.Name), Does.Not.Contain("endpointType"));
            Assert.That(getMethod.Signature.Parameters.Select(p => p.Name), Does.Contain("endpointName"));
            Assert.That(getMethod.BodyStatements?.ToDisplayString(), Does.Contain("\"AzureEndpoints\""));
            Assert.That(getMethod.BodyStatements?.ToDisplayString(), Does.Not.Contain("endpointType"));

            var createMethod = azureEndpointCollection.Methods.Single(m => m.Signature.Name == "CreateOrUpdate");
            Assert.That(createMethod.Signature.Parameters.Select(p => p.Name), Does.Not.Contain("endpointType"));

            var parentResource = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ResourceClientProvider>()
                .SingleOrDefault(p => p.Name == "ProfileResource");
            Assert.That(parentResource, Is.Not.Null);
            var parentGetMethod = parentResource!.Methods.Single(m => m.Signature.Name == "GetAzureEndpoint");
            Assert.That(parentGetMethod.Signature.Parameters.Select(p => p.Name), Does.Not.Contain("endpointType"));
        }

        [TestCase]
        public void Verify_GetOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("Get");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual));
            Assert.That(signature.Parameters.Count, Is.EqualTo(2));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Response<>)));

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_GetAsyncOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("GetAsync");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async));
            Assert.That(signature.Parameters.Count, Is.EqualTo(2));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Task<>)));

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_ExistsOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("Exists");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual));
            Assert.That(signature.Parameters.Count, Is.EqualTo(2));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Response<>)));

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase("Exists")]
        [TestCase("ExistsAsync")]
        public void ExistsUsesHeadWhenCheckExistenceIsAvailable(string methodName)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            var body = collection.Methods.Single(m => m.Signature.Name == methodName).BodyStatements!.ToDisplayString();

            Assert.That(body, Does.Contain("CreateCheckExistenceRequest"));
            Assert.That(body, Does.Not.Contain("CreateGetRequest"));
            Assert.That(body, Does.Not.Contain(".FromResponse("));
            Assert.That(body, Does.Contain("404"));
        }

        [TestCase("Exists")]
        [TestCase("ExistsAsync")]
        public void CheckExistenceAcceptsModeledNotModifiedResponse(string methodName)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true);
            var check = client.Methods.Single(method => method.Name == "checkExistence");
            check.Operation.Update(responses: [InputFactory.OperationResponse([204]), InputFactory.OperationResponse([304])]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            var body = collection.Methods.Single(method => method.Signature.Name == methodName).BodyStatements!.ToDisplayString();

            Assert.That(body, Does.Contain("304"));
        }

        [TestCase("Exists")]
        [TestCase("ExistsAsync")]
        public void CheckExistenceResponseHandlingDoesNotDependOnHttpVerb(string methodName)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true);
            client.Methods.Single(method => method.Name == "checkExistence").Operation.Update(httpMethod: "POST");
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            var body = collection.Methods.Single(method => method.Signature.Name == methodName).BodyStatements!.ToDisplayString();

            Assert.That(body, Does.Contain("CreateCheckExistenceRequest"));
            Assert.That(body, Does.Contain("404"));
            Assert.That(body, Does.Not.Contain(".FromResponse("));
        }

        [TestCase("Exists")]
        [TestCase("ExistsAsync")]
        public void CheckExistenceUsesInternalVisibilityWithPreviousPublicContract(string methodName)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true, headIsInternal: true);
            var source = """
                using System.Threading;
                using System.Threading.Tasks;
                using Azure;
                using Azure.ResourceManager;
                namespace Samples
                {
                    public partial class ResponseTypeCollection : ArmCollection
                    {
                        public virtual Response<bool> Exists(string testName, CancellationToken cancellationToken = default) => throw null;
                        public virtual Task<Response<bool>> ExistsAsync(string testName, CancellationToken cancellationToken = default) => throw null;
                    }
                }
                """;
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client], lastContractCompilation: () => Helpers.BuildCompilation([("LastContract.cs", source)]));
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            ManagementMockHelpers.ProcessTypeForBackCompatibility(collection);
            var method = collection.Methods.Single(method => method.Signature.Name == methodName);

            Assert.That(method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public), Is.False);
            Assert.That(method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal), Is.True);
            Assert.That(method.BodyStatements!.ToDisplayString(), Does.Contain("CreateCheckExistenceRequest"));
        }

        [Test]
        public void ReadSelectorRemainsAvailableOnGetIfExists()
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true, includeGetQueryParameter: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client], lastContractCompilation: () => Helpers.GetCompilationFromDirectory(method: nameof(CustomGetOverloadCanCoexistWithCheckExistence)));
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            ManagementMockHelpers.ProcessTypeForBackCompatibility(collection);

            foreach (var methodName in new[] { "GetIfExists", "GetIfExistsAsync" })
            {
                var method = collection.Methods.Single(m => m.Signature.Name == methodName);
                Assert.That(method.Signature.Parameters.Select(p => p.Name), Does.Contain("expand"));
                Assert.That(method.BodyStatements!.ToDisplayString(), Does.Contain("CreateGetRequest"));
            }
        }

        [Test]
        public void CustomGetOverloadCanCoexistWithCheckExistence()
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true, includeGetQueryParameter: true);
            var custom = Helpers.GetCompilationFromDirectory();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client],
                lastContractCompilation: () => custom, customizationCompilation: () => custom);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            ManagementMockHelpers.ProcessTypeForBackCompatibility(collection);

            foreach (var methodName in new[] { "Exists", "ExistsAsync" })
            {
                var generated = collection.Methods.Single(m => m.Signature.Name == methodName && !m.Signature.Parameters.Any(p => p.Name == "expand"));
                Assert.That(generated.BodyStatements!.ToDisplayString(), Does.Contain("CreateCheckExistenceRequest"));
                Assert.That(collection.CustomCodeView!.Methods.Any(m => m.Signature.Name == methodName && m.Signature.Parameters.Any(p => p.Name == "expand")), Is.True);
                var getIfExists = collection.Methods.Single(m => m.Signature.Name == (methodName == "Exists" ? "GetIfExists" : "GetIfExistsAsync"));
                Assert.That(getIfExists.BodyStatements!.ToDisplayString(), Does.Contain("CreateGetRequest"));
                Assert.That(getIfExists.Signature.Parameters.Single(p => p.Name == "expand").DefaultValue, Is.Not.Null);
            }

            var generatedSource = new TypeProviderWriter(collection).Write().Content;
            const string callers = "namespace Samples { internal class Caller { void Call(ResponseTypeCollection collection) { collection.Exists(\"test\"); } } }";
            var compilation = Helpers.BuildCompilation([("Collection.cs", generatedSource), ("Customization.cs", custom.SyntaxTrees.Single().ToString()), ("Callers.cs", callers)])
                .AddReferences(Microsoft.CodeAnalysis.MetadataReference.CreateFromFile(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(typeof(object).Assembly.Location)!, "System.Runtime.dll")));
            Assert.That(compilation.GetDiagnostics().Any(diagnostic => diagnostic.Id == "CS0121" && diagnostic.Location.SourceTree?.FilePath == "Callers.cs"), Is.True);
        }

        [TestCase("Exists")]
        [TestCase("ExistsAsync")]
        public void StandardBackCompatCanForwardToCheckExistence(string methodName)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true, includeGetQueryParameter: true);
            var head = client.Methods.Single(method => method.Name == "checkExistence");
            head.Operation.Update(parameters: [.. head.Operation.Parameters, InputFactory.QueryParameter("headToken", InputPrimitiveType.String)]);
            head.Update(parameters: [.. head.Parameters, InputFactory.MethodParameter("headToken", InputPrimitiveType.String, location: InputRequestLocation.Query)]);
            var source = """
                using System.Threading;
                using System.Threading.Tasks;
                using Azure;
                using Azure.ResourceManager;
                namespace Samples
                {
                    public partial class ResponseTypeCollection : ArmCollection
                    {
                        public virtual Response<bool> Exists(string testName, CancellationToken cancellationToken = default) => throw null;
                        public virtual Task<Response<bool>> ExistsAsync(string testName, CancellationToken cancellationToken = default) => throw null;
                    }
                }
                """;
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client], lastContractCompilation: () => Helpers.BuildCompilation([("LastContract.cs", source)]));
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            ManagementMockHelpers.ProcessTypeForBackCompatibility(collection);
            var legacy = collection.Methods.Single(method => method.Signature.Name == methodName && method.Signature.Parameters.Count == 2);

            Assert.That(legacy.BodyStatements!.ToDisplayString(), Does.Contain($"this.{methodName}(").And.Contain("headToken: default"));
            var check = collection.Methods.Single(method => method.Signature.Name == methodName && method.Signature.Parameters.Any(p => p.Name == "headToken"));
            Assert.That(check.BodyStatements!.ToDisplayString(), Does.Contain("CreateCheckExistenceRequest"));
        }

        [TestCase("Exists")]
        [TestCase("ExistsAsync")]
        public void CheckExistenceUsesItsRequiredParameterWithPreviousGetContract(string methodName)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true, includeGetQueryParameter: true);
            var head = client.Methods.Single(method => method.Name == "checkExistence");
            head.Operation.Update(parameters: [.. head.Operation.Parameters, InputFactory.QueryParameter("expand", InputPrimitiveType.String, isRequired: true, serializedName: "$expand")]);
            head.Update(parameters: [.. head.Parameters, InputFactory.MethodParameter("expand", InputPrimitiveType.String, isRequired: true, location: InputRequestLocation.Query, serializedName: "$expand")]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client], lastContractCompilation: () => Helpers.GetCompilationFromDirectory(method: nameof(CustomGetOverloadCanCoexistWithCheckExistence)));
            using var diagnostics = CaptureDiagnostics(plugin);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            ManagementMockHelpers.ProcessTypeForBackCompatibility(collection);

            var method = collection.Methods.Single(method => method.Signature.Name == methodName);
            Assert.That(method.Signature.Parameters.Single(parameter => parameter.Name == "expand").DefaultValue, Is.Null);
            Assert.That(method.BodyStatements!.ToDisplayString(), Does.Contain("CreateCheckExistenceRequest"));
            Assert.That(System.Text.Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""));
        }

        [TestCase("Exists")]
        [TestCase("ExistsAsync")]
        public void PublishedParameterRenameKeepsCheckExistenceBodyInSync(string methodName)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true, includeGetQueryParameter: true);
            var head = client.Methods.Single(method => method.Name == "checkExistence");
            head.Operation.Update(parameters: [.. head.Operation.Parameters, InputFactory.QueryParameter("headExpand", InputPrimitiveType.String, serializedName: "$expand")]);
            head.Update(parameters: [.. head.Parameters, InputFactory.MethodParameter("headExpand", InputPrimitiveType.String, location: InputRequestLocation.Query, serializedName: "$expand")]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client], lastContractCompilation: () => Helpers.GetCompilationFromDirectory(method: nameof(CustomGetOverloadCanCoexistWithCheckExistence)));
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            ManagementMockHelpers.ProcessTypeForBackCompatibility(collection);
            var method = collection.Methods.Single(method => method.Signature.Name == methodName);

            Assert.That(method.Signature.Parameters.Select(parameter => parameter.Name), Does.Contain("expand"));
            Assert.That(method.BodyStatements!.ToDisplayString(), Does.Not.Contain("headExpand"));
        }

        [TestCase("Exists")]
        [TestCase("ExistsAsync")]
        public void CustomExistsOverloadCoexistsWithGeneratedCheck(string methodName)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true, includeGetQueryParameter: true);
            var source = """
                using System.Threading;
                using System.Threading.Tasks;
                using Azure;
                namespace Samples
                {
                    public partial class ResponseTypeCollection
                    {
                        public virtual Response<bool> Exists(string testName, string expand = null, CancellationToken cancellationToken = default) => throw null;
                        public virtual Task<Response<bool>> ExistsAsync(string testName, string expand = null, CancellationToken cancellationToken = default) => throw null;
                    }
                }
                """;
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client], customizationSources: [source], lastContractCompilation: () => Helpers.GetCompilationFromDirectory(method: nameof(CustomGetOverloadCanCoexistWithCheckExistence)));
            using var diagnostics = CaptureDiagnostics(plugin);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            ManagementMockHelpers.ProcessTypeForBackCompatibility(collection);

            Assert.That(collection.CustomCodeView!.Methods.Any(method => method.Signature.Name == methodName && method.Signature.Parameters.Any(p => p.Name == "expand")), Is.True);
            var check = collection.Methods.Single(method => method.Signature.Name == methodName && !method.Signature.Parameters.Any(p => p.Name == "expand"));
            Assert.That(check.BodyStatements!.ToDisplayString(), Does.Contain("CreateCheckExistenceRequest"));
            Assert.That(System.Text.Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void CustomOverloadCanIntroducePositionalAmbiguity(bool differentRequiredCounts)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true, includeGetQueryParameter: true, includeCheckExistenceQueryParameter: differentRequiredCounts);
            var head = client.Methods.Single(method => method.Name == "checkExistence");
            if (differentRequiredCounts)
            {
                head.Operation.Update(parameters: head.Operation.Parameters.Select(parameter => parameter.Name == "headToken"
                    ? InputFactory.QueryParameter("headToken", InputPrimitiveType.Int32, isRequired: true) : parameter));
                head.Update(parameters: head.Parameters.Select(parameter => parameter.Name == "headToken"
                    ? InputFactory.MethodParameter("headToken", InputPrimitiveType.Int32, isRequired: true, location: InputRequestLocation.Query) : parameter));
            }
            else
            {
                head.Update(parameters: head.Parameters.Select(parameter => parameter.Name == "testName"
                    ? InputFactory.MethodParameter("alternateName", InputPrimitiveType.String, isRequired: true, location: InputRequestLocation.Path, serializedName: "testName") : parameter));
            }
            var custom = Helpers.GetCompilationFromDirectory(method: nameof(CustomGetOverloadCanCoexistWithCheckExistence));
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client], lastContractCompilation: () => custom, customizationCompilation: () => custom);
            using var diagnostics = CaptureDiagnostics(plugin);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            ManagementMockHelpers.ProcessTypeForBackCompatibility(collection);

            var text = System.Text.Encoding.UTF8.GetString(diagnostics.ToArray());
            Assert.That(text, Does.Not.Contain("\"severity\":\"error\""));
            var source = new TypeProviderWriter(collection).Write().Content;
            var call = differentRequiredCounts ? "collection.Exists(\"test\", default)" : "collection.Exists(\"test\")";
            var callers = $"namespace Samples {{ internal class Caller {{ void Call(ResponseTypeCollection collection) {{ {call}; }} }} }}";
            var compilation = Helpers.BuildCompilation([("Collection.cs", source), ("Customization.cs", custom.SyntaxTrees.Single().ToString()), ("Callers.cs", callers)])
                .AddReferences(Microsoft.CodeAnalysis.MetadataReference.CreateFromFile(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(typeof(object).Assembly.Location)!, "System.Runtime.dll")));
            Assert.That(compilation.GetDiagnostics().Any(diagnostic => diagnostic.Id == "CS0121" && diagnostic.Location.SourceTree?.FilePath == "Callers.cs"), Is.True);
        }

        [Test]
        public void CustomRequiredOverloadCoexistsWithOptionalRead()
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true, includeGetQueryParameter: true);
            var head = client.Methods.Single(method => method.Name == "checkExistence");
            foreach (var name in new[] { "one", "two", "three" })
            {
                head.Operation.Update(parameters: [.. head.Operation.Parameters, InputFactory.QueryParameter(name, InputPrimitiveType.Int32, isRequired: true)]);
                head.Update(parameters: [.. head.Parameters, InputFactory.MethodParameter(name, InputPrimitiveType.Int32, isRequired: true, location: InputRequestLocation.Query)]);
            }
            const string lastContract = """
                using System.Threading;
                using Azure;
                using Azure.ResourceManager;
                namespace Samples
                {
                    public partial class ResponseTypeCollection : ArmCollection
                    {
                        public virtual Response<bool> Exists(string testName, string expand, CancellationToken cancellationToken = default) => throw null;
                    }
                }
                """;
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client], customizationSources: [lastContract], lastContractCompilation: () => Helpers.BuildCompilation([("LastContract.cs", lastContract)]));
            using var diagnostics = CaptureDiagnostics(plugin);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            ManagementMockHelpers.ProcessTypeForBackCompatibility(collection);
            var legacy = collection.CustomCodeView!.Methods.Single(method => method.Signature.Name == "Exists" && method.Signature.Parameters.Any(p => p.Name == "expand"));

            Assert.That(legacy.Signature.Parameters.Single(parameter => parameter.Name == "expand").DefaultValue, Is.Null);
            var check = collection.Methods.Single(method => method.Signature.Name == "Exists");
            Assert.That(check.BodyStatements!.ToDisplayString(), Does.Contain("CreateCheckExistenceRequest"));
            Assert.That(collection.Methods.Single(method => method.Signature.Name == "GetIfExists").BodyStatements!.ToDisplayString(), Does.Contain("CreateGetRequest"));
            Assert.That(System.Text.Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""));
        }

        [Test]
        public void CustomOverloadCanIntroduceNamedCallAmbiguity()
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true);
            var get = client.Methods.Single(method => method.Name == "get");
            var head = client.Methods.Single(method => method.Name == "checkExistence");
            foreach (var (method, name, type) in new[]
            {
                (get, "a", InputPrimitiveType.Int64), (get, "b", InputPrimitiveType.Int32), (get, "c", InputPrimitiveType.Int32),
                (head, "b", InputPrimitiveType.Int64), (head, "c", InputPrimitiveType.Int64), (head, "a", InputPrimitiveType.Int32)
            })
            {
                method.Operation.Update(parameters: [.. method.Operation.Parameters, InputFactory.QueryParameter(name, type, isRequired: true)]);
                method.Update(parameters: [.. method.Parameters, InputFactory.MethodParameter(name, type, isRequired: true, location: InputRequestLocation.Query)]);
            }
            const string lastContract = """
                using System.Threading;
                using Azure;
                using Azure.ResourceManager;
                namespace Samples
                {
                    public partial class ResponseTypeCollection : ArmCollection
                    {
                        public virtual Response<bool> Exists(string testName, long a, int b, int c, CancellationToken cancellationToken = default) => throw null;
                    }
                }
                """;
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client], customizationSources: [lastContract], lastContractCompilation: () => Helpers.BuildCompilation([("LastContract.cs", lastContract)]));
            using var diagnostics = CaptureDiagnostics(plugin);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            ManagementMockHelpers.ProcessTypeForBackCompatibility(collection);
            var generated = new TypeProviderWriter(collection).Write().Content;
            const string callers = "namespace Samples { internal class Caller { void Call(ResponseTypeCollection collection) { collection.Exists(\"test\", a: 1, b: 2, c: 3); } } }";
            var compilation = Helpers.BuildCompilation([("Collection.cs", generated), ("Customization.cs", lastContract), ("Callers.cs", callers)])
                .AddReferences(Microsoft.CodeAnalysis.MetadataReference.CreateFromFile(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(typeof(object).Assembly.Location)!, "System.Runtime.dll")));
            Assert.That(compilation.GetDiagnostics().Any(diagnostic => diagnostic.Id == "CS0121" && diagnostic.Location.SourceTree?.FilePath == "Callers.cs"), Is.True);
            Assert.That(System.Text.Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""));
        }

        [Test]
        public void CustomRequiredOverloadsCanMakeDefaultAmbiguous()
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true, includeGetQueryParameter: true, includeCheckExistenceQueryParameter: true);
            var get = client.Methods.Single(method => method.Name == "get");
            get.Operation.Update(parameters: get.Operation.Parameters.Select(parameter => parameter.Name == "expand"
                ? InputFactory.QueryParameter("expand", InputPrimitiveType.String, isRequired: true, serializedName: "$expand") : parameter));
            get.Update(parameters: get.Parameters.Select(parameter => parameter.Name == "expand"
                ? InputFactory.MethodParameter("expand", InputPrimitiveType.String, isRequired: true, location: InputRequestLocation.Query, serializedName: "$expand") : parameter));
            var head = client.Methods.Single(method => method.Name == "checkExistence");
            head.Operation.Update(parameters: head.Operation.Parameters.Select(parameter => parameter.Name == "headToken"
                ? InputFactory.QueryParameter("headToken", InputPrimitiveType.Int32, isRequired: true) : parameter));
            head.Update(parameters: head.Parameters.Select(parameter => parameter.Name == "headToken"
                ? InputFactory.MethodParameter("headToken", InputPrimitiveType.Int32, isRequired: true, location: InputRequestLocation.Query) : parameter));
            var source = """
                using System.Threading;
                using System.Threading.Tasks;
                using Azure;
                using Azure.ResourceManager;
                namespace Samples
                {
                    public partial class ResponseTypeCollection : ArmCollection
                    {
                        public virtual Response<bool> Exists(string testName, string expand, CancellationToken cancellationToken = default) => throw null;
                        public virtual Task<Response<bool>> ExistsAsync(string testName, string expand, CancellationToken cancellationToken = default) => throw null;
                    }
                }
                """;
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client], customizationSources: [source], lastContractCompilation: () => Helpers.BuildCompilation([("LastContract.cs", source)]));
            using var diagnostics = CaptureDiagnostics(plugin);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            ManagementMockHelpers.ProcessTypeForBackCompatibility(collection);
            var generated = new TypeProviderWriter(collection).Write().Content;
            const string callers = "namespace Samples { internal class Caller { void Call(ResponseTypeCollection collection) { collection.Exists(\"test\", default); } } }";
            var compilation = Helpers.BuildCompilation([("Collection.cs", generated), ("Customization.cs", source), ("Callers.cs", callers)])
                .AddReferences(Microsoft.CodeAnalysis.MetadataReference.CreateFromFile(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(typeof(object).Assembly.Location)!, "System.Runtime.dll")));
            Assert.That(compilation.GetDiagnostics().Any(diagnostic => diagnostic.Id == "CS0121" && diagnostic.Location.SourceTree?.FilePath == "Callers.cs"), Is.True);
            Assert.That(System.Text.Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void CustomNumericOverloadsBindAccordingToCSharp(bool publishedIsLong)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true, includeGetQueryParameter: true, includeCheckExistenceQueryParameter: true);
            var readType = publishedIsLong ? InputPrimitiveType.Int64 : InputPrimitiveType.Int32;
            var checkType = publishedIsLong ? InputPrimitiveType.Int32 : InputPrimitiveType.Int64;
            var get = client.Methods.Single(method => method.Name == "get");
            get.Operation.Update(parameters: get.Operation.Parameters.Select(parameter => parameter.Name == "expand"
                ? InputFactory.QueryParameter("expand", readType, isRequired: true, serializedName: "$expand") : parameter));
            get.Update(parameters: get.Parameters.Select(parameter => parameter.Name == "expand"
                ? InputFactory.MethodParameter("expand", readType, isRequired: true, location: InputRequestLocation.Query, serializedName: "$expand") : parameter));
            var head = client.Methods.Single(method => method.Name == "checkExistence");
            head.Operation.Update(parameters: head.Operation.Parameters.Select(parameter => parameter.Name == "headToken"
                ? InputFactory.QueryParameter("headToken", checkType, isRequired: true) : parameter));
            head.Update(parameters: head.Parameters.Select(parameter => parameter.Name == "headToken"
                ? InputFactory.MethodParameter("headToken", checkType, isRequired: true, location: InputRequestLocation.Query) : parameter));
            var lastContract = $$"""
                using System.Threading;
                using Azure;
                using Azure.ResourceManager;
                namespace Samples
                {
                    public partial class ResponseTypeCollection : ArmCollection
                    {
                        public virtual Response<bool> Exists(string testName, {{(publishedIsLong ? "long" : "int")}} expand, CancellationToken cancellationToken = default) => throw null;
                    }
                }
                """;
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client], customizationSources: [lastContract], lastContractCompilation: () => Helpers.BuildCompilation([("LastContract.cs", lastContract)]));
            using var diagnostics = CaptureDiagnostics(plugin);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            ManagementMockHelpers.ProcessTypeForBackCompatibility(collection);
            var generated = new TypeProviderWriter(collection).Write().Content;
            const string callers = "namespace Samples { internal class Caller { void Call(ResponseTypeCollection collection) { collection.Exists(\"test\", default); } } }";
            var compilation = Helpers.BuildCompilation([("Collection.cs", generated), ("Customization.cs", lastContract), ("Callers.cs", callers)])
                .AddReferences(Microsoft.CodeAnalysis.MetadataReference.CreateFromFile(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(typeof(object).Assembly.Location)!, "System.Runtime.dll")));
            Assert.That(compilation.GetDiagnostics().Any(diagnostic => diagnostic.Id == "CS0121" && diagnostic.Location.SourceTree?.FilePath == "Callers.cs"), Is.False);
            var tree = compilation.SyntaxTrees.Single(tree => tree.FilePath == "Callers.cs");
            var invocation = tree.GetRoot().DescendantNodes().OfType<Microsoft.CodeAnalysis.CSharp.Syntax.InvocationExpressionSyntax>().Single();
            var symbol = Microsoft.CodeAnalysis.CSharp.CSharpExtensions.GetSymbolInfo(compilation.GetSemanticModel(tree), invocation).Symbol as Microsoft.CodeAnalysis.IMethodSymbol;
            Assert.That(symbol?.Parameters[1].Type.SpecialType, Is.EqualTo(Microsoft.CodeAnalysis.SpecialType.System_Int32));
            var text = System.Text.Encoding.UTF8.GetString(diagnostics.ToArray());
            Assert.That(text, Does.Not.Contain("\"severity\":\"error\""));
        }

        [Test]
        public void CustomGenericOverloadCanMakeDefaultAmbiguous()
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true, includeGetQueryParameter: true, includeCheckExistenceQueryParameter: true);
            var array = InputFactory.Array(InputPrimitiveType.String);
            var get = client.Methods.Single(method => method.Name == "get");
            get.Operation.Update(parameters: get.Operation.Parameters.Select(parameter => parameter.Name == "expand"
                ? InputFactory.QueryParameter("expand", array, isRequired: true, serializedName: "$expand") : parameter));
            get.Update(parameters: get.Parameters.Select(parameter => parameter.Name == "expand"
                ? InputFactory.MethodParameter("expand", array, isRequired: true, location: InputRequestLocation.Query, serializedName: "$expand") : parameter));
            var head = client.Methods.Single(method => method.Name == "checkExistence");
            head.Operation.Update(parameters: head.Operation.Parameters.Select(parameter => parameter.Name == "headToken"
                ? InputFactory.QueryParameter("headToken", InputPrimitiveType.Int32, isRequired: true) : parameter));
            head.Update(parameters: head.Parameters.Select(parameter => parameter.Name == "headToken"
                ? InputFactory.MethodParameter("headToken", InputPrimitiveType.Int32, isRequired: true, location: InputRequestLocation.Query) : parameter));
            const string lastContract = """
                using System.Collections.Generic;
                using System.Threading;
                using Azure;
                using Azure.ResourceManager;
                namespace Samples
                {
                    public partial class ResponseTypeCollection : ArmCollection
                    {
                        public virtual Response<bool> Exists(string testName, IEnumerable<string> expand, CancellationToken cancellationToken = default) => throw null;
                    }
                }
                """;
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client], customizationSources: [lastContract], lastContractCompilation: () => Helpers.BuildCompilation([("LastContract.cs", lastContract)]));
            using var diagnostics = CaptureDiagnostics(plugin);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            ManagementMockHelpers.ProcessTypeForBackCompatibility(collection);
            var generated = new TypeProviderWriter(collection).Write().Content;
            const string callers = "namespace Samples { internal class Caller { void Call(ResponseTypeCollection collection) { collection.Exists(\"test\", default); } } }";
            var compilation = Helpers.BuildCompilation([("Collection.cs", generated), ("Customization.cs", lastContract), ("Callers.cs", callers)])
                .AddReferences(Microsoft.CodeAnalysis.MetadataReference.CreateFromFile(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(typeof(object).Assembly.Location)!, "System.Runtime.dll")));
            Assert.That(compilation.GetDiagnostics().Any(diagnostic => diagnostic.Id == "CS0121" && diagnostic.Location.SourceTree?.FilePath == "Callers.cs"), Is.True);
            Assert.That(System.Text.Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""));
        }

        [Test]
        public void CustomCheckExistenceOverridesGeneratedMethod()
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true, includeGetQueryParameter: true);
            var source = """
                using System.Threading;
                using System.Threading.Tasks;
                using Azure;
                namespace Samples
                {
                    public partial class ResponseTypeCollection
                    {
                        public virtual Response<bool> Exists(string testName, CancellationToken cancellationToken = default) => throw null;
                        public virtual Task<Response<bool>> ExistsAsync(string testName, CancellationToken cancellationToken = default) => throw null;
                    }
                }
                """;
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client], customizationSources: [source], lastContractCompilation: () => Helpers.GetCompilationFromDirectory(method: nameof(CustomGetOverloadCanCoexistWithCheckExistence)));
            using var diagnostics = CaptureDiagnostics(plugin);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            ManagementMockHelpers.ProcessTypeForBackCompatibility(collection);
            var text = System.Text.Encoding.UTF8.GetString(diagnostics.ToArray());
            Assert.That(collection.CustomCodeView!.Methods.Select(method => method.Signature.Name), Does.Contain("Exists").And.Contain("ExistsAsync"));
            Assert.That(collection.Methods.Single(method => method.Signature.Name == "GetIfExists").BodyStatements!.ToDisplayString(), Does.Contain("CreateGetRequest"));
            Assert.That(text, Does.Not.Contain("\"severity\":\"error\""));
        }

        private static System.IO.MemoryStream CaptureDiagnostics(Moq.Mock<ManagementClientGenerator> plugin)
        {
            var diagnostics = new System.IO.MemoryStream();
            var emitter = (Microsoft.TypeSpec.Generator.EmitterRpc.Emitter)Activator.CreateInstance(typeof(Microsoft.TypeSpec.Generator.EmitterRpc.Emitter),
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, [diagnostics], null)!;
            plugin.Setup(p => p.Emitter).Returns(emitter);
            return diagnostics;
        }

        [TestCase("Exists")]
        [TestCase("ExistsAsync")]
        public void ExistsUsesHeadWhenItRequiresAdditionalParameter(string methodName)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true, includeCheckExistenceQueryParameter: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            var method = collection.Methods.Single(m => m.Signature.Name == methodName);

            Assert.That(method.Signature.Parameters.Select(p => p.Name), Does.Contain("headToken"));
            Assert.That(method.BodyStatements!.ToDisplayString(), Does.Contain("CreateCheckExistenceRequest"));
        }

        [TestCase("Exists")]
        [TestCase("ExistsAsync")]
        public void ExistsUsesHeadContextualParameterType(string methodName)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true, headResourceGroupIsGuid: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            var body = collection.Methods.Single(m => m.Signature.Name == methodName).BodyStatements!.ToDisplayString();

            Assert.That(body, Does.Contain("CreateCheckExistenceRequest"));
            Assert.That(body, Does.Contain("Guid.Parse(this.Id.ResourceGroupName)"));
        }

        [TestCase("Exists")]
        [TestCase("ExistsAsync")]
        public void ExistsUsesCheckExistenceParametersWhenTheyDifferFromRead(string methodName)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true, includeCheckExistenceQueryParameter: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            var method = collection.Methods.Single(m => m.Signature.Name == methodName);

            Assert.That(method.Signature.Parameters.Select(p => p.Name), Does.Contain("headToken"));
            Assert.That(method.BodyStatements!.ToDisplayString(), Does.Contain("CreateCheckExistenceRequest"));
        }

        [TestCase("Exists", false)]
        [TestCase("ExistsAsync", false)]
        [TestCase("Exists", true)]
        [TestCase("ExistsAsync", true)]
        public void ExistsUsesHeadWhenPathEscapingDiffers(string methodName, bool contextual)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true,
                headResourceGroupSkipEncoding: contextual, headNameSkipEncoding: !contextual);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            var body = collection.Methods.Single(m => m.Signature.Name == methodName).BodyStatements!.ToDisplayString();

            Assert.That(body, Does.Contain("CreateCheckExistenceRequest"));
        }

        [TestCase("Exists")]
        [TestCase("ExistsAsync")]
        public void ExistsUsesHeadVisibilityWhenHeadIsInternal(string methodName)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true, headIsInternal: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            var method = collection.Methods.Single(m => m.Signature.Name == methodName);

            Assert.That(method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public), Is.False);
            Assert.That(method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal), Is.True);
            Assert.That(method.BodyStatements!.ToDisplayString(), Does.Contain("CreateCheckExistenceRequest"));
        }

        [TestCase("Exists", false)]
        [TestCase("ExistsAsync", false)]
        [TestCase("Exists", true)]
        [TestCase("ExistsAsync", true)]
        public void ExistsUsesHeadWhenConstantQuerySelectorDiffers(string methodName, bool headOmitsSelector)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true);
            var get = client.Methods.Single(m => m.Name == "get");
            var head = client.Methods.Single(m => m.Name == "checkExistence");
            get.Operation.Update(parameters: [.. get.Operation.Parameters, InputFactory.QueryParameter("partition", InputFactory.Literal.String("primary"), isRequired: true, scope: InputParameterScope.Constant)]);
            if (!headOmitsSelector)
            {
                head.Operation.Update(parameters: [.. head.Operation.Parameters, InputFactory.QueryParameter("partition", InputFactory.Literal.String("secondary"), isRequired: true, scope: InputParameterScope.Constant)]);
            }
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            var body = collection.Methods.Single(m => m.Signature.Name == methodName).BodyStatements!.ToDisplayString();

            Assert.That(body, Does.Contain("CreateCheckExistenceRequest"));
        }

        [TestCase("Exists")]
        [TestCase("ExistsAsync")]
        public void ExistsUsesHeadWhenGroupedConditionalHeadersDiffer(string methodName)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true);
            var get = client.Methods.Single(m => m.Name == "get");
            var head = client.Methods.Single(m => m.Name == "checkExistence");
            var dateTime = new InputDateTimeType(DateTimeKnownEncoding.Rfc3339, "utcDateTime", "TypeSpec.utcDateTime", InputPrimitiveType.String);
            AddConditionalHeader(get, "ifModifiedSince", "If-Modified-Since", dateTime);
            AddConditionalHeader(head, "ifUnmodifiedSince", "If-Unmodified-Since", dateTime);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            var method = collection.Methods.Single(m => m.Signature.Name == methodName);

            Assert.That(method.Signature.Parameters.Any(p => p.Type.FrameworkType == typeof(RequestConditions)), Is.True);
            Assert.That(method.BodyStatements!.ToDisplayString(), Does.Contain("CreateCheckExistenceRequest"));
        }

        [TestCase("Exists")]
        [TestCase("ExistsAsync")]
        public void ExistsUsesHeadWhenConstantSelectorsAndConditionalHeadersMatch(string methodName)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true);
            var get = client.Methods.Single(m => m.Name == "get");
            var head = client.Methods.Single(m => m.Name == "checkExistence");
            var dateTime = new InputDateTimeType(DateTimeKnownEncoding.Rfc3339, "utcDateTime", "TypeSpec.utcDateTime", InputPrimitiveType.String);
            foreach (var method in new[] { get, head })
            {
                method.Operation.Update(parameters: [.. method.Operation.Parameters, InputFactory.QueryParameter("partition", InputFactory.Literal.String("primary"), isRequired: true, scope: InputParameterScope.Constant)]);
                AddConditionalHeader(method, "ifModifiedSince", "If-Modified-Since", dateTime);
            }
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            var body = collection.Methods.Single(m => m.Signature.Name == methodName).BodyStatements!.ToDisplayString();

            Assert.That(body, Does.Contain("CreateCheckExistenceRequest"));
        }

        private static void AddConditionalHeader(InputServiceMethod method, string name, string wireName, InputType type)
        {
            method.Operation.Update(parameters: [.. method.Operation.Parameters, InputFactory.HeaderParameter(name, type, serializedName: wireName)]);
            method.Update(parameters: [.. method.Parameters, InputFactory.MethodParameter(name, type, serializedName: wireName, location: InputRequestLocation.Header)]);
        }

        [TestCase("Exists", false)]
        [TestCase("ExistsAsync", false)]
        [TestCase("Exists", true)]
        [TestCase("ExistsAsync", true)]
        public void ExistsUsesHeadWhenConstantHeaderSelectorDiffers(string methodName, bool headOmitsSelector)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true);
            var get = client.Methods.Single(m => m.Name == "get");
            var head = client.Methods.Single(m => m.Name == "checkExistence");
            AddConstantHeader(get, "primary");
            if (!headOmitsSelector)
            {
                AddConstantHeader(head, "secondary");
            }
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            Assert.That(collection.Methods.Single(m => m.Signature.Name == methodName).BodyStatements!.ToDisplayString(), Does.Contain("CreateCheckExistenceRequest"));
        }

        [TestCase("Exists")]
        [TestCase("ExistsAsync")]
        public void ExistsUsesHeadWhenQueryArrayEncodingDiffers(string methodName)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true);
            var get = client.Methods.Single(m => m.Name == "get");
            var head = client.Methods.Single(m => m.Name == "checkExistence");
            var array = InputFactory.Array(InputPrimitiveType.String);
            AddQueryArray(get, array, ",");
            AddQueryArray(head, array, "|");
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var restMethods = plugin.Object.TypeFactory.CreateClient(client)!.RestClient.Methods;
            var getRequest = restMethods.Single(m => m.Signature.Name == "CreateGetRequest").BodyStatements!.ToDisplayString();
            var headRequest = restMethods.Single(m => m.Signature.Name == "CreateCheckExistenceRequest").BodyStatements!.ToDisplayString();
            Assert.That(getRequest, Does.Contain("AppendQueryDelimited").And.Contain("\",\""));
            Assert.That(headRequest, Does.Contain("AppendQueryDelimited").And.Contain("\"|\""));
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            Assert.That(collection.Methods.Single(m => m.Signature.Name == methodName).BodyStatements!.ToDisplayString(), Does.Contain("CreateCheckExistenceRequest"));
        }

        [TestCase("Exists")]
        [TestCase("ExistsAsync")]
        public void ExistsUsesHeadWhenQueryArrayAndConstantHeadersMatch(string methodName)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true);
            var get = client.Methods.Single(m => m.Name == "get");
            var head = client.Methods.Single(m => m.Name == "checkExistence");
            var array = InputFactory.Array(InputPrimitiveType.String);
            foreach (var method in new[] { get, head })
            {
                AddQueryArray(method, array, ",");
                AddConstantHeader(method, "primary");
            }
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            Assert.That(collection.Methods.Single(m => m.Signature.Name == methodName).BodyStatements!.ToDisplayString(), Does.Contain("CreateCheckExistenceRequest"));
        }

        [TestCase("Exists", false)]
        [TestCase("ExistsAsync", false)]
        [TestCase("Exists", true)]
        [TestCase("ExistsAsync", true)]
        public void ExistsUsesHeadHeaderArrayEncoding(string methodName, bool matching)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true);
            var get = client.Methods.Single(m => m.Name == "get");
            var head = client.Methods.Single(m => m.Name == "checkExistence");
            var array = InputFactory.Array(InputPrimitiveType.String);
            AddHeaderArray(get, array, ",");
            AddHeaderArray(head, array, matching ? "," : "|");
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var restMethods = plugin.Object.TypeFactory.CreateClient(client)!.RestClient.Methods;
            var getRequest = restMethods.Single(m => m.Signature.Name == "CreateGetRequest").BodyStatements!.ToDisplayString();
            var headRequest = restMethods.Single(m => m.Signature.Name == "CreateCheckExistenceRequest").BodyStatements!.ToDisplayString();
            Assert.That(getRequest, Does.Contain("\",\""));
            Assert.That(headRequest, Does.Contain(matching ? "\",\"" : "\"|\""));
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            var body = collection.Methods.Single(m => m.Signature.Name == methodName).BodyStatements!.ToDisplayString();
            Assert.That(body, Does.Contain("CreateCheckExistenceRequest"));
        }

        private static void AddHeaderArray(InputServiceMethod method, InputType type, string delimiter)
        {
            var header = new InputHeaderParameter("tags", null, null, type, true, false, null, null, "x-ms-tags", false, null,
                InputParameterScope.Method, delimiter, false);
            method.Operation.Update(parameters: [.. method.Operation.Parameters, header]);
            method.Update(parameters: [.. method.Parameters, InputFactory.MethodParameter("tags", type, isRequired: true,
                serializedName: "x-ms-tags", location: InputRequestLocation.Header)]);
        }

        private static void AddConstantHeader(InputServiceMethod method, string value)
        {
            method.Operation.Update(parameters: [.. method.Operation.Parameters, InputFactory.HeaderParameter("partition", InputFactory.Literal.String(value), isRequired: true, serializedName: "x-ms-partition", scope: InputParameterScope.Constant)]);
        }

        private static void AddQueryArray(InputServiceMethod method, InputType type, string delimiter)
        {
            method.Operation.Update(parameters: [.. method.Operation.Parameters, InputFactory.QueryParameter("filters", type, isRequired: true, delimiter: delimiter)]);
            method.Update(parameters: [.. method.Parameters, InputFactory.MethodParameter("filters", type, isRequired: true, location: InputRequestLocation.Query)]);
        }

        [TestCase("Exists", false)]
        [TestCase("ExistsAsync", false)]
        [TestCase("Exists", true)]
        [TestCase("ExistsAsync", true)]
        public void ExistsUsesHeadConstantPath(string methodName, bool matching)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true);
            var get = client.Methods.Single(m => m.Name == "get");
            var head = client.Methods.Single(m => m.Name == "checkExistence");
            SetConstantResourceGroup(get, "primary");
            SetConstantResourceGroup(head, matching ? "primary" : "secondary");
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var restMethods = plugin.Object.TypeFactory.CreateClient(client)!.RestClient.Methods;
            Assert.That(restMethods.Single(m => m.Signature.Name == "CreateGetRequest").BodyStatements!.ToDisplayString(), Does.Contain("\"primary\""));
            Assert.That(restMethods.Single(m => m.Signature.Name == "CreateCheckExistenceRequest").BodyStatements!.ToDisplayString(), Does.Contain(matching ? "\"primary\"" : "\"secondary\""));
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            var body = collection.Methods.Single(m => m.Signature.Name == methodName).BodyStatements!.ToDisplayString();
            Assert.That(body, Does.Contain("CreateCheckExistenceRequest"));
        }

        [TestCase("Exists", false)]
        [TestCase("ExistsAsync", false)]
        [TestCase("Exists", true)]
        [TestCase("ExistsAsync", true)]
        public void ExistsUsesHeadOperationUri(string methodName, bool matching)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true);
            var get = client.Methods.Single(m => m.Name == "get");
            var head = client.Methods.Single(m => m.Name == "checkExistence");
            get.Operation.Update(uri: "/primary");
            head.Operation.Update(uri: matching ? "/primary" : "/secondary");
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var restMethods = plugin.Object.TypeFactory.CreateClient(client)!.RestClient.Methods;
            Assert.That(restMethods.Single(m => m.Signature.Name == "CreateGetRequest").BodyStatements!.ToDisplayString(), Does.Contain("\"/primary\""));
            Assert.That(restMethods.Single(m => m.Signature.Name == "CreateCheckExistenceRequest").BodyStatements!.ToDisplayString(), Does.Contain(matching ? "\"/primary\"" : "\"/secondary\""));
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            var body = collection.Methods.Single(m => m.Signature.Name == methodName).BodyStatements!.ToDisplayString();
            Assert.That(body, Does.Contain("CreateCheckExistenceRequest"));
        }

        private static void SetConstantResourceGroup(InputServiceMethod method, string value)
        {
            var parameter = InputFactory.PathParameter("resourceGroupName", InputFactory.Literal.String(value), isRequired: true, scope: InputParameterScope.Constant);
            method.Operation.Update(parameters: [.. method.Operation.Parameters.Select(p => p.SerializedName == "resourceGroupName" ? parameter : p)]);
        }

        [TestCase("GetIfExists")]
        [TestCase("GetIfExistsAsync")]
        public void GetIfExistsUsesReadWhenCheckExistenceIsAvailable(string methodName)
        {
            var (client, models) = InputResourceData.ClientWithResource(includeCheckExistence: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single();
            var body = collection.Methods.Single(m => m.Signature.Name == methodName).BodyStatements!.ToDisplayString();

            Assert.That(body, Does.Contain("CreateGetRequest"));
            Assert.That(body, Does.Not.Contain("CreateCheckExistenceRequest"));
        }

        [TestCase]
        public void Verify_ExistsAsyncOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("ExistsAsync");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async));
            Assert.That(signature.Parameters.Count, Is.EqualTo(2));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Task<>)));

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_GetIfExistsOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("GetIfExists");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual));
            Assert.That(signature.Parameters.Count, Is.EqualTo(2));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(NullableResponse<>)));

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_GetIfExistsAsyncOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("GetIfExistsAsync");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async));
            Assert.That(signature.Parameters.Count, Is.EqualTo(2));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Task<>)));

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_CreateOrUpdateOperationMethod()
        {
            ResourceCollectionClientProvider resourceProvider = GetResourceCollectionClientProvider();

            MethodProvider createOrUpdateMethod = GetResourceCollectionClientProviderMethodByName("CreateOrUpdate");

            // verify the method signature
            var signature = createOrUpdateMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual));
            // the createOrUpdate method is a fake LRO, therefore it has 4 parameters
            Assert.That(signature.Parameters.Count, Is.EqualTo(4));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(WaitUntil)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[2].Type.Name.EndsWith("Data"), Is.True);
            // Body parameter for PUT operations must be required (no default value)
            Assert.That(signature.Parameters[2].DefaultValue, Is.Null, "Body parameter should be required for PUT operations");
            Assert.That(signature.Parameters[3].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(ArmOperation<>)));

            // verify the method body
            var bodyStatements = createOrUpdateMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var expected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(expected));
            Assert.That(resourceProvider.BodyDependencyTypes, Does.Contain(ManagementClientGenerator.Instance.OutputLibrary.ArmOperationOfT.Type));
            Assert.That(resourceProvider.BodyDependencyTypes.Any(type => type.Name.EndsWith("OperationSource")), Is.False);
        }

        [TestCase]
        public void Verify_CreateOrUpdateAsyncOperationMethod()
        {
            MethodProvider createOrUpdateMethod = GetResourceCollectionClientProviderMethodByName("CreateOrUpdateAsync");

            // verify the method signature
            var signature = createOrUpdateMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async));
            // the createOrUpdate method is a fake LRO, therefore it has 4 parameters
            Assert.That(signature.Parameters.Count, Is.EqualTo(4));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(WaitUntil)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[2].Type.Name.EndsWith("Data"), Is.True);
            // Body parameter for PUT operations must be required (no default value)
            Assert.That(signature.Parameters[2].DefaultValue, Is.Null, "Body parameter should be required for PUT operations");
            Assert.That(signature.Parameters[3].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Task<>)));
            Assert.That(signature.ReturnType?.Arguments[0].FrameworkType, Is.EqualTo(typeof(ArmOperation<>)));

            // verify the method body
            var bodyStatements = createOrUpdateMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var expected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(expected));
        }

        [TestCase]
        public void Verify_PutBodyParameterIsRequiredEvenWhenOptionalInSpec()
        {
            var (client, models) = InputResourceData.ClientWithResourceOptionalBody();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceCollectionClientProvider) as ResourceCollectionClientProvider;
            Assert.That(resourceProvider, Is.Not.Null);

            var createOrUpdate = resourceProvider!.Methods.FirstOrDefault(m => m.Signature.Name == "CreateOrUpdate");
            Assert.That(createOrUpdate, Is.Not.Null);
            var signature = createOrUpdate!.Signature;

            // Body parameter (Data) should be required even though it's optional in the spec
            var dataParam = signature.Parameters.FirstOrDefault(p => p.Type.Name.EndsWith("Data"));
            Assert.That(dataParam, Is.Not.Null, "Body parameter should exist");
            Assert.That(dataParam!.DefaultValue, Is.Null, "PUT body parameter should be required (no default value) even when optional in spec");
        }

        [TestCase]
        public void Verify_PatchBodyParameterIsRequiredEvenWhenOptionalInSpec()
        {
            var (client, models) = InputResourceData.ClientWithResourceOptionalBody();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceClientProvider) as ResourceClientProvider;
            Assert.That(resourceProvider, Is.Not.Null);

            var update = resourceProvider!.Methods.FirstOrDefault(m => m.Signature.Name == "Update");
            Assert.That(update, Is.Not.Null);
            var signature = update!.Signature;

            // Body parameter should be required even though it's optional in the spec
            var bodyParam = signature.Parameters.FirstOrDefault(p => p.Location == ParameterLocation.Body);
            Assert.That(bodyParam, Is.Not.Null, "Body parameter should exist");
            Assert.That(bodyParam!.DefaultValue, Is.Null, "PATCH body parameter should be required (no default value) even when optional in spec");
        }

        [TestCase]
        public void Verify_ExistsReturnType_WhenGetIsLro()
        {
            var (client, models) = InputResourceData.ClientWithResourceLroGet();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceCollectionClientProvider) as ResourceCollectionClientProvider;
            Assert.That(resourceProvider, Is.Not.Null);

            var existsMethod = resourceProvider!.Methods.FirstOrDefault(m => m.Signature.Name == "Exists");
            Assert.That(existsMethod, Is.Not.Null);
            var signature = existsMethod!.Signature;
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Response<>)),
                "Exists should return Response<bool> even when Get is an LRO");
            // Verify no WaitUntil parameter and correct parameter shape
            Assert.That(signature.Parameters.Count, Is.EqualTo(2), "Exists should have 2 parameters (testName, cancellationToken)");
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.Parameters.Any(p => p.Type.Equals(typeof(WaitUntil))), Is.False,
                "Exists should not have a WaitUntil parameter even when Get is an LRO");
        }

        [TestCase]
        public void Verify_ExistsAsyncReturnType_WhenGetIsLro()
        {
            var (client, models) = InputResourceData.ClientWithResourceLroGet();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceCollectionClientProvider) as ResourceCollectionClientProvider;
            Assert.That(resourceProvider, Is.Not.Null);

            var existsAsyncMethod = resourceProvider!.Methods.FirstOrDefault(m => m.Signature.Name == "ExistsAsync");
            Assert.That(existsAsyncMethod, Is.Not.Null);
            var signature = existsAsyncMethod!.Signature;
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Task<>)),
                "ExistsAsync should return Task<Response<bool>> even when Get is an LRO");
            Assert.That(signature.ReturnType?.Arguments[0].FrameworkType, Is.EqualTo(typeof(Response<>)),
                "ExistsAsync inner type should be Response<bool> even when Get is an LRO");
            // Verify no WaitUntil parameter and correct parameter shape
            Assert.That(signature.Parameters.Count, Is.EqualTo(2), "ExistsAsync should have 2 parameters (testName, cancellationToken)");
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.Parameters.Any(p => p.Type.Equals(typeof(WaitUntil))), Is.False,
                "ExistsAsync should not have a WaitUntil parameter even when Get is an LRO");
        }

        [TestCase]
        public void Verify_GetIfExistsReturnType_WhenGetIsLro()
        {
            var (client, models) = InputResourceData.ClientWithResourceLroGet();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceCollectionClientProvider) as ResourceCollectionClientProvider;
            Assert.That(resourceProvider, Is.Not.Null);

            var getIfExistsMethod = resourceProvider!.Methods.FirstOrDefault(m => m.Signature.Name == "GetIfExists");
            Assert.That(getIfExistsMethod, Is.Not.Null);
            var signature = getIfExistsMethod!.Signature;
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(NullableResponse<>)),
                "GetIfExists should return NullableResponse<> even when Get is an LRO");
            // Verify no WaitUntil parameter and correct parameter shape
            Assert.That(signature.Parameters.Count, Is.EqualTo(2), "GetIfExists should have 2 parameters (testName, cancellationToken)");
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.Parameters.Any(p => p.Type.Equals(typeof(WaitUntil))), Is.False,
                "GetIfExists should not have a WaitUntil parameter even when Get is an LRO");
        }

        [TestCase]
        public void Verify_GetIfExistsAsyncReturnType_WhenGetIsLro()
        {
            var (client, models) = InputResourceData.ClientWithResourceLroGet();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceCollectionClientProvider) as ResourceCollectionClientProvider;
            Assert.That(resourceProvider, Is.Not.Null);

            var getIfExistsAsyncMethod = resourceProvider!.Methods.FirstOrDefault(m => m.Signature.Name == "GetIfExistsAsync");
            Assert.That(getIfExistsAsyncMethod, Is.Not.Null);
            var signature = getIfExistsAsyncMethod!.Signature;
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Task<>)),
                "GetIfExistsAsync should return Task<NullableResponse<>> even when Get is an LRO");
            Assert.That(signature.ReturnType?.Arguments[0].FrameworkType, Is.EqualTo(typeof(NullableResponse<>)),
                "GetIfExistsAsync inner type should be NullableResponse<> even when Get is an LRO");
            // Verify no WaitUntil parameter and correct parameter shape
            Assert.That(signature.Parameters.Count, Is.EqualTo(2), "GetIfExistsAsync should have 2 parameters (testName, cancellationToken)");
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.Parameters.Any(p => p.Type.Equals(typeof(WaitUntil))), Is.False,
                "GetIfExistsAsync should not have a WaitUntil parameter even when Get is an LRO");
        }

        // Regression test for https://github.com/Azure/azure-sdk-for-net/issues/59242
        // The collection class must only declare REST client / diagnostics fields for operation
        // groups whose methods are actually emitted on the collection. Methods whose operation
        // group only contributes to the resource class (e.g. Actions) must not leak fields onto
        // the collection.
        [TestCase]
        public void CollectionDoesNotEmitFieldsForActionOnlyOperationGroup()
        {
            var (mainClient, actionClient, models) = InputResourceData.ClientWithResourceActionInDifferentClient();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [mainClient, actionClient]);

            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().FirstOrDefault();
            Assert.That(collection, Is.Not.Null);

            // ActionClient's REST client type is named "ActionClient" -> field name "_actionClientRestClient".
            // The bug being guarded against would have emitted this field on the collection because
            // CreateClientInfosMap iterated the full resource metadata methods list, including the
            // action method.
            var fieldNames = collection!.Fields.Select(f => f.Name).ToArray();
            Assert.That(fieldNames, Does.Not.Contain("_actionClientRestClient"),
                "Collection must not declare a REST client field for an operation group whose methods are only emitted on the resource class.");
            Assert.That(fieldNames, Does.Not.Contain("_actionClientClientDiagnostics"),
                "Collection must not declare a diagnostics field for an operation group whose methods are only emitted on the resource class.");
        }

        [TestCase]
        public void ResourceStillEmitsFieldsForActionOnlyOperationGroup()
        {
            // Companion to CollectionDoesNotEmitFieldsForActionOnlyOperationGroup: the resource
            // class IS allowed (and required) to keep the ActionClient field, since the action
            // method is emitted on the resource.
            var (mainClient, actionClient, models) = InputResourceData.ClientWithResourceActionInDifferentClient();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [mainClient, actionClient]);

            var resource = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().FirstOrDefault();
            Assert.That(resource, Is.Not.Null);

            var fieldNames = resource!.Fields.Select(f => f.Name).ToArray();
            Assert.That(fieldNames, Does.Contain("_actionClientRestClient"),
                "Resource must declare a REST client field for the action's operation group.");
            Assert.That(fieldNames, Does.Contain("_actionClientClientDiagnostics"),
                "Resource must declare a diagnostics field for the action's operation group.");
        }

        [TestCase]
        public void CollectionEmitsCollectionActionFromSeparateOperationGroup()
        {
            var (mainClient, actionClient, models) = InputResourceData.ClientWithResourceCollectionActionInDifferentClient();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [mainClient, actionClient]);

            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().FirstOrDefault();
            Assert.That(collection, Is.Not.Null);

            var methodNames = collection!.Methods.Select(m => m.Signature.Name).ToArray();
            Assert.That(methodNames, Does.Contain("DoAction"));
            Assert.That(methodNames, Does.Contain("DoActionAsync"));

            var fieldNames = collection.Fields.Select(f => f.Name).ToArray();
            Assert.That(fieldNames, Does.Contain("_actionClientRestClient"));
            Assert.That(fieldNames, Does.Contain("_actionClientClientDiagnostics"));

            var resource = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().FirstOrDefault();
            Assert.That(resource, Is.Not.Null);
            Assert.That(resource!.Methods.Select(m => m.Signature.Name), Does.Not.Contain("DoAction"));
            Assert.That(resource.Methods.Select(m => m.Signature.Name), Does.Not.Contain("DoActionAsync"));
        }
    }
}
