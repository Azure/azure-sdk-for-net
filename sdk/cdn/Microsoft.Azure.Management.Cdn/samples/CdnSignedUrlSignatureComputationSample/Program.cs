using System;

namespace CdnSignedUrlSignatureComputationSample
{
    /// <summary>
    /// Serves as a main entry point into the application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The method invoked as the main entry point for execution.
        /// </summary>
        /// <param name="args"> Parameters to compute the signature for signed urls.</param>
        /// The signature is redirected to the standard output i.e. it is printed on the command line.
        static void Main(string[] args)
        {
            // Validate the arguments passed to the application.
            if (args.Length < 6)
            {
                Console.WriteLine("Error in the application usage.");
                Console.WriteLine("Usage: ./SignatureComputationApp <ResourcePath> <ExpiresParamName> <ExpiresParamValue> <KeyIdParamName> <KeyIdParamValue> <Secret>");
                Environment.Exit(1);
            }

            // Get the signed url signature based on the parameters passed.
            SignedUrlSignature signedUrlSignature = new SignedUrlSignature();

            string signature = signedUrlSignature.GetSignature(args[0], args[1], args[2], args[3], args[4], args[5]);

            Console.WriteLine(signature);
        }
    }
}
