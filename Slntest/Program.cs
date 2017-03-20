using System;
using System.IO;
using System.Linq;
using Onion.SolutionParser.Parser;
using Onion.SolutionParser.Parser.Model;

namespace Slntest
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			ISolution solution;
			GlobalSection postSolution, preSolution;
			if (File.Exists("/Users/dean/Projects/Foo2/Foo2.sln")) {
				solution = SolutionParser.Parse("/Users/dean/Projects/Foo2/Foo2.sln");
				preSolution = solution.Global.FirstOrDefault(x => x.Type == GlobalSectionType.PreSolution);
				postSolution = solution.Global.FirstOrDefault(x => x.Type == GlobalSectionType.PostSolution);
			}
			else
			{
				solution = new Solution();
				solution.Header.Add("Microsoft Visual Studio Solution File, Format Version 12.00");
				solution.Header.Add("# Visual Studio 2012");
				preSolution = new GlobalSection("SolutionConfigurationPlatforms", GlobalSectionType.PreSolution);
				preSolution.Entries.Add("Debug|AnyCPU", "Debug|AnyCPU");
				preSolution.Entries.Add("Release|AnyCPU", "Release|AnyCPU");
				solution.Global.Add(preSolution);
				postSolution = new GlobalSection("ProjectConfigurationPlatforms", GlobalSectionType.PostSolution);
				solution.Global.Add(preSolution);
			}

			if (!solution.Projects.Any((arg) => arg.Name == "Test.UWP"))
			{
				var guid = Guid.NewGuid();
				solution.Projects.Add(new Project(Guid.Parse("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"), "Test.UWP", "Test.UWP\\Test.UWP.csproj", guid) { });
				postSolution.Entries.Add($"{guid}.Debug|AnyCPU.ActiveCfg", "Debug");
				postSolution.Entries.Add($"{guid}.Debug|AnyCPU.Build.0", "Debug");
				postSolution.Entries.Add($"{guid}.Release|AnyCPU.ActiveCfg", "Release");
				postSolution.Entries.Add($"{guid}.Release|AnyCPU.Build.0", "Release");
			}

			var renderer = new SolutionRenderer(solution);
			Console.WriteLine (renderer.Render());
		}
	}
}
