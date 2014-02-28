using System;
using System.Collections.Generic;
using FootStat.Domain;
using FootStat.Domain.Abstract;

namespace FootStat.WebUI.Models
{
    public class IndexViewModel {
        private readonly IQueryRepository repository;
        public IndexViewModel(IQueryRepository repository) {
            this.repository = repository;
        }
    }
}