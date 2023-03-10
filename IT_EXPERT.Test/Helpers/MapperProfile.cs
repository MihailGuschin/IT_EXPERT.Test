using AutoMapper;
using IT_EXPERT.Test.DTOs;
using IT_EXPERT.Test.Entities;
using System.Security.Cryptography;
using System.Text;

namespace IT_EXPERT.Test.Helpers
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Todo, TodoDto>()
                .ForMember(
                dest => dest.Hash,
                opt => opt.MapFrom(src => GetHash(src.Title))
            );
            CreateMap<TodoDtoCreate, Todo>();
            CreateMap<Comment, CommentDto>()
                .ReverseMap();
        }

        private string GetHash(string title)
        {
            MD5 MD5Hash = MD5.Create(); 
            byte[] inputBytes = Encoding.ASCII.GetBytes(title); 
            byte[] hash = MD5Hash.ComputeHash(inputBytes); 
            return Convert.ToHexString(hash);
        }
    }
}
