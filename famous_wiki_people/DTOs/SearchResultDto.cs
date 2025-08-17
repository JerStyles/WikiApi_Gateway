namespace Wikipedia.DTOs
{
    public record SearchResultDto(
        long PageId,
        string Title,
        string Snippet
    );
}