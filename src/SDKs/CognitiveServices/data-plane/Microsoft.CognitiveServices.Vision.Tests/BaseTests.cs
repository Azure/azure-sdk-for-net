using Microsoft.CognitiveServices.Vision.Face;
using Microsoft.Extensions.Configuration;

namespace FaceSDK.Tests
{
    public abstract class BaseTests
    {
        private static string SubscriptionKey = null;
        private static string Region = null;

        static BaseTests()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("testsettings.json");

            // Create the configuration object that the application will
            // use to retrieve configuration information.
            var configuration = builder.Build();

            // Retrieve the configuration information.
            SubscriptionKey = configuration["SubscriptionKey"];
            Region = configuration["Region"];
        }

        protected FaceAPI GetClient()
        {
            return new FaceAPI()
            {
                SubscriptionKey = SubscriptionKey,
                AzureRegion1 = Region
            };
        }
    }
}
