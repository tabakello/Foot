using System;
using System.Collections.Generic;
using FootStat.Domain;
using FootStat.Domain.Abstract;
using System.Linq;

namespace FootStat.WebUI.Models {
    public class MatchDetailsViewModel {
        public Match Match;
        public Tourney Tourney;
        public IEnumerable<TournamentTable> TournamentTable;
        public int ScoredGoalsAtHome;
        public int ScoredGoalsAtAway;
        public int MissedGoalsAtHome;
        public int MissedGoalsAtAway;
        public Match LastGameHomeCommand;
        public Match LastGameAwayCommand;
        public int CountMatchesAtHome;
        public int CountMatchesAtAway;
        public IEnumerable<MatchDetail> MatchDetails;
        

        public MatchDetailsViewModel(int matchId, IRepository<Match> matchRepository, IQueryRepository queryRepository, IRepository<Tourney> tourneyRepository, IRepository<MatchDetail> mDetailsRepository ) {
            Match = matchRepository.GetById(matchId);
            TournamentTable = queryRepository.GetTournamentTable(Match.TourneyId);
            Tourney = tourneyRepository.GetById(Match.TourneyId);
            ScoredGoalsAtHome = queryRepository.GetCountGoalsScoredAtHome(Match.Command.Id);
            ScoredGoalsAtAway = queryRepository.GetCountGoalsScoredAtAway(Match.Command1.Id);
            MissedGoalsAtAway = queryRepository.GetCountMissedGoalsAtAway(Match.Command1.Id);
            MissedGoalsAtHome = queryRepository.GetCountMissedGoalsAtHome(Match.Command.Id);
            LastGameAwayCommand = matchRepository.GetAll()
                                                 .Where(p => (p.Command1.Id == Match.Command1.Id || p.Command.Id == Match.Command1.Id) && p.Date < DateTime.Now)
                                                 .OrderByDescending(p => p.Date).FirstOrDefault();
            LastGameHomeCommand = matchRepository.GetAll()
                                                 .Where(p => (p.Command.Id == Match.Command.Id || p.Command1.Id == Match.Command.Id) && p.Date < DateTime.Now)
                                                 .OrderByDescending(p => p.Date).FirstOrDefault();

            CountMatchesAtHome = matchRepository.GetAll()
                .Count(p => p.Command.Id == Match.Command.Id && p.ResultId != 4 && p.SeasonId == 3);
            CountMatchesAtAway = matchRepository.GetAll()
                .Count(p => p.Command1.Id == Match.Command1.Id && p.ResultId != 4 && p.SeasonId == 3);

            MatchDetails = mDetailsRepository.GetAll().Where(p => p.MatchId == Match.Id);
        }
    }
}