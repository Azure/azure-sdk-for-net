// =============================================================================
// Repro for GitHub Issue #58093
// https://github.com/Azure/azure-sdk-for-net/issues/58093
//
// [BUG] Azure.ResourceManager.Sql 1.4.0 GA has breaking dependency jump
// from 1.4.0-beta.3 (Azure.Core 1.47.1 → 1.52.0)
//
// HOW TO RUN:
//   1. On Windows with .NET Framework 4.7.2: dotnet build && dotnet run
//   2. On any platform with .NET 8+: dotnet build && dotnet run
//      (On .NET 8+, the MissingMethodException won't occur because
//       ActivitySource is part of the BCL — but the sample still demonstrates
//       the dependency chain and code path involved.)
//
// TO REPRODUCE THE BUG:
//   - Target net472 on Windows
//   - Set AutoGenerateBindingRedirects to false in the .csproj
//   - Use an App.config with a stale DiagnosticSource binding redirect
//     pointing to v6.0.1.0 (from the beta.3 era)
//   - Build: succeeds
//   - Run: MissingMethodException at DiagnosticScopeFactory.CreateScope()
// =============================================================================

using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Sql;

namespace ReproIssue58093
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Issue #58093 Repro ===");
            Console.WriteLine($"Runtime: {Environment.Version}");
            Console.WriteLine();

            // Step 1: Show dependency versions to confirm the version chain
            Console.WriteLine("--- Loaded Assembly Versions ---");
            ShowAssemblyInfo("Azure.Core");
            ShowAssemblyInfo("Azure.ResourceManager");
            ShowAssemblyInfo("Azure.ResourceManager.Sql");
            ShowAssemblyInfo("System.Diagnostics.DiagnosticSource");
            Console.WriteLine();

            // Step 2: Check if ActivitySource(string) constructor is available
            // On .NET Framework 4.7.2 with stale binding redirects, this will fail
            Console.WriteLine("--- ActivitySource(string) Constructor Check ---");
            try
            {
                var ctor = typeof(ActivitySource).GetConstructor(new[] { typeof(string) });
                if (ctor != null)
                {
                    Console.WriteLine("  FOUND: ActivitySource(string) constructor is available");
                    Console.WriteLine($"  From: {typeof(ActivitySource).Assembly.FullName}");
                }
                else
                {
                    Console.WriteLine("  NOT FOUND: ActivitySource(string) constructor is MISSING!");
                    Console.WriteLine("  This WILL cause MissingMethodException on ARM operations.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  ERROR: {ex.Message}");
            }
            Console.WriteLine();

            // Step 3: Exercise the code path that triggers the bug
            // DiagnosticScopeFactory.CreateScope() -> new ActivitySource(name)
            Console.WriteLine("--- Attempting ARM Operation (triggers DiagnosticScopeFactory.CreateScope) ---");
            try
            {
                // Create ARM client. On .NET Framework 4.7.2 with stale binding
                // redirects, the MissingMethodException occurs during the first
                // ARM operation that triggers telemetry scope creation.
                var credential = new DefaultAzureCredential();
                var armClient = new ArmClient(credential);

                // This line internally calls DiagnosticScopeFactory.CreateScope(),
                // which calls:
                //   ActivitySources.GetOrAdd(clientName, static n => new ActivitySource(n))
                // This is where MissingMethodException is thrown on net472 with
                // stale DiagnosticSource binding redirects.
                SubscriptionResource subscription = armClient.GetDefaultSubscription();
                Console.WriteLine($"  Subscription: {subscription.Data.DisplayName}");

                // List resource groups and SQL servers
                await foreach (ResourceGroupResource rg in subscription.GetResourceGroups().GetAllAsync())
                {
                    Console.WriteLine($"  Resource Group: {rg.Data.Name}");

                    // Get SQL servers — this is the exact code path from the
                    // stack trace in the issue report
                    SqlServerCollection sqlServers = rg.GetSqlServers();
                    await foreach (SqlServerResource server in sqlServers.GetAllAsync())
                    {
                        Console.WriteLine($"    SQL Server: {server.Data.Name}");
                    }
                }
            }
            catch (MissingMethodException ex)
            {
                // THIS IS THE BUG — MissingMethodException at runtime
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("  *** BUG REPRODUCED: Issue #58093 ***");
                Console.WriteLine($"  MissingMethodException: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("  Root cause:");
                Console.WriteLine("    Azure.ResourceManager.Sql 1.4.0 requires Azure.Core >= 1.52.0,");
                Console.WriteLine("    which needs System.Diagnostics.DiagnosticSource 9.x+.");
                Console.WriteLine("    The loaded DiagnosticSource assembly is too old and doesn't have");
                Console.WriteLine("    the ActivitySource(string) constructor.");
                Console.WriteLine();
                Console.WriteLine("  Workaround:");
                Console.WriteLine("    Update binding redirects in App.config/Web.config:");
                Console.WriteLine("    <bindingRedirect oldVersion=\"0.0.0.0-10.0.0.3\" newVersion=\"10.0.0.3\" />");
                Console.WriteLine();
                Console.WriteLine("  Stack trace:");
                Console.WriteLine($"  {ex.StackTrace}");
            }
            catch (Azure.Identity.AuthenticationFailedException)
            {
                Console.WriteLine("  Auth failed (expected without Azure credentials configured).");
                Console.WriteLine("  On .NET Framework 4.7.2 with stale redirects, MissingMethodException");
                Console.WriteLine("  would occur BEFORE reaching authentication.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  {ex.GetType().Name}: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("=== Done ===");
        }

        static void ShowAssemblyInfo(string name)
        {
            try
            {
                var asm = Assembly.Load(name);
                var v = asm.GetName().Version;
                Console.WriteLine($"  {name}: v{v} ({asm.FullName})");
            }
            catch
            {
                Console.WriteLine($"  {name}: Not loaded");
            }
        }
    }
}
