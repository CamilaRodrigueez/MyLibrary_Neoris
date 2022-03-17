
using MyLibrary.Domain.Dto;
using MyLibrary.Domain.Dto.Books;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Domain.Services.Interface
{
    public interface IBooksServices
    {
        Task<ResponseDto> GetAllBooks(string token);
        Task<ResponseDto> GetAllTypeState(string token);
        Task<ResponseDto> InsertBooksAsync(InsertBooksDto data, string token);
        Task<ResponseDto> UpdateBooksAsync(BooksDto data, string token);
        Task<ResponseDto> DeleteBooksAsync(string token, string id);
    }
}
