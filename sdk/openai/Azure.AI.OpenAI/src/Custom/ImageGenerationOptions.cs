// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI;

public partial class ImageGenerationOptions
{
    // CUSTOM CODE NOTE:
    // - Add a setter to this required property to allow for an "init" pattern when using the public
    //   default constructor.
    // - Add custom doc comment.

    /// <summary>
    /// Gets or sets the description used to influence the generation of requested images.
    /// </summary>
    /// <remarks>
    ///     For best results, ensure that the prompt is specific and sufficiently rich in details about
    ///     desired topical content.
    /// </remarks>
    public string Prompt { get; set; }

    // CUSTOM CODE NOTE:
    // Mark the `response_format` property as internal. This functionality will be handled by unique
    // method signatures for the different response types (i.e. blob URL versus base64 methods).

    internal ImageGenerationResponseFormat? ResponseFormat { get; set; }

    // CUSTOM CODE NOTE:
    // Add a public default constructor to allow for an "init" pattern using property setters.

    /// <summary> Initializes a new instance of <see cref="ImageGenerationOptions"/>. </summary>
    public ImageGenerationOptions()
    { }
}
