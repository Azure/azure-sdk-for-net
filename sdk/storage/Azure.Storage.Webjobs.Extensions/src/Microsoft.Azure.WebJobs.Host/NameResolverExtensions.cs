// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Text;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Contains extension methods for INameResolver.
    /// </summary>
    public static class NameResolverExtensions
    {
        /// <summary>
        /// Attempt to resolve all %% matches within a string.
        /// </summary>
        /// <param name="resolver">resolver to apply to each name</param>
        /// <param name="resolve">the input string. IE, "start%name1%...%name2%end"</param>
        /// <param name="result">The resolved string</param>
        /// <returns></returns>
        public static bool TryResolveWholeString(this INameResolver resolver, string resolve, out string result)
        {
            result = ResolveWholeStringCore(resolver, resolve, throwOnFailure: false);
            return result != null;
        }

        /// <summary>
        /// Resolve all %% matches within a string.
        /// </summary>
        /// <param name="resolver">resolver to apply to each name</param>
        /// <param name="resolve">the input string. IE, "start%name1%...%name2%end"</param>
        /// <returns>The resolved string</returns>
        public static string ResolveWholeString(this INameResolver resolver, string resolve)
        {
            return ResolveWholeStringCore(resolver, resolve, throwOnFailure: true);
        }

        private static string ResolveWholeStringCore(this INameResolver resolver, string resolve, bool throwOnFailure = true)
        {
            if (resolver == null)
            {
                throw new ArgumentNullException("resolver");
            }

            if (resolve == null)
            {
                return null;
            }

            int i = 0;
            StringBuilder sb = new StringBuilder();

            while (i < resolve.Length)
            {
                int idxStart = resolve.IndexOf('%', i);
                if (idxStart >= 0)
                {
                    int idxEnd = resolve.IndexOf('%', idxStart + 1);
                    if (idxEnd < 0)
                    {
                        string msg = string.Format(CultureInfo.CurrentCulture, "The '%' at position {0} does not have a closing '%'", idxStart);
                        if (throwOnFailure)
                        {
                            throw new InvalidOperationException(msg);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    string name = resolve.Substring(idxStart + 1, idxEnd - idxStart - 1);

                    string value;
                    try
                    {
                        value = resolver.Resolve(name);
                    }
                    catch (Exception e)
                    {
                        string msg = string.Format(CultureInfo.CurrentCulture, "Threw an exception trying to resolve '%{0}%' ({1}:{2}).", name, e.GetType().Name, e.Message);
                        if (throwOnFailure)
                        {
                            throw new InvalidOperationException(msg, e);
                        }
                        else
                        {
                            return null;
                        } 
                    }
                    if (value == null)
                    {
                        string msg = string.Format(CultureInfo.CurrentCulture, "'%{0}%' does not resolve to a value.", name);
                        if (throwOnFailure)
                        {
                            throw new InvalidOperationException(msg);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    sb.Append(resolve.Substring(i, idxStart - i));
                    sb.Append(value);
                    i = idxEnd + 1;
                }
                else
                {
                    // no more '%' tokens
                    sb.Append(resolve.Substring(i));
                    break;
                }
            }

            return sb.ToString();
        }
    }
}
