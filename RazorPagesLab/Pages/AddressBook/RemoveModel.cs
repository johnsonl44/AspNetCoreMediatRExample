// File: Pages/AddressBook/Remove.cshtml.cs
using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesLab.Pages.AddressBook
{
    public class RemoveModel : PageModel
    {
        private readonly IMediator _mediator;

        public RemoveModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        // The method triggered when a user submits a form to delete an entry
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            // Send the RemoveAddressRequest command via MediatR
            await _mediator.Send(new RemoveAddressRequest(id));

            // Redirect to the list page (e.g., Index) after deletion
            return RedirectToPage("Index");
        }
    }
}
