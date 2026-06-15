// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.PerfStress
{
    internal static class PerfUtilities
    {
        private static readonly Lazy<Parser> _parser = new Lazy<Parser>(() => new Parser(settings =>
        {
            settings.CaseSensitive = false;
            settings.HelpWriter = Console.Error;
        }));

        internal static Parser Parser => _parser.Value;

        internal static bool ContainsOperationCanceledException(Exception e)
        {
            if (e is OperationCanceledException)
            {
                return true;
            }
            else if (e.InnerException != null)
            {
                return ContainsOperationCanceledException(e.InnerException);
            }
            else
            {
                return false;
            }
        }

        // Dynamically create option types with a "Verb" attribute
        internal static Type[] GetOptionTypes(IEnumerable<Type> testTypes)
        {
            var optionTypes = new List<Type>();

            var ab = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("Options"), AssemblyBuilderAccess.Run);
            var mb = ab.DefineDynamicModule("Options");

            foreach (var t in testTypes)
            {
                var baseOptionsType = t.GetConstructors().First().GetParameters()[0].ParameterType;
                var tb = mb.DefineType(t.Name + "Options", TypeAttributes.Public, baseOptionsType);

                // CustomAttributeBuilder requires a value for every constructor parameter, so select the
                // VerbAttribute constructor with the fewest parameters whose first parameter is the verb name.
                // We pass the verb name for that first parameter and the compiler-provided default value for any
                // remaining parameter. Preferring the smallest constructor keeps this working if CommandLineParser
                // changes its constructor signatures (e.g. the 'aliases' parameter added in 2.9.1), since the
                // minimal constructor is the least likely to change.
                var attrCtor = typeof(VerbAttribute).GetConstructors()
                    .Where(c => c.GetParameters() is var p && p.Length >= 1 && p[0].ParameterType == typeof(string))
                    .OrderBy(c => c.GetParameters().Length)
                    .First();
                var ctorParameters = attrCtor.GetParameters();
                var verbName = GetVerbName(t.Name);
                var attrArgs = new object[ctorParameters.Length];
                attrArgs[0] = verbName;
                for (var i = 1; i < ctorParameters.Length; i++)
                {
                    attrArgs[i] = ctorParameters[i].DefaultValue;
                }
                tb.SetCustomAttribute(new CustomAttributeBuilder(attrCtor, attrArgs));

                optionTypes.Add(tb.CreateType());
            }

            return optionTypes.ToArray();
        }

        internal static string GetVerbName(string testName)
        {
            // Remove suffix "Test" if exists
            return Regex.Replace(testName, "Test$", string.Empty, RegexOptions.IgnoreCase);
        }

        // Run in dedicated thread instead of using async/await in ThreadPool, to ensure this thread has priority
        // and never fails to run to due ThreadPool starvation.
        internal static Thread PrintStatus(string header, Func<object> status, bool newLine, CancellationToken token, int intervalSeconds = 1)
        {
            var thread = new Thread(() =>
            {
                Console.WriteLine(header);

                bool needsExtraNewline = false;

                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        Task.Delay(TimeSpan.FromSeconds(intervalSeconds), token).Wait();
                    }
                    catch (Exception e) when (ContainsOperationCanceledException(e))
                    {
                    }

                    var obj = status();

                    if (newLine)
                    {
                        Console.WriteLine(obj);
                    }
                    else
                    {
                        Console.Write(obj);
                        needsExtraNewline = true;
                    }
                }

                if (needsExtraNewline)
                {
                    Console.WriteLine();
                }

                Console.WriteLine();
            });

            thread.Start();

            return thread;
        }
    }
}
