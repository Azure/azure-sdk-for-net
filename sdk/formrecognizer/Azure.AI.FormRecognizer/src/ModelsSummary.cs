// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    // We must set the "internal" access modifier ourselves here because ModelsSummary is not
    // caught by our autorest filter:
    //   $.definitions.*
    // This happens because the "summary" property is not part of the "definitions" section,
    // but a property defined in the "Models" definition.

    internal partial class ModelsSummary
    {
    }
}
