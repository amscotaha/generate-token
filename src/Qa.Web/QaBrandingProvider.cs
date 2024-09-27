using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using Qa.Localization;

namespace Qa.Web;

[Dependency(ReplaceServices = true)]
public class QaBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<QaResource> _localizer;

    public QaBrandingProvider(IStringLocalizer<QaResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
