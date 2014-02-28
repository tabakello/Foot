using System.Web.Mvc;
using FootStat.Domain;
using FootStat.Domain.Abstract;
using FootStat.WebUI.Models;

namespace FootStat.WebUI.Controllers
{
    public class MatchesController : Controller {
        private readonly IRepository<Tourney> _tourneyRepository;
        private readonly IRepository<Command> _commandRepository;
        private readonly IRepository<Match> _matchRepository; 
        private readonly IQueryRepository _queryRepository;
        private readonly IRepository<MatchDetail> _mDetailsRepository;
        public MatchesController(IRepository<Tourney> tourneyRepository, IQueryRepository queryRepository, 
            IRepository<Command> commandRepository, IRepository<Match> matchRepository, IRepository<MatchDetail> mDetailsRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _tourneyRepository = tourneyRepository;
            _matchRepository = matchRepository;
            _mDetailsRepository = mDetailsRepository;
        }
        
        public ActionResult Index() {
            return View(new IndexViewModel(_queryRepository));
        }

        public ActionResult Tourney(int id) {
            return View(new TourneyViewModel(id, _queryRepository, _tourneyRepository, _commandRepository));
        }

        public ActionResult MatchDetails(int id) {
            return View(new MatchDetailsViewModel(id, _matchRepository, _queryRepository, _tourneyRepository, _mDetailsRepository));
        }
    }
}
