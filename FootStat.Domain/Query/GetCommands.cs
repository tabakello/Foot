using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FootStat.Domain.Abstract;

namespace FootStat.Domain.Query
{
    public class GetCommands {
        private readonly IRepository<Command> commandRepository;
        private readonly int tourneyId;

        public GetCommands(IRepository<Command> commandRepository, int tourneyId) {
            this.commandRepository = commandRepository;
            this.tourneyId = tourneyId;
        }

        public IEnumerable<Command> GetActualCommandsByTourney() {
            return commandRepository.GetAll().Where(p => p.Actual && p.TourneyId == tourneyId);
        }
    }
}
