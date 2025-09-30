namespace EmilsAuto.Interfaces
{
    public interface ISqlCustomer
    {
        void GetCustomer(string firstName, string lastName = "");
    }
}
