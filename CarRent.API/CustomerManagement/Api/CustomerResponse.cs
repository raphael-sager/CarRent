namespace CarRent.API.CustomerManagement.Api
{
    public record CustomerResponse(
        Guid Id,
        string CustomerNr,
        string Name,
        string? Address
    );
}
