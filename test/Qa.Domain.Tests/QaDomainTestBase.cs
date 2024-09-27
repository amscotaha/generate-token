using Volo.Abp.Modularity;

namespace Qa;

/* Inherit from this class for your domain layer tests. */
public abstract class QaDomainTestBase<TStartupModule> : QaTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
