namespace Picorm.Common.Mapping.Common
{
    public class EntityMapperFactory : IEntityMapperFactory
    {
        public IEntityMapper<T> Create<T>() where T : class
        {
            return new EntityMapper<T>();
        }
    }
}
