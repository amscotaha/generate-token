using Volo.Abp.Modularity;

namespace Qa;

public abstract class QaApplicationTestBase<TStartupModule> : QaTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
