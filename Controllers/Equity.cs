using Microsoft.AspNetCore.Mvc; //imported for hadling http requests,[FromRoute] attribute etc.
using MiniSecMaster.Database;
using MiniSecMaster.Models;
using System;



namespace MiniSecMaster.Controller{

   [ApiController]
   [Route("api/[controller]")]

    public class EquityController{

        public readonly Cs1Context _dbContext;

        public EquityController()
        {
           _dbContext = new Cs1Context();

           _dbContext.Database.EnsureCreated();
        } 
        
        [HttpGet]
        [Route("[action]")]

        public List<Equity> GetEquities(){
            return _dbContext.Equities.ToList();
        }
        
        [HttpGet]
        [Route("[action]/{id}")]
        public Equity GetEquityById([FromRoute]int id){
            return _dbContext.Equities.Find(id);
        }

        [HttpPost]
        [Route("[action]")]

        public Equity AddEquity(Equity e){

            _dbContext.Equities.Add(e);
            _dbContext.SaveChanges();

            return e;

        }

        [HttpDelete]
        [Route("[action]/{id}")]

        public void DeleteEquity([FromRoute]int id){

             var e = _dbContext.Equities.Find(id);

             if(e!=null){
                 _dbContext.Equities.Remove(e);
                 _dbContext.SaveChanges();

                 return;
             }
             else{
                 Console.WriteLine("Security doesn't exist");
                 return;
             }

        }

        [HttpPut]
        [Route("[action]/{id}")]
        public Equity UpdateEquity([FromRoute]int id,Equity e){

          var originalEquity = _dbContext.Equities.Find(id);

          if(originalEquity==null){
              Console.WriteLine("Record Not Found");
              return null;
          }
          
        _dbContext.Entry(originalEquity).CurrentValues.SetValues(e);

        // Console.WriteLine(a);

          _dbContext.SaveChanges();
          return e;
       }
    }

    
}