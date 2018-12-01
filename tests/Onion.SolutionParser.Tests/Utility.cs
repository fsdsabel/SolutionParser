using System.IO;
using System.Reflection;

namespace Onion.SolutionParser.Tests
{
    public static class Utility
    {
        public static string GetFixtureContents(string fileName)
        {
            var slnPath = GetFixturePath(fileName);
            using (var reader = new StreamReader(slnPath))
            {
                return reader.ReadToEnd();
            }
        }

        public static string GetFixturePath(string fileName)
        {
            var fixturesPath = Path.Combine(Path.GetDirectoryName(typeof(Utility).Assembly.Location), "Fixtures");
            return Path.Combine(fixturesPath, fileName);
        }
    }
}
