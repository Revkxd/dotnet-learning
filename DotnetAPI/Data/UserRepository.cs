namespace DotnetAPI.Data
{
    public class UserRepository
    {
        DataContextEF _entityFramework;

        public UserRepository(DataContextEF entityFramework)
        {
            _entityFramework = entityFramework;
        }

        public bool SaveChanges()
        {
            return _entityFramework.SaveChanges() > 0;
        }

        public void AddEntity<T>(T entityToAdd)
        {
            if (entityToAdd != null)
            {
                _entityFramework.Add(entityToAdd);
            }
        }

        public void RemoveEntity<T>(T entityToAdd)
        {
            if (entityToAdd != null)
            {
                _entityFramework.Remove(entityToAdd);
            }
        }
    }
}