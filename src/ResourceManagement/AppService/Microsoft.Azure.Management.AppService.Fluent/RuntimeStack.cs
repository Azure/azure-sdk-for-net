// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    /// <summary>
    /// Defines App service pricing tiers.
    /// </summary>
    public partial class RuntimeStack
    {
        public static readonly RuntimeStack NodeJS_6_10 = new RuntimeStack("NODE", "6.10");
        public static readonly RuntimeStack NodeJS_6_9 = new RuntimeStack("NODE", "6.9");
        public static readonly RuntimeStack NodeJS_6_6 = new RuntimeStack("NODE", "6.6");
        public static readonly RuntimeStack NodeJS_6_2 = new RuntimeStack("NODE", "6.2");
        public static readonly RuntimeStack NodeJS_4_5 = new RuntimeStack("NODE", "4.5");
        public static readonly RuntimeStack NodeJS_4_4 = new RuntimeStack("NODE", "4.4");
        public static readonly RuntimeStack PHP_5_6 = new RuntimeStack("PHP", "5.6");
        public static readonly RuntimeStack PHP_7_0 = new RuntimeStack("PHP", "7.0");
        public static readonly RuntimeStack NETCore_V1_0 = new RuntimeStack("DOTNETCORE", "1.0");
        public static readonly RuntimeStack NETCore_V1_1 = new RuntimeStack("DOTNETCORE", "1.1");
        public static readonly RuntimeStack Ruby_2_3 = new RuntimeStack("RUBY", "2.3");

        private string stack;
        private string version;

        public override bool Equals(object obj)
        {
            if (!(obj is RuntimeStack))
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            RuntimeStack rhs = (RuntimeStack)obj;
            return ToString().Equals(rhs.ToString());
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return stack + " " + version;
        }

        /// <return>The name of the language runtime stack.</return>
        public string Stack()
        {
            return stack;
        }

        /// <summary>
        /// Creates a custom app service pricing tier.
        /// </summary>
        /// <param name="stack">The name of the language stack.</param>
        /// <param name="version">The version of the runtime.</param>
        public  RuntimeStack(string stack, string version)
        {
            this.stack = stack;
            this.version = version;
        }

        /// <return>The version of the runtime stack.</return>
        public string Version()
        {
            return version;
        }
    }
}
