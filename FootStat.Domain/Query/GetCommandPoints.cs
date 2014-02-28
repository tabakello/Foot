using System.Collections.Generic;
using System.Linq;
using FootStat.Domain.Abstract;

namespace FootStat.Domain.Query
{
    public class GetCommandPoints
    {
        /// <summary>
        /// The _ match repisitory.
        /// </summary>
        private readonly IRepository<Match> matchRepisitory;

        /// <summary>
        /// The command id.
        /// </summary>
        private readonly int commandId;
        
        /// <summary>
        /// The all matches.
        /// </summary>
        private readonly IEnumerable<Match> allMatches;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCommandPoints"/> class. 
        /// Initializes a new instance of the <see cref="GetCommandGoals"/> class.
        /// </summary>
        /// <param name="matchRepository">
        /// The match Repository.
        /// </param>
        /// <param name="commandId">
        /// The command id.
        /// </param>
        /// <param name="tourneyId">
        /// The tourney Id.
        /// </param>
        public GetCommandPoints(IRepository<Match> matchRepository, int commandId, int tourneyId) 
        {
            this.commandId = commandId;
            matchRepisitory = matchRepository;
            allMatches = matchRepisitory.GetAll().Where(p => p.TourneyId.Equals(tourneyId) && p.SeasonId.Equals(3));
        }

        /// <summary>
        /// The get points.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetPoints() 
        {
            return allMatches.Count(p => p.FirstCommandId == commandId && p.ResultId == 1) * 3 +
                             allMatches.Count(p => p.FirstCommandId == commandId && p.ResultId == 2) +
                             allMatches.Count(p => p.SecondCommandId == commandId && p.ResultId == 3) * 3 +
                             allMatches.Count(p => p.SecondCommandId == commandId && p.ResultId == 2);
        }
    }
}
