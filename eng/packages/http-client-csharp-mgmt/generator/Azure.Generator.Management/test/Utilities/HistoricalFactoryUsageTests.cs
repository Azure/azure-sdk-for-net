// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests.Utilities
{
    internal class HistoricalFactoryUsageTests
    {
        [TestCase("return new Patch { Id = id };", true, true)]
        [TestCase("return new Patch { Id = null };", true, false)]
        [TestCase("var result = new Patch { Id = id }; result.Id = null; return result;", true, false)]
        [TestCase("var unused = new Patch { Id = id }; return new Patch();", true, false)]
        [TestCase("return new Patch(id);", true, true)]
        [TestCase("if (id == null) throw new System.ArgumentNullException(nameof(id)); return new Patch();", false, false)]
        [TestCase("return new Patch { Id = string.Concat(id, \"suffix\") };", false, false)]
        [TestCase("var result = new Derived(); result.VirtualId = id; return result;", false, false)]
        public void ClassifiesOnlySupportedReturnValueFlow(string body, bool known, bool preserved)
        {
            var usage = Read(body, "1.0.0", true);
            Assert.That(usage.ContainsKey("Patch(System.String)"), Is.EqualTo(known));
            if (known)
            {
                Assert.That(usage["Patch(System.String)"].Contains("id"), Is.EqualTo(preserved));
            }
        }

        [TestCase("1.0.0-beta.1")]
        [TestCase("1.0.0-preview.1+sha")]
        [TestCase(null)]
        public void PreviewOrUnclassifiedBaselineIsNotEnforced(string? version)
        {
            Assert.That(Read("return new Patch { Id = id };", version, true), Is.Empty);
        }

        [Test]
        public void StableBuildMetadataDoesNotMakeBaselinePreview()
        {
            Assert.That(Read("return new Patch { Id = id };", "1.0.0+sha", true)["Patch(System.String)"],
                Does.Contain("id"));
        }

        [Test]
        public void ReplacedImplementationIsNotEvidenceForOriginalContract()
        {
            Assert.That(Read("return new Patch { Id = null };", "1.0.0", true, replaceBaseline: true), Is.Empty);
        }

        [TestCase(null)]
        [TestCase("1.0.0-preview.1")]
        [TestCase("2.0.0")]
        public void UnknownPreviewOrDifferentSelectedVersionIsNotEnforced(string? selectedVersion)
        {
            Assert.That(Read("return new Patch { Id = id };", "1.0.0", true, selectedVersion: selectedVersion), Is.Empty);
        }

        [Test]
        public void OverlappingFieldsDoNotProveHistoricalPreservation()
        {
            var usage = Read("return new Patch(new Slot(id));", "1.0.0", true, parameterType: "int",
                patchMembers: "public Slot State; public Patch(Slot state) { State = state; }",
                extraTypes: """
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)]
                public struct Slot
                {
                    [System.Runtime.InteropServices.FieldOffset(0)] public int First;
                    [System.Runtime.InteropServices.FieldOffset(0)] public int Second;
                    public Slot(int id) { First = id; Second = 0; }
                }
                """);
            Assert.That(usage, Is.Empty,
                "Overlapping storage is unsupported evidence, not proof that the first field retains id.");
        }

        [TestCase("Patch result = null; result.Id = id; return result;")]
        [TestCase("Patch result = null; result.DirectId = id; return result;")]
        [TestCase("return new Patch { Id = ((Patch)null).Id };")]
        [TestCase("return new Patch { Id = ((Patch)null).DirectId };")]
        public void NullDereferenceDoesNotProveReturnedState(string body)
        {
            Assert.That(Read(body, "1.0.0", true, patchMembers: "public string DirectId;"), Is.Empty,
                "An implementation which dereferences a definite null cannot prove returned-state flow.");
        }

        private static IReadOnlyDictionary<string, IReadOnlySet<string>> Read(
            string body, string? version, bool metadataOnly, bool replaceBaseline = false, string? selectedVersion = "1.0.0",
            string parameterType = "string", string patchMembers = "", string extraTypes = "")
        {
            var input = InputFactory.Model("Patch", properties: [InputFactory.Property("id", Microsoft.TypeSpec.Generator.Input.InputPrimitiveType.String)]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input],
                configurationJson: """{"package-name":"Samples"}""");
            var factory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var contract = Helpers.BuildCompilation(
            [
                ("Baseline.cs", $$"""
                {{(version is null ? "" : $"[assembly: System.Reflection.AssemblyInformationalVersion(\"{version}\")]")}}
                namespace Samples
                {
                    {{extraTypes}}
                    public class Patch
                    {
                        public string Id { get; set; }
                        public virtual string VirtualId { get; set; }
                        public Patch() { }
                        public Patch(string id) { Id = id; }
                        {{patchMembers}}
                    }
                    public class Derived : Patch
                    {
                        public override string VirtualId { get => null; set { } }
                    }
                    public static class SamplesModelFactory
                    {
                        public static Patch Patch({{parameterType}} id) { {{body}} }
                    }
                }
                """)
            ]).WithAssemblyName("Samples");
            var source = contract;
            using var file = new FileStream(Path.Combine(Path.GetTempPath(), $"factory-usage-{Guid.NewGuid():N}.dll"),
                FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Read | FileShare.Delete, 4096, FileOptions.DeleteOnClose);
            if (metadataOnly)
            {
                var emit = contract.Emit(file);
                Assert.That(emit.Success, Is.True, string.Join(Environment.NewLine, emit.Diagnostics));
                file.Flush();
                contract = contract.RemoveAllSyntaxTrees().WithAssemblyName("MetadataContract")
                    .AddReferences(MetadataReference.CreateFromFile(file.Name));
            }
            if (replaceBaseline)
            {
                var reference = contract.References.OfType<PortableExecutableReference>().Single(r => r.FilePath == file.Name);
                _ = ((AssemblyMetadata)reference.GetMetadata()).GetModules()[0].GetModuleVersionId();
                _ = contract.GetTypeByMetadataName("Samples.SamplesModelFactory")!.ContainingAssembly.GetAttributes();
                var replacementPath = file.Name + ".replacement";
                try
                {
                    using (var replacement = File.Create(replacementPath))
                    {
                        var replacementSource = source.ReplaceSyntaxTree(source.SyntaxTrees.Single(),
                            Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree.ParseText(source.SyntaxTrees.Single().ToString()
                                .Replace("Id = null", "Id = id", StringComparison.Ordinal)));
                        Assert.That(replacementSource.Emit(replacement).Success, Is.True);
                    }
                    File.Move(replacementPath, file.Name, overwrite: true);
                    return HistoricalFactoryUsage.Read(contract, factory.Type, selectedVersion, "Samples");
                }
                finally
                {
                    File.Delete(replacementPath);
                    File.Delete(file.Name);
                }
            }
            return HistoricalFactoryUsage.Read(contract, factory.Type, selectedVersion, "Samples");
        }
    }
}
