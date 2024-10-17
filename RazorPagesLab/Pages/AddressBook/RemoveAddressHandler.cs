using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class RemoveAddressHandler : IRequestHandler<RemoveAddressRequest>
{
    private readonly IRepo<AddressBookEntry> _repo;

    public RemoveAddressHandler(IRepo<AddressBookEntry> repo)
    {
        _repo = repo;
    }

    public async Task<Unit> Handle(RemoveAddressRequest request, CancellationToken cancellationToken)
    {
        var entry = _repo.Find(new EntryByIdSpecification(request.Id)).FirstOrDefault();

        if (entry == null)
        {
            throw new KeyNotFoundException("Address book entry not found.");
        }

        _repo.Remove(entry);

        return Unit.Value; 
    }
}
