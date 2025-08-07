// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Azure.Provisioning.Generator;

/// <summary>
/// Helper utility to read the XML doc comments associated with reflected members.
/// </summary>
/// <remarks>
/// Add the following MSBuild snippet to your .csproj file to include the XML doc comments from any NuGet packages on restore:
/// <code>
///   <Target Name="_ResolveCopyLocalNuGetPkgXmls" AfterTargets="ResolveReferences">
///     <ItemGroup>
///       <ReferenceCopyLocalPaths
///         Include="@(ReferenceCopyLocalPaths -> '%(RootDir)%(Directory)%(Filename).xml')"
///         Condition="'%(ReferenceCopyLocalPaths.NuGetPackageId)' != '' and Exists('%(RootDir)%(Directory)%(Filename).xml')" />
///     </ItemGroup>
///   </Target>
/// </code>
/// </remarks>
/// <param name="assembly">The assembly explained by the doc comments.</param>
public class XmlDocCommentReader(Assembly assembly)
{
    /// <summary>
    /// Gets the assembly explained by the doc comments.
    /// </summary>
    public Assembly Assembly { get; } = assembly;

    private readonly Lazy<IDictionary<string, XElement>> _members =
        new(() =>
        {
            string path = assembly.Location;
            if (string.IsNullOrEmpty(path))
            {
                throw new InvalidOperationException($"Could not load XML doc comments for assembly {assembly.FullName} because it has no Location.");
            }

            path = Path.ChangeExtension(path, ".xml");
            if (!File.Exists(path))
            {
                throw new InvalidOperationException($"XML doc comments for assembly {assembly.FullName} were not found at: {path}");
            }

            Dictionary<string, XElement> members = [];
            XDocument doc = XDocument.Load(path);
            foreach (XElement element in doc.Root!.Element("members")!.Elements("member"))
            {
                string name = element.Attribute("name")!.Value;
                members[name] = element;
            }
            return members;
        });

    /// <summary>
    /// Convert a member to its ID string as defined by
    /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments#d42-id-string-format">
    /// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments#d42-id-string-format</see>.
    /// </summary>
    /// <param name="member">The member.</param>
    /// <returns>The member's XML doc comment ID.</returns>
    /// <remarks>
    /// Some of the more esoteric features probably aren't supported correctly, but we're covered for
    /// the common patterns in Azure.ResourceManager.*
    /// </remarks>
    public static string AsXmlDocCommentId(MemberInfo member)
    {
        return member switch
        {
            Type t => $"T:{EncodeType(t)}",
            FieldInfo f => $"F:{EncodeType(f.DeclaringType!)}.{f.Name}",
            PropertyInfo p => $"P:{EncodeType(p.DeclaringType!)}.{p.Name}",
            MethodBase m => $"M:{EncodeType(m.DeclaringType!)}.{EncodeSignature(m)}",
            EventInfo e => $"E:{EncodeType(e.DeclaringType!)}.{e.Name}",
            _ => throw new InvalidOperationException($"Unexpected member: {member}")
        };

        static StringBuilder EncodeType(Type type, StringBuilder? text = default)
        {
            text ??= new();

            if (type.IsArray || type.IsPointer)
            {
                EncodeType(type.GetElementType()!, text);
                if (type.IsArray)
                {
                    text.Append('[');
                    for (int r = 0; r < type.GetArrayRank(); r++) { text.Append(','); }
                    text.Append(']');
                }
                else
                {
                    text.Append('*');
                }

                // Bail out early
                return text;
            }


            if (type.IsNested)
            {
                EncodeType(type.DeclaringType!, text).Append('.');
            }
            else
            {
                text.Append(type.Namespace).Append('.');
            }
            text.Append(type.Name);
            if (type.IsConstructedGenericType)
            {
                text.Append('{');
                IndentWriter.Fenceposter fence = new();
                foreach (Type arg in type.GenericTypeArguments)
                {
                    if (fence.RequiresSeparator) { text.Append(','); }
                    EncodeType(arg, text);
                }
                text.Append('}');
            }
            else if (type.IsGenericType)
            {
                text.Append('`').Append(type.GetGenericArguments().Length);
            }
            return text;
        }

        static StringBuilder EncodeSignature(MethodBase method, StringBuilder? text = default)
        {
            text ??= new();
            if (method.IsConstructor)
            {
                text.Append('#');
                if (method.IsStatic) { text.Append('c'); }
                text.Append("ctor");
            }
            else
            {
                text.Append(method.Name);
            }

            ParameterInfo[] parameters = method.GetParameters();
            if (parameters.Length > 0)
            {
                IndentWriter.Fenceposter fence = new();
                text.Append('(');
                foreach (ParameterInfo param in parameters)
                {
                    if (fence.RequiresSeparator) { text.Append(','); }
                    if (param.ParameterType.IsGenericMethodParameter)
                    {
                        text.Append("``");
                        text.Append(Array.IndexOf(method.GetGenericArguments(), param.ParameterType));
                    }
                    else if (param.ParameterType.IsGenericParameter)
                    {
                        text.Append('`');
                        text.Append(Array.IndexOf(method.DeclaringType!.GetGenericArguments(), param.ParameterType));
                    }
                    else
                    {
                        EncodeType(param.ParameterType, text);
                    }
                    if (param.IsIn || param.IsOut) { text.Append('@'); }
                }
                text.Append(')');
            }

            if (method.Name == "op_Explicit" || method.Name == "op_Implicit")
            {
                text.Append('~');
                EncodeType(((MethodInfo)method).ReturnType, text);
            }

            return text;
        }
    }

    private static string? Clean(string? text)
    {
        if (string.IsNullOrEmpty(text)) { return text; }
        return text.Replace('\n', ' ').Replace('\r', ' ').Trim();
    }

    public string? GetSummary(MemberInfo member) =>
        _members.Value.TryGetValue(AsXmlDocCommentId(member), out XElement? e) ?
            Clean(GetInnerText(e.Element("summary")).ToString()) :
            null;

    public string? GetSummary(ParameterInfo param)
    {
        if (_members.Value.TryGetValue(AsXmlDocCommentId(param.Member), out XElement? method))
        {
            foreach (var e in method.Elements("param"))
            {
                if (e.Attribute("name")?.Value == param.Name)
                {
                    return Clean(GetInnerText(e).ToString());
                }
            }
        }
        return null;
    }

    private static StringBuilder GetInnerText(XElement? element, StringBuilder? text = default)
    {
        text ??= new();
        if (element is not null)
        {
            foreach (XNode node in element.Nodes())
            {
                if (node is XElement e)
                {
                    GetInnerText(e, text);
                }
                else if (node is XText t)
                {
                    text.Append(t.Value);
                }
            }

            if (element.Name.LocalName == "see")
            {
                if (element.Attribute("cref") is { Value: string id })
                {
                    text.Append(id[2..]); // Stripping off the prefix makes it kind of legible
                }
                else if (element.Attribute("href") is { Value: string href })
                {
                    text.Append(href);
                }
            }
        }
        return text;
    }
}
