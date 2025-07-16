namespace Restaurants.Domain.Exceptions
{
    public class NotFoundException(string message, string v) : Exception(message)
    {

    }
}
