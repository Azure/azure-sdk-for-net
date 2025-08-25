// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.InteropServices;

namespace System.ClientModel.Internal;

internal class RuntimeInformationWrapper
{
    public virtual string FrameworkDescription => RuntimeInformation.FrameworkDescription;
    public virtual string OSDescription => RuntimeInformation.OSDescription;
    public virtual Architecture OSArchitecture => RuntimeInformation.OSArchitecture;
    public virtual Architecture ProcessArchitecture => RuntimeInformation.ProcessArchitecture;
    public virtual bool IsOSPlatform(OSPlatform osPlatform) => RuntimeInformation.IsOSPlatform(osPlatform);
}
