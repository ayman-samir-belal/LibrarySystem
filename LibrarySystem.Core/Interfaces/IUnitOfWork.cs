namespace LibrarySystem.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IBookRepository BookRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        Task<int> CompleteAsync();
    }
}
