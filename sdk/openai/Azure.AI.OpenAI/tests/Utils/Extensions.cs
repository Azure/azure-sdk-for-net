// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;

namespace Azure.AI.OpenAI.Tests.Utils;

/// <summary>
/// Helper extension methods.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Attempts to fill the buffer as much as possible from a stream. This will try to keep reading
    /// until the buffer is filled, or the stream ends.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <param name="buffer">The buffer to try to fill.</param>
    /// <returns>The number of bytes read.</returns>
    public static int FillBuffer(this Stream stream, byte[] buffer)
    {
        if (stream == null)
            throw new ArgumentNullException(nameof(stream));
        else if (buffer == null)
            throw new ArgumentNullException(nameof(buffer));

        int totalRead = 0;
        while (totalRead < buffer.Length)
        {
            int read = stream.Read(buffer, totalRead, buffer.Length - totalRead);
            if (read == 0)
            {
                return totalRead;
            }

            totalRead += read;
        }

        return totalRead;
    }

    /// <summary>
    /// Pads the current <see cref="StringBuilder"/> instance with the specified character on the left.
    /// </summary>
    /// <param name="builder">The string builder instance</param>
    /// <param name="totalWidth">The total width we want the string builder to be</param>
    /// <param name="paddingChar">The padding characters</param>
    /// <returns>The same builder for chaining, with any needed padding.</returns>
    public static StringBuilder PadRight(this StringBuilder builder, int totalWidth, char paddingChar = ' ')
    {
        if (builder == null)
            throw new ArgumentNullException(nameof(builder));
        else if (totalWidth < 0)
            throw new ArgumentOutOfRangeException(nameof(totalWidth), "Total width must be greater than or equal to 0.");
        else if (totalWidth == 0)
            return builder;

        int padding = totalWidth - builder.Length;
        if (padding > 0)
        {
            builder.Append(paddingChar, padding);
        }

        return builder;
    }
}
