using Xunit;

namespace Qa.EntityFrameworkCore;

[CollectionDefinition(QaTestConsts.CollectionDefinitionName)]
public class QaEntityFrameworkCoreCollection : ICollectionFixture<QaEntityFrameworkCoreFixture>
{

}
