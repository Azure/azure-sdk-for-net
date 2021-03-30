// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    // Setting the "internal" access modifier while we don't expose the reading order
    // feature as part of our design.

    internal enum ReadingOrder
    {
        Basic,
        Natural
    }
}
