﻿using UniversityApi.DbModels;
using UniversityApi.Models;

namespace UniversityApi.Repository
{
    public interface IUniversityRepository
    {
        Task<IEnumerable<DestSpeciality>> GetListAsync(DestinationCriteria criteria);
        Task<University> GetAsync(short destId);
        Task UpdateInterestedStudentsCountAsync(int id, bool increment);
        Task<IEnumerable<StudyDomain>> GetStudyDomainListAsync();
        Task<IEnumerable<StudyArea>> GetStudyAreaListAsync();
        Task<IEnumerable<DestSpeciality>> GetListRecommendedDestinationsAsync(short? studyDomainId, float? averageGrade);
        Task<DestSpeciality> GetRecommendedByStudentsDestinationsAsync(short destId);
        Task<IEnumerable<DestSpeciality>> GetListForUserAsync(UserDestinationCriteria criteria);
    }
}
