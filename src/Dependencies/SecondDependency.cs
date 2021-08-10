using MetaResolutionIssue.Meta;
using System.Threading.Tasks;

namespace MetaResolutionIssue.Dependencies
{
    [Meta("Second")]
    public class SecondDependency : IDependency
    {
        public async Task Work() => await Task.CompletedTask;
    }
}
