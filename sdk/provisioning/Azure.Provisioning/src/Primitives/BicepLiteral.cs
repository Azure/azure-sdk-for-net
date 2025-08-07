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
public class BicepLiteral(params BicepStatement[] statements)
    : ProvisionableConstruct()
{
    public IList<BicepStatement> Statements { get; } = statements;
    protected internal override IEnumerable<BicepStatement> Compile() => Statements;
}
