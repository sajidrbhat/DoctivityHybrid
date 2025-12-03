using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctivityHybrid.Shared
{
    public class RedirectToLogin : ComponentBase
    {
        [Inject]
        protected NavigationManager Navigation { get; set; } = null!;
        protected override void OnInitialized()
        {
            Navigation.NavigateTo("/login", true);
        }
    }
}
