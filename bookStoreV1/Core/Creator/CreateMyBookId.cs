namespace bookStoreV1.Core.Creator
{
    public class CreateMyBookId
    {
        public static int CreateId()
        {
            Random rnd = new Random();
            return rnd.Next(10000, 99999);
        }
    }
}
