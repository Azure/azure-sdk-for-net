// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity;

public class ProcessWrapper : IProcess
{
    private readonly Process _process;

    public ProcessWrapper(Process process)
    {
        _process = process;
    }

    // Implement all IProcess members...

    public Process RawProcess => _process;
}
