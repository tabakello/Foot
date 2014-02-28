using System.Web.Mvc;
using FootStat.Domain;
using FootStat.Domain.Abstract;
using FootStat.WebUI.Models;

namespace FootStat.WebUI.Controllers
{
    public class MatchesController : Controller {
        private readonly IRepository<Tourney> tourneyRepository;
        private readonly IRepository<Command> commandRepository;
        private readonly IRepository<Match> matchRepository; 
        private readonly IQueryRepository queryRepository;
        private readonly IRepository<MatchDetail> mDetailsRepository;
        public MatchesController(IRepository<Tourney> tourneyRepository, IQueryRepository queryRepository, 
            IRepository<Command> commandRepository, IRepository<Match> matchRepository, IRepository<MatchDetail> mDetailsRepository)
        {
            this.commandRepository = commandRepository;
            this.queryRepository = queryRepository;
            this.tourneyRepository = tourneyRepository;
            this.matchRepository = matchRepository;
            this.mDetailsRepository = mDetailsRepository;
        }
        
        public ActionResult Index() {
            return View(new IndexViewModel(queryRepository));
        }

        public ActionResult Tourney(int id) {
            return View(new TourneyViewModel(id, queryRepository, tourneyRepository, commandRepository));
        }

        public ActionResult MatchDetails(int id) {
            return View(new MatchDetailsViewModel(id, matchRepository, queryRepository, tourneyRepository, mDetailsRepository));
        }
    }
}
