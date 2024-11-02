using Fantasy.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Fantasy.Frontend.Layout;

public partial class MainLayout
{
    [Inject]
    public IStringLocalizer<Literals> Localizer { get; set; } = null!;
}