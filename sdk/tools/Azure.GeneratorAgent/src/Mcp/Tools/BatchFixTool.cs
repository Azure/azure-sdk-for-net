// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that applies multiple deterministic fixes in a single call.
/// Each fix is described by a tool name and arguments.
/// </summary>
[McpServerToolType]
public static class BatchFixTool
{
    [McpServerTool(Name = "batch_fix"), Description("Apply multiple deterministic fixes in one call. Takes a JSON array of fix operations.")]
    public static string Execute(
        [Description("JSON array of fix operations. Each element: {\"tool\": \"tool_name\", \"args\": {\"key\": \"value\"}}")] string fixes)
    {
        try
        {
            var fixList = JsonSerializer.Deserialize<List<FixOperation>>(fixes);
            if (fixList is null || fixList.Count == 0)
            {
                return JsonSerializer.Serialize(new { success = true, applied = 0, message = "No fixes provided" });
            }

            var results = new List<object>();
            var applied = 0;

            foreach (var fix in fixList)
            {
                var result = ApplySingleFix(fix);
                results.Add(result);
                if (result.Success)
                {
                    applied++;
                }
            }

            return JsonSerializer.Serialize(new { success = true, applied, total = fixList.Count, results });
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { success = false, error = ex.Message });
        }
    }

    /// <summary>
    /// In-process batch execution for the orchestrator.
    /// </summary>
    public static List<FixResult> ExecuteInProcess(List<FixOperation> fixes)
    {
        var results = new List<FixResult>();

        foreach (var fix in fixes)
        {
            results.Add(ApplySingleFix(fix));
        }

        return results;
    }

    private static FixResult ApplySingleFix(FixOperation fix)
    {
        try
        {
            switch (fix.Tool)
            {
                case "regex_replacement":
                    {
                        var filePath = fix.Args.GetValueOrDefault("filePath") ?? string.Empty;
                        var pattern = fix.Args.GetValueOrDefault("pattern") ?? string.Empty;
                        var replacement = fix.Args.GetValueOrDefault("replacement") ?? string.Empty;
                        var singleLine = string.Equals(fix.Args.GetValueOrDefault("singleLine"), "true", StringComparison.OrdinalIgnoreCase);
                        var (success, count, error) = RegexReplacementTool.ExecuteInProcess(filePath, pattern, replacement, singleLine);
                        return new FixResult { Success = success, Tool = fix.Tool, Message = error ?? $"{count} replacements" };
                    }
                case "add_using_directive":
                    {
                        var filePath = fix.Args.GetValueOrDefault("filePath") ?? string.Empty;
                        var ns = fix.Args.GetValueOrDefault("namespace") ?? string.Empty;
                        if (string.IsNullOrEmpty(ns))
                        {
                            return new FixResult { Success = false, Tool = fix.Tool, Message = "No namespace mapping found for this type" };
                        }
                        var (success, added, error) = AddUsingDirectiveTool.ExecuteInProcess(filePath, ns);
                        return new FixResult { Success = success, Tool = fix.Tool, Message = error ?? (added ? "Added" : "Already present") };
                    }
                case "remove_using_directive":
                    {
                        var filePath = fix.Args.GetValueOrDefault("filePath") ?? string.Empty;
                        var nsPattern = fix.Args.GetValueOrDefault("namespacePattern") ?? string.Empty;
                        var (success, count, error) = RemoveUsingDirectiveTool.ExecuteInProcess(filePath, nsPattern);
                        return new FixResult { Success = success, Tool = fix.Tool, Message = error ?? $"{count} removed" };
                    }
                case "nullable_annotation_fix":
                    {
                        var filePath = fix.Args.GetValueOrDefault("filePath") ?? string.Empty;
                        var line = fix.Args.GetValueOrDefault("line") ?? "0";
                        var (success, modified, error) = NullableAnnotationFixTool.ExecuteInProcess(filePath, line);
                        return new FixResult { Success = success, Tool = fix.Tool, Message = error ?? (modified ? "Fixed" : "No change needed") };
                    }
                case "fetch_to_fromlro":
                    {
                        var projectPath = fix.Args.GetValueOrDefault("projectPath") ?? string.Empty;
                        var (success, fixCount, error) = FetchToFromLroResponseTool.ExecuteInProcess(projectPath);
                        return new FixResult { Success = success, Tool = fix.Tool, Message = error ?? $"{fixCount} files fixed" };
                    }
                case "rename_codegen_type":
                    {
                        var projectPath = fix.Args.GetValueOrDefault("projectPath") ?? string.Empty;
                        var typeSuffix = fix.Args.GetValueOrDefault("typeSuffix") ?? string.Empty;
                        var (success, fixes, error) = RenameCodeGenTypeTool.ExecuteInProcess(projectPath, typeSuffix);
                        return new FixResult { Success = success, Tool = fix.Tool, Message = error ?? $"{fixes.Count} types fixed" };
                    }
                case "add_codegen_suppress":
                    {
                        var filePath = fix.Args.GetValueOrDefault("filePath") ?? string.Empty;
                        var memberName = fix.Args.GetValueOrDefault("memberName") ?? string.Empty;
                        var (success, result, error) = AddCodeGenSuppressTool.ExecuteInProcess(filePath, memberName);
                        return new FixResult { Success = success, Tool = fix.Tool, Message = error ?? result?.Attribute ?? "No matching member" };
                    }
                default:
                    return new FixResult { Success = false, Tool = fix.Tool, Message = $"Unknown tool: {fix.Tool}" };
            }
        }
        catch (Exception ex)
        {
            return new FixResult { Success = false, Tool = fix.Tool, Message = ex.Message };
        }
    }
}
