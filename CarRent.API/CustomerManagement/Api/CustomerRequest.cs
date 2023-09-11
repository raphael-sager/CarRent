namespace CarRent.API.CustomerManagement.Api
{
    public record CustomerRequest(
        int Id,
        string Name,
        string Address,
        string FullName
    );
}
