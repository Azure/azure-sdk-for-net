// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Verifier = Azure.SdkAnalyzers.Tests.AzureAnalyzerVerifier<Azure.SdkAnalyzers.ArrowPublicApiAnalyzer>;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0040Tests
    {
        private const string ArrowStub = @"
namespace Apache.Arrow
{
    public class Table { }
    public class RecordBatch { }
}

namespace Apache.Arrow.Types
{
    public class Schema { }
}
";

        [Test]
        public async Task AZC0040_ProducedForArrowReturnType()
        {
            string code = @"
using Apache.Arrow;
" + ArrowStub + @"
namespace Azure.Test
{
    public class TableClient
    {
        public Table {|AZC0040:GetTable|}() => null;
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0040_ProducedForArrowParameter()
        {
            string code = @"
using Apache.Arrow;
" + ArrowStub + @"
namespace Azure.Test
{
    public class TableClient
    {
        public void Upload(Table {|AZC0040:table|}) { }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0040_ProducedForArrowProperty()
        {
            string code = @"
using Apache.Arrow;
" + ArrowStub + @"
namespace Azure.Test
{
    public class TableModel
    {
        public Table {|AZC0040:Data|} { get; set; }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0040_ProducedForArrowField()
        {
            string code = @"
using Apache.Arrow;
" + ArrowStub + @"
namespace Azure.Test
{
    public class TableModel
    {
        public Table {|AZC0040:Data|};
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0040_ProducedForArrowEvent()
        {
            string code = @"
using System;
using Apache.Arrow;
" + ArrowStub + @"
namespace Azure.Test
{
    public class TableModel
    {
        public event Action<Table> {|AZC0040:Updated|};
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0040_ProducedForArrowGenericTypeArgument()
        {
            string code = @"
using System.Collections.Generic;
using Apache.Arrow;
" + ArrowStub + @"
namespace Azure.Test
{
    public class TableClient
    {
        public IReadOnlyList<Table> {|AZC0040:GetTables|}() => null;
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0040_ProducedForArrowArrayElement()
        {
            string code = @"
using Apache.Arrow;
" + ArrowStub + @"
namespace Azure.Test
{
    public class TableClient
    {
        public Table[] {|AZC0040:GetTables|}() => null;
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0040_ProducedForArrowSubNamespaceType()
        {
            string code = @"
using Apache.Arrow.Types;
" + ArrowStub + @"
namespace Azure.Test
{
    public class TableModel
    {
        public Schema {|AZC0040:Schema|} { get; set; }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0040_ProducedForArrowBaseType()
        {
            string code = @"
using Apache.Arrow;
" + ArrowStub + @"
namespace Azure.Test
{
    public class {|AZC0040:CustomTable|} : Table
    {
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0040_ProducedForProtectedMember()
        {
            string code = @"
using Apache.Arrow;
" + ArrowStub + @"
namespace Azure.Test
{
    public class TableModel
    {
        protected Table {|AZC0040:Data|} { get; set; }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0040_ProducedForArrowConstructorParameter()
        {
            string code = @"
using Apache.Arrow;
" + ArrowStub + @"
namespace Azure.Test
{
    public class TableModel
    {
        public TableModel(Table {|AZC0040:table|}) { }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0040_ProducedForArrowTypeParameterConstraintOnType()
        {
            string code = @"
using Apache.Arrow;
" + ArrowStub + @"
namespace Azure.Test
{
    public class {|AZC0040:CustomContainer|}<T> where T : Table
    {
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0040_ProducedForArrowTypeParameterConstraintOnMethod()
        {
            string code = @"
using Apache.Arrow;
" + ArrowStub + @"
namespace Azure.Test
{
    public class TableClient
    {
        public void {|AZC0040:Process|}<T>(T item) where T : Table { }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0040_NotProducedForNonArrowTypeParameterConstraint()
        {
            string code = @"
using System;
" + ArrowStub + @"
namespace Azure.Test
{
    public class CustomContainer<T> where T : IDisposable
    {
        public void Process<TItem>(TItem item) where TItem : class { }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0040_NotProducedForInternalMember()
        {
            string code = @"
using Apache.Arrow;
" + ArrowStub + @"
namespace Azure.Test
{
    public class TableModel
    {
        internal Table Data { get; set; }
        private Table OtherData { get; set; }
        public string Name { get; set; }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0040_NotProducedForMemberInPrivateType()
        {
            string code = @"
using Apache.Arrow;
" + ArrowStub + @"
namespace Azure.Test
{
    internal class TableModel
    {
        public Table Data { get; set; }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0040_NotProducedForNonArrowTypes()
        {
            string code = @"
using System.Collections.Generic;
" + ArrowStub + @"
namespace Azure.Test
{
    public class TableModel
    {
        public string Name { get; set; }
        public IReadOnlyList<int> Values { get; set; }
        public int[] Numbers { get; set; }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0040_NotProducedForAzureCoreNamespace()
        {
            string code = @"
using Apache.Arrow;
" + ArrowStub + @"
namespace Azure.Core
{
    public class TableModel
    {
        public Table Data { get; set; }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }
    }
}
