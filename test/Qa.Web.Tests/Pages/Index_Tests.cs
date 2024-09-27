using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Qa.Pages;

[Collection(QaTestConsts.CollectionDefinitionName)]
public class Index_Tests : QaWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
