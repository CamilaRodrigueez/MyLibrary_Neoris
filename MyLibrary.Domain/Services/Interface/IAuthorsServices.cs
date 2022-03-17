using MiLibrary.Domain.Dto.Authors;
using MyLibrary.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiLibrary.Domain.Services.Interface
{
    public interface IAuthorsServices
    {
        Task<ResponseDto> GetAllAuthors(string token);
        Task<ResponseDto> InsertAuthorAsync(InsertAuthorsDto data, string token);
        Task<ResponseDto> UpdateAuthorAsync(AuthorsDto data, string token);
        Task<ResponseDto> DeleteAuthorAsync(string token, string id);

    }
}
