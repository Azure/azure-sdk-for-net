// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Verifier = Azure.SdkAnalyzers.Tests.AzureCodeFixVerifier<Azure.SdkAnalyzers.TypeNameAnalyzer, Azure.SdkAnalyzers.TypeNameCodeFixProvider>;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0012CodeFixTests
    {
        [Test]
        public async Task CodeFixRenamesClassWithFirstSuggestion()
        {
            const string code = @"
namespace Azure.Data.Tables
{
    public class {|AZC0012:Foo|}
    {
        public Foo() { }
        public Foo(string connectionString) { }
    }

    public class UsageExample
    {
        public void UseFoo()
        {
            var Foo = new Foo();
            Foo anotherFoo = new Foo(""test"");
        }
    }
}";

            const string fixedCode = @"
namespace Azure.Data.Tables
{
    public class TablesFoo
    {
        public TablesFoo() { }
        public TablesFoo(string connectionString) { }
    }

    public class UsageExample
    {
        public void UseFoo()
        {
            var Foo = new TablesFoo();
            TablesFoo anotherFoo = new TablesFoo(""test"");
        }
    }
}";

            await Verifier.VerifyCodeFixAsync(code, fixedCode, codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixRenamesClassWithSecondSuggestion()
        {
            const string code = @"
namespace Azure.Data.Tables
{
    public class {|AZC0012:Foo|}
    {
        public Foo() { }
    }
}";

            const string fixedCode = @"
namespace Azure.Data.Tables
{
    public class DataFoo
    {
        public DataFoo() { }
    }
}";

            await Verifier.VerifyCodeFixAsync(code, fixedCode, codeActionIndex: 1);
        }

        [Test]
        public async Task CodeFixRenamesInterfaceWithPrefix()
        {
            const string code = @"
namespace Azure.Data.Tables
{
    public interface {|AZC0012:IFoo|}
    {
    }
}";

            const string fixedCode = @"
namespace Azure.Data.Tables
{
    public interface ITablesFoo
    {
    }
}";

            await Verifier.VerifyCodeFixAsync(code, fixedCode, codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixRenamesInterfaceIIO()
        {
            const string code = @"
namespace Azure.Data.Streams
{
    public interface {|AZC0012:IIO|}
    {
        void Read();
    }
}";

            const string fixedCode = @"
namespace Azure.Data.Streams
{
    public interface IStreamsIO
    {
        void Read();
    }
}";

            await Verifier.VerifyCodeFixAsync(code, fixedCode, codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixRenamesInterfaceWithReferences()
        {
            const string code = @"
namespace Azure.Data.Tables
{
    public interface {|AZC0012:ICache|}
    {
        void Set(string key, object value);
    }

    public class CacheManager
    {
        private ICache _cache;

        public CacheManager(ICache cache)
        {
            _cache = cache;
        }

        public void Store(string key, object value)
        {
            _cache.Set(key, value);
        }
    }
}";

            const string fixedCode = @"
namespace Azure.Data.Tables
{
    public interface ITablesCache
    {
        void Set(string key, object value);
    }

    public class CacheManager
    {
        private ITablesCache _cache;

        public CacheManager(ITablesCache cache)
        {
            _cache = cache;
        }

        public void Store(string key, object value)
        {
            _cache.Set(key, value);
        }
    }
}";

            await Verifier.VerifyCodeFixAsync(code, fixedCode, codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixRenamesStructWithConstructor()
        {
            const string code = @"
namespace Azure.Storage.Blobs
{
    public struct {|AZC0012:Options|}
    {
        public Options(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}";

            const string fixedCode = @"
namespace Azure.Storage.Blobs
{
    public struct BlobsOptions
    {
        public BlobsOptions(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}";

            await Verifier.VerifyCodeFixAsync(code, fixedCode, codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixUpdatesReferencesAcrossMultipleMembers()
        {
            const string code = @"
namespace Azure.Messaging
{
    public class {|AZC0012:Sender|}
    {
        public Sender() { }

        public static Sender Create() => new Sender();
    }
}";

            const string fixedCode = @"
namespace Azure.Messaging
{
    public class MessagingSender
    {
        public MessagingSender() { }

        public static MessagingSender Create() => new MessagingSender();
    }
}";

            await Verifier.VerifyCodeFixAsync(code, fixedCode, codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixUsesNamespacePartsInOrder()
        {
            const string code = @"
namespace Azure.Security.KeyVault.Keys
{
    public class {|AZC0012:Foo|}
    {
    }
}";

            // First suggestion should use the most specific namespace part (Keys)
            const string fixedCode = @"
namespace Azure.Security.KeyVault.Keys
{
    public class KeysFoo
    {
    }
}";

            await Verifier.VerifyCodeFixAsync(code, fixedCode, codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixRenamesClassImage()
        {
            const string code = @"
namespace Azure.Data.Tables
{
    public class {|AZC0012:Image|}
    {
        public Image() { }
    }
}";

            const string fixedCode = @"
namespace Azure.Data.Tables
{
    public class TablesImage
    {
        public TablesImage() { }
    }
}";

            await Verifier.VerifyCodeFixAsync(code, fixedCode, codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixRenamesClassIndigo()
        {
            const string code = @"
namespace Azure.Data.Tables
{
    public class {|AZC0012:Indigo|}
    {
        public Indigo() { }
    }
}";

            const string fixedCode = @"
namespace Azure.Data.Tables
{
    public class TablesIndigo
    {
        public TablesIndigo() { }
    }
}";

            await Verifier.VerifyCodeFixAsync(code, fixedCode, codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixRenamesClassIPv4()
        {
            const string code = @"
namespace Azure.Data.Networking
{
    public class {|AZC0012:IPv4|}
    {
        public IPv4() { }
    }
}";

            const string fixedCode = @"
namespace Azure.Data.Networking
{
    public class NetworkingIPv4
    {
        public NetworkingIPv4() { }
    }
}";

            await Verifier.VerifyCodeFixAsync(code, fixedCode, codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixRenamesClassIPv6()
        {
            const string code = @"
namespace Azure.Data.Networking
{
    public class {|AZC0012:IPv6|}
    {
        public IPv6() { }
    }
}";

            const string fixedCode = @"
namespace Azure.Data.Networking
{
    public class NetworkingIPv6
    {
        public NetworkingIPv6() { }
    }
}";

            await Verifier.VerifyCodeFixAsync(code, fixedCode, codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixRenamesClassIndex()
        {
            const string code = @"
namespace Azure.Search.Documents
{
    public class {|AZC0012:Index|}
    {
        public Index(string name) { }
    }
}";

            const string fixedCode = @"
namespace Azure.Search.Documents
{
    public class DocumentsIndex
    {
        public DocumentsIndex(string name) { }
    }
}";

            await Verifier.VerifyCodeFixAsync(code, fixedCode, codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixRenamesAcronymOS()
        {
            const string code = @"
namespace Azure.Compute
{
    public class {|AZC0012:OS|}
    {
        public OS() { }
    }
}";

            const string fixedCode = @"
namespace Azure.Compute
{
    public class ComputeOS
    {
        public ComputeOS() { }
    }
}";

            await Verifier.VerifyCodeFixAsync(code, fixedCode, codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixRenamesAcronymIP()
        {
            const string code = @"
namespace Azure.Data.Networking
{
    public class {|AZC0012:IP|}
    {
        public IP() { }
    }
}";

            const string fixedCode = @"
namespace Azure.Data.Networking
{
    public class NetworkingIP
    {
        public NetworkingIP() { }
    }
}";

            await Verifier.VerifyCodeFixAsync(code, fixedCode, codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixRenamesSingleLetterA()
        {
            const string code = @"
namespace Azure.Data
{
    public class {|AZC0012:A|}
    {
        public A() { }
    }
}";

            const string fixedCode = @"
namespace Azure.Data
{
    public class DataA
    {
        public DataA() { }
    }
}";

            await Verifier.VerifyCodeFixAsync(code, fixedCode, codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixCreatesCustomFileForGeneratedFolderDirectly()
        {
            const string code = @"
namespace Azure.Data.Tables
{
    /// <summary> Represents a foo. </summary>
    public partial class {|AZC0012:Foo|}
    {
        public Foo() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Tables
{
    /// <summary> Represents a foo. </summary>
    public partial class TablesFoo
    {
        public TablesFoo() { }
    }
}";

            const string expectedCustomCode = @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.Tables
{
    /// <summary> Represents a foo. </summary>
    [CodeGenType(""Foo"")]
    public partial class TablesFoo
    {
    }
}
";

            await Verifier.VerifyCodeFixCreatesMultipleFilesAsync(
                code,
                sourceFilePath: "Generated/Foo.cs",
                fixedGeneratedCode,
                fixedGeneratedFilePath: "Generated/TablesFoo.cs",
                expectedCustomCode,
                customFilePath: "/0/Custom/TablesFoo.cs",
                codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixCreatesCustomFileForGeneratedModelsFolder()
        {
            const string code = @"
namespace Azure.Data.Tables.Models
{
    /// <summary> A model representing a foo. </summary>
    public partial class {|AZC0012:Foo|}
    {
        public Foo() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Tables.Models
{
    /// <summary> A model representing a foo. </summary>
    public partial class ModelsFoo
    {
        public ModelsFoo() { }
    }
}";

            const string expectedCustomCode = @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.Tables.Models
{
    /// <summary> A model representing a foo. </summary>
    [CodeGenType(""Foo"")]
    public partial class ModelsFoo
    {
    }
}
";

            await Verifier.VerifyCodeFixCreatesMultipleFilesAsync(
                code,
                sourceFilePath: "Generated/Models/Foo.cs",
                fixedGeneratedCode,
                fixedGeneratedFilePath: "Generated/Models/ModelsFoo.cs",
                expectedCustomCode,
                customFilePath: "/0/Custom/Models/ModelsFoo.cs",
                codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixCreatesCustomFileForGeneratedModelsRequestsFolder()
        {
            const string code = @"
namespace Azure.Data.Tables.Models.Requests
{
    /// <summary> A request model for foo operations. </summary>
    public partial class {|AZC0012:Foo|}
    {
        public Foo() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Tables.Models.Requests
{
    /// <summary> A request model for foo operations. </summary>
    public partial class RequestsFoo
    {
        public RequestsFoo() { }
    }
}";

            const string expectedCustomCode = @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.Tables.Models.Requests
{
    /// <summary> A request model for foo operations. </summary>
    [CodeGenType(""Foo"")]
    public partial class RequestsFoo
    {
    }
}
";

            await Verifier.VerifyCodeFixCreatesMultipleFilesAsync(
                code,
                sourceFilePath: "Generated/Models/Requests/Foo.cs",
                fixedGeneratedCode,
                fixedGeneratedFilePath: "Generated/Models/Requests/RequestsFoo.cs",
                expectedCustomCode,
                customFilePath: "/0/Custom/Models/Requests/RequestsFoo.cs",
                codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixCreatesCustomFileForGeneratedInternalFolder()
        {
            const string code = @"
namespace Azure.Data.Tables.Internal
{
    /// <summary> Internal foo implementation. </summary>
    public partial class {|AZC0012:Foo|}
    {
        public Foo() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Tables.Internal
{
    /// <summary> Internal foo implementation. </summary>
    public partial class InternalFoo
    {
        public InternalFoo() { }
    }
}";

            const string expectedCustomCode = @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.Tables.Internal
{
    /// <summary> Internal foo implementation. </summary>
    [CodeGenType(""Foo"")]
    public partial class InternalFoo
    {
    }
}
";

            await Verifier.VerifyCodeFixCreatesMultipleFilesAsync(
                code,
                sourceFilePath: "Generated/Internal/Foo.cs",
                fixedGeneratedCode,
                fixedGeneratedFilePath: "Generated/Internal/InternalFoo.cs",
                expectedCustomCode,
                customFilePath: "/0/Custom/Internal/InternalFoo.cs",
                codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixCreatesCustomFileForGeneratedFolderSecondSuggestion()
        {
            const string code = @"
namespace Azure.Data.Tables.Models
{
    /// <summary> A model representing a foo. </summary>
    public partial class {|AZC0012:Foo|}
    {
        public Foo() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Tables.Models
{
    /// <summary> A model representing a foo. </summary>
    public partial class TablesFoo
    {
        public TablesFoo() { }
    }
}";

            const string expectedCustomCode = @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.Tables.Models
{
    /// <summary> A model representing a foo. </summary>
    [CodeGenType(""Foo"")]
    public partial class TablesFoo
    {
    }
}
";

            await Verifier.VerifyCodeFixCreatesMultipleFilesAsync(
                code,
                sourceFilePath: "Generated/Models/Foo.cs",
                fixedGeneratedCode,
                fixedGeneratedFilePath: "Generated/Models/TablesFoo.cs",
                expectedCustomCode,
                customFilePath: "/0/Custom/Models/TablesFoo.cs",
                codeActionIndex: 1);
        }

        [Test]
        public async Task CodeFixCreatesCustomFileForGeneratedFolderThirdSuggestion()
        {
            const string code = @"
namespace Azure.Data.Tables.Models
{
    /// <summary> A model representing a foo. </summary>
    public partial class {|AZC0012:Foo|}
    {
        public Foo() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Tables.Models
{
    /// <summary> A model representing a foo. </summary>
    public partial class DataFoo
    {
        public DataFoo() { }
    }
}";

            const string expectedCustomCode = @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.Tables.Models
{
    /// <summary> A model representing a foo. </summary>
    [CodeGenType(""Foo"")]
    public partial class DataFoo
    {
    }
}
";

            await Verifier.VerifyCodeFixCreatesMultipleFilesAsync(
                code,
                sourceFilePath: "Generated/Models/Foo.cs",
                fixedGeneratedCode,
                fixedGeneratedFilePath: "Generated/Models/DataFoo.cs",
                expectedCustomCode,
                customFilePath: "/0/Custom/Models/DataFoo.cs",
                codeActionIndex: 2);
        }

        [Test]
        public async Task CodeFixCreatesCustomFileForGeneratedImage()
        {
            const string code = @"
namespace Azure.Data.Tables
{
    /// <summary> Represents an image resource. </summary>
    public partial class {|AZC0012:Image|}
    {
        public Image() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Tables
{
    /// <summary> Represents an image resource. </summary>
    public partial class TablesImage
    {
        public TablesImage() { }
    }
}";

            const string expectedCustomCode = @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.Tables
{
    /// <summary> Represents an image resource. </summary>
    [CodeGenType(""Image"")]
    public partial class TablesImage
    {
    }
}
";

            await Verifier.VerifyCodeFixCreatesMultipleFilesAsync(
                code,
                sourceFilePath: "Generated/Image.cs",
                fixedGeneratedCode,
                fixedGeneratedFilePath: "Generated/TablesImage.cs",
                expectedCustomCode,
                customFilePath: "/0/Custom/TablesImage.cs",
                codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixCreatesCustomFileForGeneratedIndigo()
        {
            const string code = @"
namespace Azure.Data.Tables
{
    /// <summary> Represents an indigo color configuration. </summary>
    public partial class {|AZC0012:Indigo|}
    {
        public Indigo() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Tables
{
    /// <summary> Represents an indigo color configuration. </summary>
    public partial class TablesIndigo
    {
        public TablesIndigo() { }
    }
}";

            const string expectedCustomCode = @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.Tables
{
    /// <summary> Represents an indigo color configuration. </summary>
    [CodeGenType(""Indigo"")]
    public partial class TablesIndigo
    {
    }
}
";

            await Verifier.VerifyCodeFixCreatesMultipleFilesAsync(
                code,
                sourceFilePath: "Generated/Indigo.cs",
                fixedGeneratedCode,
                fixedGeneratedFilePath: "Generated/TablesIndigo.cs",
                expectedCustomCode,
                customFilePath: "/0/Custom/TablesIndigo.cs",
                codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixCreatesCustomFileForGeneratedIPv4()
        {
            const string code = @"
namespace Azure.Data.Networking.Models
{
    /// <summary> Represents an IPv4 address configuration. </summary>
    public partial class {|AZC0012:IPv4|}
    {
        public IPv4() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Networking.Models
{
    /// <summary> Represents an IPv4 address configuration. </summary>
    public partial class ModelsIPv4
    {
        public ModelsIPv4() { }
    }
}";

            const string expectedCustomCode = @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.Networking.Models
{
    /// <summary> Represents an IPv4 address configuration. </summary>
    [CodeGenType(""IPv4"")]
    public partial class ModelsIPv4
    {
    }
}
";

            await Verifier.VerifyCodeFixCreatesMultipleFilesAsync(
                code,
                sourceFilePath: "Generated/Models/IPv4.cs",
                fixedGeneratedCode,
                fixedGeneratedFilePath: "Generated/Models/ModelsIPv4.cs",
                expectedCustomCode,
                customFilePath: "/0/Custom/Models/ModelsIPv4.cs",
                codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixCreatesCustomFileForGeneratedIPv6()
        {
            const string code = @"
namespace Azure.Data.Networking.Models
{
    /// <summary> Represents an IPv6 address configuration. </summary>
    public partial class {|AZC0012:IPv6|}
    {
        public IPv6() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Networking.Models
{
    /// <summary> Represents an IPv6 address configuration. </summary>
    public partial class ModelsIPv6
    {
        public ModelsIPv6() { }
    }
}";

            const string expectedCustomCode = @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.Networking.Models
{
    /// <summary> Represents an IPv6 address configuration. </summary>
    [CodeGenType(""IPv6"")]
    public partial class ModelsIPv6
    {
    }
}
";

            await Verifier.VerifyCodeFixCreatesMultipleFilesAsync(
                code,
                sourceFilePath: "Generated/Models/IPv6.cs",
                fixedGeneratedCode,
                fixedGeneratedFilePath: "Generated/Models/ModelsIPv6.cs",
                expectedCustomCode,
                customFilePath: "/0/Custom/Models/ModelsIPv6.cs",
                codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixCreatesCustomFileForGeneratedIndex()
        {
            const string code = @"
namespace Azure.Search.Documents.Models
{
    /// <summary> Represents a search index. </summary>
    public partial class {|AZC0012:Index|}
    {
        public Index() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Search.Documents.Models
{
    /// <summary> Represents a search index. </summary>
    public partial class ModelsIndex
    {
        public ModelsIndex() { }
    }
}";

            const string expectedCustomCode = @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Models
{
    /// <summary> Represents a search index. </summary>
    [CodeGenType(""Index"")]
    public partial class ModelsIndex
    {
    }
}
";

            await Verifier.VerifyCodeFixCreatesMultipleFilesAsync(
                code,
                sourceFilePath: "Generated/Models/Index.cs",
                fixedGeneratedCode,
                fixedGeneratedFilePath: "Generated/Models/ModelsIndex.cs",
                expectedCustomCode,
                customFilePath: "/0/Custom/Models/ModelsIndex.cs",
                codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixCreatesCustomFileForGeneratedAcronymOS()
        {
            const string code = @"
namespace Azure.Compute.Models
{
    /// <summary> Represents an operating system configuration. </summary>
    public partial class {|AZC0012:OS|}
    {
        public OS() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Compute.Models
{
    /// <summary> Represents an operating system configuration. </summary>
    public partial class ModelsOS
    {
        public ModelsOS() { }
    }
}";

            const string expectedCustomCode = @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Compute.Models
{
    /// <summary> Represents an operating system configuration. </summary>
    [CodeGenType(""OS"")]
    public partial class ModelsOS
    {
    }
}
";

            await Verifier.VerifyCodeFixCreatesMultipleFilesAsync(
                code,
                sourceFilePath: "Generated/Models/OS.cs",
                fixedGeneratedCode,
                fixedGeneratedFilePath: "Generated/Models/ModelsOS.cs",
                expectedCustomCode,
                customFilePath: "/0/Custom/Models/ModelsOS.cs",
                codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixCreatesCustomFileForGeneratedAcronymIP()
        {
            const string code = @"
namespace Azure.Data.Networking
{
    /// <summary> Represents an IP address. </summary>
    public partial class {|AZC0012:IP|}
    {
        public IP() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Networking
{
    /// <summary> Represents an IP address. </summary>
    public partial class NetworkingIP
    {
        public NetworkingIP() { }
    }
}";

            const string expectedCustomCode = @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.Networking
{
    /// <summary> Represents an IP address. </summary>
    [CodeGenType(""IP"")]
    public partial class NetworkingIP
    {
    }
}
";

            await Verifier.VerifyCodeFixCreatesMultipleFilesAsync(
                code,
                sourceFilePath: "Generated/IP.cs",
                fixedGeneratedCode,
                fixedGeneratedFilePath: "Generated/NetworkingIP.cs",
                expectedCustomCode,
                customFilePath: "/0/Custom/NetworkingIP.cs",
                codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixCreatesCustomFilePreservingCompleteXmlDocumentation()
        {
            const string code = @"
namespace Azure.Data.Tables.Models
{
    /// <summary> Represents a configuration model. </summary>
    /// <remarks>
    /// This model contains advanced configuration settings.
    /// Use with caution in production environments.
    /// </remarks>
    public partial class {|AZC0012:Config|}
    {
        public Config() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Tables.Models
{
    /// <summary> Represents a configuration model. </summary>
    /// <remarks>
    /// This model contains advanced configuration settings.
    /// Use with caution in production environments.
    /// </remarks>
    public partial class ModelsConfig
    {
        public ModelsConfig() { }
    }
}";

            const string expectedCustomCode = @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.Tables.Models
{
    /// <summary> Represents a configuration model. </summary>
    /// <remarks>
    /// This model contains advanced configuration settings.
    /// Use with caution in production environments.
    /// </remarks>
    [CodeGenType(""Config"")]
    public partial class ModelsConfig
    {
    }
}
";

            await Verifier.VerifyCodeFixCreatesMultipleFilesAsync(
                code,
                sourceFilePath: "Generated/Models/Config.cs",
                fixedGeneratedCode,
                fixedGeneratedFilePath: "Generated/Models/ModelsConfig.cs",
                expectedCustomCode,
                customFilePath: "/0/Custom/Models/ModelsConfig.cs",
                codeActionIndex: 0);
        }

        [Test]
        public async Task CodeFixNotOfferedForInterfaceInGeneratedFolder()
        {
            // Interfaces can't have [CodeGenType] attribute, so no fix should be offered
            const string code = @"
namespace Azure.Data.Tables
{
    /// <summary> Represents an image interface. </summary>
    public partial interface {|AZC0012:IImage|}
    {
        void Display();
    }
}";

            await Verifier.VerifyNoCodeFixOfferedAsync(code, sourceFilePath: "Generated/IImage.cs");
        }
    }
}
