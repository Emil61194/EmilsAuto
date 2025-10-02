namespace EmilsAuto.Interfaces
{
    public interface IPagination
    {
        int getMaxPages<T>(List<T> list, int pageSize);
        List<T> GetPage<T>(int pageSize, int currentPage, List<T> list);
    }
}
