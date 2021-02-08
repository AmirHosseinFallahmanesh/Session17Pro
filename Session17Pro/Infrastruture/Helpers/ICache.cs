namespace Session17Pro.Infrastruture.Helpers
{
    public interface ICache
    {
        void Set<T>(object key, T value);

        T Get<T>(object key);
    }
}
