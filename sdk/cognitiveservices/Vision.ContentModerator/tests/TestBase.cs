using ContentModeratorTests.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ContentModeratorTests
{
        public class TestBase:IDisposable
    {

        #region Declarations
        const int sleepTime = 1000;
       
        public static string currentExecutingDirectory = Path.GetDirectoryName(Environment.CurrentDirectory).Replace(@"\bin\Debug", "");  //Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        internal string rawImageCurrentPath = Path.Combine(currentExecutingDirectory, @"TestDataSources\NormalImages\", ImageFiles.JpegOCR.GetDescription());

        #region Reviews

        public static string teamName;
       
        #endregion
        #endregion
        private MemoryStream _stream;

        public TestBase()
        {
            _stream = new MemoryStream();
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
        }

        public void Dispose()
        {
            _stream.Dispose();
            TestCleanupConfiguration();
        }
        

        
        public void TestSetUpConfiguration()
        {
           
            teamName = Constants.TeamName;
            
            Constants.ReviewAPISubscriptionKey = Constants.ContentModeratorSubscriptionKey;

            currentExecutingDirectory = Utilities.GetCorrectedDeploymentDirectory(currentExecutingDirectory);
        }
        
        public void TestCleanupConfiguration(){}
        
        public static string ErrorMessage { get;  set; }


        public static void wait(int timeinSec)
        {
            Thread.Sleep(timeinSec * sleepTime);

        }


    }
}

