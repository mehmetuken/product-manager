using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ProductManager
{
    [Dependency(ReplaceServices = true)]
    public class ProductManagerBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ProductManager";
    }
}
