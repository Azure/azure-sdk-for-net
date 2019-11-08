// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copied from https://github.com/aspnet/Extensions/tree/master/src/Primitives/src

using System;
using System.Diagnostics;

#pragma warning disable CA1305  // ToString Locale
#pragma warning disable IDE0051 // Private member not used

namespace Azure.Core.Http.Multipart
{
    internal static class ThrowHelper
    {
        internal static void ThrowArgumentNullException(ExceptionArgument argument)
        {
            throw new ArgumentNullException(GetArgumentName(argument));
        }

        internal static void ThrowArgumentOutOfRangeException(ExceptionArgument argument)
        {
            throw new ArgumentOutOfRangeException(GetArgumentName(argument));
        }

        internal static void ThrowArgumentException(ExceptionResource resource)
        {
            throw new ArgumentException(GetResourceText(resource));
        }

        internal static void ThrowInvalidOperationException(ExceptionResource resource)
        {
            throw new InvalidOperationException(GetResourceText(resource));
        }

        internal static void ThrowInvalidOperationException(ExceptionResource resource, params object[] args)
        {
            var message = string.Format(GetResourceText(resource), args);

            throw new InvalidOperationException(message);
        }

        internal static ArgumentNullException GetArgumentNullException(ExceptionArgument argument)
        {
            return new ArgumentNullException(GetArgumentName(argument));
        }

        internal static ArgumentOutOfRangeException GetArgumentOutOfRangeException(ExceptionArgument argument)
        {
            return new ArgumentOutOfRangeException(GetArgumentName(argument));
        }

        internal static ArgumentException GetArgumentException(ExceptionResource resource)
        {
            return new ArgumentException(GetResourceText(resource));
        }

        private static string GetResourceText(ExceptionResource resource)
        {
            // return Resources.ResourceManager.GetString(GetResourceName(resource), Resources.Culture);
            // Hack to avoid including the resx:
            return resource switch
            {
                ExceptionResource.Argument_InvalidOffsetLength => "Offset and length are out of bounds for the string or length is greater than the number of characters from index to the end of the string.",
                ExceptionResource.Argument_InvalidOffsetLengthStringSegment => "Offset and length are out of bounds for this StringSegment or length is greater than the number of characters to the end of this StringSegment.",
                ExceptionResource.Capacity_CannotChangeAfterWriteStarted => "Cannot change capacity after write started.",
                ExceptionResource.Capacity_NotEnough => "Not enough capacity to write '{0}' characters, only '{1}' left.",
                ExceptionResource.Capacity_NotUsedEntirely => "Entire reserved capacity was not used. Capacity: '{0}', written '{1}'.",
                _ => throw new ArgumentOutOfRangeException(nameof(resource))
            };
        }

        private static string GetArgumentName(ExceptionArgument argument)
        {
            Debug.Assert(Enum.IsDefined(typeof(ExceptionArgument), argument),
                "The enum value is not defined, please check the ExceptionArgument Enum.");

            return argument.ToString();
        }

        private static string GetResourceName(ExceptionResource resource)
        {
            Debug.Assert(Enum.IsDefined(typeof(ExceptionResource), resource),
                "The enum value is not defined, please check the ExceptionResource Enum.");

            return resource.ToString();
        }
    }

    internal enum ExceptionArgument
    {
        buffer,
        offset,
        length,
        text,
        start,
        count,
        index,
        value,
        capacity,
        separators
    }

    internal enum ExceptionResource
    {
        Argument_InvalidOffsetLength,
        Argument_InvalidOffsetLengthStringSegment,
        Capacity_CannotChangeAfterWriteStarted,
        Capacity_NotEnough,
        Capacity_NotUsedEntirely
    }
}
