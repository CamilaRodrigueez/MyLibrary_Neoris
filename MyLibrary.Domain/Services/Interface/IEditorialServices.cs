using MiLibrary.Domain.Dto.EditorialDto;
using MyLibrary.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiLibrary.Domain.Services.Interface
{
    public interface IEditorialServices
    {
        Task<ResponseDto> GetAllEditorial(string token);
        Task<ResponseDto> InsertEditorialAsync(InsertEditorialDto data, string token);
        Task<ResponseDto> UpdateEditorialAsync(EditorialDto data, string token);
        Task<ResponseDto> DeleteEditorialAsync(string id, string token);

    }
}
