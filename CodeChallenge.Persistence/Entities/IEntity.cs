namespace CodeChallenge.Persistence.Entities
{
    public interface IEntity
    {
    }

    public interface IEntity<TIdentifier> : IEntity
    {
        TIdentifier Id { get; set; }
    }
}