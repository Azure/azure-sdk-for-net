// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    // Back-compat ApiCompat shim — kept solely to preserve the binary contract of the previously
    // published GA package (Azure.ResourceManager.AlertsManagement v1.1.x).
    //
    // Why it lives here instead of being regenerated:
    //   The abstract base AlertProcessingRuleRecurrence declares its System.ClientModel
    //   [PersistableModelProxy(typeof(UnknownRecurrence))] fallback so the JSON deserializer can
    //   materialize unknown discriminator values (recurrence kinds other than Daily / Weekly /
    //   Monthly) into a concrete instance. Since the entire AlertProcessingRule type family was
    //   extracted into the sibling 'Azure.ResourceManager.AlertProcessingRules' package (see
    //   AlertProcessingRuleRecurrence.cs), the generator does not emit this proxy here, but it must
    //   continue to exist so the v1.1.x type graph stays loadable for old consumer assemblies.
    //
    // What this stub provides:
    //   An empty internal partial that re-declares the proxy type. It inherits the [Obsolete] /
    //   [EditorBrowsable] contract from the abstract base; instantiation will throw via the base
    //   stub members.
    [Obsolete("The AlertProcessingRule types have been moved to the 'Azure.ResourceManager.AlertProcessingRules' package. Reference that package and use the same-named type (e.g., Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource) instead.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal partial class UnknownRecurrence : AlertProcessingRuleRecurrence
    {
    }
}
