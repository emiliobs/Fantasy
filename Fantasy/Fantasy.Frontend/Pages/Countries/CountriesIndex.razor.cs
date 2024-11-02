using Fantasy.Frontend.Repositories;
using Fantasy.Shared.Entities;
using Fantasy.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Fantasy.Frontend.Pages.Countries;

public partial class CountriesIndex
{
    [Inject]
    private IStringLocalizer<Literals> Localizer { get; set; } = null!;

    [Inject]
    private IRepository Repository { get; set; } = null!;

    public List<Country>? Countries { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var responseHttp = await Repository.GetAsync<List<Country>>("api/Countries");
        Countries = responseHttp.Response;
    }
}