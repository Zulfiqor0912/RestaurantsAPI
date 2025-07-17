namespace Restaurants.Domain.Exceptions
{
    public class NotFoundException(string resourceType, string resourceIdentifier) : Exception($"{resourceType} bilan {resourceIdentifier} bo'sh emas")
    {
        
    }
}
