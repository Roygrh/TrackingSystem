using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackingSystem.Models;
using TrackingSystem.Services.Unit;
using TrackingSystem.ViewModels;

namespace TrackingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            IndexVM index = new IndexVM();
            var candidates = this._mapper.Map<List<CandidateVM>>(this._unitOfWork.Candidates.Get().OrderByDescending(e => e.CandidateId).ToList());
            index.Candidates = candidates.Take(5).ToList();
            int total = candidates.Count();
            index.TotalPages = total % 5 == 0 ? total / 5 : (total / 5) + 1;
            index.CurrentPage = 1;
            return View(index);
        }

        [HttpPost]
        public ActionResult Index(string phrase = null, int page = 1)
        {
            IndexVM index = new IndexVM();
            var candidates = this._mapper.Map<List<CandidateVM>>(this._unitOfWork.Candidates.Get(e => string.IsNullOrEmpty(phrase) || e.FirstName.Contains(phrase) || e.LastName.Contains(phrase) || e.EmailAdress.Contains(phrase) || e.PhoneNumber.Contains(phrase) || e.ResidentialZipCode.Contains(phrase)).OrderByDescending(e => e.CandidateId).ToList());
            index.Candidates = candidates.Skip(5 * (page - 1)).Take(5).ToList();
            int total = candidates.Count();
            index.TotalPages = total % 5 == 0 ? total / 5 : (total / 5) + 1;
            index.CurrentPage = page;
            index.Phrase = phrase;
            return View(index);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(decimal id)
        {
            var candidate = this._mapper.Map<CandidateVM>(this._unitOfWork.Candidates.GetById(id));
            return View(candidate);
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            CandidateVM candidate = new CandidateVM();
            return View(candidate);
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CandidateVM candidateVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    var candidateDB = this._mapper.Map<Candidate>(candidateVM);
                    this._unitOfWork.Candidates.Add(candidateDB);
                    this._unitOfWork.Commit();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(decimal id)
        {
            var candidate = this._mapper.Map<CandidateVM>(this._unitOfWork.Candidates.GetById(id));
            candidate.EmailMessage = "right";
            return View(candidate);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(decimal id, CandidateVM candidateVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var candidateDB = this._unitOfWork.Candidates.GetById(id);
                var candidatesDB = this._unitOfWork.Candidates.Get(e => e.EmailAdress.Equals(candidateVM.EmailAdress.Trim())).ToList();

                if (candidatesDB.Count() > 0)
                {
                    var candidate = this._mapper.Map<CandidateVM>(candidateDB);
                    candidate.EmailMessage = "There is already a user with the email '"+ candidateVM.EmailAdress + "' choose another.";
                    return View(candidate);
                }

                candidateDB.FirstName = candidateVM.FirstName;
                candidateDB.LastName = candidateVM.LastName;
                if (!string.IsNullOrEmpty(candidateVM.ResidentialZipCode))
                {
                    candidateDB.ResidentialZipCode = candidateVM.ResidentialZipCode;
                }

                this._unitOfWork.Candidates.Update(candidateDB);
                this._unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(decimal id)
        {
            var candidate = this._mapper.Map<CandidateVM>(this._unitOfWork.Candidates.GetById(id));
            return View(candidate);
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(decimal id, CandidateVM candidateVM)
        {
            try
            {
                var candidate = this._unitOfWork.Candidates.GetById(id);
                if (candidate != null)
                {
                    this._unitOfWork.Candidates.Delete(candidate);
                    this._unitOfWork.Commit();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
