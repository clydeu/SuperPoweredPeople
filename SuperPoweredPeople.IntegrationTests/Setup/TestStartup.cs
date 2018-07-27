namespace SuperPoweredPeople.IntegrationTests.Setup
{
    public class TestStartup : Startup
    {
        protected override string DataPath => BaseTest.DataPath;
    }
}
