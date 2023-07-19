namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests
{
    public class TestCaseStructure
    {
        public object Test { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public object[] ToArray => new object[] { Test, Message, Success };
    }
}
