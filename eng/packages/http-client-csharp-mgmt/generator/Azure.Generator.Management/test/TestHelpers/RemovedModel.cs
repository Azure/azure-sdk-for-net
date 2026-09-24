// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Samples.Models
{
    /// <summary>
    /// Stand-in for a model that a previous contract exposed but the current generation no longer emits.
    /// Used to verify that the model factory does not resurrect overloads referencing removed types.
    /// </summary>
    internal class RemovedModel
    {
    }
}
