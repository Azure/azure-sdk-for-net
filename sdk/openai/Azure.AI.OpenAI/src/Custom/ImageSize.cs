// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.OpenAI
{
    /// <summary> The desired size of the generated images. Must be one of 256x256, 512x512, or 1024x1024. </summary>
    public readonly partial struct ImageSize : IEquatable<ImageSize>
    {
        //Temp change need until we resolve usage issue.
        //https://github.com/Azure/autorest.csharp/issues/3836
    }
}
