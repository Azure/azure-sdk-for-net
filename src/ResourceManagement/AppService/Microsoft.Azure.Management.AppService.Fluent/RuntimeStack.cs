// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    /// <summary>
    /// Defines App service pricing tiers.
    /// </summary>
    public partial class RuntimeStack 
    {
        public RuntimeStack NODEJS_6_9_3;
        public RuntimeStack NODEJS_6_6_0;
        public RuntimeStack NODEJS_6_2_2;
        public RuntimeStack NODEJS_4_5_0;
        public RuntimeStack NODEJS_4_4_7;
        public RuntimeStack PHP_5_6_23;
        public RuntimeStack PHP_7_0_6;
        public RuntimeStack NETCORE_V1_0;
        public RuntimeStack RUBY_2_3;
        private string stack;
        private string version;
                public bool Equals(object obj)
        {
            //$ if (!(obj instanceof RuntimeStack)) {
            //$ return false;
            //$ }
            //$ if (obj == this) {
            //$ return true;
            //$ }
            //$ RuntimeStack rhs = (RuntimeStack) obj;
            //$ return toString().EqualsIgnoreCase(rhs.ToString());

            return false;
        }

                public int HashCode()
        {
            //$ return toString().HashCode();

            return 0;
        }

                public string ToString()
        {
            //$ return stack + " " + version;

            return null;
        }

        /// <return>The name of the language runtime stack.</return>
                public string Stack()
        {
            //$ return stack;
            //$ }

            return null;
        }

        /// <summary>
        /// Creates a custom app service pricing tier.
        /// </summary>
        /// <param name="stack">The name of the language stack.</param>
        /// <param name="version">The version of the runtime.</param>
                public  RuntimeStack(string stack, string version)
        {
            //$ this.stack = stack;
            //$ this.version = version;
            //$ }

        }

        /// <return>The version of the runtime stack.</return>
                public string Version()
        {
            //$ return version;
            //$ }

            return null;
        }
    }
}
