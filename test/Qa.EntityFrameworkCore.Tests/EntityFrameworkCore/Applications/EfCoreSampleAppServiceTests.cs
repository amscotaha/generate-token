using Qa.Samples;
using Xunit;

namespace Qa.EntityFrameworkCore.Applications;

[Collection(QaTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<QaEntityFrameworkCoreTestModule>
{

}
