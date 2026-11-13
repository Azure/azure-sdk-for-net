// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Projects;

public partial class RoutineRun
{
    /// <summary>
    /// The run status.
    /// <para> To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>. </para>
    /// <para>
    /// <remarks>
    /// Supported types:
    /// <list type="bullet">
    /// <item>
    /// <description> <see cref="string"/>. </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// </para>
    /// <para>
    /// Examples:
    /// <list type="bullet">
    /// <item>
    /// <term> BinaryData.FromObjectAsJson("foo"). </term>
    /// <description> Creates a payload of "foo". </description>
    /// </item>
    /// <item>
    /// <term> BinaryData.FromString("\"foo\""). </term>
    /// <description> Creates a payload of "foo". </description>
    /// </item>
    /// <item>
    /// <term> BinaryData.FromObjectAsJson(new { key = "value" }). </term>
    /// <description> Creates a payload of { "key": "value" }. </description>
    /// </item>
    /// <item>
    /// <term> BinaryData.FromString("{\"key\": \"value\"}"). </term>
    /// <description> Creates a payload of { "key": "value" }. </description>
    /// </item>
    /// </list>
    /// </para>
    /// </summary>
    [CodeGenMember("Status")]
    internal BinaryData StatusInternal { get; }

    /// <summary>
    /// The run status.
    /// </summary>
    public string Status { get => StatusInternal.ToString().Trim('"'); }
}
