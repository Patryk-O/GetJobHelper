﻿using GetJobHelper.Web.Services.Contracts;
using GetJobHelper.Web.Services;
using Microsoft.AspNetCore.Components;
using Data;

namespace GetJobHelper.Web.Pages
{
    public class RecruiterBase : ComponentBase
    {
        [Inject]
        public required IRecruiterService RecruiterService { get; set; }

        public required IEnumerable<RecruiterDTO> Recruiters { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Recruiters = await RecruiterService.GetAllRecruitersAsync();
        }

    }
}
