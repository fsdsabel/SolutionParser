using System.Collections.Generic;

namespace Onion.SolutionParser.Parser.Model
{
    public interface ISolution
    {
        IList<string> Header { get; }
        IList<GlobalSection> Global { get; }
        IList<Project> Projects { get; }
    }
}
