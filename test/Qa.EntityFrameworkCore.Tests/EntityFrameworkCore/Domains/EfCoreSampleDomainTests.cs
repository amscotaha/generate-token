using Qa.Samples;
using Xunit;

namespace Qa.EntityFrameworkCore.Domains;

[Collection(QaTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<QaEntityFrameworkCoreTestModule>
{

}
