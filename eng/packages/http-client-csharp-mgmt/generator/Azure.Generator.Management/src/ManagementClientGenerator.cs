// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Visitors;
using Azure.ResourceManager;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator;
using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Azure.Generator.Management
{
    /// <summary>
    /// The Azure management client generator to generate the Azure management client SDK.
    /// </summary>
    [Export(typeof(CodeModelGenerator))]
    [ExportMetadata(GeneratorMetadataName, nameof(ManagementClientGenerator))]
    public class ManagementClientGenerator : AzureClientGenerator
    {
        private static ManagementClientGenerator? _instance;
        internal static new ManagementClientGenerator Instance => _instance ?? throw new InvalidOperationException("ManagementClientGenerator is not loaded.");

        /// <summary>
        /// The Azure management client generator to generate the Azure management client SDK.
        /// </summary>
        /// <param name="context"></param>
        [ImportingConstructor]
        public ManagementClientGenerator(GeneratorContext context) : base(context)
        {
            TypeFactory = new ManagementTypeFactory();
            InputLibrary = new ManagementInputLibrary(Configuration.OutputDirectory);
            _instance = this;
        }

        /// <inheritdoc/>
        public override ManagementInputLibrary InputLibrary { get; }

        private ManagementOutputLibrary? _azureOutputLibrary;
        /// <inheritdoc/>
        public override ManagementOutputLibrary OutputLibrary => _azureOutputLibrary ??= new();

        /// <inheritdoc/>
        public override ManagementTypeFactory TypeFactory { get; }

        /// <summary>
        /// Customize the generation output for Azure client SDK.
        /// </summary>
        protected override void Configure()
        {
            base.Configure();
            // Include Azure.ResourceManager
            AddMetadataReference(MetadataReference.CreateFromFile(typeof(ArmClient).Assembly.Location));
            // renaming should come first
            AddVisitor(new NameVisitor());
            AddVisitor(new SerializationVisitor());
            AddVisitor(new RestClientVisitor());
            AddVisitor(new ResourceVisitor());
            AddVisitor(new InheritableSystemObjectModelVisitor());
            AddVisitor(new FlattenPropertyVisitor());
            AddVisitor(new TypeFilterVisitor());
            AddVisitor(new PaginationVisitor());
            AddVisitor(new ModelFactoryVisitor());
            AddVisitor(new ManagedIdentityV3Visitor());
            if (IsWirePathEnabled())
            {
                AddVisitor(new WirePathVisitor());
            }
        }

        private const string EnableWirePathFeatureFlag = "enable-wire-path-attribute";
        private const string SkipApiVersionOverrideFlag = "skip-api-version-override";
        private const string ApplyModelRenamingFlag = "apply-model-renaming";

        private bool IsWirePathEnabled()
        {
            if (Configuration.AdditionalConfigurationOptions.TryGetValue(EnableWirePathFeatureFlag, out var value)
                && bool.TryParse(value.ToString(), out var flag))
            {
                return flag;
            }
            return false;
        }

        // TODO: This is a temporary workaround until the api-version override issue is properly resolved in Azure.Core.
        // Once Azure.Core handles api-version correctly during LRO polling, this flag and related logic should be removed.
        internal bool IsSkipApiVersionOverrideEnabled()
        {
            if (Configuration.AdditionalConfigurationOptions.TryGetValue(SkipApiVersionOverrideFlag, out var value)
                && bool.TryParse(value.ToString(), out var flag))
            {
                return flag;
            }
            return false;
        }

        /// <summary>
        /// Determines whether the generator should apply the automatic model and enum name overrides
        /// performed by <see cref="Visitors.NameVisitor"/> (e.g., renaming a PATCH body to
        /// '{Resource}Patch' or prefixing known-type names like 'Sku' with the resource provider name).
        /// When this returns <c>false</c>, those renames are skipped so that user-provided names in
        /// TypeSpec (including names set via the <c>@@clientName</c> decorator) are preserved.
        /// </summary>
        /// <remarks>
        /// The value is controlled by the <c>apply-model-renaming</c> emitter option. The default is <c>true</c>
        /// so that existing generated code is unchanged when the option is not specified.
        /// </remarks>
        public virtual bool IsApplyModelRenamingEnabled()
        {
            if (Configuration.AdditionalConfigurationOptions.TryGetValue(ApplyModelRenamingFlag, out var value)
                && bool.TryParse(value.ToString(), out var flag))
            {
                return flag;
            }
            return true;
        }

        /// <summary>
        /// Management plane SDKs do not need ConfigurationSchema.json generation.
        /// </summary>
        public override Task WriteAdditionalFiles(string outputPath) => Task.CompletedTask;
    }
}
