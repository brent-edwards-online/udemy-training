namespace DNNTeaching.Repository
{
    public interface IUnitOfWork
    {
        void RollBack();

        void SaveChanges();
    }
}
