using EmilsAuto.Interfaces;

namespace EmilsAuto.Helper
{
    public class Pagination : IPagination
    {
        public int getMaxPages<T>(List<T> list, int pageSize)
        {
            return list.Count / pageSize;
        }
        public List<T> GetPage<T>(int pageSize, int currentPage, List<T> list)
        {
            currentPage = currentPage - 1; // Indexes always need to start at 0 :)
            int startIndex = currentPage * pageSize;
            int endIndex = (currentPage+1) * pageSize;
            int count = endIndex - startIndex;
            list = list.GetRange(startIndex, count);

            return list;
        }
    }
}
