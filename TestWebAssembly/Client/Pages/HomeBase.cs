using Microsoft.AspNetCore.Components;

namespace TestWebAssembly.Client.Pages
{
    public class HomeBase : ComponentBase
    {
        public required Car Car { get; set; }
        protected override Task OnInitializedAsync()
        {
            Car = new Car {Name = "Porse", canDrive = true };
            return base.OnInitializedAsync();
        }
    }

    public class Car
    {
        public string? Name { get; set; }
        public bool canDrive{ get; init; }
    }
}
