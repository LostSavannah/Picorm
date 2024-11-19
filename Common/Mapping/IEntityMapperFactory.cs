namespace Picorm.Common.Mapping
{
    public interface IEntityMapperFactory
    {
        IEntityMapper<T> Create<T>() where T : class;
    }
}
