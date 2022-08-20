using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RadioFreeEroup.Domain.Entities;
using RadioFreeEroup.Domain.IJsonItem;
using RadioFreeEroup.Domain.Interfaces;
using RadioFreeEroup.Infrastructure.Context;
using RadioFreeEroup.Infrastructure.Repository;
using RadioFreeEroup.Infrastructure.UnitOfWork;
using RadioFreeEurop.Apllication.Service.DTO;
using RadioFreeEurop.Apllication.Service.IService;
using RadioFreeEurop.Apllication.Service.Service;
using System;

namespace RadioFreeEroupe.Test
{
    public class CheckJsonDiff 
    {

        private static Microsoft.EntityFrameworkCore.DbContextOptions<JsonItemContext> options = new
      Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<JsonItemContext>()
                      .UseSqlServer("Data Source=AKRAM-BOKTOR\\DEVELOPER;Initial Catalog=RadioFreeEroupe;Integrated Security=true")
                      .Options;
        protected readonly IConfiguration Configuration;
        public CheckJsonDiff(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //JsonItemContext JsonContext = new JsonItemContext(Configuration.GetConnectionString("DefaultConnection"));


        [Fact(DisplayName = "Check if return the same as expected")]
        public void ShouldBeTheSame()
        {
            //IUnitOfWork unitOfWork = new UnitOfWork(JsonContext);

            //IJsonItemDiffService _service = new JsonItemDiffService(unitOfWork);

            //Task<JsonDiffDto> returnDTO = _service.GetComparison("1");

            //Assert.True(returnDTO.Result.Message == "The data is the same");
        }




    }
}