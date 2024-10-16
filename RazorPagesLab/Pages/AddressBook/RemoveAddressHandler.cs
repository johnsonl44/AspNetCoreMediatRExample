// File: Application/Handlers/RemoveAddressHandler.cs
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class RemoveAddressHandler : IRequestHandler<RemoveAddressRequest>
{
    private readonly IRepo<AddressBookEntry> _repo;

    public RemoveAddressHandler(IRepo<AddressBookEntry> repo)
    {
        _repo = repo;
    }

    public async Task<Unit> Handle(RemoveAddressRequest request, CancellationToken cancellationToken)
    {
        // Find the entry by ID using a specification pattern or repository query
        var entry = _repo.Find(new EntryByIdSpecification(request.Id)).FirstOrDefault();

        if (entry == null)
        {
            throw new KeyNotFoundException("Address book entry not found.");
        }

        // Remove the entry from the repository
        _repo.Remove(entry);

        return Unit.Value; // Return Unit.Value to signify the command was handled successfully
    }
}
