namespace Wikipedia.DTOs
{
    public record SearchResultWithImageDto(
        long PageId,
        string Title,
        string Snippet,
        string ImageUrl
    );
}