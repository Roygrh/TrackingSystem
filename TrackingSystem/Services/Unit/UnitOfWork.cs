using TrackingSystem.Data;
using TrackingSystem.Models;
using TrackingSystem.Services.Repository;

namespace TrackingSystem.Services.Unit
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _context;
        private GenericRepository<Candidate> CandidateRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        IRepository<Candidate> IUnitOfWork.Candidates
        {
            get
            {

                if (this.CandidateRepository == null)
                {
                    this.CandidateRepository = new GenericRepository<Candidate>(_context);
                }
                return CandidateRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void RollBack()
        {
            //TODO
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
