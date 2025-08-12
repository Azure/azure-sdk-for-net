// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Internal;
using System.Runtime.InteropServices;

namespace ClientModel.Tests.Mocks
{
    internal class MockRuntimeInformation : RuntimeInformationWrapper
    {
        public string? FrameworkDescriptionMock { get; set; }
        public string? OSDescriptionMock { get; set; }
        public Architecture OSArchitectureMock { get; set; }
        public Architecture ProcessArchitectureMock { get; set; }
        public Func<OSPlatform, bool>? IsOSPlatformMock { get; set; }

        public override string OSDescription => OSDescriptionMock ?? base.OSDescription;
        public override string FrameworkDescription => FrameworkDescriptionMock ?? base.FrameworkDescription;
        public override Architecture OSArchitecture => OSArchitectureMock;
        public override Architecture ProcessArchitecture => ProcessArchitectureMock;
        public override bool IsOSPlatform(OSPlatform osPlatform) => IsOSPlatformMock?.Invoke(osPlatform) ?? base.IsOSPlatform(osPlatform);
    }
}
