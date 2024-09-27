using Qa.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Qa.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(QaEntityFrameworkCoreModule),
    typeof(QaApplicationContractsModule)
)]
public class QaDbMigratorModule : AbpModule
{
}
