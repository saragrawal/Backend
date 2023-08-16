using Microsoft.AspNetCore.Mvc;
using MiniSecMaster.Models;
using MiniSecMaster.Database;
using System;


namespace MiniSecMaster.Controller{

    [ApiController]
   [Route("api/[controller]")]

    public class BondsController{
   
        public readonly Cs1Context _dbContext;


        public BondsController(){

            _dbContext = new Cs1Context();

            _dbContext.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("[action]")]

        public List<Bond> GetBonds(){
            return _dbContext.Bonds.ToList();
        }
        
        [HttpGet]
        [Route("[action]/{id}")]
        public Bond GetBondById([FromRoute]int id){
            return _dbContext.Bonds.Find(id);
        }

        [HttpPost]
        [Route("[action]")]

        public Bond AddBond(Bond b){

            _dbContext.Bonds.Add(b);
            _dbContext.SaveChanges();

            return b;

        }

        [HttpDelete]
        [Route("[action]/{id}")]

        public string DeleteBond([FromRoute]int id){

             var b = _dbContext.Bonds.Find(id);

             if(b!=null){
                 _dbContext.Bonds.Remove(b);
                 _dbContext.SaveChanges();

                 return "Record Deleted for BOND ID: "+id;
             }
             else{
                 //Console.WriteLine("Security doesn't exist");
                 return "Record Does not exist for BOND ID: "+id;
             }

        }

        [HttpPut]
        [Route("[action]/{id}")]
        public Bond UpdateBond([FromRoute]int id,Bond b){

          var originalBond = _dbContext.Bonds.Find(id);

          if(originalBond==null){
              Console.WriteLine("Record Not Found");
              return null;
          }
          
        _dbContext.Entry(originalBond).CurrentValues.SetValues(b);

        // Console.WriteLine(a);

          _dbContext.SaveChanges();
          return b;
       }

        


    }
}