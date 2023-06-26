namespace CarRent.API.CustomerManagement.Api
{
    public record CustomerRequest(
        Guid Id,
        string Name,
        string Address,
        string FullName
    );
}
