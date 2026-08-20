// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402 // File may only contain a single namespace
#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.ResourceManager.PlatformValidation;

namespace Azure.ResourceManager.PlatformValidation.Models
{
    /// <summary> A configuration used to author <see cref="ValidationExecutionPlanProperties.PlanConfigurationJson"/>. </summary>
    public sealed class ExecutionPlanConfiguration : IJsonModel<ExecutionPlanConfiguration>
    {
        /// <summary> The execution plan API version. </summary>
        public const string ApiVersion = "microsoft.validate/executionPlan.v0";

        /// <summary> The execution plan kind. </summary>
        public const string Kind = "ExecutionPlan";

        internal ExecutionPlanConfiguration()
        {
            Steps = new List<ValidationStep>();
        }

        /// <summary> Initializes a new instance of <see cref="ExecutionPlanConfiguration"/>. </summary>
        /// <param name="name"> The execution plan name. </param>
        /// <param name="certificationPackageReference"> The certification package to validate. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="certificationPackageReference"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        public ExecutionPlanConfiguration(string name, CertificationPackageReference certificationPackageReference)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(certificationPackageReference, nameof(certificationPackageReference));

            Name = name;
            CertificationPackageReference = certificationPackageReference;
            Steps = new List<ValidationStep>();
        }

        /// <summary> Gets the execution plan name. </summary>
        public string Name { get; }

        /// <summary> Gets the certification package to validate. </summary>
        public CertificationPackageReference CertificationPackageReference { get; }

        /// <summary> Gets the validation steps in execution order. </summary>
        public IList<ValidationStep> Steps { get; }

