using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Azure.Generator.Tests.Common
{
    internal static class Helpers
    {
        private static readonly string _assemblyLocation = Path.GetDirectoryName(typeof(Helpers).Assembly.Location)!;

        public static string GetExpectedFromFile(string? parameters = null)
        {
            return File.ReadAllText(GetAssetFileOrDirectoryPath(true, parameters));
        }

        private static string GetAssetFileOrDirectoryPath(bool isFile, string? parameters = null)
        {
            var stackTrace = new StackTrace();
            var stackFrame = GetRealMethodInvocation(stackTrace);
            var method = stackFrame.GetMethod();
            var callingClass = method!.DeclaringType;
            var nsSplit = callingClass!.Namespace!.Split('.');
            var paramString = parameters is null ? string.Empty : $"({parameters})";
            var extName = isFile ? ".cs" : string.Empty;
            var path = _assemblyLocation;
            var nsSkip = 3;
            for (int i = nsSkip; i < nsSplit.Length; i++)
            {
                path = Path.Combine(path, nsSplit[i]);
            }
            return Path.Combine(path, "TestData", callingClass.Name, $"{method.Name}{paramString}{extName}");
        }

        private static StackFrame GetRealMethodInvocation(StackTrace stackTrace)
        {
            int i = 1;
            while (i < stackTrace.FrameCount)
            {
                var frame = stackTrace.GetFrame(i);
                var declaringType = frame!.GetMethod()!.DeclaringType!;
                // we need to skip those method invocations from this class, or from the async state machine when the caller is an async method
                if (declaringType != typeof(Helpers) && declaringType.Name != "MockHelpers" && !IsCompilerGenerated(declaringType))
                {
                    return frame;
                }
                i++;
            }

            throw new InvalidOperationException($"There is no method invocation outside the {typeof(Helpers)} class in the stack trace");

            static bool IsCompilerGenerated(Type type)
            {
                return type.IsDefined(typeof(CompilerGeneratedAttribute), false) || (type.Namespace?.StartsWith("System.Runtime.CompilerServices") ?? false) ||
                    type.Name.StartsWith("<<", StringComparison.Ordinal);
            }
        }
    }
}
