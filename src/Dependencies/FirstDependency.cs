using MetaResolutionIssue.Meta;
using System.Threading.Tasks;

namespace MetaResolutionIssue.Dependencies
{
    [Meta("First")]
    public class FirstDependency : IDependency
    {
        public async Task Work() => await Task.CompletedTask;
    }
}
