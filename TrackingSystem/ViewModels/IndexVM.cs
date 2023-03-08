using System.Net;

namespace TrackingSystem.ViewModels
{
    public class IndexVM
    {
        public CandidateVM Candidate { get; set; }
        public List<CandidateVM> Candidates { get; set; }
        public int CurrentPage { get; set; }
        public int Size { get; set; }
        public int TotalPages { get; set; }
        public string Phrase { get; set; }
    }
}
