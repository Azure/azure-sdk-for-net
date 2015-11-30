namespace NetMapRed
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The entry class for the application (when executed on a server).
    /// </summary>
    internal class Program
    {
        [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields",
            Justification = "Suppressing for now until the the arguments are utilized. [tgs]")]
        private readonly string[] args;

        private Program(string[] args)
        {
            this.args = args;
        }

        private int Run()
        {
            return 0;
        }

        /// <summary>
        /// The main entry point for the application when executed on the server.
        /// </summary>
        /// <param name="args">
        /// The command line arguments supplied when the application is executed.
        /// </param>
        /// <returns>
        /// The exit code for the application.
        /// </returns>
        internal static int Main(string[] args)
        {
            return new Program(args).Run();
        }
    }
}
