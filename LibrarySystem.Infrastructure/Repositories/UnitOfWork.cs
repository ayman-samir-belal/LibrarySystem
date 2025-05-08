using LibrarySystem.Core.Interfaces;
using LibrarySystem.Infrastructure.Data;

namespace LibrarySystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IBookRepository BookRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            BookRepository = new BookRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
