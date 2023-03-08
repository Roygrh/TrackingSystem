using TrackingSystem.Models;
using TrackingSystem.Services.Repository;

namespace TrackingSystem.Services.Unit
{
    public interface IUnitOfWork
    {
        IRepository<Candidate> Candidates { get; }

        void Commit();
        void RollBack();
    }
}
