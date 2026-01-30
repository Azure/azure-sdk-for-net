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
        public async Task CodeFixCreatesCustomFileForGeneratedFolderDirectly()
        {
            const string code = @"
namespace Azure.Data.Tables
{
    public partial class {|AZC0012:Foo|}
    {
        public Foo() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Tables
{
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
    /// <summary> TablesFoo. </summary>
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
    public partial class {|AZC0012:Foo|}
    {
        public Foo() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Tables.Models
{
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
    /// <summary> ModelsFoo. </summary>
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
    public partial class {|AZC0012:Foo|}
    {
        public Foo() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Tables.Models.Requests
{
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
    /// <summary> RequestsFoo. </summary>
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
    public partial class {|AZC0012:Foo|}
    {
        public Foo() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Tables.Internal
{
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
    /// <summary> InternalFoo. </summary>
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
    public partial class {|AZC0012:Foo|}
    {
        public Foo() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Tables.Models
{
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
    /// <summary> TablesFoo. </summary>
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
    public partial class {|AZC0012:Foo|}
    {
        public Foo() { }
    }
}";

            const string fixedGeneratedCode = @"
namespace Azure.Data.Tables.Models
{
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
    /// <summary> DataFoo. </summary>
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
    }
}
