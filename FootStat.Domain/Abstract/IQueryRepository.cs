using System.Collections.Generic;

namespace FootStat.Domain.Abstract
{
    public interface IQueryRepository {
        int GetCountGoalsScoredAtHome(int commandId);
        int GetCountGoalsScoredAtAway(int commandId);
        int GetAllScoredGoals(int commandId);
        int GetCountMissedGoalsAtHome(int commandId);
        int GetCountMissedGoalsAtAway(int commandId);
        int GetAllMissedGoals(int commandId);
        int GetCommandPoints(int commandId, int tourneyId);
        IEnumerable<Command> GetActualCommandsByTourney(int tourneyId);
        int GetMathesCount(int commandId, int tourneyId);
        IEnumerable<Match> GetMatchesInNearestTour(int tourneyId);
        IEnumerable<Match> GetMatchesByTourney(int tourneyId);
        IEnumerable<TournamentTable> GetTournamentTable(int tourneyId);
    }
}
