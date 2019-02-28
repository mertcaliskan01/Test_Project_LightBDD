using LightBDD.Core.Configuration;
using LightBDD.MsTest2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]

namespace Translate_Management_System_Test
{
    [TestClass]
    public class ConfiguredLightBddScope
    {
        [AssemblyInitialize]
        public static void Setup(TestContext testContext)
        {
            LightBddScope.Initialize(OnConfigure);

            // code executed before any scenarios
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            LightBddScope.Cleanup();

            // code executed after all scenarios
        }

        private static void OnConfigure(LightBddConfiguration configuration)
        {
            // LightBDD configuration
        }
    }
}
