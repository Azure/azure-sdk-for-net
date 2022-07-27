using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;

namespace Track2SRPSDK
{
    public class TestHelper
    {
        // default time out for runcmd
        // AzCopy will retry for 15 min when server error happens 
        // Set command timeout to 20 min in case azcopy is terminated during retry and cause no error output
        public const int CommandTimeoutInSec = 1200;
        public const int CommandTimeoutInMs = CommandTimeoutInSec * 1000;
        public const int WaitForKillTimeoutInMs = 30 * 1000;

        public static int RunCmd(string cmd, string args, string input = null)
        {
            return RunCmd(cmd, args, CommandTimeoutInMs, input);
        }

        public static int RunCmd(string cmd, string args, out string stdout, out string stderr, string input = null)
        {
            return RunCmd(cmd, args, out stdout, out stderr, CommandTimeoutInMs, input);
        }

        public static int RunCmd(string cmd, string args, int timeout, string input = null)
        {
            string stdout, stderr;
            return RunCmd(cmd, args, out stdout, out stderr, timeout, input);
        }

        public static int RunCmd(string cmd, string args, out string stdout, out string stderr, int timeout, string input = null)
        {
            ProcessStartInfo psi = new ProcessStartInfo(cmd, args);
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;
            if (string.IsNullOrEmpty(input))
            {
                psi.RedirectStandardInput = false;
            }
            else
            {
                psi.RedirectStandardInput = true;
            }

            Process p = Process.Start(psi);
            // To avoid deadlock between Process.WaitForExit and Process output redirection buffer filled up, we need to async read output before calling Process.WaitForExit
            StringBuilder outputBuffer = new StringBuilder();
            var outputBufferLock = new object();
            p.OutputDataReceived += (sendingProcess, outLine) =>
            {
                if (!String.IsNullOrEmpty(outLine.Data))
                {
                    lock (outputBufferLock)
                    {
                        outputBuffer.Append(outLine.Data + "\n");
                    }
                }
            };
            StringBuilder errorBuffer = new StringBuilder();
            var errorBufferLock = new object();
            p.ErrorDataReceived += (sendingProcess, outLine) =>
            {
                if (!String.IsNullOrEmpty(outLine.Data))
                {
                    lock (errorBufferLock)
                    {
                        errorBuffer.Append(outLine.Data + "\n");
                    }
                }
            };

            if (!string.IsNullOrEmpty(input))
            {
                var writer = p.StandardInput;
                writer.AutoFlush = true;
                writer.WriteLine(input);
                writer.Close();
            }

            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            if (p.WaitForExit(timeout))
            {
                GetStdOutAndStdErr(p, outputBuffer, errorBuffer, out stdout, out stderr);
                return p.ExitCode;
            }
            else
            {
                KillProcess(p);
                GetStdOutAndStdErr(p, outputBuffer, errorBuffer, out stdout, out stderr);
                return int.MinValue;
            }
        }
        private static void GetStdOutAndStdErr(Process p, StringBuilder outputBuffer, StringBuilder errorBuffer, out string stdout, out string stderr)
        {
            // Call this overload of WaitForExit to make sure all stdout/stderr strings are flushed.
            p.WaitForExit();

            stdout = outputBuffer.ToString();
            stderr = errorBuffer.ToString();

            //Console.WriteLine("Stdout: {0}", stdout);
            //if (!string.IsNullOrEmpty(stderr)
            //    && !string.Equals(stdout, stderr, StringComparison.InvariantCultureIgnoreCase))
            //{
            //    Console.WriteLine("Stderr: {0}", stderr);
            //}
        }


        public static bool StringMatch(string source, string pattern, RegexOptions? regexOptions = null)
        {
            Regex r = null;
            if (regexOptions.HasValue)
            {
                r = new Regex(pattern, regexOptions.Value);
            }
            else
            {
                r = new Regex(pattern);
            }

            Match m = r.Match(source);
            return m.Success;
        }
        public static void KillProcess(Process process)
        {
            try
            {
                process.Kill();
                bool exit = process.WaitForExit(WaitForKillTimeoutInMs);
                //Test.Assert(exit, "Process {0} should exit after being killed", process.Id);
                if (!exit)
                {
                    Console.WriteLine("Process {0} should exit after being killed", process.Id);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("InvalidOperationException caught while trying to kill process {0}: {1}", process.Id, e.ToString());
            }
        }
    }
}
