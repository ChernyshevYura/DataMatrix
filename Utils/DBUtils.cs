namespace DataMatrix.Utils
{
    public class DBUtils
    {
        public static string MakeQueryPaginated(string query, int pageNum, int pageSize)
        {
            var offset = (pageNum - 1) * pageSize;
            return string.Format("{0} LIMIT {1} OFFSET {2}", query, pageSize, offset);
        }
    }
}
