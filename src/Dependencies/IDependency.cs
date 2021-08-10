using System.Threading.Tasks;

namespace MetaResolutionIssue.Dependencies
{
    public interface IDependency
    {
        Task Work();
    }
}