        BinaryData IPersistableModel<ExecutionPlanConfiguration>.Write(ModelReaderWriterOptions options)
        {
            EnsureJsonFormat(options, false);
            using MemoryStream stream = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<ExecutionPlanConfiguration>)this).Write(writer, options);
            }
            return BinaryData.FromBytes(stream.ToArray());
        }

        ExecutionPlanConfiguration IPersistableModel<ExecutionPlanConfiguration>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            EnsureJsonFormat(options, true);
            using JsonDocument document = JsonDocument.Parse(data);
            return Deserialize(document.RootElement);
        }

        string IPersistableModel<ExecutionPlanConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<ExecutionPlanConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            EnsureJsonFormat(options, false);
            if (Steps.Count == 0)
            {
                throw new InvalidOperationException("The execution plan must contain at least one validation step.");
            }

            writer.WriteStartObject();
            writer.WriteString("apiVersion", ApiVersion);
            writer.WriteString("kind", Kind);
            writer.WritePropertyName("metadata");
            writer.WriteStartObject();
            writer.WriteString("name", Name);
            writer.WriteEndObject();
            writer.WritePropertyName("parameters");
            writer.WriteStartObject();
            writer.WritePropertyName("certificationPackageReference");
            CertificationPackageReference.Write(writer);
            writer.WriteEndObject();
            writer.WritePropertyName("authoring");
            writer.WriteStartObject();
            writer.WritePropertyName("steps");
            writer.WriteStartArray();
            foreach (ValidationStep step in Steps)
            {
                Argument.AssertNotNull(step, nameof(Steps));
                step.Write(writer);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        ExecutionPlanConfiguration IJsonModel<ExecutionPlanConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            EnsureJsonFormat(options, true);
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return Deserialize(document.RootElement);
        }

        private static void EnsureJsonFormat(ModelReaderWriterOptions options, bool reading)
        {
            string format = options.Format == "W" ? "J" : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ExecutionPlanConfiguration)} does not support {(reading ? "reading" : "writing")} '{options.Format}' format.");
            }
        }

        private static ExecutionPlanConfiguration Deserialize(JsonElement element)
        {
            JsonElement package = element.GetProperty("parameters").GetProperty("certificationPackageReference");
            var result = new ExecutionPlanConfiguration(
                element.GetProperty("metadata").GetProperty("name").GetString(),
                CertificationPackageReference.Deserialize(package));

            foreach (JsonElement step in element.GetProperty("authoring").GetProperty("steps").EnumerateArray())
            {
                result.Steps.Add(ValidationStep.Deserialize(step));
            }

            return result;
        }
    }

    /// <summary> Describes the certification package referenced by an execution plan. </summary>
    public sealed class CertificationPackageReference
    {
        /// <summary> Initializes a new instance of <see cref="CertificationPackageReference"/>. </summary>
        /// <param name="osType"> The operating system type. </param>
        /// <param name="vmGenerationType"> The virtual machine generation type. </param>
        /// <param name="architectureType"> The processor architecture type. </param>
        /// <param name="storageProfile"> The storage profile. </param>
        /// <exception cref="ArgumentNullException"> A required argument is null. </exception>
        /// <exception cref="ArgumentException"> A required string argument is empty. </exception>
        public CertificationPackageReference(string osType, string vmGenerationType, string architectureType, CertificationPackageStorageProfile storageProfile)
        {
            Argument.AssertNotNullOrEmpty(osType, nameof(osType));
            Argument.AssertNotNullOrEmpty(vmGenerationType, nameof(vmGenerationType));
            Argument.AssertNotNullOrEmpty(architectureType, nameof(architectureType));
            Argument.AssertNotNull(storageProfile, nameof(storageProfile));

            OsType = osType;
            VmGenerationType = vmGenerationType;
            ArchitectureType = architectureType;
            StorageProfile = storageProfile;
            RecommendedVmSizes = new List<string>();
            AdditionalProperties = new Dictionary<string, BinaryData>();
        }

        /// <summary> Gets the operating system type. </summary>
        public string OsType { get; }

        /// <summary> Gets the virtual machine generation type. </summary>
        public string VmGenerationType { get; }

        /// <summary> Gets the processor architecture type. </summary>
        public string ArchitectureType { get; }

        /// <summary> Gets the recommended virtual machine sizes. </summary>
        public IList<string> RecommendedVmSizes { get; }

        /// <summary> Gets the storage profile. </summary>
        public CertificationPackageStorageProfile StorageProfile { get; }

        /// <summary> Gets additional certification package properties. Values are written as JSON. </summary>
        public IDictionary<string, BinaryData> AdditionalProperties { get; }

        internal void Write(Utf8JsonWriter writer)
        {
            if (RecommendedVmSizes.Count == 0)
            {
                throw new InvalidOperationException("The certification package must contain at least one recommended VM size.");
            }

            writer.WriteStartObject();
            writer.WriteString("osType", OsType);
            writer.WriteString("vmGenerationType", VmGenerationType);
            writer.WriteString("architectureType", ArchitectureType);
            writer.WritePropertyName("recommendedVMSizes");
            writer.WriteStartArray();
            foreach (string size in RecommendedVmSizes)
            {
                Argument.AssertNotNullOrEmpty(size, nameof(RecommendedVmSizes));
                writer.WriteStringValue(size);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("storageProfile");
            StorageProfile.Write(writer);
            writer.WritePropertyName("additionalProperties");
            writer.WriteStartObject();
            foreach (KeyValuePair<string, BinaryData> property in AdditionalProperties)
            {
                Argument.AssertNotNullOrEmpty(property.Key, nameof(AdditionalProperties));
                Argument.AssertNotNull(property.Value, nameof(AdditionalProperties));
                writer.WritePropertyName(property.Key);
                JsonSerialization.WriteBinaryData(writer, property.Value);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static CertificationPackageReference Deserialize(JsonElement element)
        {
            var result = new CertificationPackageReference(
                element.GetProperty("osType").GetString(),
                element.GetProperty("vmGenerationType").GetString(),
                element.GetProperty("architectureType").GetString(),
                CertificationPackageStorageProfile.Deserialize(element.GetProperty("storageProfile")));

            foreach (JsonElement size in element.GetProperty("recommendedVMSizes").EnumerateArray())
            {
                result.RecommendedVmSizes.Add(size.GetString());
            }
            foreach (JsonProperty property in element.GetProperty("additionalProperties").EnumerateObject())
            {
                result.AdditionalProperties.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
            return result;
        }
    }

    /// <summary> Describes the storage images in a certification package. </summary>
    public sealed class CertificationPackageStorageProfile
    {
        /// <summary> Initializes a new instance of <see cref="CertificationPackageStorageProfile"/>. </summary>
        /// <param name="osDiskImage"> The operating system disk image. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="osDiskImage"/> is null. </exception>
        public CertificationPackageStorageProfile(CertificationPackageDiskImage osDiskImage)
        {
            Argument.AssertNotNull(osDiskImage, nameof(osDiskImage));
            OsDiskImage = osDiskImage;
            DataDiskImages = new List<CertificationPackageDiskImage>();
        }

        /// <summary> Gets the operating system disk image. </summary>
        public CertificationPackageDiskImage OsDiskImage { get; }

        /// <summary> Gets the data disk images. </summary>
        public IList<CertificationPackageDiskImage> DataDiskImages { get; }

        internal void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("osDiskImage");
            OsDiskImage.Write(writer);
            writer.WritePropertyName("dataDiskImages");
            writer.WriteStartArray();
            foreach (CertificationPackageDiskImage image in DataDiskImages)
            {
                Argument.AssertNotNull(image, nameof(DataDiskImages));
                image.Write(writer);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        internal static CertificationPackageStorageProfile Deserialize(JsonElement element)
        {
            var result = new CertificationPackageStorageProfile(CertificationPackageDiskImage.Deserialize(element.GetProperty("osDiskImage")));
            foreach (JsonElement image in element.GetProperty("dataDiskImages").EnumerateArray())
            {
                result.DataDiskImages.Add(CertificationPackageDiskImage.Deserialize(image));
            }
            return result;
        }
    }

    /// <summary> Describes a disk image in a certification package. </summary>
    public sealed class CertificationPackageDiskImage
    {
        /// <summary> Initializes a new instance of <see cref="CertificationPackageDiskImage"/>. </summary>
        /// <param name="sourceVhdUri"> The source VHD URI. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceVhdUri"/> is null. </exception>
        public CertificationPackageDiskImage(Uri sourceVhdUri)
        {
            Argument.AssertNotNull(sourceVhdUri, nameof(sourceVhdUri));
            if (!sourceVhdUri.IsAbsoluteUri)
            {
                throw new ArgumentException("The source VHD URI must be absolute.", nameof(sourceVhdUri));
            }

            SourceVhdUri = sourceVhdUri;
        }

        /// <summary> Gets the source VHD URI. </summary>
        public Uri SourceVhdUri { get; }

        internal void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteString("sourceVhdUri", SourceVhdUri.AbsoluteUri);
            writer.WriteEndObject();
        }

        internal static CertificationPackageDiskImage Deserialize(JsonElement element) =>
            new CertificationPackageDiskImage(new Uri(element.GetProperty("sourceVhdUri").GetString(), UriKind.Absolute));
    }

    /// <summary> Describes a validation step in an execution plan. </summary>
    public sealed class ValidationStep
    {
        private ValidationStep(string name, string testRef)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(testRef, nameof(testRef));
            Name = name;
            TestRef = testRef;
        }

        /// <summary> Gets the step name. </summary>
        public string Name { get; }

        /// <summary> Gets the complete validation test resource reference. </summary>
        public string TestRef { get; }

        /// <summary> Gets or sets optional test-specific inputs, written as JSON. </summary>
        public BinaryData Inputs { get; set; }

        /// <summary> Creates a test validation step using the complete <paramref name="testRef"/> unchanged. </summary>
        /// <param name="name"> The step name. </param>
        /// <param name="testRef"> The complete validation test resource reference. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="testRef"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="testRef"/> is empty. </exception>
        public static ValidationStep Test(string name, string testRef) => new ValidationStep(name, testRef);

        internal void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteString("name", Name);
            writer.WriteString("type", "test");
            writer.WriteString("testRef", TestRef);
            if (Inputs != null)
            {
                writer.WritePropertyName("inputs");
                JsonSerialization.WriteBinaryData(writer, Inputs);
            }
            writer.WriteEndObject();
        }

        internal static ValidationStep Deserialize(JsonElement element)
        {
            var result = Test(element.GetProperty("name").GetString(), element.GetProperty("testRef").GetString());
            if (element.TryGetProperty("inputs", out JsonElement inputs))
            {
                result.Inputs = BinaryData.FromString(inputs.GetRawText());
            }
            return result;
        }
    }

    internal static class JsonSerialization
    {
        internal static void WriteBinaryData(Utf8JsonWriter writer, BinaryData data)
        {
#if NET6_0_OR_GREATER
            writer.WriteRawValue(data);
#else
            using JsonDocument document = JsonDocument.Parse(data);
            JsonSerializer.Serialize(writer, document.RootElement);
#endif
        }
    }
}
