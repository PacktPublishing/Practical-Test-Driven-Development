using System;
using System.Collections.Generic;
using System.Linq;
using SpeakerMeet.DTO;
using SpeakerMeet.Exceptions;
using SpeakerMeet.Repositories.Interfaces;
using SpeakerMeet.Services.Interfaces;

namespace SpeakerMeet.Services
{
    public class SpeakerService : ISpeakerService
    {
        private readonly IRepository<Speaker> _repository;

        public SpeakerService(IRepository<Speaker> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Speaker> Search(string searchString)
        {
            var speakers = _repository.GetAll()
                .Where(x => x.Name.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)).ToList();

            return speakers.Select(x => new Speaker
            {
                Id = x.Id,
                Name = x.Name,
                Location = x.Location,
            });
        }

        public IEnumerable<SpeakerSummary> GetAll()
        {
            var speakers = _repository.GetAll();

            return speakers
                .Where(x => !x.IsDeleted)
                .Select(speaker => new SpeakerSummary
                {
                    Id = speaker.Id,
                    Name = speaker.Name,
                    Location = speaker.Location
                });
        }

        public SpeakerDetail Get(int id)
        {
            var speaker = _repository.Get(id);

            if (speaker == null || speaker.IsDeleted)
            {
                throw new SpeakerNotFoundException();
            }

            return new SpeakerDetail
            {
                Id = speaker.Id,
                Name = speaker.Name,
                Location = speaker.Location,
            };
        }
    }
}