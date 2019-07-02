using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmokeTest
{
    abstract class TestBase
    {
        /// <summary>
        /// High order function to handle the exceptions of each test.
        /// </summary>
        /// <param name="testAction"></param>
        /// <returns></returns>
        protected async Task<bool> ExecuteTest(Func<Task> testAction)
        {
            try
            {
                await testAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAILED.");
                Console.WriteLine(ex);
                return false;
            }

            Console.WriteLine("done");
            return true;
        }
    }
}