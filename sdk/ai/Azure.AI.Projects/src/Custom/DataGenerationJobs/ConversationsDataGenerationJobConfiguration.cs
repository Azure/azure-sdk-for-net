// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.Projects;

public partial class ConversationsDataGenerationJobConfiguration
{
    // In the code below we are not serializing ModelOptions, because we do it in
    // superclass.
    /// <param name="writer"> The JSON writer. </param>
    /// <param name="options"> The client options for reading and writing models. </param>
    protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        string format = options.Format == "W" ? ((IPersistableModel<ConversationsDataGenerationJobConfiguration>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ConversationsDataGenerationJobConfiguration)} does not support writing '{format}' format.");
        }
        base.JsonModelWriteCore(writer, options);
        if (Optional.IsDefined(MaxSamples))
        {
            writer.WritePropertyName("max_samples"u8);
            writer.WriteNumberValue(MaxSamples.Value);
        }
        if (Optional.IsDefined(RedactPrivateContent))
        {
            writer.WritePropertyName("redact_private_content"u8);
            writer.WriteBooleanValue(RedactPrivateContent.Value);
        }
        if (Optional.IsDefined(GenerateTestCaseDescription))
        {
            writer.WritePropertyName("generate_test_case_description"u8);
            writer.WriteBooleanValue(GenerateTestCaseDescription.Value);
        }
        if (Optional.IsDefined(GenerateTestCaseRubric))
        {
            writer.WritePropertyName("generate_test_case_rubric"u8);
            writer.WriteBooleanValue(GenerateTestCaseRubric.Value);
        }
    }
}
