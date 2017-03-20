using System.Collections.Generic;

namespace Onion.SolutionParser.Parser.Model
{
    public class Solution : ISolution
    {
        public IList<string> Header { get; set; }
        public IList<GlobalSection> Global { get; set; }
        public IList<Project> Projects { get; set; }

		public Solution()
		{
			Header = new List<string>();
			Global = new List<GlobalSection>();
			Projects = new List<Project>();
		}
	}
}
