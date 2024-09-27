using Volo.Abp.Modularity;

namespace Qa;

[DependsOn(
    typeof(QaDomainModule),
    typeof(QaTestBaseModule)
)]
public class QaDomainTestModule : AbpModule
{

}
