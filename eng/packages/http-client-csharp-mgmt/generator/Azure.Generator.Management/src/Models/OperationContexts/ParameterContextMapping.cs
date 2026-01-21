// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Generator.Management.Models;

/// <summary>
/// Represents a mapping between an operation parameter name and its contextual information.
/// <para>
/// The <see cref="ParameterContextMapping"/> associates a parameter name with a <see cref="ContextualParameter"/>,
/// if the parameter can be derived from the resource identifier (Id) of the enclosing resource or resource collection.
/// If <see cref="ContextualParameter"/> is <c>null</c>, the parameter is considered a pass-through parameter and must be provided by the caller.
/// </para>
/// <para>
/// This record is used within <see cref="ParameterContextRegistry"/> to describe how each operation parameter should be resolved
/// during code generation for Azure management SDKs.
/// </para>
/// </summary>
internal record ParameterContextMapping(string ParameterName, ContextualParameter? ContextualParameter);
