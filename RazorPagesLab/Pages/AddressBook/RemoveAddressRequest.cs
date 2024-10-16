using MediatR;
using System;

public class RemoveAddressRequest : IRequest
{
    public Guid Id { get; set; }

    public RemoveAddressRequest(Guid id)
    {
        Id = id;
    }
}
