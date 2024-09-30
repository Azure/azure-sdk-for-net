// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Primitives;

// TODO: Decide if we need/want this.  We could also offer just a string
// alternative.  This is a little easier to have intellisense guide you, but it's
// so much more verbose.

/// <summary>
/// Inject literal bicep statements.
/// </summary>
public class BicepLiteral(string resourceName, params Statement[] statements)
    : NamedProvisioningConstruct(resourceName)
{
    public IList<Statement> Statements { get; } = statements;

    protected internal override IEnumerable<Statement> Compile() => Statements;
}
