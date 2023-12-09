// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI;

public partial class ImageGenerationOptions
{
    // CUSTOM CODE NOTE:
    //   These changes facilitate "init" style use of the options type via a public default constructor and
    //   accessible setters.

    /// <summary> Initializes a new instance of ImageGenerationOptions. </summary>
    public ImageGenerationOptions()
    {}

    /// <summary>
    /// Gets or sets the description used to influence the generation of requested images.
    /// </summary>
    /// <remarks>
    ///     For best results, ensure that the prompt is specific and sufficiently rich in details about
    ///     desired topical content.
    /// </remarks>
    public string Prompt { get; set; }

    // CUSTOM CODE NOTE:
    //   We suppress the ResponseFormat field as it'll be handled by unique method signatures
    //   for the differing response types (separate URL and b64 methods)
    internal ImageGenerationResponseFormat? ResponseFormat { get; set; }
}
