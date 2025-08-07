// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;

namespace Xunit
{
    public class CustomXunitAttributes
    {
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
        public class ConditionallySkipOSFactAttribute : FactAttribute
        {
            private readonly string _platformToSkip;
            private readonly string _reason;

            public ConditionallySkipOSFactAttribute(string platformToSkip, string reason)
            {
                _platformToSkip = platformToSkip;
                _reason = reason;
            }

            public override string Skip
            {
                get => IsCurrentOS(_platformToSkip)
                    ? $"Test skipped on {_platformToSkip}. {_reason}"
                    : base.Skip;
                set => base.Skip = value;
            }
        }

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
        public class ConditionallySkipOSTheoryAttribute : TheoryAttribute
        {
            private readonly string _platformToSkip;
            private readonly string _reason;

            public ConditionallySkipOSTheoryAttribute(string platformToSkip, string reason)
            {
                _platformToSkip = platformToSkip;
                _reason = reason;
            }

            public override string Skip
            {
                get
                {
                    return IsCurrentOS(_platformToSkip)
                        ? $"Test skipped on {_platformToSkip}. {_reason}"
                        : base.Skip;
                }
                set => base.Skip = value;
            }
        }

        private static bool IsCurrentOS(string osName)
        {
            switch (osName.ToLowerInvariant())
            {
                case "windows":
                    return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
                case "linux":
                    return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
                case "osx":
                case "macos":
                    return RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
                default:
                    throw new ArgumentException($"Unsupported OS name: {osName}");
            }
        }
    }
}
